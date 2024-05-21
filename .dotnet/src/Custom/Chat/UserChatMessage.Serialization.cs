using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Chat;

[CodeGenSuppress("global::System.ClientModel.Primitives.IJsonModel<OpenAI.Chat.UserChatMessage>.Write", typeof(Utf8JsonWriter), typeof(ModelReaderWriterOptions))]
public partial class UserChatMessage : IJsonModel<UserChatMessage>
{
    void IJsonModel<UserChatMessage>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        var format = options.Format == "W" ? ((IPersistableModel<UserChatMessage>)this).GetFormatFromOptions(options) : options.Format;
        if (format != "J")
        {
            throw new FormatException($"The model {nameof(UserChatMessage)} does not support writing '{format}' format.");
        }

        writer.WriteStartObject();
        if (Optional.IsDefined(ParticipantName))
        {
            writer.WritePropertyName("name"u8);
            writer.WriteStringValue(ParticipantName);
        }
        writer.WritePropertyName("role"u8);
        writer.WriteStringValue(Role);
        if (Optional.IsCollectionDefined(Content))
        {
            writer.WritePropertyName("content"u8);
            if (Content.Count == 1 && !string.IsNullOrEmpty(Content[0].Text))
            {
                writer.WriteStringValue(Content[0].Text);
            }
            else
            {
                writer.WriteStartArray();
                foreach (var item in Content)
                {
                    writer.WriteObjectValue(item, options);
                }
                writer.WriteEndArray();
            }
        }
        if (true && _serializedAdditionalRawData != null)
        {
            foreach (var item in _serializedAdditionalRawData)
            {
                writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
                writer.WriteRawValue(item.Value);
#else
                    using (JsonDocument document = JsonDocument.Parse(item.Value))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
            }
        }
        writer.WriteEndObject();
    }

    internal static UserChatMessage DeserializeUserChatMessage(JsonElement element, ModelReaderWriterOptions options = null)
    {
        options ??= ModelSerializationExtensions.WireOptions;

        if (element.ValueKind == JsonValueKind.Null)
        {
            return null;
        }
        string name = default;
        string role = default;
        IList<ChatMessageContentPart> content = default;
        IDictionary<string, BinaryData> serializedAdditionalRawData = default;
        Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
        foreach (var property in element.EnumerateObject())
        {
            if (property.NameEquals("name"u8))
            {
                name = property.Value.GetString();
                continue;
            }
            if (property.NameEquals("role"u8))
            {
                role = property.Value.GetString();
                continue;
            }
            if (property.NameEquals("content"u8))
            {
                if (property.Value.ValueKind == JsonValueKind.String)
                {
                    List<ChatMessageContentPart> array = new List<ChatMessageContentPart>();
                    array.Add(ChatMessageContentPart.CreateTextMessageContentPart(property.Value.GetString()));
                    continue;
                }
                else
                {
                    List<ChatMessageContentPart> array = new List<ChatMessageContentPart>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(ChatMessageContentPart.DeserializeChatMessageContentPart(item, options));
                    }
                    content = array;
                    continue;
                }
            }
            if (true)
            {
                rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
            }
        }
        serializedAdditionalRawData = rawDataDictionary;
        return new UserChatMessage(role, content ?? new ChangeTrackingList<ChatMessageContentPart>(), serializedAdditionalRawData, name);
    }
}
