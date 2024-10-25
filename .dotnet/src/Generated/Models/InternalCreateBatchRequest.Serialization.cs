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
    internal partial class InternalCreateBatchRequest : IJsonModel<InternalCreateBatchRequest>
    {
        internal InternalCreateBatchRequest()
        {
        }

        void IJsonModel<InternalCreateBatchRequest>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalCreateBatchRequest>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalCreateBatchRequest)} does not support writing '{format}' format.");
            }
            if (_additionalBinaryDataProperties?.ContainsKey("input_file_id") != true)
            {
                writer.WritePropertyName("input_file_id"u8);
                writer.WriteStringValue(InputFileId);
            }
            if (_additionalBinaryDataProperties?.ContainsKey("endpoint") != true)
            {
                writer.WritePropertyName("endpoint"u8);
                writer.WriteStringValue(Endpoint.ToString());
            }
            if (_additionalBinaryDataProperties?.ContainsKey("completion_window") != true)
            {
                writer.WritePropertyName("completion_window"u8);
                writer.WriteStringValue(CompletionWindow.ToString());
            }
            if (Optional.IsCollectionDefined(Metadata) && _additionalBinaryDataProperties?.ContainsKey("metadata") != true)
            {
                if (Metadata != null)
                {
                    writer.WritePropertyName("metadata"u8);
                    writer.WriteStartObject();
                    foreach (var item in Metadata)
                    {
                        writer.WritePropertyName(item.Key);
                        if (item.Value == null)
                        {
                            writer.WriteNullValue();
                            continue;
                        }
                        writer.WriteStringValue(item.Value);
                    }
                    writer.WriteEndObject();
                }
                else
                {
                    writer.WriteNull("metadata"u8);
                }
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

        InternalCreateBatchRequest IJsonModel<InternalCreateBatchRequest>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual InternalCreateBatchRequest JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalCreateBatchRequest>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalCreateBatchRequest)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalCreateBatchRequest(document.RootElement, options);
        }

        internal static InternalCreateBatchRequest DeserializeInternalCreateBatchRequest(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string inputFileId = default;
            InternalCreateBatchRequestEndpoint endpoint = default;
            InternalBatchCompletionTimeframe completionWindow = default;
            IDictionary<string, string> metadata = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("input_file_id"u8))
                {
                    inputFileId = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("endpoint"u8))
                {
                    endpoint = new InternalCreateBatchRequestEndpoint(prop.Value.GetString());
                    continue;
                }
                if (prop.NameEquals("completion_window"u8))
                {
                    completionWindow = new InternalBatchCompletionTimeframe(prop.Value.GetString());
                    continue;
                }
                if (prop.NameEquals("metadata"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    Dictionary<string, string> dictionary = new Dictionary<string, string>();
                    foreach (var prop0 in prop.Value.EnumerateObject())
                    {
                        if (prop0.Value.ValueKind == JsonValueKind.Null)
                        {
                            dictionary.Add(prop0.Name, null);
                        }
                        else
                        {
                            dictionary.Add(prop0.Name, prop0.Value.GetString());
                        }
                    }
                    metadata = dictionary;
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new InternalCreateBatchRequest(inputFileId, endpoint, completionWindow, metadata ?? new ChangeTrackingDictionary<string, string>(), additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<InternalCreateBatchRequest>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalCreateBatchRequest>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalCreateBatchRequest)} does not support writing '{options.Format}' format.");
            }
        }

        InternalCreateBatchRequest IPersistableModel<InternalCreateBatchRequest>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        protected virtual InternalCreateBatchRequest PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalCreateBatchRequest>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeInternalCreateBatchRequest(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalCreateBatchRequest)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalCreateBatchRequest>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(InternalCreateBatchRequest internalCreateBatchRequest)
        {
            return BinaryContent.Create(internalCreateBatchRequest, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator InternalCreateBatchRequest(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeInternalCreateBatchRequest(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
