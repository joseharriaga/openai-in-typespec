// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Internal.Models
{
    internal partial class SubmitToolOutputsRunRequest : IJsonModel<SubmitToolOutputsRunRequest>
    {
        void IJsonModel<SubmitToolOutputsRunRequest>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<SubmitToolOutputsRunRequest>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(SubmitToolOutputsRunRequest)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("tool_outputs"u8);
            writer.WriteStartArray();
            foreach (var item in ToolOutputs)
            {
                writer.WriteObjectValue<SubmitToolOutputsRunRequestToolOutput>(item, options);
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

        SubmitToolOutputsRunRequest IJsonModel<SubmitToolOutputsRunRequest>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<SubmitToolOutputsRunRequest>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(SubmitToolOutputsRunRequest)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeSubmitToolOutputsRunRequest(document.RootElement, options);
        }

        internal static SubmitToolOutputsRunRequest DeserializeSubmitToolOutputsRunRequest(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IList<SubmitToolOutputsRunRequestToolOutput> toolOutputs = default;
            bool? stream = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("tool_outputs"u8))
                {
                    List<SubmitToolOutputsRunRequestToolOutput> array = new List<SubmitToolOutputsRunRequestToolOutput>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(SubmitToolOutputsRunRequestToolOutput.DeserializeSubmitToolOutputsRunRequestToolOutput(item, options));
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
            return new SubmitToolOutputsRunRequest(toolOutputs, stream, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<SubmitToolOutputsRunRequest>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<SubmitToolOutputsRunRequest>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(SubmitToolOutputsRunRequest)} does not support writing '{options.Format}' format.");
            }
        }

        SubmitToolOutputsRunRequest IPersistableModel<SubmitToolOutputsRunRequest>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<SubmitToolOutputsRunRequest>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeSubmitToolOutputsRunRequest(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(SubmitToolOutputsRunRequest)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<SubmitToolOutputsRunRequest>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The result to deserialize the model from. </param>
        internal static SubmitToolOutputsRunRequest FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeSubmitToolOutputsRunRequest(document.RootElement);
        }

        /// <summary> Convert into a Utf8JsonRequestBody. </summary>
        internal virtual BinaryContent ToBinaryBody()
        {
            return BinaryContent.Create(this, new ModelReaderWriterOptions("W"));
        }
    }
}
