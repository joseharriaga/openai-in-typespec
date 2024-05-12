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
    internal partial class InternalSubmitToolOutputsRunRequest : IJsonModel<InternalSubmitToolOutputsRunRequest>
    {
        void IJsonModel<InternalSubmitToolOutputsRunRequest>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalSubmitToolOutputsRunRequest>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalSubmitToolOutputsRunRequest)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("tool_outputs"u8);
            writer.WriteStartArray();
            foreach (var item in ToolOutputs)
            {
                writer.WriteObjectValue(item, options);
            }
            writer.WriteEndArray();
            if (Optional.IsDefined(Stream))
            {
                if (Stream != null)
                {
                    writer.WritePropertyName("stream"u8);
                    writer.WriteBooleanValue(Stream.Value);
                }
                else
                {
                    writer.WriteNull("stream");
                }
            }
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

        InternalSubmitToolOutputsRunRequest IJsonModel<InternalSubmitToolOutputsRunRequest>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalSubmitToolOutputsRunRequest>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalSubmitToolOutputsRunRequest)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalSubmitToolOutputsRunRequest(document.RootElement, options);
        }

        internal static InternalSubmitToolOutputsRunRequest DeserializeInternalSubmitToolOutputsRunRequest(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IList<ToolOutput> toolOutputs = default;
            bool? stream = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("tool_outputs"u8))
                {
                    List<ToolOutput> array = new List<ToolOutput>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(ToolOutput.DeserializeToolOutput(item, options));
                    }
                    toolOutputs = array;
                    continue;
                }
                if (property.NameEquals("stream"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        stream = null;
                        continue;
                    }
                    stream = property.Value.GetBoolean();
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new InternalSubmitToolOutputsRunRequest(toolOutputs, stream, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<InternalSubmitToolOutputsRunRequest>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalSubmitToolOutputsRunRequest>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalSubmitToolOutputsRunRequest)} does not support writing '{options.Format}' format.");
            }
        }

        InternalSubmitToolOutputsRunRequest IPersistableModel<InternalSubmitToolOutputsRunRequest>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalSubmitToolOutputsRunRequest>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeInternalSubmitToolOutputsRunRequest(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalSubmitToolOutputsRunRequest)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalSubmitToolOutputsRunRequest>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The result to deserialize the model from. </param>
        internal static InternalSubmitToolOutputsRunRequest FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeInternalSubmitToolOutputsRunRequest(document.RootElement);
        }

        /// <summary> Convert into a <see cref="BinaryContent"/>. </summary>
        internal virtual BinaryContent ToBinaryContent()
        {
            return BinaryContent.Create(this, ModelSerializationExtensions.WireOptions);
        }
    }
}
