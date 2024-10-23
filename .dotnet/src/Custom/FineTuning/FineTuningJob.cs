using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace OpenAI.FineTuning;

[CodeGenModel("FineTuningJob")]
public partial class FineTuningJob
{
    [CodeGenMember("Id")]
    public string JobId { get; }

    [CodeGenMember("Model")]
    public string BaseModel { get; }

    [CodeGenMember("EstimatedFinish")]
    public DateTimeOffset? EstimatedFinishAt { get; }

    [CodeGenMember("ValidationFile")]
    public string ValidationFileId { get; }

    [CodeGenMember("TrainingFile")]
    public string TrainingFileId { get; }

    [CodeGenMember("ResultFiles")]
    public IReadOnlyList<string> ResultFileIds { get; }

    [CodeGenMember("Status")]
    public FineTuningJobStatus Status { get; }

    [CodeGenMember("Object")]
    private string _object { get; }

    [CodeGenMember("Hyperparameters")]
    public FineTuningJobHyperparameters Hyperparameters { get; } = default;

    [CodeGenMember("Integrations")]
    public IReadOnlyList<FineTuningIntegration> Integrations { get; }

    [CodeGenMember("TrainedTokens")]
    public int? BillableTrainedTokens { get; }

    public override string ToString()
    {
        return $"FineTuningJob<{JobId}, {Status}, {CreatedAt}>";
    }
}