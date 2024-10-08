using System;

namespace OpenAI.FineTuning;

[CodeGenModel("FineTuningJobCheckpoint")]
public partial class FineTuningJobCheckpoint
{
    [CodeGenMember("Id")]
    public string Id { get; }

    [CodeGenMember("CreatedAt")]
    public DateTimeOffset CreatedAt { get; }

    [CodeGenMember("FineTunedModelCheckpoint")]
    public string FineTunedModelCheckpointId { get; }

    [CodeGenMember("StepNumber")]
    public int StepNumber { get; }

    [CodeGenMember("FineTuningJobCheckpointMetrics")]
    public CheckpointMetrics Metrics { get; }

    [CodeGenMember("FineTuningJobId")]
    public string JobId { get; }

    [CodeGenMember("Object")]
    private string _object { get; }

    // toString
    public override string ToString()
    {
        return $"FineTuningJobCheckpoint<{Id}, {StepNumber}, {FineTunedModelCheckpointId}>";
    }

}
