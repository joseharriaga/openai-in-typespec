namespace OpenAI.Assistants;

[CodeGenModel("ThreadObject")]
public partial class AssistantThread
{
    private readonly object Object;

    public AssistantToolResources ToolResources { get; set; }
     
}
