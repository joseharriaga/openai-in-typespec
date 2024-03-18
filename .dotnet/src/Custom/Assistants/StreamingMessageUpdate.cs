namespace OpenAI.Assistants;

using System.Collections.Generic;
using System.Text.Json;

public partial class StreamingMessageUpdate : StreamingRunUpdate
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
