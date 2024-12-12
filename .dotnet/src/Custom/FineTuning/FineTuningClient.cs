using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;

namespace OpenAI.FineTuning;

// CUSTOM:
// - Renamed.
// - Suppressed constructor that takes endpoint parameter; endpoint is now a property in the options class.
// - Suppressed convenience methods for now.
/// <summary> The service client for OpenAI fine-tuning jobs. </summary>
[Experimental("OPENAI001")]
[CodeGenClient("FineTuning")]
[CodeGenSuppress("FineTuningClient", typeof(ClientPipeline), typeof(ApiKeyCredential), typeof(Uri))]
[CodeGenSuppress("CreateFineTuningJobAsync", typeof(FineTuningOptions))]
[CodeGenSuppress("CreateFineTuningJob", typeof(FineTuningOptions))]
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
    // CUSTOM: Remove virtual keyword.
    /// <summary>
    /// The HTTP pipeline for sending and receiving REST requests and responses.
    /// </summary>
    public ClientPipeline Pipeline => _pipeline;

    // CUSTOM: Added as a convenience.
    /// <summary> Initializes a new instance of <see cref="FineTuningClient">. </summary>
    /// <param name="apiKey"> The API key to authenticate with the service. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="apiKey"/> is null. </exception>
    public FineTuningClient(string apiKey) : this(new ApiKeyCredential(apiKey), new OpenAIClientOptions())
    {
    }

    // CUSTOM:
    // - Used a custom pipeline.
    // - Demoted the endpoint parameter to be a property in the options class.
    /// <summary> Initializes a new instance of <see cref="FineTuningClient">. </summary>
    /// <param name="credential"> The API key to authenticate with the service. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="credential"/> is null. </exception>
    public FineTuningClient(ApiKeyCredential credential) : this(credential, new OpenAIClientOptions())
    {
    }

    /// <summary>
    /// Initializes a new instance of <see cref="FineTuningClient"/> that will use an API key when authenticating.
    /// </summary>
    /// <param name="credential"> The API key used to authenticate with the service endpoint. </param>
    /// <param name="options"> Additional options to customize the client. </param>
    /// <exception cref="ArgumentNullException"> The provided <paramref name="credential"/> was null. </exception>
    public FineTuningClient(ApiKeyCredential credential, OpenAIClientOptions options)
    {
        Argument.AssertNotNull(credential, nameof(credential));
        options ??= new OpenAIClientOptions();

        _pipeline = OpenAIClient.CreatePipeline(credential, options);
        _endpoint = OpenAIClient.GetEndpoint(options);
    }

    // CUSTOM:
    // - Used a custom pipeline.
    // - Demoted the endpoint parameter to be a property in the options class.
    // - Made protected.
    /// <summary> Initializes a new instance of <see cref="FineTuningClient">. </summary>
    /// <param name="pipeline"> The HTTP pipeline to send and receive REST requests and responses. </param>
    /// <param name="options"> The options to configure the client. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="pipeline"/> is null. </exception>
    protected internal FineTuningClient(ClientPipeline pipeline, OpenAIClientOptions options)
    {
        Argument.AssertNotNull(pipeline, nameof(pipeline));
        options ??= new OpenAIClientOptions();

        _pipeline = pipeline;
        _endpoint = OpenAIClient.GetEndpoint(options);
    }

    /// <summary> Creates a job with a training file and base model. </summary>
    /// <param name="baseModel"> The original model to use as a starting base to fine-tune. String such as "gpt-3.5-turbo" </param>
    /// <param name="trainingFileId"> The training file Id that is already uploaded. String should match pattern '^file-[a-zA-Z0-9]{24}$'. </param>
    /// <param name="options"> Additional options (<see cref="FineTuningOptions"/>) to customize the request. </param>
    /// <param name="cancellationToken"> The cancellation token. </param>
    /// <returns>A <see cref="ClientResult{FineTuningJob}"/> containing the newly started fine-tuning job.</returns>
    public virtual FineTuningJob FineTune(
        string baseModel,
        string trainingFileId,
        FineTuningOptions options = default,
        CancellationToken cancellationToken = default
        )
    {
        options ??= new FineTuningOptions();
        options.Model = baseModel;
        options.TrainingFile = trainingFileId;

        return FineTune(options.ToBinaryContent(), false, cancellationToken.ToRequestOptions());
    }

    /// <inheritdoc cref="FineTune(string, string, FineTuningOptions, CancellationToken)"/>
    public virtual async Task<FineTuningJob> FineTuneAsync(
        string baseModel,
        string trainingFileId,
        FineTuningOptions options = default,
        CancellationToken cancellationToken = default
        )
    {

        options ??= new FineTuningOptions();
        options.Model = baseModel;
        options.TrainingFile = trainingFileId;

        return await FineTuneAsync(options.ToBinaryContent(), false, cancellationToken.ToRequestOptions()).ConfigureAwait(false);
    }
    /// <summary>
    /// Get FineTuningJob for a previously started fine-tuning job.
    ///
    /// [Learn more about fine-tuning](/docs/guides/fine-tuning)
    /// </summary>
    /// <param name="JobId"> The ID of the fine-tuning job. </param>
    /// <param name="cancellationToken"> The cancellation token. </param>
    public FineTuningJob GetJob(string JobId, CancellationToken cancellationToken = default)
    {
        return FineTuningJob.Rehydrate(this, JobId, cancellationToken.ToRequestOptions());
    }

    /// <summary>
    /// Get FineTuningJob for a previously started fine-tuning job.
    ///
    /// [Learn more about fine-tuning](/docs/guides/fine-tuning)
    /// </summary>
    /// <param name="JobId"> The ID of the fine-tuning job. </param>
    /// <param name="cancellationToken"> The cancellation token. </param>
    public async Task<FineTuningJob> GetJobAsync(string JobId, CancellationToken cancellationToken = default)
    {
        return await FineTuningJob.RehydrateAsync(this, JobId, cancellationToken.ToRequestOptions()).ConfigureAwait(false);
    }

    /// <summary>
    /// Retrieves a list of fine-tuning jobs.
    /// </summary>
    /// <param name="options"> Additional options: <see cref="ListJobsOptions"/> to customize the request. </param>
    /// <param name="cancellationToken"> The cancellation token. </param>
    /// <returns> A <see cref="CollectionResult{FineTuningJob}"/> containing the list of fine-tuning jobs. </returns>
    public virtual CollectionResult<FineTuningJob> ListJobs(ListJobsOptions options = default, CancellationToken cancellationToken = default)
    {
        options ??= new ListJobsOptions();
        return ListJobs(options.AfterJobId, options.PageSize, cancellationToken.ToRequestOptions()) as CollectionResult<FineTuningJob>;
    }

    /// <inheritdoc cref="ListJobs(ListJobsOptions, CancellationToken)"/>
    /// <returns> A <see cref="AsyncCollectionResult{FineTuningJob}"/> containing the list of fine-tuning jobs. </returns>
    public virtual AsyncCollectionResult<FineTuningJob> ListJobsAsync(
    ListJobsOptions options = default,
    CancellationToken cancellationToken = default)
    {
        options ??= new ListJobsOptions();
        AsyncCollectionResult jobs = ListJobsAsync(options.AfterJobId, options.PageSize, cancellationToken.ToRequestOptions());
        return (AsyncCollectionResult<FineTuningJob>)jobs;
    }

    internal virtual FineTuningJob CreateJobFromResponse(PipelineResponse response)
    {
        return new FineTuningJob(_pipeline, _endpoint, response);
    }

    internal virtual IEnumerable<FineTuningJob> CreateJobsFromPageResponse(PipelineResponse response)
    {
        InternalListPaginatedFineTuningJobsResponse jobs = ModelReaderWriter.Read<InternalListPaginatedFineTuningJobsResponse>(response.Content)!;
        return jobs.Data.Select(job => new FineTuningJob(_pipeline, _endpoint, job, response));
    }
}
