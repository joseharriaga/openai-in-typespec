namespace OpenAI.Assistants;

using System.ClientModel.Primitives;
using System.Text.Json;

public partial class StreamingMessageCreation
{
    internal static StreamingUpdate DeserializeSseMessageCreation(
        JsonElement sseDataJson,
        ModelReaderWriterOptions options = null)
    {
        Internal.Models.MessageObject internalMessage
            = Internal.Models.MessageObject.DeserializeMessageObject(sseDataJson, options);
        ThreadMessage message = new(internalMessage);
        return new StreamingMessageCreation(message);
    }
}
