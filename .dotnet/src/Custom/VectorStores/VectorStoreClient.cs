using System;
using System.ClientModel;
using System.ClientModel.Primitives;

namespace OpenAI.VectorStores;

/// <summary>
/// The service client for OpenAI vector store operations.
/// </summary>
[CodeGenClient("VectorStores")]
[CodeGenSuppress("GetVectorStoresAsync", typeof(int?), typeof(ListOrder?), typeof(string), typeof(string))]
[CodeGenSuppress("GetVectorStores", typeof(int?), typeof(ListOrder?), typeof(string), typeof(string))]
[CodeGenSuppress("CreateVectorStoreAsync", typeof(InternalCreateVectorStoreRequest))]
[CodeGenSuppress("CreateVectorStore", typeof(InternalCreateVectorStoreRequest))]
[CodeGenSuppress("GetVectorStoreAsync", typeof(string))]
[CodeGenSuppress("GetVectorStore", typeof(string))]
[CodeGenSuppress("ModifyVectorStoreAsync", typeof(string), typeof(InternalUpdateVectorStoreRequest))]
[CodeGenSuppress("ModifyVectorStore", typeof(string), typeof(InternalUpdateVectorStoreRequest))]
[CodeGenSuppress("DeleteVectorStoreAsync", typeof(string))]
[CodeGenSuppress("DeleteVectorStore", typeof(string))]
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
public partial class VectorStoreClient
{
    /// <summary>
    /// Initializes a new instance of <see cref="VectorStoreClient"/> that will use an API key when authenticating.
    /// </summary>
    /// <param name="model"> The model name to use for moderation operations. </param>
    /// <param name="credential"> The API key used to authenticate with the service endpoint. </param>
    /// <param name="options"> Additional options to customize the client. </param>
    /// <exception cref="ArgumentNullException"> The provided <paramref name="credential"/> was null. </exception>
    public VectorStoreClient(string model, ApiKeyCredential credential, OpenAIClientOptions options = null)
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
    /// <see cref="VectorStoreClient(string, ApiKeyCredential,OpenAIClientOptions)"/>.
    /// </remarks>
    /// <param name="model"> The model name to use for moderation operations. </param>
    /// <param name="options"> Additional options to customize the client. </param>
    /// <exception cref="InvalidOperationException"> The OPENAI_API_KEY environment variable was not found. </exception>
    public VectorStoreClient(string model, OpenAIClientOptions options = null)
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
}
