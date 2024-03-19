namespace OpenAI.Assistants;

public partial class StreamingRequiredAction : StreamingUpdate
{
    public RunRequiredAction RequiredAction { get; }

    internal StreamingRequiredAction(RunRequiredAction requiredAction)
    {
        RequiredAction = requiredAction;
    }
}
