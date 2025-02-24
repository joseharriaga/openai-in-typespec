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
    public int? BillableTrainedTokenCount { get; set; }

    [CodeGenMember("UserProvidedSuffix")]
    public string UserProvidedSuffix { get; }

    [CodeGenMember("CreatedAt")]
    public DateTimeOffset CreatedAt { get; }

    [CodeGenMember("Error")]
    public FineTuningError Error { get; }

    [CodeGenMember("FineTunedModel")]
    public string FineTunedModel { get; }

    [CodeGenMember("FinishedAt")]
    public DateTimeOffset? FinishedAt { get; }

    [CodeGenMember("OrganizationId")]
    public string OrganizationId { get; }

    [CodeGenMember("Seed")]
    public int Seed { get; }

    [CodeGenMember("Method")]
    public FineTuningTrainingMethod Method { get; }

    public override string ToString()
    {
        return $"FineTuningJob<{JobId}, {Status}, {CreatedAt}>";
    }
}