// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using OpenAI;

namespace OpenAI.Batch
{
    internal partial class InternalBatchRequestInput : IJsonModel<InternalBatchRequestInput>
    {
        void IJsonModel<InternalBatchRequestInput>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalBatchRequestInput>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalBatchRequestInput)} does not support writing '{format}' format.");
            }
            if (Optional.IsDefined(CustomId) && _additionalBinaryDataProperties?.ContainsKey("custom_id") != true)
            {
                writer.WritePropertyName("custom_id"u8);
                writer.WriteStringValue(CustomId);
            }
            if (Optional.IsDefined(Method) && _additionalBinaryDataProperties?.ContainsKey("method") != true)
            {
                writer.WritePropertyName("method"u8);
                writer.WriteStringValue(Method.Value.ToString());
            }
            if (Optional.IsDefined(Url) && _additionalBinaryDataProperties?.ContainsKey("url") != true)
            {
                writer.WritePropertyName("url"u8);
                writer.WriteStringValue(Url.AbsoluteUri);
            }
            if (options.Format != "W" && _additionalBinaryDataProperties != null)
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

        InternalBatchRequestInput IJsonModel<InternalBatchRequestInput>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual InternalBatchRequestInput JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalBatchRequestInput>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalBatchRequestInput)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalBatchRequestInput(document.RootElement, options);
        }

        internal static InternalBatchRequestInput DeserializeInternalBatchRequestInput(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string customId = default;
            InternalBatchRequestInputMethod? @method = default;
            Uri url = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("custom_id"u8))
                {
                    customId = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("method"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    @method = new InternalBatchRequestInputMethod(prop.Value.GetString());
                    continue;
                }
                if (prop.NameEquals("url"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    url = new Uri(prop.Value.GetString());
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new InternalBatchRequestInput(customId, @method, url, additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<InternalBatchRequestInput>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalBatchRequestInput>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalBatchRequestInput)} does not support writing '{options.Format}' format.");
            }
        }

        InternalBatchRequestInput IPersistableModel<InternalBatchRequestInput>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        protected virtual InternalBatchRequestInput PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalBatchRequestInput>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeInternalBatchRequestInput(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalBatchRequestInput)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalBatchRequestInput>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(InternalBatchRequestInput internalBatchRequestInput)
        {
            if (internalBatchRequestInput == null)
            {
                return null;
            }
            return BinaryContent.Create(internalBatchRequestInput, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator InternalBatchRequestInput(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeInternalBatchRequestInput(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
