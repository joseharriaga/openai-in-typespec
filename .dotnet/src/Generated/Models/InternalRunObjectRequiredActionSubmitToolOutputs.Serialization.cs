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
    internal partial class InternalRunObjectRequiredActionSubmitToolOutputs : IJsonModel<InternalRunObjectRequiredActionSubmitToolOutputs>
    {
        void IJsonModel<InternalRunObjectRequiredActionSubmitToolOutputs>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRunObjectRequiredActionSubmitToolOutputs>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalRunObjectRequiredActionSubmitToolOutputs)} does not support writing '{format}' format.");
            }
            if (_additionalBinaryDataProperties?.ContainsKey("tool_calls") != true)
            {
                writer.WritePropertyName("tool_calls"u8);
                writer.WriteStartArray();
                foreach (InternalRequiredFunctionToolCall item in ToolCalls)
                {
                    writer.WriteObjectValue(item, options);
                }
                writer.WriteEndArray();
            }
            if (_additionalBinaryDataProperties != null)
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

        InternalRunObjectRequiredActionSubmitToolOutputs IJsonModel<InternalRunObjectRequiredActionSubmitToolOutputs>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual InternalRunObjectRequiredActionSubmitToolOutputs JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRunObjectRequiredActionSubmitToolOutputs>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalRunObjectRequiredActionSubmitToolOutputs)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalRunObjectRequiredActionSubmitToolOutputs(document.RootElement, options);
        }

        internal static InternalRunObjectRequiredActionSubmitToolOutputs DeserializeInternalRunObjectRequiredActionSubmitToolOutputs(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IReadOnlyList<InternalRequiredFunctionToolCall> toolCalls = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("tool_calls"u8))
                {
                    List<InternalRequiredFunctionToolCall> array = new List<InternalRequiredFunctionToolCall>();
                    foreach (var item in prop.Value.EnumerateArray())
                    {
                        array.Add(InternalRequiredFunctionToolCall.DeserializeInternalRequiredFunctionToolCall(item, options));
                    }
                    toolCalls = array;
                    continue;
                }
                additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
            }
            return new InternalRunObjectRequiredActionSubmitToolOutputs(toolCalls, additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<InternalRunObjectRequiredActionSubmitToolOutputs>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRunObjectRequiredActionSubmitToolOutputs>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalRunObjectRequiredActionSubmitToolOutputs)} does not support writing '{options.Format}' format.");
            }
        }

        InternalRunObjectRequiredActionSubmitToolOutputs IPersistableModel<InternalRunObjectRequiredActionSubmitToolOutputs>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        protected virtual InternalRunObjectRequiredActionSubmitToolOutputs PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRunObjectRequiredActionSubmitToolOutputs>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeInternalRunObjectRequiredActionSubmitToolOutputs(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalRunObjectRequiredActionSubmitToolOutputs)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalRunObjectRequiredActionSubmitToolOutputs>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(InternalRunObjectRequiredActionSubmitToolOutputs internalRunObjectRequiredActionSubmitToolOutputs)
        {
            if (internalRunObjectRequiredActionSubmitToolOutputs == null)
            {
                return null;
            }
            return BinaryContent.Create(internalRunObjectRequiredActionSubmitToolOutputs, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator InternalRunObjectRequiredActionSubmitToolOutputs(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeInternalRunObjectRequiredActionSubmitToolOutputs(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
