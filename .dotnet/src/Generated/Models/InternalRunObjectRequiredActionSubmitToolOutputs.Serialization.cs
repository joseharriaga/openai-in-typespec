// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using OpenAI.Assistants;

namespace OpenAI.Internal.Models
{
    internal partial class InternalRunObjectRequiredActionSubmitToolOutputs : IJsonModel<InternalRunObjectRequiredActionSubmitToolOutputs>
    {
        void IJsonModel<InternalRunObjectRequiredActionSubmitToolOutputs>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalRunObjectRequiredActionSubmitToolOutputs>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalRunObjectRequiredActionSubmitToolOutputs)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("tool_calls"u8);
            writer.WriteStartArray();
            foreach (var item in ToolCalls)
            {
                writer.WriteObjectValue(item, options);
            }
            writer.WriteEndArray();
            if (options.Format != "W" && _serializedAdditionalRawData != null)
            {
                foreach (var item in _serializedAdditionalRawData)
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
            writer.WriteEndObject();
        }

        InternalRunObjectRequiredActionSubmitToolOutputs IJsonModel<InternalRunObjectRequiredActionSubmitToolOutputs>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalRunObjectRequiredActionSubmitToolOutputs>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalRunObjectRequiredActionSubmitToolOutputs)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalRunObjectRequiredActionSubmitToolOutputs(document.RootElement, options);
        }

        internal static InternalRunObjectRequiredActionSubmitToolOutputs DeserializeInternalRunObjectRequiredActionSubmitToolOutputs(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IReadOnlyList<RequiredFunctionToolCall> toolCalls = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("tool_calls"u8))
                {
                    List<RequiredFunctionToolCall> array = new List<RequiredFunctionToolCall>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(RequiredFunctionToolCall.DeserializeRequiredFunctionToolCall(item, options));
                    }
                    toolCalls = array;
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new InternalRunObjectRequiredActionSubmitToolOutputs(toolCalls, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<InternalRunObjectRequiredActionSubmitToolOutputs>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalRunObjectRequiredActionSubmitToolOutputs>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalRunObjectRequiredActionSubmitToolOutputs)} does not support writing '{options.Format}' format.");
            }
        }

        InternalRunObjectRequiredActionSubmitToolOutputs IPersistableModel<InternalRunObjectRequiredActionSubmitToolOutputs>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalRunObjectRequiredActionSubmitToolOutputs>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeInternalRunObjectRequiredActionSubmitToolOutputs(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalRunObjectRequiredActionSubmitToolOutputs)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalRunObjectRequiredActionSubmitToolOutputs>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The result to deserialize the model from. </param>
        internal static InternalRunObjectRequiredActionSubmitToolOutputs FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeInternalRunObjectRequiredActionSubmitToolOutputs(document.RootElement);
        }

        /// <summary> Convert into a <see cref="BinaryContent"/>. </summary>
        internal virtual BinaryContent ToBinaryContent()
        {
            return BinaryContent.Create(this, ModelSerializationExtensions.WireOptions);
        }
    }
}