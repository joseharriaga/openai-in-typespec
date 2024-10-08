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
    public partial class AssistantChatMessage : IJsonModel<AssistantChatMessage>
    {
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<AssistantChatMessage>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(AssistantChatMessage)} does not support writing '{format}' format.");
            }
            base.JsonModelWriteCore(writer, options);
            if (Optional.IsDefined(Content))
            {
                if (Content != null)
                {
                    writer.WritePropertyName("content"u8);
#if NET6_0_OR_GREATER
                    writer.WriteRawValue(Content);
#else
                    using (JsonDocument document = JsonDocument.Parse(Content))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
                else
                {
                    writer.WriteNull("content"u8);
                }
            }
            if (Optional.IsDefined(Refusal))
            {
                if (Refusal != null)
                {
                    writer.WritePropertyName("refusal"u8);
                    writer.WriteStringValue(Refusal);
                }
                else
                {
                    writer.WriteNull("refusal"u8);
                }
            }
            if (Optional.IsDefined(ParticipantName))
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(ParticipantName);
            }
            if (Optional.IsCollectionDefined(ToolCalls))
            {
                writer.WritePropertyName("tool_calls"u8);
                writer.WriteStartArray();
                foreach (ChatToolCall item in ToolCalls)
                {
                    writer.WriteObjectValue(item, options);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(FunctionCall))
            {
                if (FunctionCall != null)
                {
                    writer.WritePropertyName("function_call"u8);
                    writer.WriteObjectValue<ChatFunctionCall>(FunctionCall, options);
                }
                else
                {
                    writer.WriteNull("functionCall"u8);
                }
            }
        }

        AssistantChatMessage IJsonModel<AssistantChatMessage>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => (AssistantChatMessage)JsonModelCreateCore(ref reader, options);

        protected override ChatMessage JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<AssistantChatMessage>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(AssistantChatMessage)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeAssistantChatMessage(document.RootElement, options);
        }

        internal static AssistantChatMessage DeserializeAssistantChatMessage(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            BinaryData content = default;
            string refusal = default;
            string participantName = default;
            IList<ChatToolCall> toolCalls = default;
            ChatFunctionCall functionCall = default;
            Chat.ChatMessageRole role = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("content"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        content = null;
                        continue;
                    }
                    content = BinaryData.FromString(prop.Value.GetRawText());
                    continue;
                }
                if (prop.NameEquals("refusal"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        refusal = null;
                        continue;
                    }
                    refusal = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("name"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        participantName = null;
                        continue;
                    }
                    participantName = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("tool_calls"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<ChatToolCall> array = new List<ChatToolCall>();
                    foreach (var item in prop.Value.EnumerateArray())
                    {
                        array.Add(ChatToolCall.DeserializeChatToolCall(item, options));
                    }
                    toolCalls = array;
                    continue;
                }
                if (prop.NameEquals("function_call"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        functionCall = null;
                        continue;
                    }
                    functionCall = ChatFunctionCall.DeserializeChatFunctionCall(prop.Value, options);
                    continue;
                }
                if (prop.NameEquals("role"u8))
                {
                    role = prop.Value.GetInt32().ToChatMessageRole();
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new AssistantChatMessage(
                content,
                refusal,
                participantName,
                toolCalls ?? new ChangeTrackingList<ChatToolCall>(),
                functionCall,
                role,
                additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<AssistantChatMessage>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected override BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<AssistantChatMessage>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(AssistantChatMessage)} does not support writing '{options.Format}' format.");
            }
        }

        AssistantChatMessage IPersistableModel<AssistantChatMessage>.Create(BinaryData data, ModelReaderWriterOptions options) => (AssistantChatMessage)PersistableModelCreateCore(data, options);

        protected override ChatMessage PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<AssistantChatMessage>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeAssistantChatMessage(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(AssistantChatMessage)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<AssistantChatMessage>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(AssistantChatMessage assistantChatMessage)
        {
            return BinaryContent.Create(assistantChatMessage, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator AssistantChatMessage(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeAssistantChatMessage(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
