using OpenAI.ClientShared.Internal;
using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OpenAI.Chat;

/// <summary> The service client for the OpenAI Chat Completions endpoint. </summary>
public partial class ChatClient
{
    private readonly OpenAIClientConnector _clientConnector;
    private Internal.Chat Shim => _clientConnector.InternalClient.GetChatClient();

    /// <summary>
    /// Initializes a new instance of <see cref="ChatClient"/>, used for Chat Completion requests. 
    /// </summary>
    /// <remarks>
    /// <para>
    ///     If an endpoint is not provided, the client will use the <c>OPENAI_ENDPOINT</c> environment variable if it
    ///     defined and otherwise use the default OpenAI v1 endpoint.
    /// </para>
    /// <para>
    ///    If an authentication credential is not defined, the client use the <c>OPENAI_API_KEY</c> environment variable
    ///    if it is defined.
    /// </para>
    /// </remarks>
    /// <param name="endpoint">The connection endpoint to use.</param>
    /// <param name="model">The model name for chat completions that the client should use.</param>
    /// <param name="credential">The API key used to authenticate with the service endpoint.</param>
    /// <param name="options">Additional options to customize the client.</param>
    public ChatClient(Uri endpoint, string model, ApiKeyCredential credential, OpenAIClientOptions options = null)
    {
        _clientConnector = new(model, endpoint, credential, options);
    }

    /// <summary>
    /// Initializes a new instance of <see cref="ChatClient"/>, used for Chat Completion requests. 
    /// </summary>
    /// <remarks>
    /// <para>
    ///     If an endpoint is not provided, the client will use the <c>OPENAI_ENDPOINT</c> environment variable if it
    ///     defined and otherwise use the default OpenAI v1 endpoint.
    /// </para>
    /// <para>
    ///    If an authentication credential is not defined, the client use the <c>OPENAI_API_KEY</c> environment variable
    ///    if it is defined.
    /// </para>
    /// </remarks>
    /// <param name="endpoint">The connection endpoint to use.</param>
    /// <param name="model">The model name for chat completions that the client should use.</param>
    /// <param name="options">Additional options to customize the client.</param>
    public ChatClient(Uri endpoint, string model, OpenAIClientOptions options = null)
        : this(endpoint, model, credential: null, options)
    { }

    /// <summary>
    /// Initializes a new instance of <see cref="ChatClient"/>, used for Chat Completion requests. 
    /// </summary>
    /// <remarks>
    /// <para>
    ///     If an endpoint is not provided, the client will use the <c>OPENAI_ENDPOINT</c> environment variable if it
    ///     defined and otherwise use the default OpenAI v1 endpoint.
    /// </para>
    /// <para>
    ///    If an authentication credential is not defined, the client use the <c>OPENAI_API_KEY</c> environment variable
    ///    if it is defined.
    /// </para>
    /// </remarks>
    /// <param name="model">The model name for chat completions that the client should use.</param>
    /// <param name="credential">The API key used to authenticate with the service endpoint.</param>
    /// <param name="options">Additional options to customize the client.</param>
    public ChatClient(string model, ApiKeyCredential credential, OpenAIClientOptions options = null)
        : this(endpoint: null, model, credential, options)
    { }

    /// <summary>
    /// Initializes a new instance of <see cref="ChatClient"/>, used for Chat Completion requests. 
    /// </summary>
    /// <remarks>
    /// <para>
    ///     If an endpoint is not provided, the client will use the <c>OPENAI_ENDPOINT</c> environment variable if it
    ///     defined and otherwise use the default OpenAI v1 endpoint.
    /// </para>
    /// <para>
    ///    If an authentication credential is not defined, the client use the <c>OPENAI_API_KEY</c> environment variable
    ///    if it is defined.
    /// </para>
    /// </remarks>
    /// <param name="model">The model name for chat completions that the client should use.</param>
    /// <param name="options">Additional options to customize the client.</param>
    public ChatClient(string model, OpenAIClientOptions options = null)
        : this(endpoint: null, model, credential: null, options)
    { }

    /// <summary>
    /// Generates a single chat completion result for a single, simple user message.
    /// </summary>
    /// <param name="message"> The user message to provide as a prompt for chat completion. </param>
    /// <param name="options"> Additional options for the chat completion request. </param>
    /// <returns> A result for a single chat completion. </returns>
     public virtual ClientResult<ChatCompletion> CompleteChat(string message, ChatCompletionOptions options = null)
         => CompleteChat(new List<ChatRequestMessage>() { new ChatRequestUserMessage(message) }, options);

    /// <summary>
    /// Generates a single chat completion result for a single, simple user message.
    /// </summary>
    /// <param name="message"> The user message to provide as a prompt for chat completion. </param>
    /// <param name="options"> Additional options for the chat completion request. </param>
    /// <returns> A result for a single chat completion. </returns>
     public virtual Task<ClientResult<ChatCompletion>> CompleteChatAsync(string message, ChatCompletionOptions options = null)
        => CompleteChatAsync(
             new List<ChatRequestMessage>() { new ChatRequestUserMessage(message) }, options);

    /// <summary>
    /// Generates a single chat completion result for a provided set of input chat messages.
    /// </summary>
    /// <param name="messages"> The messages to provide as input and history for chat completion. </param>
    /// <param name="options"> Additional options for the chat completion request. </param>
    /// <returns> A result for a single chat completion. </returns>
    public virtual ClientResult<ChatCompletion> CompleteChat(
        IEnumerable<ChatRequestMessage> messages,
        ChatCompletionOptions options = null)
    {
        return CompleteChatInternal(CreateSingleItemResponseInternal, messages, options);
    }

    /// <summary>
    /// Generates a single chat completion result for a provided set of input chat messages.
    /// </summary>
    /// <param name="messages"> The messages to provide as input and history for chat completion. </param>
    /// <param name="options"> Additional options for the chat completion request. </param>
    /// <returns> A result for a single chat completion. </returns>
    public virtual Task<ClientResult<ChatCompletion>> CompleteChatAsync(
        IEnumerable<ChatRequestMessage> messages,
        ChatCompletionOptions options = null)
    {
        return CompleteChatInternalAsync(CreateSingleItemResponseInternal, messages, options);
    }

    /// <summary>
    /// Generates a collection of chat completion results for a provided set of input chat messages.
    /// </summary>
    /// <param name="messages"> The messages to provide as input and history for chat completion. </param>
    /// <param name="choiceCount">
    ///     The number of independent, alternative response choices that should be generated.
    /// </param>
    /// <param name="options"> Additional options for the chat completion request. </param>
    /// <returns> A result for a single chat completion. </returns>
    public virtual ClientResult<ChatCompletionCollection> CompleteChat(
        IEnumerable<ChatRequestMessage> messages,
        int choiceCount,
        ChatCompletionOptions options = null)
    {
        return CompleteChatInternal(CreateResponseCollectionInternal, messages, options, choiceCount, stream: false);
    }

    /// <summary>
    /// Generates a collection of chat completion results for a provided set of input chat messages.
    /// </summary>
    /// <param name="messages"> The messages to provide as input and history for chat completion. </param>
    /// <param name="choiceCount">
    ///     The number of independent, alternative response choices that should be generated.
    /// </param>
    /// <param name="options"> Additional options for the chat completion request. </param>
    /// <returns> A result for a single chat completion. </returns>
    public virtual Task<ClientResult<ChatCompletionCollection>> CompleteChatAsync(
        IEnumerable<ChatRequestMessage> messages,
        int choiceCount,
        ChatCompletionOptions options = null)
    {
        return CompleteChatInternalAsync(CreateResponseCollectionInternal, messages, options, choiceCount, stream: false);
    }

    /// <summary>
    /// Begins a streaming response for a chat completion request using a single, simple user message as input.
    /// </summary>
    /// <remarks>
    /// <see cref="StreamingClientResult{T}"/> can be enumerated over using the <c>await foreach</c> pattern using the
    /// <see cref="IAsyncEnumerable{T}"/> interface. 
    /// </remarks>
    /// <param name="message"> The user message to provide as a prompt for chat completion. </param>
    /// <param name="choiceCount">
    ///     The number of independent, alternative choices that the chat completion request should generate.
    /// </param>
    /// <param name="options"> Additional options for the chat completion request. </param>
    /// <returns> A streaming result with incremental chat completion updates. </returns>
   public virtual StreamingClientResult<StreamingChatUpdate> CompleteChatStreaming(
        string message,
        int? choiceCount = null,
        ChatCompletionOptions options = null)
        => CompleteChatStreaming(
            new List<ChatRequestMessage> { new ChatRequestUserMessage(message) },
            choiceCount,
            options);

    /// <summary>
    /// Begins a streaming response for a chat completion request using a single, simple user message as input.
    /// </summary>
    /// <remarks>
    /// <see cref="StreamingClientResult{T}"/> can be enumerated over using the <c>await foreach</c> pattern using the
    /// <see cref="IAsyncEnumerable{T}"/> interface. 
    /// </remarks>
    /// <param name="message"> The user message to provide as a prompt for chat completion. </param>
    /// <param name="choiceCount">
    ///     The number of independent, alternative choices that the chat completion request should generate.
    /// </param>
    /// <param name="options"> Additional options for the chat completion request. </param>
    /// <returns> A streaming result with incremental chat completion updates. </returns>
    public virtual Task<StreamingClientResult<StreamingChatUpdate>> CompleteChatStreamingAsync(
        string message,
        int? choiceCount = null,
        ChatCompletionOptions options = null)
    => CompleteChatStreamingAsync(
        new List<ChatRequestMessage> { new ChatRequestUserMessage(message) },
        choiceCount,
        options);

    /// <summary>
    /// Begins a streaming response for a chat completion request using the provided chat messages as input and
    /// history.
    /// </summary>
    /// <remarks>
    /// <see cref="StreamingClientResult{T}"/> can be enumerated over using the <c>await foreach</c> pattern using the
    /// <see cref="IAsyncEnumerable{T}"/> interface. 
    /// </remarks>
    /// <param name="messages"> The messages to provide as input for chat completion. </param>
    /// <param name="choiceCount">
    ///     The number of independent, alternative choices that the chat completion request should generate.
    /// </param>
    /// <param name="options"> Additional options for the chat completion request. </param>
    /// <param name="cancellationToken"> The cancellation token for the operation. </param>
    /// <returns> A streaming result with incremental chat completion updates. </returns>
    public virtual StreamingClientResult<StreamingChatUpdate> CompleteChatStreaming(
        IEnumerable<ChatRequestMessage> messages,
        int? choiceCount = null,
        ChatCompletionOptions options = null)
    {
        return CompleteChatInternal(CreateStreamingResponseInternal, messages, options, choiceCount, stream: true);
    }

    /// <summary>
    /// Begins a streaming response for a chat completion request using the provided chat messages as input and
    /// history.
    /// </summary>
    /// <remarks>
    /// <see cref="StreamingClientResult{T}"/> can be enumerated over using the <c>await foreach</c> pattern using the
    /// <see cref="IAsyncEnumerable{T}"/> interface. 
    /// </remarks>
    /// <param name="messages"> The messages to provide as input for chat completion. </param>
    /// <param name="choiceCount">
    ///     The number of independent, alternative choices that the chat completion request should generate.
    /// </param>
    /// <param name="options"> Additional options for the chat completion request. </param>
    /// <returns> A streaming result with incremental chat completion updates. </returns>
    public virtual Task<StreamingClientResult<StreamingChatUpdate>> CompleteChatStreamingAsync(
        IEnumerable<ChatRequestMessage> messages,
        int? choiceCount = null,
        ChatCompletionOptions options = null)
    {
        return CompleteChatInternalAsync(CreateStreamingResponseInternal, messages, options, choiceCount, stream: true);
    }

    protected virtual T CompleteChatInternal<T>(
        Func<PipelineMessage, T> resultCreationFunc,
        IEnumerable<ChatRequestMessage> messages,
        ChatCompletionOptions options,
        int? choiceCount = null,
        bool? stream = null)
    {
        using PipelineMessage requestMessage = CreateChatRequest(messages, options, choiceCount, stream);
        Shim.Pipeline.Send(requestMessage);
        if (requestMessage.Response.IsError)
        {
            throw new ClientResultException(requestMessage.Response);
        }
        return resultCreationFunc.Invoke(requestMessage);
    }

    protected virtual async Task<T> CompleteChatInternalAsync<T>(
        Func<PipelineMessage, T> resultCreationFunc,
        IEnumerable<ChatRequestMessage> messages,
        ChatCompletionOptions options,
        int? choiceCount = null,
        bool? stream = null)
    {
        using PipelineMessage requestMessage = CreateChatRequest(messages, options, choiceCount, stream);
        await Shim.Pipeline.SendAsync(requestMessage);
        if (requestMessage.Response.IsError)
        {
            throw new ClientResultException(requestMessage.Response);
        }
        return resultCreationFunc.Invoke(requestMessage);
    }

    protected virtual PipelineMessage CreateChatRequest(
        IEnumerable<ChatRequestMessage> messages,
        ChatCompletionOptions options = null,
        int? choiceCount = null,
        bool? stream = null)
    {
        PipelineMessage message = Shim.Pipeline.CreateMessage();
        message.ResponseClassifier = ResponseErrorClassifier200;
        if (stream == true)
        {
            message.BufferResponse = false;
        }
        PipelineRequest request = message.Request;
        request.Method = "POST";
        request.Uri = CreateChatRequestUri();
        request.Headers.Set("Accept", "application/json");
        request.Headers.Set("Content-Type", "application/json");
        request.Content = CreateChatRequestBody(messages, options, choiceCount, stream);

        return message;
    }

    protected virtual BinaryContent CreateChatRequestBody(
        IEnumerable<ChatRequestMessage> messages,
        ChatCompletionOptions options,
        int? choiceCount = null,
        bool? stream = null)
    {
        using MemoryStream jsonStream = new();
        using Utf8JsonWriter jsonWriter = new(jsonStream);
        jsonWriter.WriteStartObject();
        jsonWriter.WritePropertyName("messages"u8);
        jsonWriter.WriteStartArray();
        foreach (ChatRequestMessage message in messages)
        {
            jsonWriter.WriteObjectValue(message);
        }
        jsonWriter.WriteEndArray();
        jsonWriter.WriteString("model"u8, _clientConnector.Model);
        if (choiceCount.HasValue)
        {
            jsonWriter.WriteNumber("n"u8, choiceCount.Value);
        }
        if (stream.HasValue)
        {
            jsonWriter.WriteBoolean("stream"u8, stream.Value);
        }
        (options as IJsonModel<ChatCompletionOptions>)?.Write(jsonWriter, new ModelReaderWriterOptions("J"));
        jsonWriter.WriteEndObject();
        jsonWriter.Flush();
        jsonStream.Position = 0;
        BinaryData jsonData = BinaryData.FromStream(jsonStream);
        return BinaryContent.Create(jsonData);
    }

    protected ClientResult<ChatCompletionCollection> CreateResponseCollectionInternal(PipelineMessage message)
    {
        using JsonDocument responseDocument = JsonDocument.Parse(message.Response.Content);
        ChatCompletionCollection chatCompletionCollection
            = ChatCompletionCollection.DeserializeChatCompletionCollection(responseDocument.RootElement);
        return ClientResult.FromValue(chatCompletionCollection, message.Response);
    }

    protected ClientResult<ChatCompletion> CreateSingleItemResponseInternal(PipelineMessage message)
    {
        using JsonDocument responseDocument = JsonDocument.Parse(message.Response.Content);
        ChatCompletionCollection chatCompletionCollection
            = ChatCompletionCollection.DeserializeChatCompletionCollection(responseDocument.RootElement);
        return ClientResult.FromValue(chatCompletionCollection[0], message.Response);
    }

    protected StreamingClientResult<StreamingChatUpdate> CreateStreamingResponseInternal(PipelineMessage message)
    {
        PipelineResponse extractedResponse = null;
        try
        {
            extractedResponse = message.ExtractResponse();
            ClientResult genericResult = ClientResult.FromResponse(extractedResponse);
            StreamingClientResult<StreamingChatUpdate> result = StreamingClientResult<StreamingChatUpdate>.CreateFromResponse(
                genericResult,
                (responseForEnumeration) => SseAsyncEnumerator<StreamingChatUpdate>.EnumerateFromSseStream(
                    responseForEnumeration.GetRawResponse().ContentStream,
                    e => StreamingChatUpdate.DeserializeStreamingChatUpdates(e)));
            extractedResponse = null;
            return result;
        }
        finally
        {
            extractedResponse?.Dispose();
        }
    }

    protected Uri GetEndpoint() => _clientConnector.Endpoint;

    protected virtual Uri CreateChatRequestUri()
    {
        UriBuilder uriBuilder = new(GetEndpoint());
        StringBuilder path = new();
        path.Append("/chat/completions");
        uriBuilder.Path += path.ToString();
        return uriBuilder.Uri;
    }

    private static PipelineMessageClassifier _responseErrorClassifier200;
    private static PipelineMessageClassifier ResponseErrorClassifier200 => _responseErrorClassifier200 ??= PipelineMessageClassifier.Create(stackalloc ushort[] { 200 });
}
