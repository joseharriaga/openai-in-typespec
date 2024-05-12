using OpenAI.Models;
using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAI.Chat;

[CodeGenClient("Chat")]
[CodeGenSuppress("CreateChatCompletionAsync", typeof(ChatCompletionOptions))]
[CodeGenSuppress("CreateChatCompletion", typeof(ChatCompletionOptions))]
public partial class ChatClient
{
    private readonly string _model;

    /// <summary>
    /// Initializes a new instance of <see cref="ChatClient"/> that will use an API key when authenticating.
    /// </summary>
    /// <param name="model"> The model name for chat completions that the client should use. </param>
    /// <param name="credential"> The API key used to authenticate with the service endpoint. </param>
    /// <param name="options"> Additional options to customize the client. </param>
    /// <exception cref="ArgumentNullException"> The provided <paramref name="credential"/> was null. </exception>
    public ChatClient(string model, ApiKeyCredential credential, OpenAIClientOptions options = null)
        : this(
              OpenAIClient.CreatePipeline(OpenAIClient.GetApiKey(credential, requireExplicitCredential: true), options),
              model,
              OpenAIClient.GetEndpoint(options),
              options)
    { }

    /// <summary>
    /// Initializes a new instance of <see cref="ChatClient"/> that will use an API key from the OPENAI_API_KEY
    /// environment variable when authenticating.
    /// </summary>
    /// <remarks>
    /// To provide an explicit credential instead of using the environment variable, use an alternate constructor like
    /// <see cref="ChatClient(string,ApiKeyCredential,OpenAIClientOptions)"/>.
    /// </remarks>
    /// <param name="model"> The model name for chat completions that the client should use. </param>
    /// <param name="options"> Additional options to customize the client. </param>
    /// <exception cref="InvalidOperationException"> The OPENAI_API_KEY environment variable was not found. </exception>
    public ChatClient(string model, OpenAIClientOptions options = null)
        : this(
              OpenAIClient.CreatePipeline(OpenAIClient.GetApiKey(), options),
              model,
              OpenAIClient.GetEndpoint(options),
              options)
    { }

    /// <summary>
    /// Initializes a new instance of <see cref="ChatClient"/>.
    /// </summary>
    /// <param name="pipeline"> The <see cref="ClientPipeline"/> instance to use. </param>
    /// <param name="model"> The model name to use. </param>
    /// <param name="endpoint"> The endpoint to use. </param>
    protected internal ChatClient(ClientPipeline pipeline, string model, Uri endpoint, OpenAIClientOptions options)
    {
        Argument.AssertNotNullOrEmpty(model, nameof(model));

        _model = model;
        _pipeline = pipeline;
        _endpoint = endpoint;
    }

    /// <summary>
    /// Generates a single chat completion result for a provided set of input chat messages.
    /// </summary>
    /// <param name="messages"> The messages to provide as input and history for chat completion. </param>
    /// <param name="options"> Additional options for the chat completion request. </param>
    /// <returns> A result for a single chat completion. </returns>
    public virtual async Task<ClientResult<ChatCompletion>> CompleteChatAsync(IEnumerable<ChatMessage> messages, ChatCompletionOptions options = null)
    {
        Argument.AssertNotNullOrEmpty(messages, nameof(messages));

        options ??= new();
        CreateChatCompletionOptions(messages, ref options);

        using BinaryContent content = options.ToBinaryContent();
        ClientResult result = await CompleteChatAsync(content, null).ConfigureAwait(false);
        return ClientResult.FromValue(ChatCompletion.FromResponse(result.GetRawResponse()), result.GetRawResponse());
    }

    /// <summary>
    /// Generates a single chat completion result for a provided set of input chat messages.
    /// </summary>
    /// <param name="messages"> The messages to provide as input and history for chat completion. </param>
    /// <param name="options"> Additional options for the chat completion request. </param>
    /// <returns> A result for a single chat completion. </returns>
    public virtual ClientResult<ChatCompletion> CompleteChat(IEnumerable<ChatMessage> messages, ChatCompletionOptions options = null)
    {
        Argument.AssertNotNullOrEmpty(messages, nameof(messages));

        options ??= new();
        CreateChatCompletionOptions(messages, ref options);

        using BinaryContent content = options.ToBinaryContent();
        ClientResult result = CompleteChat(content, null);
        return ClientResult.FromValue(ChatCompletion.FromResponse(result.GetRawResponse()), result.GetRawResponse());

    }

    ///// <summary>
    ///// Begins a streaming response for a chat completion request using the provided chat messages as input and
    ///// history.
    ///// </summary>
    ///// <remarks>
    ///// <see cref="StreamingClientResult{T}"/> can be enumerated over using the <c>await foreach</c> pattern using the
    ///// <see cref="IAsyncEnumerable{T}"/> interface. 
    ///// </remarks>
    ///// <param name="messages"> The messages to provide as input for chat completion. </param>
    ///// <param name="options"> Additional options for the chat completion request. </param>
    ///// <returns> A streaming result with incremental chat completion updates. </returns>
    //public virtual StreamingClientResult<StreamingChatUpdate> CompleteChatStreaming(IEnumerable<ChatRequestMessage> messages, ChatCompletionOptions options = null)
    //{
    //    Argument.AssertNotNull(messages, nameof(messages));
    //    Internal.Models.CreateChatCompletionRequest internalRequest = CreateInternalRequest(messages, options, choiceCount, stream: true);
    //    using BinaryContent content = BinaryContent.Create(internalRequest);
    //    PipelineMessage requestMessage = CreateChatCompletionPipelineMessage(content, null, bufferResponse: false);
    //    PipelineResponse response = Pipeline.ProcessMessage(requestMessage, null);
    //    ClientResult protocolResult = ClientResult.FromResponse(response);
    //    return StreamingClientResult<StreamingChatUpdate>.CreateFromResponse(
    //        protocolResult,
    //        (responseForEnumeration) => SseAsyncEnumerator<StreamingChatUpdate>.EnumerateFromSseStream(
    //            responseForEnumeration.GetRawResponse().ContentStream,
    //            e => StreamingChatUpdate.DeserializeStreamingChatUpdates(e)));
    //}

    ///// <summary>
    ///// Begins a streaming response for a chat completion request using the provided chat messages as input and
    ///// history.
    ///// </summary>
    ///// <remarks>
    ///// <see cref="StreamingClientResult{T}"/> can be enumerated over using the <c>await foreach</c> pattern using the
    ///// <see cref="IAsyncEnumerable{T}"/> interface. 
    ///// </remarks>
    ///// <param name="messages"> The messages to provide as input for chat completion. </param>
    ///// <param name="options"> Additional options for the chat completion request. </param>
    ///// <returns> A streaming result with incremental chat completion updates. </returns>
    //public virtual async Task<StreamingClientResult<StreamingChatUpdate>> CompleteChatStreamingAsync(IEnumerable<ChatRequestMessage> messages, ChatCompletionOptions options = null)
    //{
    //    Argument.AssertNotNull(messages, nameof(messages));
    //    Internal.Models.CreateChatCompletionRequest internalRequest = CreateInternalRequest(messages, options, choiceCount, stream: true);
    //    using BinaryContent content = BinaryContent.Create(internalRequest);
    //    PipelineMessage requestMessage = CreateChatCompletionPipelineMessage(content, null, bufferResponse: false);
    //    PipelineResponse response = Pipeline.ProcessMessage(requestMessage, null);
    //    ClientResult protocolResult = ClientResult.FromResponse(response);
    //    return StreamingClientResult<StreamingChatUpdate>.CreateFromResponse(
    //        protocolResult,
    //        (responseForEnumeration) => SseAsyncEnumerator<StreamingChatUpdate>.EnumerateFromSseStream(
    //            responseForEnumeration.GetRawResponse().ContentStream,
    //            e => StreamingChatUpdate.DeserializeStreamingChatUpdates(e)));
    //}

    //private PipelineMessage CreateChatCompletionPipelineMessage(BinaryContent content, RequestOptions options = null, bool bufferResponse = true)
    //{
    //    PipelineMessage message = Pipeline.CreateMessage();
    //    message.ResponseClassifier = PipelineMessageClassifier200;
    //    message.BufferResponse = bufferResponse;
    //    PipelineRequest request = message.Request;
    //    request.Method = "POST";
    //    UriBuilder uriBuilder = new(_endpoint.AbsoluteUri);
    //    StringBuilder path = new();
    //    path.Append("/chat/completions");
    //    uriBuilder.Path += path.ToString();
    //    request.Uri = uriBuilder.Uri;
    //    request.Headers.Set("Accept", "application/json");
    //    request.Headers.Set("Content-Type", "application/json");
    //    request.Content = content;
    //    if (options is not null)
    //    {
    //        message.Apply(options);
    //    }
    //    return message;
    //}

    //private Internal.Models.CreateChatCompletionRequest CreateInternalRequest(
    //    IEnumerable<ChatRequestMessage> messages,
    //    ChatCompletionOptions options = null,
    //    int? choiceCount = null,
    //    bool? stream = null)
    //{
    //    options ??= new();
    //    Internal.Models.CreateChatCompletionRequestResponseFormat? internalFormat = null;
    //    if (options.ResponseFormat is not null)
    //    {
    //        internalFormat = new(options.ResponseFormat switch
    //        {
    //            ChatResponseFormat.Text => Internal.Models.CreateChatCompletionRequestResponseFormatType.Text,
    //            ChatResponseFormat.JsonObject => Internal.Models.CreateChatCompletionRequestResponseFormatType.JsonObject,
    //            _ => throw new ArgumentException(nameof(options.ResponseFormat)),
    //        }, null);
    //    }
    //    List<BinaryData> messageDataItems = [];
    //    foreach (ChatRequestMessage message in messages)
    //    {
    //        messageDataItems.Add(ModelReaderWriter.Write(message));
    //    }
    //    Dictionary<string, BinaryData> additionalData = [];
    //    InternalChatCompletionStreamOptions streamOptions = stream == true
    //        ? new InternalChatCompletionStreamOptions(includeUsage: stream, serializedAdditionalRawData: null)
    //        : null;
    //    return new Internal.Models.CreateChatCompletionRequest(
    //        messageDataItems,
    //        _model,
    //        options?.FrequencyPenalty,
    //        options?.GetInternalLogitBias(),
    //        options?.IncludeLogProbabilities,
    //        options?.LogProbabilityCount,
    //        options?.MaxTokens,
    //        choiceCount,
    //        options?.PresencePenalty,
    //        internalFormat,
    //        options?.Seed,
    //        options?.GetInternalStopSequences(),
    //        stream,
    //        streamOptions,
    //        options?.Temperature,
    //        options?.NucleusSamplingFactor,
    //        options?.GetInternalTools(),
    //        options?.ToolConstraint?.GetBinaryData(),
    //        options?.User,
    //        options?.FunctionConstraint?.ToBinaryData(),
    //        options?.GetInternalFunctions(),
    //        additionalData
    //    );
    //}

    private void CreateChatCompletionOptions(IEnumerable<ChatMessage> messages, ref ChatCompletionOptions options)
    {
        options.Messages = messages.ToList();
        options.Model = _model;
    }
}