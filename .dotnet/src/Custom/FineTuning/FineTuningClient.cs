using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Threading;
using System.Threading.Tasks;

namespace OpenAI.FineTuning;

/// <summary>
/// The service client for OpenAI fine-tuning operations.
/// </summary>
[CodeGenClient("FineTuning")]
[CodeGenSuppress("CreateFineTuningJobAsync", typeof(InternalCreateFineTuningJobRequest))]
[CodeGenSuppress("CreateFineTuningJob", typeof(InternalCreateFineTuningJobRequest))]
[CodeGenSuppress("GetPaginatedFineTuningJobsAsync", typeof(string), typeof(int?))]
[CodeGenSuppress("GetPaginatedFineTuningJobs", typeof(string), typeof(int?))]
[CodeGenSuppress("RetrieveFineTuningJobAsync", typeof(string))]
[CodeGenSuppress("RetrieveFineTuningJob", typeof(string))]
[CodeGenSuppress("CancelFineTuningJobAsync", typeof(string))]
[CodeGenSuppress("CancelFineTuningJob", typeof(string))]
[CodeGenSuppress("GetFineTuningEventsAsync", typeof(string), typeof(string), typeof(int?))]
[CodeGenSuppress("GetFineTuningEvents", typeof(string), typeof(string), typeof(int?))]
[CodeGenSuppress("GetFineTuningJobCheckpointsAsync", typeof(string), typeof(string), typeof(int?))]
[CodeGenSuppress("GetFineTuningJobCheckpoints", typeof(string), typeof(string), typeof(int?))]
public partial class FineTuningClient
{
    // Customization: documented constructors, apply protected visibility

    /// <summary>
    /// Initializes a new instance of <see cref="FineTuningClient"/> that will use an API key when authenticating.
    /// </summary>
    /// <param name="credential"> The API key used to authenticate with the service endpoint. </param>
    /// <param name="options"> Additional options to customize the client. </param>
    /// <exception cref="ArgumentNullException"> The provided <paramref name="credential"/> was null. </exception>
    public FineTuningClient(ApiKeyCredential credential, OpenAIClientOptions options = null)
        : this(
              OpenAIClient.CreatePipeline(OpenAIClient.GetApiKey(credential, requireExplicitCredential: true), options),
              OpenAIClient.GetEndpoint(options),
              options)
    { }

    /// <summary>
    /// Initializes a new instance of <see cref="FineTuningClient"/> that will use an API key from the OPENAI_API_KEY
    /// environment variable when authenticating.
    /// </summary>
    /// <remarks>
    /// To provide an explicit credential instead of using the environment variable, use an alternate constructor like
    /// <see cref="FineTuningClient(ApiKeyCredential,OpenAIClientOptions)"/>.
    /// </remarks>
    /// <param name="options"> Additional options to customize the client. </param>
    /// <exception cref="InvalidOperationException"> The OPENAI_API_KEY environment variable was not found. </exception>
    public FineTuningClient(OpenAIClientOptions options = null)
        : this(
              OpenAIClient.CreatePipeline(OpenAIClient.GetApiKey(), options),
              OpenAIClient.GetEndpoint(options),
              options)
    {}

    /// <summary> Initializes a new instance of FineTuningClient. </summary>
    /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
    /// <param name="endpoint"> OpenAI Endpoint. </param>
    protected internal FineTuningClient(ClientPipeline pipeline, Uri endpoint, OpenAIClientOptions options)
    {
        _pipeline = pipeline;
        _endpoint = endpoint;
    }

    /// <summary> Creates a job with a training file and model. </summary>
    /// <param name="model"> The model name to fine-tune. String such as "gpt-3.5-turbo" </param>
    /// <param name="trainingFile"> The training file name that is already uploaded. String should match pattern '^file-[a-zA-Z0-9]{24}$'  </param>
    /// <param name="options"> Additional options (<see cref="RequestOptions"/>) to customize the request. </param>
    public ClientResult<FineTuningJob> CreateJob(string model, string trainingFile, HyperparameterOptions hyperparameters = default, RequestOptions options = default)
    {
        var request = new InternalCreateFineTuningJobRequest(model, trainingFile);
        request.Hyperparameters = hyperparameters;
        var content = request.ToBinaryContent();
        ClientResult result = CreateJob(content, options);
        return ClientResult.FromValue(FineTuningJob.FromResponse(result.GetRawResponse()), result.GetRawResponse());
    }

    /// <summary> Async version of create job</summary>
    /// <param name="model"> The model name to fine-tune. String such as "gpt-3.5-turbo" </param>
    /// <param name="trainingFile"> The training file name that is already uploaded. String should match pattern '^file-[a-zA-Z0-9]{24}$'  </param>
    /// <param name="options"> Additional options (<see cref="RequestOptions"/>) to customize the request. </param>
    public async Task<ClientResult<FineTuningJob>> CreateJobAsync(string model, string trainingFile, RequestOptions options = default)
    {
        var request = new InternalCreateFineTuningJobRequest(model, trainingFile);
        var content = request.ToBinaryContent();
        ClientResult result = await CreateJobAsync(content, options);
        return ClientResult.FromValue(FineTuningJob.FromResponse(result.GetRawResponse()), result.GetRawResponse());
    }

    /// <summary>
    /// Cancels a fine-tuning job with the specified job ID.
    /// </summary>
    /// <param name="jobId">The ID of the job to cancel.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="ClientResult{FineTuningJob}"/> containing the canceled fine-tuning job.</returns>
    public ClientResult<FineTuningJob> CancelJob(string jobId, CancellationToken cancellationToken = default)
    {
        ClientResult result = CancelJob(jobId, cancellationToken.ToRequestOptions());
        return ClientResult.FromValue(FineTuningJob.FromResponse(result.GetRawResponse()), result.GetRawResponse());
    }

    /// <summary> Async version of cancel job</summary>
    /// <param name="jobId"> The job ID to cancel. </param>
    /// <param name="cancellationToken"> The cancellation token. </param>
    /// <returns> A <see cref="Task{T}"/> of <see cref="ClientResult{FineTuningJob}"/> containing the canceled fine-tuning job. </returns>
    public async Task<ClientResult<FineTuningJob>> CancelJobAsync(string jobId, CancellationToken cancellationToken = default)
    {
        ClientResult result = await CancelJobAsync(jobId, cancellationToken.ToRequestOptions());
        return ClientResult.FromValue(FineTuningJob.FromResponse(result.GetRawResponse()), result.GetRawResponse());
    }
}
