using System.ClientModel.Primitives;
using System.ClientModel;
using System;
using System.Threading;

namespace OpenAI.FineTuning;

/// <summary>
/// The service client for OpenAI fine-tuning operations.
/// </summary>
[CodeGenClient("FineTuning")]
[CodeGenSuppress("CreateFineTuningJobAsync", typeof(CreateFineTuningJobRequest))]
[CodeGenSuppress("CreateFineTuningJob", typeof(CreateFineTuningJobRequest))]
[CodeGenSuppress("GetPaginatedFineTuningJobsAsync", typeof(string), typeof(int?))]
[CodeGenSuppress("GetPaginatedFineTuningJobs", typeof(string), typeof(int?))]
[CodeGenSuppress("RetrieveFineTuningJobAsync", typeof(string))]
[CodeGenSuppress("RetrieveFineTuningJob", typeof(string))]
[CodeGenSuppress("CancelFineTuningJobAsync", typeof(string))]
[CodeGenSuppress("CancelFineTuningJob", typeof(string))]
[CodeGenSuppress("GetFineTuningEventsAsync", typeof(string), typeof(string), typeof(int?))]
[CodeGenSuppress("GetFineTuningEvents", typeof(string), typeof(string), typeof(int?))]
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
