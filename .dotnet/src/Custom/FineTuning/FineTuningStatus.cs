namespace OpenAI.FineTuning;

[CodeGenModel("FineTuningJobStatus")]
public readonly partial struct FineTuningStatus
{
    public bool InProgress =>
        _value == FineTuningStatus.ValidatingFiles ||
        _value == FineTuningStatus.Queued ||
        _value == FineTuningStatus.Running;
}
