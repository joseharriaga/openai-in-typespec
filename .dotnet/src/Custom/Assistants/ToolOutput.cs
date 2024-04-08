using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace OpenAI.Assistants;

public partial class ToolOutput
{
    public required string Id { get; init; }
    public string Output { get; init; }

    public ToolOutput()
    { }

    [SetsRequiredMembers]
    public ToolOutput(string toolCallId, string output = null)
    {
        Id = toolCallId;
        Output = output;
    }
}
