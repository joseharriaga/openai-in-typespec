namespace OpenAI.Assistants;

[CodeGenModel("ThreadObject")]
public partial class AssistantThread
{
    private readonly object Object;

    /// <summary>
    /// The set of resources that are made available to the assistant's tools on this thread.
    /// The resources are specific to the type of tool.
    /// For example, the `code_interpreter` tool requires a list of file IDs, while the `file_search` tool requires a list of vector store IDs.
    /// </summary>
    public ToolResources ToolResources { get; }
}
