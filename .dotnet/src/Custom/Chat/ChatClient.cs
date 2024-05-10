using OpenAI.Internal.Models;
using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OpenAI.Chat;

public partial class ChatClient
{
    private readonly string _model;
    private readonly ClientPipeline _pipeline;
    private readonly Uri _endpoint;

    /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
    public ClientPipeline Pipeline => _pipeline;

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
        ClientResult protocolResult = CompleteChat(content, null);
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
        ClientResult protocolResult = await CompleteChatAsync(content, null).ConfigureAwait(false);
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
        ClientResult protocolResult = CompleteChat(content, null);
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
        ClientResult protocolResult = CompleteChat(content, null);
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
    /// <see cref="AsyncResultCollection{T}"/> can be enumerated over using the <c>await foreach</c> pattern using the
    /// <see cref="IAsyncEnumerable{T}"/> interface. 
    /// </remarks>
    /// <param name="message"> The user message to provide as a prompt for chat completion. </param>
    /// <param name="choiceCount">
    ///     The number of independent, alternative choices that the chat completion request should generate.
    /// </param>
    /// <param name="options"> Additional options for the chat completion request. </param>
    /// <returns> A streaming result with incremental chat completion updates. </returns>
    public virtual AsyncResultCollection<StreamingChatUpdate> CompleteChatStreaming(
         string message,
         int? choiceCount = null,
         ChatCompletionOptions options = null)
         => CompleteChatStreamingAsync(
             new List<ChatRequestMessage> { new ChatRequestUserMessage(message) },
             choiceCount,
             options);

    /// <summary>
    /// Begins a streaming response for a chat completion request using a single, simple user message as input.
    /// </summary>
    /// <remarks>
    /// <see cref="AsyncResultCollection{T}"/> can be enumerated over using the <c>await foreach</c> pattern using the
    /// <see cref="IAsyncEnumerable{T}"/> interface. 
    /// </remarks>
    /// <param name="message"> The user message to provide as a prompt for chat completion. </param>
    /// <param name="choiceCount">
    ///     The number of independent, alternative choices that the chat completion request should generate.
    /// </param>
    /// <param name="options"> Additional options for the chat completion request. </param>
    /// <returns> A streaming result with incremental chat completion updates. </returns>
    public virtual AsyncResultCollection<StreamingChatUpdate> CompleteChatStreamingAsync(
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
    /// <see cref="ResultCollection{T}"/> can be enumerated over using the <c>await foreach</c> pattern using the
    /// <see cref="IAsyncEnumerable{T}"/> interface. 
    /// </remarks>
    /// <param name="messages"> The messages to provide as input for chat completion. </param>
    /// <param name="choiceCount">
    ///     The number of independent, alternative choices that the chat completion request should generate.
    /// </param>
    /// <param name="options"> Additional options for the chat completion request. </param>
    /// <returns> A streaming result with incremental chat completion updates. </returns>
    public virtual ResultCollection<StreamingChatUpdate> CompleteChatStreaming(
        IEnumerable<ChatRequestMessage> messages,
        int? choiceCount = null,
        ChatCompletionOptions options = null)
    {
        Argument.AssertNotNull(messages, nameof(messages));
        Internal.Models.CreateChatCompletionRequest internalRequest = CreateInternalRequest(messages, options, choiceCount, stream: true);
        using BinaryContent content = BinaryContent.Create(internalRequest);
        RequestOptions requestOptions = new() { BufferResponse = false };
        ClientResult getResult() => CompleteChat(content, requestOptions);
        return new StreamingChatUpdateCollection(getResult);
    }

    /// <summary>
    /// Begins a streaming response for a chat completion request using the provided chat messages as input and
    /// history.
    /// </summary>
    /// <remarks>
    /// <see cref="AsyncResultCollection{T}"/> can be enumerated over using the <c>await foreach</c> pattern using the
    /// <see cref="IAsyncEnumerable{T}"/> interface. 
    /// </remarks>
    /// <param name="messages"> The messages to provide as input for chat completion. </param>
    /// <param name="choiceCount">
    ///     The number of independent, alternative choices that the chat completion request should generate.
    /// </param>
    /// <param name="options"> Additional options for the chat completion request. </param>
    /// <returns> A streaming result with incremental chat completion updates. </returns>
    public virtual AsyncResultCollection<StreamingChatUpdate> CompleteChatStreamingAsync(
        IEnumerable<ChatRequestMessage> messages,
        int? choiceCount = null,
        ChatCompletionOptions options = null)
    {
        Argument.AssertNotNull(messages, nameof(messages));
        Internal.Models.CreateChatCompletionRequest internalRequest = CreateInternalRequest(messages, options, choiceCount, stream: true);
        using BinaryContent content = BinaryContent.Create(internalRequest);
        RequestOptions requestOptions = new() { BufferResponse = false };
        async Task<ClientResult> getResultAsync() =>
            await CompleteChatAsync(content, requestOptions).ConfigureAwait(false);
        return new AsyncStreamingChatUpdateCollection(getResultAsync);
    }

    private PipelineMessage CreateChatCompletionPipelineMessage(BinaryContent content, RequestOptions options = null)
    {
        PipelineMessage message = Pipeline.CreateMessage();
        message.ResponseClassifier = PipelineMessageClassifier200;
        PipelineRequest request = message.Request;
        request.Method = "POST";
        UriBuilder uriBuilder = new(_endpoint.AbsoluteUri);
        StringBuilder path = new();
        path.Append("/chat/completions");
        uriBuilder.Path += path.ToString();
        request.Uri = uriBuilder.Uri;
        request.Headers.Set("Accept", "application/json");
        request.Headers.Set("Content-Type", "application/json");
        request.Content = content;
        if (options is not null)
        {
            message.Apply(options);
        }
        return message;
    }

    private static PipelineMessageClassifier s_pipelineMessageClassifier200;
    internal static PipelineMessageClassifier PipelineMessageClassifier200
        => s_pipelineMessageClassifier200 ??= PipelineMessageClassifier.Create(stackalloc ushort[] { 200 });

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
        InternalChatCompletionStreamOptions streamOptions = stream == true
            ? new InternalChatCompletionStreamOptions(includeUsage: stream, serializedAdditionalRawData: null)
            : null;
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
            streamOptions,
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