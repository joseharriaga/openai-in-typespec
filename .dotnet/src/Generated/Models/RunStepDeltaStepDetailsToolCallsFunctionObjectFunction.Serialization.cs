// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Internal.Models
{
    internal partial class RunStepDeltaStepDetailsToolCallsFunctionObjectFunction : IJsonModel<RunStepDeltaStepDetailsToolCallsFunctionObjectFunction>
    {
        void IJsonModel<RunStepDeltaStepDetailsToolCallsFunctionObjectFunction>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<RunStepDeltaStepDetailsToolCallsFunctionObjectFunction>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(RunStepDeltaStepDetailsToolCallsFunctionObjectFunction)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            if (Optional.IsDefined(Name))
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(Name);
            }
            if (Optional.IsDefined(Arguments))
            {
                writer.WritePropertyName("arguments"u8);
                writer.WriteStringValue(Arguments);
            }
            if (Optional.IsDefined(Output))
            {
                if (Output != null)
                {
                    writer.WritePropertyName("output"u8);
                    writer.WriteStringValue(Output);
                }
                else
                {
                    writer.WriteNull("output");
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

        RunStepDeltaStepDetailsToolCallsFunctionObjectFunction IJsonModel<RunStepDeltaStepDetailsToolCallsFunctionObjectFunction>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<RunStepDeltaStepDetailsToolCallsFunctionObjectFunction>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(RunStepDeltaStepDetailsToolCallsFunctionObjectFunction)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeRunStepDeltaStepDetailsToolCallsFunctionObjectFunction(document.RootElement, options);
        }

        internal static RunStepDeltaStepDetailsToolCallsFunctionObjectFunction DeserializeRunStepDeltaStepDetailsToolCallsFunctionObjectFunction(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string name = default;
            string arguments = default;
            string output = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("arguments"u8))
                {
                    arguments = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("output"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        output = null;
                        continue;
                    }
                    output = property.Value.GetString();
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new RunStepDeltaStepDetailsToolCallsFunctionObjectFunction(name, arguments, output, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<RunStepDeltaStepDetailsToolCallsFunctionObjectFunction>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<RunStepDeltaStepDetailsToolCallsFunctionObjectFunction>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(RunStepDeltaStepDetailsToolCallsFunctionObjectFunction)} does not support writing '{options.Format}' format.");
            }
        }

        RunStepDeltaStepDetailsToolCallsFunctionObjectFunction IPersistableModel<RunStepDeltaStepDetailsToolCallsFunctionObjectFunction>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<RunStepDeltaStepDetailsToolCallsFunctionObjectFunction>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeRunStepDeltaStepDetailsToolCallsFunctionObjectFunction(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(RunStepDeltaStepDetailsToolCallsFunctionObjectFunction)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<RunStepDeltaStepDetailsToolCallsFunctionObjectFunction>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The result to deserialize the model from. </param>
        internal static RunStepDeltaStepDetailsToolCallsFunctionObjectFunction FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeRunStepDeltaStepDetailsToolCallsFunctionObjectFunction(document.RootElement);
        }

        /// <summary> Convert into a Utf8JsonRequestBody. </summary>
        internal virtual BinaryContent ToBinaryBody()
        {
            return BinaryContent.Create(this, new ModelReaderWriterOptions("W"));
        }
    }
}
