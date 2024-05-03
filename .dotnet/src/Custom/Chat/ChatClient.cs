using OpenAI.Internal.Models;
using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace OpenAI.Chat;

public partial class ChatClient
{
    protected readonly string _model;
    protected readonly ClientPipeline _pipeline;
    protected readonly Uri _endpoint;

    /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
    public virtual ClientPipeline Pipeline => _pipeline;

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
    
    public ChatClient(string model, ApiKeyCredential credential = default, OpenAIClientOptions options = null)
        : this(OpenAIClient.CreatePipeline(credential, options), model, credential: null, OpenAIClient.GetEndpoint(options))
    { }

    protected internal ChatClient(ClientPipeline pipeline, string model, ApiKeyCredential credential, Uri endpoint)
    {
        _model = model;
        _pipeline = pipeline;
        _endpoint = endpoint;
    }

    /// <summary> Initializes a new instance of ChatClient for mocking. </summary>
    protected ChatClient()
    {
    }

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
        Argument.AssertNotNull(messages, nameof(messages));
        Internal.Models.CreateChatCompletionRequest internalRequest = CreateInternalRequest(messages, options);
        using BinaryContent content = BinaryContent.Create(internalRequest);
        ClientResult protocolResult = CompleteChat(content, OpenAIClient.DefaultRequestOptions);
        Internal.Models.CreateChatCompletionResponse internalResponse
            = CreateChatCompletionResponse.FromResponse(protocolResult.GetRawResponse());
        ChatCompletion chatCompletion = new(internalResponse, internalChoiceIndex: 0);
        return ClientResult.FromValue(chatCompletion, protocolResult.GetRawResponse());
    }

    /// <summary>
    /// Generates a single chat completion result for a provided set of input chat messages.
    /// </summary>
    /// <param name="messages"> The messages to provide as input and history for chat completion. </param>
    /// <param name="options"> Additional options for the chat completion request. </param>
    /// <returns> A result for a single chat completion. </returns>
    public virtual async Task<ClientResult<ChatCompletion>> CompleteChatAsync(
        IEnumerable<ChatRequestMessage> messages,
        ChatCompletionOptions options = null)
    {
        Argument.AssertNotNull(messages, nameof(messages));
        Internal.Models.CreateChatCompletionRequest internalRequest = CreateInternalRequest(messages, options);
        using BinaryContent content = BinaryContent.Create(internalRequest);
        ClientResult protocolResult = await CompleteChatAsync(content, OpenAIClient.DefaultRequestOptions).ConfigureAwait(false);
        Internal.Models.CreateChatCompletionResponse internalResponse
            = CreateChatCompletionResponse.FromResponse(protocolResult.GetRawResponse());
        ChatCompletion chatCompletion = new(internalResponse, internalChoiceIndex: 0);
        return ClientResult.FromValue(chatCompletion, protocolResult.GetRawResponse());
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
        Argument.AssertNotNull(messages, nameof(messages));
        Internal.Models.CreateChatCompletionRequest internalRequest = CreateInternalRequest(messages, options, choiceCount);
        using BinaryContent content = BinaryContent.Create(internalRequest);
        ClientResult protocolResult = CompleteChat(content, OpenAIClient.DefaultRequestOptions);
        Internal.Models.CreateChatCompletionResponse internalResponse
            = CreateChatCompletionResponse.FromResponse(protocolResult.GetRawResponse());
        List<ChatCompletion> chatCompletions = [];
        for (int i = 0; i < internalResponse.Choices.Count; i++)
        {
            chatCompletions.Add(new(internalResponse, (int)internalResponse.Choices[i].Index));
        }
        return ClientResult.FromValue(new ChatCompletionCollection(chatCompletions), protocolResult.GetRawResponse());
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
    public virtual async Task<ClientResult<ChatCompletionCollection>> CompleteChatAsync(
        IEnumerable<ChatRequestMessage> messages,
        int choiceCount,
        ChatCompletionOptions options = null)
    {
        Argument.AssertNotNull(messages, nameof(messages));
        Internal.Models.CreateChatCompletionRequest internalRequest = CreateInternalRequest(messages, options, choiceCount);
        using BinaryContent content = BinaryContent.Create(internalRequest);
        ClientResult protocolResult = CompleteChat(content, OpenAIClient.DefaultRequestOptions);
        Internal.Models.CreateChatCompletionResponse internalResponse
            = CreateChatCompletionResponse.FromResponse(protocolResult.GetRawResponse());
        List<ChatCompletion> chatCompletions = [];
        for (int i = 0; i < internalResponse.Choices.Count; i++)
        {
            chatCompletions.Add(new(internalResponse, (int)internalResponse.Choices[i].Index));
        }
        return ClientResult.FromValue(new ChatCompletionCollection(chatCompletions), protocolResult.GetRawResponse());
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
        Argument.AssertNotNull(messages, nameof(messages));
        Internal.Models.CreateChatCompletionRequest internalRequest = CreateInternalRequest(messages, options, choiceCount, stream: true);
        using BinaryContent content = BinaryContent.Create(internalRequest);
        PipelineMessage requestMessage = CreateChatCompletionPipelineMessage(content, OpenAIClient.DefaultRequestOptions, bufferResponse: false);
        PipelineResponse response = Pipeline.ProcessMessage(requestMessage, OpenAIClient.DefaultRequestOptions);
        ClientResult protocolResult = ClientResult.FromResponse(response);
        return StreamingClientResult<StreamingChatUpdate>.CreateFromResponse(
            protocolResult,
            (responseForEnumeration) => SseAsyncEnumerator<StreamingChatUpdate>.EnumerateFromSseStream(
                responseForEnumeration.GetRawResponse().ContentStream,
                e => StreamingChatUpdate.DeserializeStreamingChatUpdates(e)));
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
    /// <param name="cancellationToken"> The cancellation token for the operation. </param>
    /// <returns> A streaming result with incremental chat completion updates. </returns>
    public virtual async Task<StreamingClientResult<StreamingChatUpdate>> CompleteChatStreamingAsync(
        IEnumerable<ChatRequestMessage> messages,
        int? choiceCount = null,
        ChatCompletionOptions options = null)
    {
        Argument.AssertNotNull(messages, nameof(messages));
        Internal.Models.CreateChatCompletionRequest internalRequest = CreateInternalRequest(messages, options, choiceCount, stream: true);
        using BinaryContent content = BinaryContent.Create(internalRequest);
        PipelineMessage requestMessage = CreateChatCompletionPipelineMessage(content, OpenAIClient.DefaultRequestOptions, bufferResponse: false);
        PipelineResponse response = Pipeline.ProcessMessage(requestMessage, OpenAIClient.DefaultRequestOptions);
        ClientResult protocolResult = ClientResult.FromResponse(response);
        return StreamingClientResult<StreamingChatUpdate>.CreateFromResponse(
            protocolResult,
            (responseForEnumeration) => SseAsyncEnumerator<StreamingChatUpdate>.EnumerateFromSseStream(
                responseForEnumeration.GetRawResponse().ContentStream,
                e => StreamingChatUpdate.DeserializeStreamingChatUpdates(e)));
    }

    private Internal.Models.CreateChatCompletionRequest CreateInternalRequest(
        IEnumerable<ChatRequestMessage> messages,
        ChatCompletionOptions options = null,
        int? choiceCount = null,
        bool? stream = null)
    {
        options ??= new();
        Internal.Models.CreateChatCompletionRequestResponseFormat? internalFormat = null;
        if (options.ResponseFormat is not null)
        {
            internalFormat = new(options.ResponseFormat switch
            {
                ChatResponseFormat.Text => Internal.Models.CreateChatCompletionRequestResponseFormatType.Text,
                ChatResponseFormat.JsonObject => Internal.Models.CreateChatCompletionRequestResponseFormatType.JsonObject,
                _ => throw new ArgumentException(nameof(options.ResponseFormat)),
            }, null);
        }
        List<BinaryData> messageDataItems = [];
        foreach (ChatRequestMessage message in messages)
        {
            messageDataItems.Add(ModelReaderWriter.Write(message));
        }
        Dictionary<string, BinaryData> additionalData = [];
        return new Internal.Models.CreateChatCompletionRequest(
            messageDataItems,
            _model,
            options?.FrequencyPenalty,
            options?.GetInternalLogitBias(),
            options?.IncludeLogProbabilities,
            options?.LogProbabilityCount,
            options?.MaxTokens,
            choiceCount,
            options?.PresencePenalty,
            internalFormat,
            options?.Seed,
            options?.GetInternalStopSequences(),
            stream,
            options?.Temperature,
            options?.NucleusSamplingFactor,
            options?.GetInternalTools(),
            options?.ToolConstraint?.GetBinaryData(),
            options?.User,
            options?.FunctionConstraint?.ToBinaryData(),
            options?.GetInternalFunctions(),
            additionalData
        );
    }
}