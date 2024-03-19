namespace OpenAI.Assistants;

public partial class StreamingMessageCreation : StreamingUpdate
{
    public ThreadMessage Message { get; }

    internal StreamingMessageCreation(ThreadMessage message)
    {
        Message = message;
    }
}
