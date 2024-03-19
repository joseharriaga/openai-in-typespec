namespace OpenAI.Assistants;

public partial class StreamingMessageUpdate : StreamingUpdate
{
    public MessageContent ContentUpdate { get; }
    public int? ContentUpdateIndex { get; }

    internal StreamingMessageUpdate(
        MessageContent contentUpdate,
        int? contentIndex)
    {
        ContentUpdate = contentUpdate;
        ContentUpdateIndex = contentIndex;
    }
}
