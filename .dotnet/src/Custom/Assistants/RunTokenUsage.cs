namespace OpenAI.Assistants;

[CodeGenModel("RunCompletionUsage")]
public partial class RunTokenUsage
{
    // Customization: renamed from prompt/completion to input/output

    /// <summary> Number of prompt tokens used over the course of the run. </summary>
    [CodeGenMember("PromptTokens")]
    public int InputTokens { get; }

    /// <summary> Number of completion tokens used over the course of the run. </summary>
    [CodeGenMember("CompletionTokens")]
    public int OutputTokens { get; }
}