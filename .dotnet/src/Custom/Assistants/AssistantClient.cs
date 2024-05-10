using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using OpenAI.Internal.Models;

namespace OpenAI.Assistants;

/// <summary>
/// The service client for OpenAI assistants.
/// </summary>
[Experimental("OPENAI001")]
[CodeGenClient("Assistants")]
[CodeGenSuppress("AssistantClient", typeof(ClientPipeline), typeof(ApiKeyCredential), typeof(Uri))]
[CodeGenSuppress("CreateAssistantAsync", typeof(AssistantCreationOptions))]
[CodeGenSuppress("CreateAssistant", typeof(AssistantCreationOptions))]
[CodeGenSuppress("ModifyAssistantAsync", typeof(string), typeof(AssistantModificationOptions))]
[CodeGenSuppress("ModifyAssistant", typeof(string), typeof(AssistantModificationOptions))]
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
    protected internal AssistantClient(ClientPipeline pipeline, Uri endpoint, OpenAIClientOptions options)
    {
        _pipeline = pipeline;
        _endpoint = endpoint;
        _messageSubClient = new(_pipeline, _endpoint, options);
        _runSubClient = new(_pipeline, _endpoint, options);
        _threadSubClient = new(_pipeline, _endpoint, options);
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
    public virtual async Task<ClientResult<ListQueryPage<Assistant>>> GetAssistantsAsync(
        int? maxResults = null,
        ListOrder? resultOrder = null,
        string previousId = null,
        string subsequentId = null)
    {
        ClientResult protocolResult
            = await GetAssistantsAsync(maxResults, resultOrder?.ToString(), previousId, subsequentId, options: null).ConfigureAwait(false);
        InternalListAssistantsResponse internalResponse = InternalListAssistantsResponse.FromResponse(protocolResult.GetRawResponse());
        ListQueryPage<Assistant> page = new (
            internalResponse.Data,
            internalResponse.FirstId,
            internalResponse.LastId,
            internalResponse.HasMore);
        return ClientResult.FromValue(page, protocolResult.GetRawResponse());
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
    public virtual ClientResult<ListQueryPage<Assistant>> GetAssistants(
        int? maxResults = null,
        ListOrder? resultOrder = null,
        string previousId = null,
        string subsequentId = null)
    {
        ClientResult protocolResult
            = GetAssistants(maxResults, resultOrder?.ToString(), previousId, subsequentId, options: null);
        InternalListAssistantsResponse internalResponse = InternalListAssistantsResponse.FromResponse(protocolResult.GetRawResponse());
        ListQueryPage<Assistant> page = new (
            internalResponse.Data,
            internalResponse.FirstId,
            internalResponse.LastId,
            internalResponse.HasMore);
        return ClientResult.FromValue(page, protocolResult.GetRawResponse());
    }

    /// <summary>
    /// Deletes an existing <see cref="Assistant"/>. 
    /// </summary>
    /// <param name="assistantId"> The ID of the assistant to delete. </param>
    /// <returns> A value indicating whether the deletion was successful. </returns>
    public virtual async Task<ClientResult<bool>> DeleteAssistantAsync(string assistantId)
    {
        ClientResult protocolResult = await DeleteAssistantAsync(assistantId).ConfigureAwait(false);
        InternalDeleteAssistantResponse internalResponse = InternalDeleteAssistantResponse.FromResponse(protocolResult.GetRawResponse());
        return ClientResult.FromValue(internalResponse.Deleted, protocolResult.GetRawResponse());
    }

    /// <summary>
    /// Deletes an existing <see cref="Assistant"/>. 
    /// </summary>
    /// <param name="assistantId"> The ID of the assistant to delete. </param>
    /// <returns> A value indicating whether the deletion was successful. </returns>
    public virtual ClientResult<bool> DeleteAssistant(string assistantId)
    {
        ClientResult protocolResult = DeleteAssistant(assistantId);
        InternalDeleteAssistantResponse internalResponse = InternalDeleteAssistantResponse.FromResponse(protocolResult.GetRawResponse());
        return ClientResult.FromValue(internalResponse.Deleted, protocolResult.GetRawResponse());
    }

}
