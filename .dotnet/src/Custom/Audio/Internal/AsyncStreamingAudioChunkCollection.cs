using System;
using System.Buffers;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

#nullable enable

namespace OpenAI.Audio;

/// <summary>
/// Implementation of collection abstraction over chunk-transfer-encoded audio.
/// </summary>
internal class AsyncStreamingAudioChunkCollection : AsyncResultCollection<BinaryData>
{
    private readonly Func<Task<ClientResult>> _getResult;

    public AsyncStreamingAudioChunkCollection(Func<Task<ClientResult>> getResult) : base()
    {
        Argument.AssertNotNull(getResult, nameof(getResult));
        _getResult = getResult;
    }

    public override IAsyncEnumerator<BinaryData> GetAsyncEnumerator(CancellationToken cancellationToken = default)
    {
        return new AsyncStreamingAudioChunkEnumerator(_getResult, this, cancellationToken);
    }

    private sealed class AsyncStreamingAudioChunkEnumerator : IAsyncEnumerator<BinaryData>
    {
        private readonly Func<Task<ClientResult>> _getResult;
        private readonly AsyncStreamingAudioChunkCollection _enumerable;
        private readonly CancellationToken _cancellationToken;

        private PipelineResponse? _response;
        private BinaryData? _current;
        private bool _started;

        public AsyncStreamingAudioChunkEnumerator(Func<Task<ClientResult>> getResult,
            AsyncStreamingAudioChunkCollection enumerable,
            CancellationToken cancellationToken)
        {
            Debug.Assert(getResult is not null);
            Debug.Assert(enumerable is not null);

            _getResult = getResult!;
            _enumerable = enumerable!;
        }

        BinaryData IAsyncEnumerator<BinaryData>.Current => _current!;

        async ValueTask<bool> IAsyncEnumerator<BinaryData>.MoveNextAsync()
        {
            if (_response is null && _started)
            {
                throw new ObjectDisposedException(nameof(AsyncStreamingAudioChunkEnumerator));
            }

            if (_response is null)
            {
                ClientResult result = await _getResult().ConfigureAwait(false);
                _response = result.GetRawResponse();
                _enumerable.SetRawResponse(_response);
            }

            if (_response.ContentStream is null)
            {
                throw new InvalidOperationException("Unable to create result from response with null ContentStream");
            }

            _started = true;

            if (!_response.ContentStream.CanRead)
            {
                _current = default;
                return false;
            }

            _cancellationToken.ThrowIfCancellationRequested();

            byte[] buffer = ArrayPool<byte>.Shared.Rent(4096);
            int bytesAlreadyRead = 0;

            do
            {
                if (bytesAlreadyRead == buffer.Length)
                {
                    byte[] newBuffer = ArrayPool<byte>.Shared.Rent(2 * buffer.Length);
                    Array.Copy(buffer, newBuffer, bytesAlreadyRead);
                    ArrayPool<byte>.Shared.Return(buffer);
                    buffer = newBuffer;
                }
                bytesAlreadyRead += await _response.ContentStream
                    .ReadAsync(buffer, bytesAlreadyRead, buffer.Length - bytesAlreadyRead, _cancellationToken)
                    .ConfigureAwait(false);
            } while (_response.ContentStream.CanRead && !_cancellationToken.IsCancellationRequested && bytesAlreadyRead == buffer.Length);

            if (bytesAlreadyRead > 0)
            {
                _current = BinaryData.FromBytes(new ReadOnlyMemory<byte>(buffer, 0, bytesAlreadyRead));
                return true;
            }

            _current = default;
            return false;
        }

        public void Reset()
        {
            throw new NotSupportedException("Cannot seek back in a chunked response stream.");
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing && _response is not null)
            {
                // Dispose the response so we don't leave the unbuffered
                // network stream open.
                _response.Dispose();
                _response = null;
            }
        }

        async ValueTask IAsyncDisposable.DisposeAsync()
        {
            await DisposeAsyncCore().ConfigureAwait(false);
            Dispose(false);
            GC.SuppressFinalize(this);
        }

        private ValueTask DisposeAsyncCore()
        {
            return new ValueTask(Task.CompletedTask);
        }
    }
}
