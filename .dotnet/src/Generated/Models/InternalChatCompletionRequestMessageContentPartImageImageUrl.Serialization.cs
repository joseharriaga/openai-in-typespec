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
    internal partial class InternalChatCompletionRequestMessageContentPartImageImageUrl : IJsonModel<InternalChatCompletionRequestMessageContentPartImageImageUrl>
    {
        internal InternalChatCompletionRequestMessageContentPartImageImageUrl()
        {
        }

        void IJsonModel<InternalChatCompletionRequestMessageContentPartImageImageUrl>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalChatCompletionRequestMessageContentPartImageImageUrl>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalChatCompletionRequestMessageContentPartImageImageUrl)} does not support writing '{format}' format.");
            }
            if (Optional.IsDefined(Detail) && _additionalBinaryDataProperties?.ContainsKey("detail") != true)
            {
                writer.WritePropertyName("detail"u8);
                writer.WriteStringValue(Detail.Value.ToString());
            }
            if (_additionalBinaryDataProperties?.ContainsKey("url") != true)
            {
                writer.WritePropertyName("url"u8);
                writer.WriteStringValue(Url);
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

        InternalChatCompletionRequestMessageContentPartImageImageUrl IJsonModel<InternalChatCompletionRequestMessageContentPartImageImageUrl>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual InternalChatCompletionRequestMessageContentPartImageImageUrl JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalChatCompletionRequestMessageContentPartImageImageUrl>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalChatCompletionRequestMessageContentPartImageImageUrl)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalChatCompletionRequestMessageContentPartImageImageUrl(document.RootElement, options);
        }

        internal static InternalChatCompletionRequestMessageContentPartImageImageUrl DeserializeInternalChatCompletionRequestMessageContentPartImageImageUrl(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            ChatImageDetailLevel? detail = default;
            string url = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("detail"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    detail = new ChatImageDetailLevel(prop.Value.GetString());
                    continue;
                }
                if (prop.NameEquals("url"u8))
                {
                    url = prop.Value.GetString();
                    continue;
                }
                if (true)
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new InternalChatCompletionRequestMessageContentPartImageImageUrl(detail, url, additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<InternalChatCompletionRequestMessageContentPartImageImageUrl>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalChatCompletionRequestMessageContentPartImageImageUrl>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalChatCompletionRequestMessageContentPartImageImageUrl)} does not support writing '{options.Format}' format.");
            }
        }

        InternalChatCompletionRequestMessageContentPartImageImageUrl IPersistableModel<InternalChatCompletionRequestMessageContentPartImageImageUrl>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        protected virtual InternalChatCompletionRequestMessageContentPartImageImageUrl PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalChatCompletionRequestMessageContentPartImageImageUrl>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeInternalChatCompletionRequestMessageContentPartImageImageUrl(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalChatCompletionRequestMessageContentPartImageImageUrl)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalChatCompletionRequestMessageContentPartImageImageUrl>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(InternalChatCompletionRequestMessageContentPartImageImageUrl internalChatCompletionRequestMessageContentPartImageImageUrl)
        {
            if (internalChatCompletionRequestMessageContentPartImageImageUrl == null)
            {
                return null;
            }
            return BinaryContent.Create(internalChatCompletionRequestMessageContentPartImageImageUrl, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator InternalChatCompletionRequestMessageContentPartImageImageUrl(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeInternalChatCompletionRequestMessageContentPartImageImageUrl(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
