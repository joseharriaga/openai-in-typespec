using OpenAI.Assistants;
using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using static OpenAI.InternalListHelpers;

namespace OpenAI.VectorStores;

/// <summary>
/// The service client for OpenAI vector store operations.
/// </summary>
[CodeGenClient("VectorStores")]
[CodeGenSuppress("GetVectorStoresAsync", typeof(int?), typeof(ListOrder?), typeof(string), typeof(string))]
[CodeGenSuppress("GetVectorStores", typeof(int?), typeof(ListOrder?), typeof(string), typeof(string))]
[CodeGenSuppress("GetVectorStoreFilesAsync", typeof(string), typeof(int?), typeof(ListOrder?), typeof(string), typeof(string), typeof(VectorStoreFileStatusFilter?))]
[CodeGenSuppress("GetVectorStoreFiles", typeof(string), typeof(int?), typeof(ListOrder?), typeof(string), typeof(string), typeof(VectorStoreFileStatusFilter?))]
[CodeGenSuppress("CreateVectorStoreFileAsync", typeof(string), typeof(InternalCreateVectorStoreFileRequest))]
[CodeGenSuppress("CreateVectorStoreFile", typeof(string), typeof(InternalCreateVectorStoreFileRequest))]
[CodeGenSuppress("GetVectorStoreFileAsync", typeof(string), typeof(string))]
[CodeGenSuppress("GetVectorStoreFile", typeof(string), typeof(string))]
[CodeGenSuppress("DeleteVectorStoreFileAsync", typeof(string), typeof(string))]
[CodeGenSuppress("DeleteVectorStoreFile", typeof(string), typeof(string))]
[CodeGenSuppress("CreateVectorStoreFileBatchAsync", typeof(string), typeof(InternalCreateVectorStoreFileBatchRequest))]
[CodeGenSuppress("CreateVectorStoreFileBatch", typeof(string), typeof(InternalCreateVectorStoreFileBatchRequest))]
[CodeGenSuppress("GetVectorStoreFileBatchAsync", typeof(string), typeof(string))]
[CodeGenSuppress("GetVectorStoreFileBatch", typeof(string), typeof(string))]
[CodeGenSuppress("CancelVectorStoreFileBatchAsync", typeof(string), typeof(string))]
[CodeGenSuppress("CancelVectorStoreFileBatch", typeof(string), typeof(string))]
[CodeGenSuppress("GetFilesInVectorStoreBatchesAsync", typeof(string), typeof(string), typeof(int?), typeof(ListOrder?), typeof(string), typeof(string), typeof(VectorStoreFileStatusFilter?))]
[CodeGenSuppress("GetFilesInVectorStoreBatches", typeof(string), typeof(string), typeof(int?), typeof(ListOrder?), typeof(string), typeof(string), typeof(VectorStoreFileStatusFilter?))]
[Experimental("OPENAI001")]
public partial class VectorStoreClient
{
    /// <summary>
    /// Initializes a new instance of <see cref="VectorStoreClient"/> that will use an API key when authenticating.
    /// </summary>
    /// <param name="credential"> The API key used to authenticate with the service endpoint. </param>
    /// <param name="options"> Additional options to customize the client. </param>
    /// <exception cref="ArgumentNullException"> The provided <paramref name="credential"/> was null. </exception>
    public VectorStoreClient(ApiKeyCredential credential, OpenAIClientOptions options = null)
        : this(
              OpenAIClient.CreatePipeline(OpenAIClient.GetApiKey(credential, requireExplicitCredential: true), options),
              OpenAIClient.GetEndpoint(options),
              options)
    {}

    /// <summary>
    /// Initializes a new instance of <see cref="VectorStoreClient"/> that will use an API key from the OPENAI_API_KEY
    /// environment variable when authenticating.
    /// </summary>
    /// <remarks>
    /// To provide an explicit credential instead of using the environment variable, use an alternate constructor like
    /// <see cref="VectorStoreClient(ApiKeyCredential,OpenAIClientOptions)"/>.
    /// </remarks>
    /// <param name="options"> Additional options to customize the client. </param>
    /// <exception cref="InvalidOperationException"> The OPENAI_API_KEY environment variable was not found. </exception>
    public VectorStoreClient(OpenAIClientOptions options = null)
        : this(
              OpenAIClient.CreatePipeline(OpenAIClient.GetApiKey(), options),
              OpenAIClient.GetEndpoint(options),
              options)
    {}

    /// <summary> Initializes a new instance of VectorStoreClient. </summary>
    /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
    /// <param name="endpoint"> OpenAI Endpoint. </param>
    protected internal VectorStoreClient(ClientPipeline pipeline, Uri endpoint, OpenAIClientOptions options)
    {
        _pipeline = pipeline;
        _endpoint = endpoint;
    }

    /// <summary> Creates a vector store. </summary>
    /// <param name="vectorStore"> The <see cref="VectorStoreCreationOptions"/> to use. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="vectorStore"/> is null. </exception>
    /// <remarks> Create vector store. </remarks>
    public virtual async Task<ClientResult<VectorStore>> CreateVectorStoreAsync(VectorStoreCreationOptions vectorStore = null)
    {
        using BinaryContent content = vectorStore?.ToBinaryContent();
        ClientResult result = await CreateVectorStoreAsync(content, null).ConfigureAwait(false);
        return ClientResult.FromValue(VectorStore.FromResponse(result.GetRawResponse()), result.GetRawResponse());
    }

    /// <summary> Creates a vector store. </summary>
    /// <param name="vectorStore"> The <see cref="VectorStoreCreationOptions"/> to use. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="vectorStore"/> is null. </exception>
    /// <remarks> Create vector store. </remarks>
    public virtual ClientResult<VectorStore> CreateVectorStore(VectorStoreCreationOptions vectorStore = null)
    {
        using BinaryContent content = vectorStore?.ToBinaryContent();
        ClientResult result = CreateVectorStore(content, null);
        return ClientResult.FromValue(VectorStore.FromResponse(result.GetRawResponse()), result.GetRawResponse());
    }

    /// <summary>
    /// Deletes a vector store.
    /// </summary>
    /// <param name="vectorStoreId"> The ID of the vector store to delete. </param>
    /// <returns> A value indicating whether the deletion operation was successful. </returns>
    public virtual async Task<ClientResult<bool>> DeleteVectorStoreAsync(string vectorStoreId)
    {
        Argument.AssertNotNullOrEmpty(vectorStoreId, nameof(vectorStoreId));

        ClientResult protocolResult = await DeleteVectorStoreAsync(vectorStoreId, null).ConfigureAwait(false);
        PipelineResponse rawProtocolResponse = protocolResult?.GetRawResponse();
        InternalDeleteVectorStoreResponse internalResponse = InternalDeleteVectorStoreResponse.FromResponse(rawProtocolResponse);
        return ClientResult.FromValue(internalResponse.Deleted, rawProtocolResponse);
    }

    /// <summary>
    /// Deletes a vector store.
    /// </summary>
    /// <param name="vectorStoreId"> The ID of the vector store to delete. </param>
    /// <returns> A value indicating whether the deletion operation was successful. </returns>
    public virtual ClientResult<bool> DeleteVectorStore(string vectorStoreId)
    {
        Argument.AssertNotNullOrEmpty(vectorStoreId, nameof(vectorStoreId));

        ClientResult protocolResult = DeleteVectorStore(vectorStoreId, null);
        PipelineResponse rawProtocolResponse = protocolResult?.GetRawResponse();
        InternalDeleteVectorStoreResponse internalResponse = InternalDeleteVectorStoreResponse.FromResponse(rawProtocolResponse);
        return ClientResult.FromValue(internalResponse.Deleted, rawProtocolResponse);
    }

    public virtual AsyncPageableCollection<VectorStore> GetVectorStoresAsync(ListOrder? resultOrder = null)
    {
        return PageableResultHelpers.Create(
            (pageSize) => GetFirstPageAsync<VectorStore, InternalListVectorStoresResponse>(GetVectorStoresAsync, resultOrder, pageSize),
            (continuation, pageSize) => GetNextPageAsync<VectorStore, InternalListVectorStoresResponse>(GetVectorStoresAsync, resultOrder, continuation, pageSize));
    }

    public virtual PageableCollection<VectorStore> GetVectorStores(ListOrder? resultOrder = null)
    {
        return PageableResultHelpers.Create(
            (pageSize) => GetFirstPage<VectorStore, InternalListVectorStoresResponse>(GetVectorStores, resultOrder, pageSize),
            (continuation, pageSize) => GetNextPage<VectorStore, InternalListVectorStoresResponse>(GetVectorStores, resultOrder, continuation, pageSize));
    }

    public virtual async Task<ClientResult<VectorStoreFileAssociation>> AddFileToVectorStoreAsync(string vectorStoreId, string fileId)
    {
        InternalCreateVectorStoreFileRequest internalRequest = new(fileId);
        ClientResult protocolResult = await CreateVectorStoreFileAsync(vectorStoreId, internalRequest.ToBinaryContent(), null).ConfigureAwait(false);
        PipelineResponse protocolResponse = protocolResult?.GetRawResponse();
        VectorStoreFileAssociation fileAssociation = VectorStoreFileAssociation.FromResponse(protocolResponse);
        return ClientResult.FromValue(fileAssociation, protocolResponse);
    }

    public virtual ClientResult<VectorStoreFileAssociation> AddFileToVectorStore(string vectorStoreId, string fileId)
    {
        InternalCreateVectorStoreFileRequest internalRequest = new(fileId);
        ClientResult protocolResult = CreateVectorStoreFile(vectorStoreId, internalRequest.ToBinaryContent(), null);
        PipelineResponse protocolResponse = protocolResult?.GetRawResponse();
        VectorStoreFileAssociation fileAssociation = VectorStoreFileAssociation.FromResponse(protocolResponse);
        return ClientResult.FromValue(fileAssociation, protocolResponse);
    }

    //public virtual AsyncPageableCollection<VectorStoreFileAssociation> GetVectorStoreFileAssociationsAsync(string vectorStoreId, ListOrder? resultOrder = null)
    //{
    //    return PageableResultHelpers.Create(
    //        (pageSize) => GetFirstPageAsync<VectorStoreFileAssociation, InternalListVectorStoreFilesResponse>(GetVectorStoreFilesAsync, vectorStoreId, resultOrder, pageSize),
    //        (continuation, pageSize) => GetNextPageAsync<VectorStoreFileAssociation, InternalListVectorStoreFilesResponse>(GetVectorStoreFilesAsync, vectorStoreId, resultOrder, continuation, pageSize));
    //}

    //public virtual PageableCollection<VectorStoreFileAssociation> GetVectorStoreFileAssociations(string vectorStoreId, ListOrder? resultOrder = null)
    //{
    //    return PageableResultHelpers.Create(
    //        (pageSize) => GetFirstPage<VectorStoreFileAssociation, InternalListVectorStoreFilesResponse>(GetVectorStoreFiles, vectorStoreId, resultOrder, pageSize),
    //        (continuation, pageSize) => GetNextPage<VectorStoreFileAssociation, InternalListVectorStoreFilesResponse>(GetVectorStoreFiles, vectorStoreId, resultOrder, continuation, pageSize));
    //}
}
