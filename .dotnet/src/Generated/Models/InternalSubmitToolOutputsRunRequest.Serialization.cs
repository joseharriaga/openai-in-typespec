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
    internal partial class InternalSubmitToolOutputsRunRequest : IJsonModel<InternalSubmitToolOutputsRunRequest>
    {
        internal InternalSubmitToolOutputsRunRequest()
        {
        }

        void IJsonModel<InternalSubmitToolOutputsRunRequest>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalSubmitToolOutputsRunRequest>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalSubmitToolOutputsRunRequest)} does not support writing '{format}' format.");
            }
            if (_additionalBinaryDataProperties?.ContainsKey("tool_outputs") != true)
            {
                writer.WritePropertyName("tool_outputs"u8);
                writer.WriteStartArray();
                foreach (ToolOutput item in ToolOutputs)
                {
                    writer.WriteObjectValue(item, options);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(Stream) && _additionalBinaryDataProperties?.ContainsKey("stream") != true)
            {
                if (Stream != null)
                {
                    writer.WritePropertyName("stream"u8);
                    writer.WriteBooleanValue(Stream.Value);
                }
                else
                {
                    writer.WriteNull("stream"u8);
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

        InternalSubmitToolOutputsRunRequest IJsonModel<InternalSubmitToolOutputsRunRequest>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual InternalSubmitToolOutputsRunRequest JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalSubmitToolOutputsRunRequest>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalSubmitToolOutputsRunRequest)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalSubmitToolOutputsRunRequest(document.RootElement, options);
        }

        internal static InternalSubmitToolOutputsRunRequest DeserializeInternalSubmitToolOutputsRunRequest(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IList<ToolOutput> toolOutputs = default;
            bool? stream = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("tool_outputs"u8))
                {
                    List<ToolOutput> array = new List<ToolOutput>();
                    foreach (var item in prop.Value.EnumerateArray())
                    {
                        array.Add(ToolOutput.DeserializeToolOutput(item, options));
                    }
                    toolOutputs = array;
                    continue;
                }
                if (prop.NameEquals("stream"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        stream = null;
                        continue;
                    }
                    stream = prop.Value.GetBoolean();
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new InternalSubmitToolOutputsRunRequest(toolOutputs, stream, additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<InternalSubmitToolOutputsRunRequest>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalSubmitToolOutputsRunRequest>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalSubmitToolOutputsRunRequest)} does not support writing '{options.Format}' format.");
            }
        }

        InternalSubmitToolOutputsRunRequest IPersistableModel<InternalSubmitToolOutputsRunRequest>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        protected virtual InternalSubmitToolOutputsRunRequest PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalSubmitToolOutputsRunRequest>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeInternalSubmitToolOutputsRunRequest(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalSubmitToolOutputsRunRequest)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalSubmitToolOutputsRunRequest>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(InternalSubmitToolOutputsRunRequest internalSubmitToolOutputsRunRequest)
        {
            if (internalSubmitToolOutputsRunRequest == null)
            {
                return null;
            }
            return BinaryContent.Create(internalSubmitToolOutputsRunRequest, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator InternalSubmitToolOutputsRunRequest(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeInternalSubmitToolOutputsRunRequest(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
