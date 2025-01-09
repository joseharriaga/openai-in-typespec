using System;

namespace OpenAI.FineTuning;

[CodeGenModel("FineTuningJobCheckpoint")]
public partial class FineTuningCheckpoint
{
    [CodeGenMember("Id")]
    public string CheckpointId { get; }

    [CodeGenMember("CreatedAt")]
    public DateTimeOffset CreatedAt { get; }

    [CodeGenMember("FineTunedModelCheckpoint")]
    public string FineTunedModelCheckpointId { get; }

    [CodeGenMember("StepNumber")]
    public int StepNumber { get; }

    [CodeGenMember("FineTuningJobCheckpointMetrics")]
    public FineTuningCheckpointMetrics Metrics { get; }

    [CodeGenMember("FineTuningJobId")]  
    public string JobId { get; }

    [CodeGenMember("Object")]
    private string _object { get; }

    public override string ToString()
    {
        return $"FineTuningJobCheckpoint<{CheckpointId}, {StepNumber}, {FineTunedModelCheckpointId}>";
    }

}
