using System.ClientModel.Primitives;
using System.ClientModel;
using System;
using System.Threading;

namespace OpenAI.FineTuning;

/// <summary>
/// The service client for OpenAI fine-tuning operations.
/// </summary>
[CodeGenClient("FineTuning")]
[CodeGenSuppress("CreateFineTuningJobAsync", typeof(CreateFineTuningJobRequest), typeof(CancellationToken))]
[CodeGenSuppress("CreateFineTuningJob", typeof(CreateFineTuningJobRequest), typeof(CancellationToken))]
[CodeGenSuppress("GetPaginatedFineTuningJobsAsync", typeof(string), typeof(int?), typeof(CancellationToken))]
[CodeGenSuppress("GetPaginatedFineTuningJobs", typeof(string), typeof(int?), typeof(CancellationToken))]
[CodeGenSuppress("RetrieveFineTuningJobAsync", typeof(string), typeof(CancellationToken))]
[CodeGenSuppress("RetrieveFineTuningJob", typeof(string), typeof(CancellationToken))]
[CodeGenSuppress("CancelFineTuningJobAsync", typeof(string), typeof(CancellationToken))]
[CodeGenSuppress("CancelFineTuningJob", typeof(string), typeof(CancellationToken))]
[CodeGenSuppress("GetFineTuningEventsAsync", typeof(string), typeof(string), typeof(int?), typeof(CancellationToken))]
[CodeGenSuppress("GetFineTuningEvents", typeof(string), typeof(string), typeof(int?), typeof(CancellationToken))]
public partial class FineTuningClient
{
    // Customization: apply protected(/+internal) visibility

    protected readonly Uri _endpoint;

    /// <summary> Initializes a new instance of FineTuningClient. </summary>
    /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
    /// <param name="credential"> The key credential to copy. </param>
    /// <param name="endpoint"> OpenAI Endpoint. </param>
    protected internal FineTuningClient(ClientPipeline pipeline, ApiKeyCredential credential, Uri endpoint)
    {
        _pipeline = pipeline;
        _keyCredential = credential;
        _endpoint = endpoint;
    }
}
