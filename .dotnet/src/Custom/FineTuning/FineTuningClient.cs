using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Threading.Tasks;

namespace OpenAI.FineTuning;

/// <summary>
///     The service client for OpenAI fine-tuning operations.
/// </summary>
public partial class FineTuningClient
{
    private readonly OpenAIClientConnector _clientConnector;
    private Internal.FineTuning FineTuningShim => _clientConnector.InternalClient.GetFineTuningClient();

    /// <summary>
    /// Initializes a new instance of <see cref="FineTuningClient"/>, used for fine-tuning operation requests. 
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
    /// <param name="endpoint">The connection endpoint to use.</param>
    /// <param name="credential">The API key used to authenticate with the service endpoint.</param>
    /// <param name="options">Additional options to customize the client.</param>
    public FineTuningClient(Uri endpoint, ApiKeyCredential credential, OpenAIClientOptions options = null)
    {
        _clientConnector = new("none", endpoint, credential, options);
    }

    /// <summary>
    /// Initializes a new instance of <see cref="FineTuningClient"/>, used for fine-tuning operation requests. 
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
    /// <param name="endpoint">The connection endpoint to use.</param>
    /// <param name="options">Additional options to customize the client.</param>
    public FineTuningClient(Uri endpoint, OpenAIClientOptions options = null)
        : this(endpoint, credential: null, options)
    { }

    /// <summary>
    /// Initializes a new instance of <see cref="FineTuningClient"/>, used for fine-tuning operation requests. 
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
    /// <param name="credential">The API key used to authenticate with the service endpoint.</param>
    /// <param name="options">Additional options to customize the client.</param>
    public FineTuningClient(ApiKeyCredential credential, OpenAIClientOptions options = null)
        : this(endpoint: null, credential, options)
    { }

    /// <summary>
    /// Initializes a new instance of <see cref="FineTuningClient"/>, used for fine-tuning operation requests. 
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
    /// <param name="options">Additional options to customize the client.</param>
    public FineTuningClient(OpenAIClientOptions options = null)
        : this(endpoint: null, credential: null, options)
    { }

    /// <inheritdoc cref="Internal.FineTuning.CreateFineTuningJob(BinaryContent, RequestOptions)"/>
    public virtual ClientResult CreateFineTuningJob(BinaryContent content, RequestOptions options = null)
        => FineTuningShim.CreateFineTuningJob(content, options);

    /// <inheritdoc cref="Internal.FineTuning.CreateFineTuningJobAsync(BinaryContent, RequestOptions)"/>
    public virtual async Task<ClientResult> CreateFineTuningJobAsync(BinaryContent content, RequestOptions options = null)
        => await FineTuningShim.CreateFineTuningJobAsync(content, options).ConfigureAwait(false);

    /// <inheritdoc cref="Internal.FineTuning.RetrieveFineTuningJob(string, RequestOptions)"/>
    public virtual ClientResult GetFineTuningJob(string jobId, RequestOptions options)
        => FineTuningShim.RetrieveFineTuningJob(jobId, options);

    /// <inheritdoc cref="Internal.FineTuning.RetrieveFineTuningJobAsync(string, RequestOptions)"/>
    public virtual async Task<ClientResult> GetFineTuningJobAsync(string jobId, RequestOptions options)
        => await FineTuningShim.RetrieveFineTuningJobAsync(jobId, options).ConfigureAwait(false);

    /// <inheritdoc cref="Internal.FineTuning.GetPaginatedFineTuningJobs(string, int?, RequestOptions)"/>
    public virtual ClientResult GetFineTuningJobs(string previousJobId, int? maxResults, RequestOptions options)
        => FineTuningShim.GetPaginatedFineTuningJobs(previousJobId, maxResults, options);

    /// <inheritdoc cref="Internal.FineTuning.GetPaginatedFineTuningJobsAsync(string, int?, RequestOptions)"/>
    public virtual async Task<ClientResult> GetFineTuningJobsAsync(string previousJobId, int? maxResults, RequestOptions options)
        => await FineTuningShim.GetPaginatedFineTuningJobsAsync(previousJobId, maxResults, options).ConfigureAwait(false);

    /// <inheritdoc cref="Internal.FineTuning.CancelFineTuningJob(string, RequestOptions)"/>
    public virtual ClientResult CancelFineTuningJob(string jobId, RequestOptions options)
        => FineTuningShim.CancelFineTuningJob(jobId, options);

    /// <inheritdoc cref="Internal.FineTuning.CancelFineTuningJobAsync(string, RequestOptions)"/>
    public virtual async Task<ClientResult> CancelFineTuningJobAsync(string jobId, RequestOptions options)
        => await FineTuningShim.CancelFineTuningJobAsync(jobId, options).ConfigureAwait(false);

    /// <inheritdoc cref="Internal.FineTuning.GetFineTuningEvents(string, string, int?, RequestOptions)"/>
    public virtual ClientResult GetFineTuningJobEvents(string jobId, string previousJobId, int? maxResults, RequestOptions options)
        => FineTuningShim.GetFineTuningEvents(jobId, previousJobId, maxResults, options);

    /// <inheritdoc cref="Internal.FineTuning.GetFineTuningEventsAsync(string, string, int?, RequestOptions)"/>
    public virtual async Task<ClientResult> GetFineTuningJobEventsAsync(string jobId, string previousJobId, int? maxResults, RequestOptions options)
        => await FineTuningShim.GetFineTuningEventsAsync(jobId, previousJobId, maxResults, options).ConfigureAwait(false);
}
