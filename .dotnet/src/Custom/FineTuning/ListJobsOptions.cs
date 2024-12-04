namespace OpenAI.FineTuning;

public class ListJobsOptions
{
    public string AfterJobId { get; set; }

    public int? PageSize { get; set; }

    // TODO: Implement status as a filter for the list of jobs
    //public FineTuningStatus Status { get; set; }
}
