// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using OpenAI;

namespace OpenAI.Moderations
{
    internal partial class InternalCreateModerationRequestInputImageUrl : IJsonModel<InternalCreateModerationRequestInputImageUrl>
    {
        internal InternalCreateModerationRequestInputImageUrl()
        {
        }

        void IJsonModel<InternalCreateModerationRequestInputImageUrl>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalCreateModerationRequestInputImageUrl>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalCreateModerationRequestInputImageUrl)} does not support writing '{format}' format.");
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

        InternalCreateModerationRequestInputImageUrl IJsonModel<InternalCreateModerationRequestInputImageUrl>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual InternalCreateModerationRequestInputImageUrl JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalCreateModerationRequestInputImageUrl>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalCreateModerationRequestInputImageUrl)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalCreateModerationRequestInputImageUrl(document.RootElement, options);
        }

        internal static InternalCreateModerationRequestInputImageUrl DeserializeInternalCreateModerationRequestInputImageUrl(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string url = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
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
            return new InternalCreateModerationRequestInputImageUrl(url, additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<InternalCreateModerationRequestInputImageUrl>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalCreateModerationRequestInputImageUrl>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalCreateModerationRequestInputImageUrl)} does not support writing '{options.Format}' format.");
            }
        }

        InternalCreateModerationRequestInputImageUrl IPersistableModel<InternalCreateModerationRequestInputImageUrl>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        protected virtual InternalCreateModerationRequestInputImageUrl PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalCreateModerationRequestInputImageUrl>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeInternalCreateModerationRequestInputImageUrl(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalCreateModerationRequestInputImageUrl)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalCreateModerationRequestInputImageUrl>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(InternalCreateModerationRequestInputImageUrl internalCreateModerationRequestInputImageUrl)
        {
            if (internalCreateModerationRequestInputImageUrl == null)
            {
                return null;
            }
            return BinaryContent.Create(internalCreateModerationRequestInputImageUrl, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator InternalCreateModerationRequestInputImageUrl(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeInternalCreateModerationRequestInputImageUrl(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
