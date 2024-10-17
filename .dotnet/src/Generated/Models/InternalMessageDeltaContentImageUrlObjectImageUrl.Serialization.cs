// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using OpenAI;

namespace OpenAI.Assistants
{
    internal partial class InternalMessageDeltaContentImageUrlObjectImageUrl : IJsonModel<InternalMessageDeltaContentImageUrlObjectImageUrl>
    {
        void IJsonModel<InternalMessageDeltaContentImageUrlObjectImageUrl>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalMessageDeltaContentImageUrlObjectImageUrl>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalMessageDeltaContentImageUrlObjectImageUrl)} does not support writing '{format}' format.");
            }
            if (Optional.IsDefined(Url))
            {
                writer.WritePropertyName("url"u8);
                writer.WriteStringValue(Url.AbsoluteUri);
            }
            if (Optional.IsDefined(Detail))
            {
                writer.WritePropertyName("detail"u8);
                writer.WriteStringValue(Detail.ToSerialString());
            }
            if (options.Format != "W" && _additionalBinaryDataProperties != null)
            {
                foreach (var item in _additionalBinaryDataProperties)
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
        }

        InternalMessageDeltaContentImageUrlObjectImageUrl IJsonModel<InternalMessageDeltaContentImageUrlObjectImageUrl>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual InternalMessageDeltaContentImageUrlObjectImageUrl JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalMessageDeltaContentImageUrlObjectImageUrl>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalMessageDeltaContentImageUrlObjectImageUrl)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalMessageDeltaContentImageUrlObjectImageUrl(document.RootElement, options);
        }

        internal static InternalMessageDeltaContentImageUrlObjectImageUrl DeserializeInternalMessageDeltaContentImageUrlObjectImageUrl(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Uri url = default;
            string detail = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("url"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        url = null;
                        continue;
                    }
                    url = new Uri(prop.Value.GetString());
                    continue;
                }
                if (prop.NameEquals("detail"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        detail = null;
                        continue;
                    }
                    detail = prop.Value.GetString().ToString();
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new InternalMessageDeltaContentImageUrlObjectImageUrl(url, detail, additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<InternalMessageDeltaContentImageUrlObjectImageUrl>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalMessageDeltaContentImageUrlObjectImageUrl>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalMessageDeltaContentImageUrlObjectImageUrl)} does not support writing '{options.Format}' format.");
            }
        }

        InternalMessageDeltaContentImageUrlObjectImageUrl IPersistableModel<InternalMessageDeltaContentImageUrlObjectImageUrl>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        protected virtual InternalMessageDeltaContentImageUrlObjectImageUrl PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalMessageDeltaContentImageUrlObjectImageUrl>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeInternalMessageDeltaContentImageUrlObjectImageUrl(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalMessageDeltaContentImageUrlObjectImageUrl)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalMessageDeltaContentImageUrlObjectImageUrl>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(InternalMessageDeltaContentImageUrlObjectImageUrl internalMessageDeltaContentImageUrlObjectImageUrl)
        {
            return BinaryContent.Create(internalMessageDeltaContentImageUrlObjectImageUrl, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator InternalMessageDeltaContentImageUrlObjectImageUrl(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeInternalMessageDeltaContentImageUrlObjectImageUrl(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
