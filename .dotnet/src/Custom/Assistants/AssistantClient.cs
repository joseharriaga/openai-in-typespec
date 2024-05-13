using OpenAI.Internal.Models;
using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace OpenAI.Assistants;

/// <summary>
/// The service client for OpenAI assistants.
/// </summary>
[Experimental("OPENAI001")]
[CodeGenClient("Assistants")]
[CodeGenSuppress("AssistantClient", typeof(ClientPipeline), typeof(ApiKeyCredential), typeof(Uri))]
[CodeGenSuppress("CreateAssistantAsync", typeof(AssistantCreationOptions))]
[CodeGenSuppress("CreateAssistant", typeof(AssistantCreationOptions))]
public partial class AssistantClient
{
    private readonly InternalAssistantMessageClient _messageSubClient;
    private readonly InternalAssistantRunClient _runSubClient;
    private readonly InternalAssistantThreadClient _threadSubClient;

    /// <summary>
    /// Initializes a new instance of <see cref="AssistantClient"/> that will use an API key when authenticating.
    /// </summary>
    /// <param name="credential"> The API key used to authenticate with the service endpoint. </param>
    /// <param name="options"> Additional options to customize the client. </param>
    /// <exception cref="ArgumentNullException"> The provided <paramref name="credential"/> was null. </exception>
    public AssistantClient(ApiKeyCredential credential, OpenAIClientOptions options = default)
        : this(
              OpenAIClient.CreatePipeline(OpenAIClient.GetApiKey(credential, requireExplicitCredential: true), options),
              OpenAIClient.GetEndpoint(options),
              options)
    { }

    /// <summary>
    /// Initializes a new instance of <see cref="AssistantClient"/> that will use an API key from the OPENAI_API_KEY
    /// environment variable when authenticating.
    /// </summary>
    /// <remarks>
    /// To provide an explicit credential instead of using the environment variable, use an alternate constructor like
    /// <see cref="AssistantClient(ApiKeyCredential,OpenAIClientOptions)"/>.
    /// </remarks>
    /// <param name="options"> Additional options to customize the client. </param>
    /// <exception cref="InvalidOperationException"> The OPENAI_API_KEY environment variable was not found. </exception>
    public AssistantClient(OpenAIClientOptions options = default)
        : this(
              OpenAIClient.CreatePipeline(OpenAIClient.GetApiKey(), options),
              OpenAIClient.GetEndpoint(options),
              options)
    { }

    /// <summary> Initializes a new instance of <see cref="AssistantClient"/>. </summary>
    /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
    /// <param name="endpoint"> OpenAI Endpoint. </param>
    /// <param name="options"> Client-wide options to propagate settings from. </param>
    protected internal AssistantClient(ClientPipeline pipeline, Uri endpoint, OpenAIClientOptions options)
    {
        _pipeline = pipeline;
        _endpoint = endpoint;
        _messageSubClient = new(_pipeline, _endpoint, options);
        _runSubClient = new(_pipeline, _endpoint, options);
        _threadSubClient = new(_pipeline, _endpoint, options);
    }

    /// <summary> Creates a new assistant. </summary>
    /// <param name="model"> The default model that the assistant should use. </param>
    /// <param name="options"> The additional <see cref="AssistantCreationOptions"/> to use. </param>
    /// <exception cref="ArgumentException"> <paramref name="model"/> is null or empty. </exception>
    public virtual async Task<ClientResult<Assistant>> CreateAssistantAsync(string model, AssistantCreationOptions options = null)
    {
        Argument.AssertNotNullOrEmpty(model, nameof(model));
        options ??= new();
        options.Model = model;

        ClientResult protocolResult = await CreateAssistantAsync(options?.ToBinaryContent(), null).ConfigureAwait(false);
        return CreateResultFromProtocol(protocolResult, Assistant.FromResponse);
    }

    /// <summary> Creates a new assistant. </summary>
    /// <param name="model"> The default model that the assistant should use. </param>
    /// <param name="options"> The additional <see cref="AssistantCreationOptions"/> to use. </param>
    /// <exception cref="ArgumentException"> <paramref name="model"/> is null or empty. </exception>
    public virtual ClientResult<Assistant> CreateAssistant(string model, AssistantCreationOptions options = null)
    {
        Argument.AssertNotNullOrEmpty(model, nameof(model));
        options ??= new();
        options.Model = model;

        ClientResult protocolResult = CreateAssistant(options?.ToBinaryContent(), null);
        return CreateResultFromProtocol(protocolResult, Assistant.FromResponse);
    }

    /// <summary>
    /// Returns a list of <see cref="Assistant"/> instances matching the provided constraints. 
    /// </summary>
    /// <param name="maxResults">
    /// A <c>limit</c> for the number of results in the list. Valid in the range of 1 to 100 with
    /// a default of 20 if not otherwise specified.
    /// </param>
    /// <param name="resultOrder">
    /// The <c>order</c> that results should appear in the list according to their <c>created_at</c>
    /// timestamp.
    /// </param>
    /// <param name="previousId">
    /// A cursor for use in pagination. If provided, results in the list will begin immediately
    /// <c>after</c> this ID according to the specified order.
    /// </param>
    /// <param name="subsequentId">
    /// A cursor for use in pagination. If provided, results in the list will end just <c>before</c>
    /// this ID according to the specified order.
    /// </param>
    /// <returns> A page of results matching any constraints provided. </returns>
    public virtual AsyncPageableCollection<Assistant> GetAssistantsAsync()
    {
        async Task<ClientPage<Assistant>> firstPageFunc(int? pageSize)
        {
            ClientResult result = await GetAssistantsAsync(limit: pageSize, order: null, after: null, before: null, options: null).ConfigureAwait(false);
            PipelineResponse response = result.GetRawResponse();
            InternalListAssistantsResponse values = ModelReaderWriter.Read<InternalListAssistantsResponse>(response.Content);
            return PageableResultHelpers.CreatePage(values.Data, values.LastId, response);
        }

        async Task<ClientPage<Assistant>> nextPageFunc(string? continuationToken, int? pageSize)
        {
            ClientResult result = await GetAssistantsAsync(limit: pageSize, order: null, after: continuationToken, before: null, options: null).ConfigureAwait(false);
            PipelineResponse response = result.GetRawResponse();
            InternalListAssistantsResponse values = ModelReaderWriter.Read<InternalListAssistantsResponse>(response.Content);
            return PageableResultHelpers.CreatePage(values.Data, values.LastId, response);
        }

        return PageableResultHelpers.Create(firstPageFunc, nextPageFunc);
    }

    /// <summary>
    /// Returns a list of <see cref="Assistant"/> instances matching the provided constraints. 
    /// </summary>
    /// <param name="maxResults">
    /// A <c>limit</c> for the number of results in the list. Valid in the range of 1 to 100 with
    /// a default of 20 if not otherwise specified.
    /// </param>
    /// <param name="resultOrder">
    /// The <c>order</c> that results should appear in the list according to their <c>created_at</c>
    /// timestamp.
    /// </param>
    /// <param name="previousId">
    /// A cursor for use in pagination. If provided, results in the list will begin immediately
    /// <c>after</c> this ID according to the specified order.
    /// </param>
    /// <param name="subsequentId">
    /// A cursor for use in pagination. If provided, results in the list will end just <c>before</c>
    /// this ID according to the specified order.
    /// </param>
    /// <returns> A page of results matching any constraints provided. </returns>
    public virtual PageableCollection<Assistant> GetAssistants()
    {
        ClientPage<Assistant> firstPageFunc(int? pageSize)
        {
            ClientResult result = GetAssistants(limit: pageSize, order: null, after: null, before: null, options: null);
            PipelineResponse response = result.GetRawResponse();
            InternalListAssistantsResponse values = ModelReaderWriter.Read<InternalListAssistantsResponse>(response.Content);
            return PageableResultHelpers.CreatePage(values.Data, values.LastId, response);
        }

        ClientPage<Assistant> nextPageFunc(string? continuationToken, int? pageSize)
        {
            ClientResult result = GetAssistants(limit: pageSize, order: null, after: continuationToken, before: null, options: null);
            PipelineResponse response = result.GetRawResponse();
            InternalListAssistantsResponse values = ModelReaderWriter.Read<InternalListAssistantsResponse>(response.Content);
            return PageableResultHelpers.CreatePage(values.Data, values.LastId, response);
        }

        return PageableResultHelpers.Create(firstPageFunc, nextPageFunc);
    }

    /// <summary>
    /// Deletes an existing <see cref="Assistant"/>. 
    /// </summary>
    /// <param name="assistantId"> The ID of the assistant to delete. </param>
    /// <returns> A value indicating whether the deletion was successful. </returns>
    public virtual async Task<ClientResult<bool>> DeleteAssistantAsync(string assistantId)
    {
        Argument.AssertNotNullOrEmpty(assistantId, nameof(assistantId));

        ClientResult protocolResult = await DeleteAssistantAsync(assistantId).ConfigureAwait(false);
        return CreateResultFromProtocol(protocolResult, response
            => InternalDeleteAssistantResponse.FromResponse(response).Deleted);
    }

    /// <summary>
    /// Deletes an existing <see cref="Assistant"/>. 
    /// </summary>
    /// <param name="assistantId"> The ID of the assistant to delete. </param>
    /// <returns> A value indicating whether the deletion was successful. </returns>
    public virtual ClientResult<bool> DeleteAssistant(string assistantId)
    {
        Argument.AssertNotNullOrEmpty(assistantId, nameof(assistantId));

        ClientResult protocolResult = DeleteAssistant(assistantId, (RequestOptions)null);
        return CreateResultFromProtocol(protocolResult, response
            => InternalDeleteAssistantResponse.FromResponse(response).Deleted);
    }

    /// <summary>
    /// Creates a new <see cref="AssistantThread"/>.
    /// </summary>
    /// <param name="options"> Additional options to use when creating the thread. </param>
    /// <returns> A new thread. </returns>
    public virtual async Task<ClientResult<AssistantThread>> CreateThreadAsync(ThreadCreationOptions options = null)
    {
        ClientResult protocolResult = await CreateThreadAsync(options?.ToBinaryContent()).ConfigureAwait(false);
        return CreateResultFromProtocol(protocolResult, AssistantThread.FromResponse);
    }

    /// <summary>
    /// Creates a new <see cref="AssistantThread"/>.
    /// </summary>
    /// <param name="options"> Additional options to use when creating the thread. </param>
    /// <returns> A new thread. </returns>
    public virtual ClientResult<AssistantThread> CreateThread(ThreadCreationOptions options = null)
    {
        ClientResult protocolResult = CreateThread(options?.ToBinaryContent());
        return CreateResultFromProtocol(protocolResult, AssistantThread.FromResponse);
    }

    /// <summary>
    /// Gets an existing <see cref="AssistantThread"/>, retrieved via a known ID.
    /// </summary>
    /// <param name="threadId"> The ID of the thread to retrieve. </param>
    /// <returns> The existing thread instance. </returns>
    public virtual async Task<ClientResult<AssistantThread>> GetThreadAsync(string threadId)
    {
        Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));

        ClientResult protocolResult = await GetThreadAsync(threadId, null).ConfigureAwait(false);
        return CreateResultFromProtocol(protocolResult, AssistantThread.FromResponse);
    }

    /// <summary>
    /// Gets an existing <see cref="AssistantThread"/>, retrieved via a known ID.
    /// </summary>
    /// <param name="threadId"> The ID of the thread to retrieve. </param>
    /// <returns> The existing thread instance. </returns>
    public virtual ClientResult<AssistantThread> GetThread(string threadId)
    {
        Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));

        ClientResult protocolResult = GetThread(threadId, null);
        return CreateResultFromProtocol(protocolResult, AssistantThread.FromResponse);
    }

    /// <summary>
    /// Modifies an existing <see cref="AssistantThread"/>.
    /// </summary>
    /// <param name="threadId"> The ID of the thread to modify. </param>
    /// <param name="options"> The modifications to apply to the thread. </param>
    /// <returns> The updated <see cref="AssistantThread"/> instance. </returns>
    public virtual async Task<ClientResult<AssistantThread>> ModifyThreadAsync(string threadId, ThreadModificationOptions options)
    {
        Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));
        Argument.AssertNotNull(options, nameof(options));

        ClientResult protocolResult = await ModifyThreadAsync(threadId, options?.ToBinaryContent(), null).ConfigureAwait(false);
        return CreateResultFromProtocol(protocolResult, AssistantThread.FromResponse);
    }

    /// <summary>
    /// Modifies an existing <see cref="AssistantThread"/>.
    /// </summary>
    /// <param name="threadId"> The ID of the thread to modify. </param>
    /// <param name="options"> The modifications to apply to the thread. </param>
    /// <returns> The updated <see cref="AssistantThread"/> instance. </returns>
    public virtual ClientResult<AssistantThread> ModifyThread(string threadId, ThreadModificationOptions options)
    {
        Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));
        Argument.AssertNotNull(options, nameof(options));

        ClientResult protocolResult = ModifyThread(threadId, options?.ToBinaryContent(), null);
        return CreateResultFromProtocol(protocolResult, AssistantThread.FromResponse);
    }

    /// <summary>
    /// Deletes an existing <see cref="AssistantThread"/>.
    /// </summary>
    /// <param name="threadId"> The ID of the thread to delete. </param>
    /// <returns> A value indicating whether the deletion was successful. </returns>
    public virtual async Task<ClientResult<bool>> DeleteThreadAsync(string threadId)
    {
        Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));

        ClientResult protocolResult = await DeleteThreadAsync(threadId, null).ConfigureAwait(false);
        return CreateResultFromProtocol(protocolResult, response
            => InternalDeleteThreadResponse.FromResponse(response).Deleted);
    }

    /// <summary>
    /// Deletes an existing <see cref="AssistantThread"/>.
    /// </summary>
    /// <param name="threadId"> The ID of the thread to delete. </param>
    /// <returns> A value indicating whether the deletion was successful. </returns>
    public virtual ClientResult<bool> DeleteThread(string threadId)
    {
        Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));

        ClientResult protocolResult = DeleteThread(threadId, null);
        return CreateResultFromProtocol(protocolResult, response
            => InternalDeleteThreadResponse.FromResponse(response).Deleted);
    }

    /// <summary>
    /// Creates a new <see cref="ThreadMessage"/> on an existing <see cref="AssistantThread"/>.
    /// </summary>
    /// <param name="threadId"> The ID of the thread to associate the new message with. </param>
    /// <param name="content"> The collection of <see cref="MessageContent"/> items for the message. </param>
    /// <param name="options"> Additional options to apply to the new message. </param>
    /// <returns> A new <see cref="ThreadMessage"/>. </returns>
    public virtual async Task<ClientResult<ThreadMessage>> CreateMessageAsync(
        string threadId,
        IEnumerable<MessageContent> content,
        MessageCreationOptions options = null)
    {
        Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));
        options ??= new();
        options.Content.Clear();
        foreach (MessageContent contentItem in content)
        {
            options.Content.Add(contentItem);
        }

        ClientResult protocolResult = await CreateMessageAsync(threadId, options?.ToBinaryContent(), null)
            .ConfigureAwait(false);
        return CreateResultFromProtocol(protocolResult, ThreadMessage.FromResponse);
    }

    /// <summary>
    /// Creates a new <see cref="ThreadMessage"/> on an existing <see cref="AssistantThread"/>.
    /// </summary>
    /// <param name="threadId"> The ID of the thread to associate the new message with. </param>
    /// <param name="content"> The collection of <see cref="MessageContent"/> items for the message. </param>
    /// <param name="options"> Additional options to apply to the new message. </param>
    /// <returns> A new <see cref="ThreadMessage"/>. </returns>
    public virtual ClientResult<ThreadMessage> CreateMessage(
        string threadId,
        IEnumerable<MessageContent> content,
        MessageCreationOptions options = null)
    {
        Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));
        options ??= new();
        options.Content.Clear();
        foreach (MessageContent contentItem in content)
        {
            options.Content.Add(contentItem);
        }

        ClientResult protocolResult = CreateMessage(threadId, options?.ToBinaryContent(), null);
        return CreateResultFromProtocol(protocolResult, ThreadMessage.FromResponse);
    }

    /// <summary>
    /// Returns a list of <see cref="ThreadMessage"/> instances from an existing <see cref="AssistantThread"/>,
    /// matching any optional constraints provided.
    /// </summary>
    /// <param name="threadId"> The ID of the thread to list messages from. </param>
    /// <param name="maxResults">
    /// A <c>limit</c> for the number of results in the list. Valid in the range of 1 to 100 with
    /// a default of 20 if not otherwise specified.
    /// </param>
    /// <param name="resultOrder">
    /// The <c>order</c> that results should appear in the list according to their <c>created_at</c>
    /// timestamp.
    /// </param>
    /// <param name="previousId">
    /// A cursor for use in pagination. If provided, results in the list will begin immediately
    /// <c>after</c> this ID according to the specified order.
    /// </param>
    /// <param name="subsequentId">
    /// A cursor for use in pagination. If provided, results in the list will end just <c>before</c>
    /// this ID according to the specified order.
    /// </param>
    /// <returns> A page of results matching any constraints provided. </returns>

    public virtual AsyncPageableCollection<ThreadMessage> GetMessagesAsync(
        string threadId,
        ListOrder? resultOrder = null,
        string previousId = null,
        string subsequentId = null)
    {
        Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));

        async Task<ClientPage<ThreadMessage>> firstPageFunc(int? pageSize)
        {
            ClientResult result = await GetMessagesAsync(threadId, limit: pageSize, order: resultOrder?.ToString(), after: null, before: null, options: null).ConfigureAwait(false);
            PipelineResponse response = result.GetRawResponse();
            InternalListMessagesResponse values = ModelReaderWriter.Read<InternalListMessagesResponse>(response.Content);
            return PageableResultHelpers.CreatePage(values.Data, values.LastId, response);
        }

        async Task<ClientPage<ThreadMessage>> nextPageFunc(string? continuationToken, int? pageSize)
        {
            ClientResult result = await GetMessagesAsync(threadId, limit: pageSize, order: null, after: continuationToken, before: null, options: null).ConfigureAwait(false);
            PipelineResponse response = result.GetRawResponse();
            InternalListMessagesResponse values = ModelReaderWriter.Read<InternalListMessagesResponse>(response.Content);
            return PageableResultHelpers.CreatePage(values.Data, values.LastId, response);
        }

        return PageableResultHelpers.Create(firstPageFunc, nextPageFunc);
    }

    /// <summary>
    /// Returns a list of <see cref="ThreadMessage"/> instances from an existing <see cref="AssistantThread"/>,
    /// matching any optional constraints provided.
    /// </summary>
    /// <param name="threadId"> The ID of the thread to list messages from. </param>
    /// <param name="maxResults">
    /// A <c>limit</c> for the number of results in the list. Valid in the range of 1 to 100 with
    /// a default of 20 if not otherwise specified.
    /// </param>
    /// <param name="resultOrder">
    /// The <c>order</c> that results should appear in the list according to their <c>created_at</c>
    /// timestamp.
    /// </param>
    /// <param name="previousId">
    /// A cursor for use in pagination. If provided, results in the list will begin immediately
    /// <c>after</c> this ID according to the specified order.
    /// </param>
    /// <param name="subsequentId">
    /// A cursor for use in pagination. If provided, results in the list will end just <c>before</c>
    /// this ID according to the specified order.
    /// </param>
    /// <returns> A page of results matching any constraints provided. </returns>
    public virtual PageableCollection<ThreadMessage> GetMessages(string threadId,
        ListOrder? resultOrder = null)
    {
        Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));

        ClientPage<ThreadMessage> firstPageFunc(int? pageSize)
        {
            ClientResult result = GetMessages(threadId, limit: pageSize, order: resultOrder?.ToString(), after: null, before: null, options: null);
            PipelineResponse response = result.GetRawResponse();
            InternalListMessagesResponse values = ModelReaderWriter.Read<InternalListMessagesResponse>(response.Content);
            return PageableResultHelpers.CreatePage(values.Data, values.LastId, response);
        }

        ClientPage<ThreadMessage> nextPageFunc(string? continuationToken, int? pageSize)
        {
            ClientResult result = GetMessages(threadId, limit: pageSize, order: null, after: continuationToken, before: null, options: null);
            PipelineResponse response = result.GetRawResponse();
            InternalListMessagesResponse values = ModelReaderWriter.Read<InternalListMessagesResponse>(response.Content);
            return PageableResultHelpers.CreatePage(values.Data, values.LastId, response);
        }

        return PageableResultHelpers.Create(firstPageFunc, nextPageFunc);
    }

    /// <summary>
    /// Gets an existing <see cref="ThreadMessage"/> from a known <see cref="AssistantThread"/>.
    /// </summary>
    /// <param name="threadId"> The ID of the thread to retrieve the message from. </param>
    /// <param name="messageId"> The ID of the message to retrieve. </param>
    /// <returns> The existing <see cref="ThreadMessage"/> instance. </returns>
    public virtual async Task<ClientResult<ThreadMessage>> GetMessageAsync(string threadId, string messageId)
    {
        Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));
        Argument.AssertNotNullOrEmpty(messageId, nameof(messageId));

        ClientResult protocolResult = await GetMessageAsync(threadId, messageId, null).ConfigureAwait(false);
        return CreateResultFromProtocol(protocolResult, ThreadMessage.FromResponse);
    }

    /// <summary>
    /// Gets an existing <see cref="ThreadMessage"/> from a known <see cref="AssistantThread"/>.
    /// </summary>
    /// <param name="threadId"> The ID of the thread to retrieve the message from. </param>
    /// <param name="messageId"> The ID of the message to retrieve. </param>
    /// <returns> The existing <see cref="ThreadMessage"/> instance. </returns>
    public virtual ClientResult<ThreadMessage> GetMessage(string threadId, string messageId)
    {
        Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));
        Argument.AssertNotNullOrEmpty(messageId, nameof(messageId));

        ClientResult protocolResult = GetMessage(threadId, messageId, null);
        return CreateResultFromProtocol(protocolResult, ThreadMessage.FromResponse);
    }

    /// <summary>
    /// Modifies an existing <see cref="ThreadMessage"/>.
    /// </summary>
    /// <param name="threadId"> The ID of the thread associated with the message to modify. </param>
    /// <param name="messageId"> The ID of the message to modify. </param>
    /// <param name="options"> The changes to apply to the message. </param>
    /// <returns> The updated <see cref="ThreadMessage"/>. </returns>
    public virtual async Task<ClientResult<ThreadMessage>> ModifyMessageAsync(string threadId, string messageId, MessageModificationOptions options)
    {
        Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));
        Argument.AssertNotNullOrEmpty(messageId, nameof(messageId));
        Argument.AssertNotNull(options, nameof(options));

        ClientResult protocolResult = await ModifyMessageAsync(threadId, messageId, options?.ToBinaryContent(), null)
            .ConfigureAwait(false);
        return CreateResultFromProtocol(protocolResult, ThreadMessage.FromResponse);
    }

    /// <summary>
    /// Modifies an existing <see cref="ThreadMessage"/>.
    /// </summary>
    /// <param name="threadId"> The ID of the thread associated with the message to modify. </param>
    /// <param name="messageId"> The ID of the message to modify. </param>
    /// <param name="options"> The changes to apply to the message. </param>
    /// <returns> The updated <see cref="ThreadMessage"/>. </returns>
    public virtual ClientResult<ThreadMessage> ModifyMessage(string threadId, string messageId, MessageModificationOptions options)
    {
        Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));
        Argument.AssertNotNullOrEmpty(messageId, nameof(messageId));
        Argument.AssertNotNull(options, nameof(options));

        ClientResult protocolResult = ModifyMessage(threadId, messageId, options?.ToBinaryContent(), null);
        return CreateResultFromProtocol(protocolResult, ThreadMessage.FromResponse);
    }

    /// <summary>
    /// Deletes an existing <see cref="ThreadMessage"/>.
    /// </summary>
    /// <param name="threadId"> The ID of the thread associated with the message. </param>
    /// <param name="messageId"> The ID of the message. </param>
    /// <returns> A value indicating whether the deletion was successful. </returns>
    public virtual async Task<ClientResult<bool>> DeleteMessageAsync(string threadId, string messageId)
    {
        Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));
        Argument.AssertNotNullOrEmpty(messageId, nameof(messageId));

        ClientResult protocolResult = await DeleteMessageAsync(threadId, messageId, null).ConfigureAwait(false);
        return CreateResultFromProtocol(protocolResult, response =>
            InternalDeleteMessageResponse.FromResponse(response).Deleted);
    }

    /// <summary>
    /// Deletes an existing <see cref="ThreadMessage"/>.
    /// </summary>
    /// <param name="threadId"> The ID of the thread associated with the message. </param>
    /// <param name="messageId"> The ID of the message. </param>
    /// <returns> A value indicating whether the deletion was successful. </returns>
    public virtual ClientResult<bool> DeleteMessage(string threadId, string messageId)
    {
        Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));
        Argument.AssertNotNullOrEmpty(messageId, nameof(messageId));

        ClientResult protocolResult = DeleteMessage(threadId, messageId, null);
        return CreateResultFromProtocol(protocolResult, response =>
            InternalDeleteMessageResponse.FromResponse(response).Deleted);
    }

    /// <summary>
    /// Begins a new <see cref="ThreadRun"/> that evaluates a <see cref="AssistantThread"/> using a specified
    /// <see cref="Assistant"/>.
    /// </summary>
    /// <param name="threadId"> The ID of the thread that the run should evaluate. </param>
    /// <param name="assistantId"> The ID of the assistant that should be used when evaluating the thread. </param>
    /// <param name="options"> Additional options for the run. </param>
    /// <returns> A new <see cref="ThreadRun"/> instance. </returns>
    public virtual async Task<ClientResult<ThreadRun>> CreateRunAsync(string threadId, string assistantId, RunCreationOptions options = null)
    {
        Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));
        Argument.AssertNotNullOrEmpty(assistantId, nameof(assistantId));
        options ??= new();
        options.AssistantId = assistantId;

        ClientResult protocolResult = await CreateRunAsync(threadId, options.ToBinaryContent(), null)
            .ConfigureAwait(false);
        return CreateResultFromProtocol(protocolResult, ThreadRun.FromResponse);
    }

    /// <summary>
    /// Begins a new <see cref="ThreadRun"/> that evaluates a <see cref="AssistantThread"/> using a specified
    /// <see cref="Assistant"/>.
    /// </summary>
    /// <param name="threadId"> The ID of the thread that the run should evaluate. </param>
    /// <param name="assistantId"> The ID of the assistant that should be used when evaluating the thread. </param>
    /// <param name="options"> Additional options for the run. </param>
    /// <returns> A new <see cref="ThreadRun"/> instance. </returns>
    public virtual ClientResult<ThreadRun> CreateRun(string threadId, string assistantId, RunCreationOptions options = null)
    {
        Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));
        Argument.AssertNotNullOrEmpty(assistantId, nameof(assistantId));
        options ??= new();
        options.AssistantId = assistantId;

        ClientResult protocolResult = CreateRun(threadId, options.ToBinaryContent(), null);
        return CreateResultFromProtocol(protocolResult, ThreadRun.FromResponse);
    }

    /// <summary>
    /// Creates a new thread and immediately begins a run against it using the specified <see cref="Assistant"/>.
    /// </summary>
    /// <param name="assistantId"> The ID of the assistant that the new run should use. </param>
    /// <param name="threadOptions"> Options for the new thread that will be created. </param>
    /// <param name="runOptions"> Additional options to apply to the run that will begin. </param>
    /// <returns> A new <see cref="ThreadRun"/>. </returns>
    public virtual async Task<ClientResult<ThreadRun>> CreateThreadAndRunAsync(
        string assistantId,
        ThreadCreationOptions threadOptions = null,
        RunCreationOptions runOptions = null)
    {
        BinaryContent protocolContent = CreateThreadAndRunProtocolContent(assistantId, threadOptions, runOptions);
        ClientResult protocolResult = await CreateThreadAndRunAsync(protocolContent, null).ConfigureAwait(false);
        return CreateResultFromProtocol(protocolResult, ThreadRun.FromResponse);
    }

    /// <summary>
    /// Creates a new thread and immediately begins a run against it using the specified <see cref="Assistant"/>.
    /// </summary>
    /// <param name="assistantId"> The ID of the assistant that the new run should use. </param>
    /// <param name="threadOptions"> Options for the new thread that will be created. </param>
    /// <param name="runOptions"> Additional options to apply to the run that will begin. </param>
    /// <returns> A new <see cref="ThreadRun"/>. </returns>
    public virtual ClientResult<ThreadRun> CreateThreadAndRun(
        string assistantId,
        ThreadCreationOptions threadOptions = null,
        RunCreationOptions runOptions = null)
    {
        BinaryContent protocolContent = CreateThreadAndRunProtocolContent(assistantId, threadOptions, runOptions);
        ClientResult protocolResult = CreateThreadAndRun(protocolContent, null);
        return CreateResultFromProtocol(protocolResult, ThreadRun.FromResponse);
    }

    ///// <summary>
    ///// Returns a list of <see cref="ThreadRun"/> instances associated with an existing <see cref="AssistantThread"/>,
    ///// matching any optional constraints provided.
    ///// </summary>
    ///// <param name="threadId"> The ID of the thread that runs in the list should be associated with. </param>
    ///// <param name="maxResults">
    ///// A <c>limit</c> for the number of results in the list. Valid in the range of 1 to 100 with
    ///// a default of 20 if not otherwise specified.
    ///// </param>
    ///// <param name="resultOrder">
    ///// The <c>order</c> that results should appear in the list according to their <c>created_at</c>
    ///// timestamp.
    ///// </param>
    ///// <param name="previousId">
    ///// A cursor for use in pagination. If provided, results in the list will begin immediately
    ///// <c>after</c> this ID according to the specified order.
    ///// </param>
    ///// <param name="subsequentId">
    ///// A cursor for use in pagination. If provided, results in the list will end just <c>before</c>
    ///// this ID according to the specified order.
    ///// </param>
    ///// <returns> A page of results matching any constraints provided. </returns>
    //public virtual async Task<ClientResult<ListQueryPage<ThreadRun>>> GetRunsAsync(
    //    string threadId,
    //    int? maxResults = null,
    //    ListOrder? resultOrder = null,
    //    string previousId = null,
    //    string subsequentId = null)
    //{
    //    Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));

    //    ClientResult protocolResult
    //        = await GetRunsAsync(threadId, maxResults, resultOrder?.ToString(), previousId, subsequentId, null)
    //            .ConfigureAwait(false);
    //    return CreateListResultFromProtocol(protocolResult, InternalListRunsResponse.FromResponse);
    //}

    ///// <summary>
    ///// Returns a list of <see cref="ThreadRun"/> instances associated with an existing <see cref="AssistantThread"/>,
    ///// matching any optional constraints provided.
    ///// </summary>
    ///// <param name="threadId"> The ID of the thread that runs in the list should be associated with. </param>
    ///// <param name="maxResults">
    ///// A <c>limit</c> for the number of results in the list. Valid in the range of 1 to 100 with
    ///// a default of 20 if not otherwise specified.
    ///// </param>
    ///// <param name="resultOrder">
    ///// The <c>order</c> that results should appear in the list according to their <c>created_at</c>
    ///// timestamp.
    ///// </param>
    ///// <param name="previousId">
    ///// A cursor for use in pagination. If provided, results in the list will begin immediately
    ///// <c>after</c> this ID according to the specified order.
    ///// </param>
    ///// <param name="subsequentId">
    ///// A cursor for use in pagination. If provided, results in the list will end just <c>before</c>
    ///// this ID according to the specified order.
    ///// </param>
    ///// <returns> A page of results matching any constraints provided. </returns>
    //public virtual ClientResult<ListQueryPage<ThreadRun>> GetRuns(
    //    string threadId,
    //    int? maxResults = null,
    //    ListOrder? resultOrder = null,
    //    string previousId = null,
    //    string subsequentId = null)
    //{
    //    Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));

    //    ClientResult protocolResult
    //        = GetRuns(threadId, maxResults, resultOrder?.ToString(), previousId, subsequentId, null);
    //    return CreateListResultFromProtocol(protocolResult, InternalListRunsResponse.FromResponse);
    //}

    /// <summary>
    /// Gets an existing <see cref="ThreadRun"/> from a known <see cref="AssistantThread"/>.
    /// </summary>
    /// <param name="threadId"> The ID of the thread to retrieve the run from. </param>
    /// <param name="runId"> The ID of the run to retrieve. </param>
    /// <returns> The existing <see cref="ThreadRun"/> instance. </returns>
    public virtual async Task<ClientResult<ThreadRun>> GetRunAsync(string threadId, string runId)
    {
        Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));
        Argument.AssertNotNullOrEmpty(runId, nameof(runId));

        ClientResult protocolResult = await GetRunAsync(threadId, runId, null).ConfigureAwait(false);
        return CreateResultFromProtocol(protocolResult, ThreadRun.FromResponse);
    }

    /// <summary>
    /// Gets an existing <see cref="ThreadRun"/> from a known <see cref="AssistantThread"/>.
    /// </summary>
    /// <param name="threadId"> The ID of the thread to retrieve the run from. </param>
    /// <param name="runId"> The ID of the run to retrieve. </param>
    /// <returns> The existing <see cref="ThreadRun"/> instance. </returns>
    public virtual ClientResult<ThreadRun> GetRun(string threadId, string runId)
    {
        Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));
        Argument.AssertNotNullOrEmpty(runId, nameof(runId));

        ClientResult protocolResult = GetRun(threadId, runId, null);
        return CreateResultFromProtocol(protocolResult, ThreadRun.FromResponse);
    }

    /// <summary>
    /// Submits a collection of required tool call outputs to a run and resumes the run.
    /// </summary>
    /// <param name="threadId"> The thread ID of the thread being run. </param>
    /// <param name="runId"> The ID of the run that reached a <c>requires_action</c> status. </param>
    /// <param name="toolOutputs">
    /// The tool outputs, corresponding to <see cref="RequiredToolCall"/> instances from the run.
    /// </param>
    /// <returns> The <see cref="ThreadRun"/>, updated after the submission was processed. </returns>
    public virtual async Task<ClientResult<ThreadRun>> SubmitToolOutputsToRunAsync(
        string threadId,
        string runId,
        IEnumerable<ToolOutput> toolOutputs)
    {
        Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));
        Argument.AssertNotNullOrEmpty(runId, nameof(runId));

        BinaryContent content = new InternalSubmitToolOutputsRunRequest(toolOutputs).ToBinaryContent();
        ClientResult protocolResult = await SubmitToolOutputsToRunAsync(threadId, runId, content, null)
            .ConfigureAwait(false);
        return CreateResultFromProtocol(protocolResult, ThreadRun.FromResponse);
    }

    /// <summary>
    /// Submits a collection of required tool call outputs to a run and resumes the run.
    /// </summary>
    /// <param name="threadId"> The thread ID of the thread being run. </param>
    /// <param name="runId"> The ID of the run that reached a <c>requires_action</c> status. </param>
    /// <param name="toolOutputs">
    /// The tool outputs, corresponding to <see cref="RequiredToolCall"/> instances from the run.
    /// </param>
    /// <returns> The <see cref="ThreadRun"/>, updated after the submission was processed. </returns>
    public virtual ClientResult<ThreadRun> SubmitToolOutputsToRun(
        string threadId,
        string runId,
        IEnumerable<ToolOutput> toolOutputs)
    {
        Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));
        Argument.AssertNotNullOrEmpty(runId, nameof(runId));

        BinaryContent content = new InternalSubmitToolOutputsRunRequest(toolOutputs).ToBinaryContent();
        ClientResult protocolResult = SubmitToolOutputsToRun(threadId, runId, content, null);
        return CreateResultFromProtocol(protocolResult, ThreadRun.FromResponse);
    }

    /// <summary>
    /// Cancels an in-progress <see cref="ThreadRun"/>.
    /// </summary>
    /// <param name="threadId"> The ID of the thread associated with the run. </param>
    /// <param name="runId"> The ID of the run to cancel. </param>
    /// <returns> An updated <see cref="ThreadRun"/> instance, reflecting the new status of the run. </returns>
    public virtual async Task<ClientResult<ThreadRun>> CancelRunAsync(string threadId, string runId)
    {
        Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));
        Argument.AssertNotNullOrEmpty(runId, nameof(runId));

        ClientResult protocolResult = await CancelRunAsync(threadId, runId, null).ConfigureAwait(false);
        return CreateResultFromProtocol(protocolResult, ThreadRun.FromResponse);
    }

    /// <summary>
    /// Cancels an in-progress <see cref="ThreadRun"/>.
    /// </summary>
    /// <param name="threadId"> The ID of the thread associated with the run. </param>
    /// <param name="runId"> The ID of the run to cancel. </param>
    /// <returns> An updated <see cref="ThreadRun"/> instance, reflecting the new status of the run. </returns>
    public virtual ClientResult<ThreadRun> CancelRun(string threadId, string runId)
    {
        Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));
        Argument.AssertNotNullOrEmpty(runId, nameof(runId));

        ClientResult protocolResult = CancelRun(threadId, runId, null);
        return CreateResultFromProtocol(protocolResult, ThreadRun.FromResponse);
    }

    ///// <summary>
    ///// Gets a collection of <see cref="RunStep"/> instances associated with a <see cref="ThreadRun"/>.
    ///// </summary>
    ///// <param name="threadId"> The ID of the thread associated with the run. </param>
    ///// <param name="runId"> The ID of the run to list run steps from. </param>
    ///// <param name="maxResults">
    ///// A <c>limit</c> for the number of results in the list. Valid in the range of 1 to 100 with
    ///// a default of 20 if not otherwise specified.
    ///// </param>
    ///// <param name="resultOrder">
    ///// The <c>order</c> that results should appear in the list according to their <c>created_at</c>
    ///// timestamp.
    ///// </param>
    ///// <param name="previousId">
    ///// A cursor for use in pagination. If provided, results in the list will begin immediately
    ///// <c>after</c> this ID according to the specified order.
    ///// </param>
    ///// <param name="subsequentId">
    ///// A cursor for use in pagination. If provided, results in the list will end just <c>before</c>
    ///// this ID according to the specified order.
    ///// </param>
    ///// <returns> A page of results matching any constraints provided. </returns>
    //public virtual async Task<ClientResult<ListQueryPage<RunStep>>> GetRunStepsAsync(
    //    string threadId,
    //    string runId,
    //    int? maxResults = null,
    //    ListOrder? resultOrder = null,
    //    string previousId = null,
    //    string subsequentId = null)
    //{
    //    ClientResult protocolResult = await GetRunStepsAsync(threadId, runId, maxResults, resultOrder?.ToString(), previousId, subsequentId, null)
    //        .ConfigureAwait(false);
    //    return CreateListResultFromProtocol(protocolResult, InternalListRunStepsResponse.FromResponse);
    //}

    ///// <summary>
    ///// Gets a collection of <see cref="RunStep"/> instances associated with a <see cref="ThreadRun"/>.
    ///// </summary>
    ///// <param name="threadId"> The ID of the thread associated with the run. </param>
    ///// <param name="runId"> The ID of the run to list run steps from. </param>
    ///// <param name="maxResults">
    ///// A <c>limit</c> for the number of results in the list. Valid in the range of 1 to 100 with
    ///// a default of 20 if not otherwise specified.
    ///// </param>
    ///// <param name="resultOrder">
    ///// The <c>order</c> that results should appear in the list according to their <c>created_at</c>
    ///// timestamp.
    ///// </param>
    ///// <param name="previousId">
    ///// A cursor for use in pagination. If provided, results in the list will begin immediately
    ///// <c>after</c> this ID according to the specified order.
    ///// </param>
    ///// <param name="subsequentId">
    ///// A cursor for use in pagination. If provided, results in the list will end just <c>before</c>
    ///// this ID according to the specified order.
    ///// </param>
    ///// <returns> A page of results matching any constraints provided. </returns>
    //public virtual ClientResult<ListQueryPage<RunStep>> GetRunSteps(
    //    string threadId,
    //    string runId,
    //    int? maxResults = null,
    //    ListOrder? resultOrder = null,
    //    string previousId = null,
    //    string subsequentId = null)
    //{
    //    ClientResult protocolResult = GetRunSteps(threadId, runId, maxResults, resultOrder?.ToString(), previousId, subsequentId, null);
    //    return CreateListResultFromProtocol(protocolResult, InternalListRunStepsResponse.FromResponse);
    //}

    /// <summary>
    /// Gets a single run step from a run.
    /// </summary>
    /// <param name="threadId"> The ID of the thread associated with the run. </param>
    /// <param name="runId"> The ID of the run. </param>
    /// <param name="stepId"> The ID of the run step. </param>
    /// <returns> A <see cref="RunStep"/> instance corresponding to the specified step. </returns>
    public virtual async Task<ClientResult<RunStep>> GetRunStepAsync(string threadId, string runId, string stepId)
    {
        ClientResult protocolResult = await GetRunStepAsync(threadId, runId, stepId).ConfigureAwait(false);
        return CreateResultFromProtocol(protocolResult, RunStep.FromResponse);
    }

    /// <summary>
    /// Gets a single run step from a run.
    /// </summary>
    /// <param name="threadId"> The ID of the thread associated with the run. </param>
    /// <param name="runId"> The ID of the run. </param>
    /// <param name="stepId"> The ID of the run step. </param>
    /// <returns> A <see cref="RunStep"/> instance corresponding to the specified step. </returns>
    public virtual ClientResult<RunStep> GetRunStep(string threadId, string runId, string stepId)
    {
        ClientResult protocolResult = GetRunStep(threadId, runId, stepId);
        return CreateResultFromProtocol(protocolResult, RunStep.FromResponse);
    }

    private static BinaryContent CreateThreadAndRunProtocolContent(
        string assistantId,
        ThreadCreationOptions threadOptions,
        RunCreationOptions runOptions)
    {
        Argument.AssertNotNullOrEmpty(assistantId, nameof(assistantId));
        InternalCreateThreadAndRunRequest internalRequest = new(
            assistantId,
            threadOptions,
            runOptions.ModelOverride,
            runOptions.InstructionsOverride,
            runOptions.Tools,
            // TODO: reconcile exposure of the the two different tool_resources, if needed
            threadOptions?.ToolResources,
            runOptions.Metadata,
            runOptions.Temperature,
            runOptions.TopP,
            runOptions.Stream,
            runOptions.MaxPromptTokens,
            runOptions.MaxCompletionTokens,
            runOptions.TruncationStrategy,
            runOptions.ToolChoice,
            runOptions.ResponseFormat,
            serializedAdditionalRawData: null);
        return internalRequest.ToBinaryContent();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static ClientResult<T> CreateResultFromProtocol<T>(ClientResult protocolResult, Func<PipelineResponse, T> responseDeserializer)
    {
        PipelineResponse pipelineResponse = protocolResult?.GetRawResponse();
        T deserializedResultValue = responseDeserializer.Invoke(pipelineResponse);
        return ClientResult.FromValue(deserializedResultValue, pipelineResponse);
    }
}
