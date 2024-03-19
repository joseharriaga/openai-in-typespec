namespace OpenAI.Assistants;

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

public partial class StreamingMessageUpdate
{
    internal static IEnumerable<StreamingUpdate> DeserializeSseMessageUpdates(
        JsonElement sseDataJson,
        ModelReaderWriterOptions options = default)
    {
        List<StreamingUpdate> results = [];
        if (sseDataJson.ValueKind == JsonValueKind.Null)
        {
            return results;
        }
        string id = null;
        List<(int Index, MessageContent Content)> indexedContentItems = [];
        foreach (JsonProperty property in sseDataJson.EnumerateObject())
        {
            if (property.NameEquals("id"u8))
            {
                id = property.Value.GetString();
                continue;
            }
            if (property.NameEquals("delta"u8))
            {
                foreach (JsonProperty messageDeltaProperty in property.Value.EnumerateObject())
                {
                    if (messageDeltaProperty.NameEquals("content"u8))
                    {
                        foreach (JsonElement contentItemElement in messageDeltaProperty.Value.EnumerateArray())
                        {
                            MessageContent contentItem = MessageContent.DeserializeMessageContent(contentItemElement);
                            foreach (JsonProperty contentItemProperty in contentItemElement.EnumerateObject())
                            {
                                if (contentItemProperty.NameEquals("index"u8))
                                {
                                    indexedContentItems.Add((contentItemProperty.Value.GetInt32(), contentItem));
                                    continue;
                                }
                            }
                        }
                        continue;
                    }
                }
                continue;
            }
        }
        foreach((int index, MessageContent contentItem) in indexedContentItems)
        {
            results.Add(new StreamingMessageUpdate(contentItem, index));
        }
        return results;
    }
}
