namespace OpenAI.FineTuning;

[CodeGenModel("FineTuningJobError")]
public partial class FineTuningError
{
    [CodeGenMember("Param")]
    public string InvalidParameter { get; }
}
