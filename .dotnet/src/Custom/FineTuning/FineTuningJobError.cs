namespace OpenAI.FineTuning;

[CodeGenModel("FineTuningJobError")]
public partial class JobError
{

    [CodeGenMember("Param")]
    public string InvalidParameter { get; }

}
