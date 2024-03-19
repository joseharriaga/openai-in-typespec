namespace OpenAI.Assistants;

public partial class StreamingRequiredAction : StreamingRunUpdate
{
    public RunRequiredAction RequiredAction { get; }

    internal StreamingRequiredAction(RunRequiredAction requiredAction)
    {
        RequiredAction = requiredAction;
    }
}
