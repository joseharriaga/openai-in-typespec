namespace OpenAI.Assistants;

public partial class StreamingMessageCompletion : StreamingUpdate
{
    public ThreadMessage Message { get; }

    internal StreamingMessageCompletion(ThreadMessage message)
    {
        Message = message;
    }
}
