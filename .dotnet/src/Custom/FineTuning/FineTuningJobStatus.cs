namespace OpenAI.FineTuning;

[CodeGenModel("FineTuningJobStatus")]
public readonly partial struct FineTuningJobStatus
{
    public bool InProgress() =>
        _value == FineTuningJobStatus.ValidatingFiles ||
        _value == FineTuningJobStatus.Queued ||
        _value == FineTuningJobStatus.Running;
}
