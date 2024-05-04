using OpenAI.FineTuning;
using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Net;
using System.Threading.Tasks;

namespace OpenAI.ModelManagement;

/// <summary>
///     The service client for OpenAI model operations.
/// </summary>
public partial class ModelManagementClient
{
    private readonly ClientPipeline _pipeline;
    private readonly Uri _endpoint;
    private readonly OpenAIClientConnector _clientConnector;
    private Internal.ModelsOps Shim => _clientConnector.InternalClient.GetModelsOpsClient();

    /// <inheritdoc cref="OpenAIClient.Pipeline"/>
    public ClientPipeline Pipeline => _pipeline;

    /// <summary>
    /// Initializes a new instance of <see cref="ModelManagementClient"/> that will use an API key when authenticating.
    /// </summary>
    /// <param name="credential"> The API key used to authenticate with the service endpoint. </param>
    /// <param name="options"> Additional options to customize the client. </param>
    /// <exception cref="ArgumentNullException"> The provided <paramref name="credential"/> was null. </exception>
    public ModelManagementClient(ApiKeyCredential credential, OpenAIClientOptions options = null)
        : this(
              OpenAIClient.CreatePipeline(OpenAIClient.GetApiKey(credential, requireExplicitCredential: true), options),
              OpenAIClient.GetEndpoint(options),
              options)
    {
        // Temporary pending codegen integration
        _clientConnector = new(model: null, credential, options);
    }

    /// <summary>
    /// Initializes a new instance of <see cref="ModelManagementClient"/> that will use an API key from the OPENAI_API_KEY
    /// environment variable when authenticating.
    /// </summary>
    /// <remarks>
    /// To provide an explicit credential instead of using the environment variable, use an alternate constructor like
    /// <see cref="FineTuningClient(ApiKeyCredential,OpenAIClientOptions)"/>.
    /// </remarks>
    /// <param name="options"> Additional options to customize the client. </param>
    /// <exception cref="InvalidOperationException"> The OPENAI_API_KEY environment variable was not found. </exception>
    public ModelManagementClient(OpenAIClientOptions options = null)
        : this(
              OpenAIClient.CreatePipeline(OpenAIClient.GetApiKey(), options),
              OpenAIClient.GetEndpoint(options),
              options)
    {
        // Temporary pending codegen integration
        _clientConnector = new(model: null, OpenAIClient.GetApiKey(), options);
    }

    /// <summary> Initializes a new instance of FineTuningClient. </summary>
    /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
    /// <param name="endpoint"> OpenAI Endpoint. </param>
    protected internal ModelManagementClient(ClientPipeline pipeline, Uri endpoint, OpenAIClientOptions options)
    {
        _pipeline = pipeline;
        _endpoint = endpoint;
    }

    public virtual ClientResult<ModelDetails> GetModelInfo(string modelId)
    {
        ClientResult<Internal.Models.Model> internalResult = Shim.Retrieve(modelId);
        return ClientResult.FromValue(new ModelDetails(internalResult.Value), internalResult.GetRawResponse());
    }

    public virtual async Task<ClientResult<ModelDetails>> GetModelInfoAsync(string modelId)
    {
        ClientResult<Internal.Models.Model> internalResult = await Shim.RetrieveAsync(modelId).ConfigureAwait(false);
        return ClientResult.FromValue(new ModelDetails(internalResult.Value), internalResult.GetRawResponse());
    }

    public virtual ClientResult<ModelDetailCollection> GetModels()
    {
        ClientResult<Internal.Models.ListModelsResponse> internalResult = Shim.GetModels();
        ChangeTrackingList<ModelDetails> modelEntries = [];
        foreach (Internal.Models.Model internalModel in internalResult.Value.Data)
        {
            modelEntries.Add(new(internalModel));
        }
        return ClientResult.FromValue(new ModelDetailCollection(modelEntries), internalResult.GetRawResponse());
    }

    public virtual async Task<ClientResult<ModelDetailCollection>> GetModelsAsync()
    {
        ClientResult<Internal.Models.ListModelsResponse> internalResult
            = await Shim.GetModelsAsync().ConfigureAwait(false);
        ChangeTrackingList<ModelDetails> modelEntries = [];
        foreach (Internal.Models.Model internalModel in internalResult.Value.Data)
        {
            modelEntries.Add(new(internalModel));
        }
        return ClientResult.FromValue(new ModelDetailCollection(modelEntries), internalResult.GetRawResponse());
    }

    public virtual ClientResult<bool> DeleteModel(string modelId)
    {
        ClientResult<Internal.Models.DeleteModelResponse> internalResult = Shim.Delete(modelId);
        return ClientResult.FromValue(internalResult.Value.Deleted, internalResult.GetRawResponse());
    }

    public virtual async Task<ClientResult<bool>> DeleteModelAsync(string modelId)
    {
        ClientResult<Internal.Models.DeleteModelResponse> internalResult
            = await Shim.DeleteAsync(modelId).ConfigureAwait(false);
        return ClientResult.FromValue(internalResult.Value.Deleted, internalResult.GetRawResponse());
    }
}
