using System.Diagnostics.CodeAnalysis;

namespace OpenAI.FineTuning;

[Experimental("OPENAI001")]
public class ListCheckpointsOptions
{
    public string AfterCheckpointId { get; set; }

    public int? PageSize { get; set; }
}
