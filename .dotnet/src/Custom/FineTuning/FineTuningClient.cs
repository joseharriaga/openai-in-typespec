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
}
