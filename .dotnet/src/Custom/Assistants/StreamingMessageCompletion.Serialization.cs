namespace OpenAI.Assistants;

using System.ClientModel.Primitives;
using System.Text.Json;

public partial class StreamingMessageCompletion : StreamingUpdate
{
    internal static StreamingMessageCompletion DeserializeStreamingMessageCompletion(JsonElement element, ModelReaderWriterOptions options = default)
    {
        return new StreamingMessageCompletion(
            new ThreadMessage(Internal.Models.MessageObject.DeserializeMessageObject(element, options)));
    }
}
