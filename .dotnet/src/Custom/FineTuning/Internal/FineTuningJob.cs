using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace OpenAI.FineTuning;



[Experimental("OPENAI001")]
[CodeGenModel("FineTuningJob")]
internal partial class InternalFineTuningJob
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
    public FineTuningStatus Status { get; }

    [CodeGenMember("Object")]
    internal string _object { get; }

    [CodeGenMember("Hyperparameters")]
    public FineTuningHyperparameters Hyperparameters { get; } = default;

    [CodeGenMember("Integrations")]
    public IReadOnlyList<FineTuningIntegration> Integrations { get; }

    [CodeGenMember("TrainedTokens")]
    public int BillableTrainedTokenCount { get; set; }

    public override string ToString()
    {
        return $"FineTuningJob<{JobId}, {Status}, {CreatedAt}>";
    }
}