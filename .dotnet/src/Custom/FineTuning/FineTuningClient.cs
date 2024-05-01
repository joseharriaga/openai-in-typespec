using OpenAI.Models;
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
}
