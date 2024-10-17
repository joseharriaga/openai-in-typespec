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
    internal partial class InternalBatchRequestOutput : IJsonModel<InternalBatchRequestOutput>
    {
        void IJsonModel<InternalBatchRequestOutput>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalBatchRequestOutput>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalBatchRequestOutput)} does not support writing '{format}' format.");
            }
            if (options.Format != "W" && Optional.IsDefined(Id))
            {
                writer.WritePropertyName("id"u8);
                writer.WriteStringValue(Id);
            }
            if (Optional.IsDefined(CustomId))
            {
                writer.WritePropertyName("custom_id"u8);
                writer.WriteStringValue(CustomId);
            }
            if (Optional.IsDefined(Response))
            {
                if (Response != null)
                {
                    writer.WritePropertyName("response"u8);
                    writer.WriteObjectValue(Response, options);
                }
                else
                {
                    writer.WriteNull("response"u8);
                }
            }
            if (Optional.IsDefined(Error))
            {
                if (Error != null)
                {
                    writer.WritePropertyName("error"u8);
                    writer.WriteObjectValue(Error, options);
                }
                else
                {
                    writer.WriteNull("error"u8);
                }
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

        InternalBatchRequestOutput IJsonModel<InternalBatchRequestOutput>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual InternalBatchRequestOutput JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalBatchRequestOutput>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalBatchRequestOutput)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalBatchRequestOutput(document.RootElement, options);
        }

        internal static InternalBatchRequestOutput DeserializeInternalBatchRequestOutput(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string id = default;
            string customId = default;
            InternalBatchRequestOutputResponse response = default;
            InternalBatchRequestOutputError error = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("id"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        id = null;
                        continue;
                    }
                    id = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("custom_id"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        customId = null;
                        continue;
                    }
                    customId = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("response"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        response = null;
                        continue;
                    }
                    response = InternalBatchRequestOutputResponse.DeserializeInternalBatchRequestOutputResponse(prop.Value, options);
                    continue;
                }
                if (prop.NameEquals("error"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        error = null;
                        continue;
                    }
                    error = InternalBatchRequestOutputError.DeserializeInternalBatchRequestOutputError(prop.Value, options);
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new InternalBatchRequestOutput(id, customId, response, error, additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<InternalBatchRequestOutput>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalBatchRequestOutput>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalBatchRequestOutput)} does not support writing '{options.Format}' format.");
            }
        }

        InternalBatchRequestOutput IPersistableModel<InternalBatchRequestOutput>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        protected virtual InternalBatchRequestOutput PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalBatchRequestOutput>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeInternalBatchRequestOutput(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalBatchRequestOutput)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalBatchRequestOutput>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(InternalBatchRequestOutput internalBatchRequestOutput)
        {
            return BinaryContent.Create(internalBatchRequestOutput, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator InternalBatchRequestOutput(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeInternalBatchRequestOutput(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
