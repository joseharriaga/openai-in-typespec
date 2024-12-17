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
    internal partial class InternalChatCompletionRequestMessageContentPartText : IJsonModel<InternalChatCompletionRequestMessageContentPartText>
    {
        internal InternalChatCompletionRequestMessageContentPartText()
        {
        }

        void IJsonModel<InternalChatCompletionRequestMessageContentPartText>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalChatCompletionRequestMessageContentPartText>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalChatCompletionRequestMessageContentPartText)} does not support writing '{format}' format.");
            }
            if (_additionalBinaryDataProperties?.ContainsKey("type") != true)
            {
                writer.WritePropertyName("type"u8);
                writer.WriteStringValue(Type.ToString());
            }
            if (_additionalBinaryDataProperties?.ContainsKey("text") != true)
            {
                writer.WritePropertyName("text"u8);
                writer.WriteStringValue(Text);
            }
            if (true && _additionalBinaryDataProperties != null)
            {
                foreach (var item in _additionalBinaryDataProperties)
                {
                    if (ModelSerializationExtensions.IsSentinelValue(item.Value))
                    {
                        continue;
                    }
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
        }

        InternalChatCompletionRequestMessageContentPartText IJsonModel<InternalChatCompletionRequestMessageContentPartText>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual InternalChatCompletionRequestMessageContentPartText JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalChatCompletionRequestMessageContentPartText>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalChatCompletionRequestMessageContentPartText)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalChatCompletionRequestMessageContentPartText(document.RootElement, options);
        }

        internal static InternalChatCompletionRequestMessageContentPartText DeserializeInternalChatCompletionRequestMessageContentPartText(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            InternalChatCompletionRequestMessageContentPartTextType @type = default;
            string text = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("type"u8))
                {
                    @type = new InternalChatCompletionRequestMessageContentPartTextType(prop.Value.GetString());
                    continue;
                }
                if (prop.NameEquals("text"u8))
                {
                    text = prop.Value.GetString();
                    continue;
                }
                if (true)
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new InternalChatCompletionRequestMessageContentPartText(@type, text, additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<InternalChatCompletionRequestMessageContentPartText>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalChatCompletionRequestMessageContentPartText>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalChatCompletionRequestMessageContentPartText)} does not support writing '{options.Format}' format.");
            }
        }

        InternalChatCompletionRequestMessageContentPartText IPersistableModel<InternalChatCompletionRequestMessageContentPartText>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        protected virtual InternalChatCompletionRequestMessageContentPartText PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalChatCompletionRequestMessageContentPartText>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeInternalChatCompletionRequestMessageContentPartText(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalChatCompletionRequestMessageContentPartText)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalChatCompletionRequestMessageContentPartText>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(InternalChatCompletionRequestMessageContentPartText internalChatCompletionRequestMessageContentPartText)
        {
            if (internalChatCompletionRequestMessageContentPartText == null)
            {
                return null;
            }
            return BinaryContent.Create(internalChatCompletionRequestMessageContentPartText, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator InternalChatCompletionRequestMessageContentPartText(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeInternalChatCompletionRequestMessageContentPartText(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
