using System;
using System.Buffers;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OpenAI.RealtimeConversation;

[Experimental("OPENAI002")]
public partial class RealtimeConversationSession : IDisposable
{
    private readonly RealtimeConversationClient _parentClient;
    private readonly Uri _endpoint;
    private readonly ApiKeyCredential _credential;
    private readonly object _sendingAudioLock = new();
    private bool _isSendingAudioStream = false;
    private readonly SemaphoreSlim _audioSendSemaphore = new(1, 1);

    internal bool ShouldBufferTurnResponseData { get; set; }

    protected internal RealtimeConversationSession(
        RealtimeConversationClient parentClient,
        Uri endpoint,
        ApiKeyCredential credential)
    {
        Argument.AssertNotNull(endpoint, nameof(endpoint));
        Argument.AssertNotNull(credential, nameof(credential));

        _parentClient = parentClient;
        _endpoint = endpoint;
        _credential = credential;
        _clientWebSocket = new ClientWebSocket();

        _credential.Deconstruct(out string dangerousCredential);
        _clientWebSocket.Options.SetRequestHeader("openai-beta", $"realtime=v1");
        _clientWebSocket.Options.SetRequestHeader("Authorization", $"Bearer {dangerousCredential}");
    }

    /// <summary>
    /// Transmits audio data from a stream, ending the client turn once the stream is complete.
    /// </summary>
    /// <param name="audio"> The audio stream to transmit. </param>
    /// <param name="cancellationToken"> An optional cancellation token. </param>
    /// <exception cref="InvalidOperationException"></exception>
    public async Task SendAudioAsync(Stream audio, CancellationToken cancellationToken = default)
    {
        await _audioSendSemaphore.WaitAsync(cancellationToken).ConfigureAwait(false);
        try
        {
            if (_isSendingAudioStream)
            {
                throw new InvalidOperationException($"Only one stream of audio may be sent at once.");
            }
            _isSendingAudioStream = true;
        }
        finally
        {
            _audioSendSemaphore.Release();
        }

        const int audioInputDataChunkSize = 1024 * 16;
        byte[] buffer = ArrayPool<byte>.Shared.Rent(audioInputDataChunkSize);
        while (true)
        {
            int bytesRead = await audio.ReadAsync(buffer, 0, buffer.Length, cancellationToken).ConfigureAwait(false);
            if (bytesRead == 0)
            {
                break;
            }

            ReadOnlyMemory<byte> audioMemory = buffer.AsMemory(0, bytesRead);
            BinaryData audioData = BinaryData.FromBytes(audioMemory);
            InternalRealtimeRequestInputAudioBufferAppendCommand internalCommand = new(audioData);
            BinaryData requestData = ModelReaderWriter.Write(internalCommand);
            await SendCommandAsync(requestData, cancellationToken.ToRequestOptions()).ConfigureAwait(false);
        }

        await _audioSendSemaphore.WaitAsync(cancellationToken).ConfigureAwait(false);
        try
        {
            _isSendingAudioStream = false;
        }
        finally
        {
            _audioSendSemaphore.Release();
        }
    }

    /// <summary>
    /// Transmits a single chunk of audio.
    /// </summary>
    /// <param name="audio"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public async Task SendAudioAsync(BinaryData audio, CancellationToken cancellationToken = default)
    {
        await _audioSendSemaphore.WaitAsync(cancellationToken).ConfigureAwait(false);
        try
        {
            if (_isSendingAudioStream)
            {
                throw new InvalidOperationException($"Cannot send a standalone audio chunk while a stream is already in progress.");
            }
            // TODO: consider automatically limiting/breaking size of chunk (as with streaming)
            // TODO: improve efficiency of data copies
            InternalRealtimeRequestInputAudioBufferAppendCommand internalCommand = new(audio);
            await SendInternalCommandAsync(internalCommand, cancellationToken).ConfigureAwait(false);
        }
        finally
        {
            _audioSendSemaphore.Release();
        }
    }

    public async Task ConfigureSessionAsync(ConversationSessionOptions sessionOptions, CancellationToken cancellationToken = default)
    {
        InternalRealtimeRequestSessionUpdateCommand internalCommand = new(sessionOptions);
        await SendInternalCommandAsync(internalCommand, cancellationToken).ConfigureAwait(false);
    }

    public async Task AddItemAsync(ConversationItem item, CancellationToken cancellationToken = default)
        => await AddItemAsync(item, null, cancellationToken).ConfigureAwait(false);

    public async Task AddItemAsync(ConversationItem item, string previousItemId, CancellationToken cancellationToken = default)
    {
        InternalRealtimeRequestItemCreateCommand internalCommand = new(item)
        {
            PreviousItemId = previousItemId,
        };
        await SendInternalCommandAsync(internalCommand, cancellationToken).ConfigureAwait(false);
    }

    public async Task DeleteItemAsync(string itemId, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNull(itemId, nameof(itemId));
        await SendInternalCommandAsync(new InternalRealtimeRequestItemDeleteCommand(itemId), cancellationToken).ConfigureAwait(false);
    }

    public async Task CommitPendingAudioAsync(CancellationToken cancellationToken = default)
    {
        await SendInternalCommandAsync(new InternalRealtimeRequestInputAudioBufferCommitCommand(), cancellationToken).ConfigureAwait(false);
    }

    public async Task InterruptTurnAsync(CancellationToken cancellationToken = default)
    {
        await SendInternalCommandAsync(new InternalRealtimeRequestResponseCancelCommand(), cancellationToken).ConfigureAwait(false);
    }

    public async Task StartResponseTurnAsync(CancellationToken cancellationToken = default)
    {
        InternalRealtimeRequestResponseCreateCommand internalCommand = new()
        {
            Response = new(commit: true, cancelPrevious: true)
        };
        await SendInternalCommandAsync(internalCommand, cancellationToken).ConfigureAwait(false);
    }

    public async Task CancelResponseTurnAsync(CancellationToken cancellationToken = default)
    {
        InternalRealtimeRequestResponseCancelCommand internalCommand = new();
        await SendInternalCommandAsync(internalCommand, cancellationToken).ConfigureAwait(false);
    }

    internal virtual async Task SendInternalCommandAsync(InternalRealtimeRequestCommand command, CancellationToken cancellationToken = default)
    {
        BinaryData requestData = ModelReaderWriter.Write(command);
        RequestOptions cancellationOptions = cancellationToken.ToRequestOptions();
        await SendCommandAsync(requestData, cancellationOptions).ConfigureAwait(false);
    }

    public async IAsyncEnumerable<ConversationUpdate> ReceiveUpdatesAsync([EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        await foreach (ClientResult protocolEvent in ReceiveUpdatesAsync(cancellationToken.ToRequestOptions()))
        {
            ConversationUpdate nextUpdate = ConversationUpdate.FromResponse(protocolEvent.GetRawResponse());
            yield return nextUpdate;
        }
    }

    public void Dispose()
    {
        _clientWebSocket?.Dispose();
    }
}