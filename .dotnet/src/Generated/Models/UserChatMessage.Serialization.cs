// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using OpenAI;

namespace OpenAI.Chat
{
    public partial class UserChatMessage : IJsonModel<UserChatMessage>
    {
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<UserChatMessage>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(UserChatMessage)} does not support writing '{format}' format.");
            }
            base.JsonModelWriteCore(writer, options);
            if (Optional.IsDefined(ParticipantName) && _additionalBinaryDataProperties?.ContainsKey("name") != true)
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(ParticipantName);
            }
        }

        UserChatMessage IJsonModel<UserChatMessage>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => (UserChatMessage)JsonModelCreateCore(ref reader, options);

        protected override ChatMessage JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<UserChatMessage>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(UserChatMessage)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeUserChatMessage(document.RootElement, options);
        }

        internal static UserChatMessage DeserializeUserChatMessage(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Chat.ChatMessageRole role = default;
            ChatMessageContent content = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            string participantName = default;
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("role"u8))
                {
                    role = prop.Value.GetString().ToChatMessageRole();
                    continue;
                }
                if (prop.NameEquals("content"u8))
                {
                    DeserializeContentValue(prop, ref content);
                    continue;
                }
                if (prop.NameEquals("name"u8))
                {
                    participantName = prop.Value.GetString();
                    continue;
                }
                if (true)
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new UserChatMessage(role, content, additionalBinaryDataProperties, participantName);
        }

        BinaryData IPersistableModel<UserChatMessage>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected override BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<UserChatMessage>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(UserChatMessage)} does not support writing '{options.Format}' format.");
            }
        }

        UserChatMessage IPersistableModel<UserChatMessage>.Create(BinaryData data, ModelReaderWriterOptions options) => (UserChatMessage)PersistableModelCreateCore(data, options);

        protected override ChatMessage PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<UserChatMessage>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeUserChatMessage(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(UserChatMessage)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<UserChatMessage>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(UserChatMessage userChatMessage)
        {
            if (userChatMessage == null)
            {
                return null;
            }
            return BinaryContent.Create(userChatMessage, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator UserChatMessage(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeUserChatMessage(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
