// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using OpenAI;

namespace OpenAI.RealtimeConversation
{
    public partial class ConversationFunctionTool : IJsonModel<ConversationFunctionTool>
    {
        void IJsonModel<ConversationFunctionTool>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ConversationFunctionTool>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ConversationFunctionTool)} does not support writing '{format}' format.");
            }
            base.JsonModelWriteCore(writer, options);
            if (_additionalBinaryDataProperties?.ContainsKey("name") != true)
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(_name);
            }
            if (Optional.IsDefined(_description) && _additionalBinaryDataProperties?.ContainsKey("description") != true)
            {
                writer.WritePropertyName("description"u8);
                writer.WriteStringValue(_description);
            }
            if (Optional.IsDefined(_parameters) && _additionalBinaryDataProperties?.ContainsKey("parameters") != true)
            {
                writer.WritePropertyName("parameters"u8);
#if NET6_0_OR_GREATER
                writer.WriteRawValue(_parameters);
#else
                using (JsonDocument document = JsonDocument.Parse(_parameters))
                {
                    JsonSerializer.Serialize(writer, document.RootElement);
                }
#endif
            }
        }

        ConversationFunctionTool IJsonModel<ConversationFunctionTool>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => (ConversationFunctionTool)JsonModelCreateCore(ref reader, options);

        protected override ConversationTool JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ConversationFunctionTool>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ConversationFunctionTool)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeConversationFunctionTool(document.RootElement, options);
        }

        internal static ConversationFunctionTool DeserializeConversationFunctionTool(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string name = default;
            string description = default;
            BinaryData parameters = default;
            ConversationToolKind kind = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("name"u8))
                {
                    name = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("description"u8))
                {
                    description = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("parameters"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    parameters = BinaryData.FromString(prop.Value.GetRawText());
                    continue;
                }
                if (prop.NameEquals("type"u8))
                {
                    kind = new ConversationToolKind(prop.Value.GetString());
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new ConversationFunctionTool(name, description, parameters, kind, additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<ConversationFunctionTool>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected override BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ConversationFunctionTool>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(ConversationFunctionTool)} does not support writing '{options.Format}' format.");
            }
        }

        ConversationFunctionTool IPersistableModel<ConversationFunctionTool>.Create(BinaryData data, ModelReaderWriterOptions options) => (ConversationFunctionTool)PersistableModelCreateCore(data, options);

        protected override ConversationTool PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ConversationFunctionTool>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeConversationFunctionTool(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(ConversationFunctionTool)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<ConversationFunctionTool>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(ConversationFunctionTool conversationFunctionTool)
        {
            return BinaryContent.Create(conversationFunctionTool, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator ConversationFunctionTool(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeConversationFunctionTool(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
