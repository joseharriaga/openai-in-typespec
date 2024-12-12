namespace OpenAI.FineTuning;

public class ListCheckpointsOptions
{
    public string AfterCheckpointId { get; set; }

    public int? PageSize { get; set; }
}
