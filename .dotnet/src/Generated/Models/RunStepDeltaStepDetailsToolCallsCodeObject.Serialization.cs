// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Internal.Models
{
    internal partial class RunStepDeltaStepDetailsToolCallsCodeObject : IJsonModel<RunStepDeltaStepDetailsToolCallsCodeObject>
    {
        void IJsonModel<RunStepDeltaStepDetailsToolCallsCodeObject>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<RunStepDeltaStepDetailsToolCallsCodeObject>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(RunStepDeltaStepDetailsToolCallsCodeObject)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("index"u8);
            writer.WriteNumberValue(Index);
            if (Optional.IsDefined(Id))
            {
                writer.WritePropertyName("id"u8);
                writer.WriteStringValue(Id);
            }
            writer.WritePropertyName("type"u8);
            writer.WriteStringValue(Type.ToString());
            if (Optional.IsDefined(CodeInterpreter))
            {
                writer.WritePropertyName("code_interpreter"u8);
                writer.WriteObjectValue<RunStepDeltaStepDetailsToolCallsCodeObjectCodeInterpreter>(CodeInterpreter, options);
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

        RunStepDeltaStepDetailsToolCallsCodeObject IJsonModel<RunStepDeltaStepDetailsToolCallsCodeObject>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<RunStepDeltaStepDetailsToolCallsCodeObject>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(RunStepDeltaStepDetailsToolCallsCodeObject)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeRunStepDeltaStepDetailsToolCallsCodeObject(document.RootElement, options);
        }

        internal static RunStepDeltaStepDetailsToolCallsCodeObject DeserializeRunStepDeltaStepDetailsToolCallsCodeObject(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            long index = default;
            string id = default;
            RunStepDeltaStepDetailsToolCallsCodeObjectType type = default;
            RunStepDeltaStepDetailsToolCallsCodeObjectCodeInterpreter codeInterpreter = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("index"u8))
                {
                    index = property.Value.GetInt64();
                    continue;
                }
                if (property.NameEquals("id"u8))
                {
                    id = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"u8))
                {
                    type = new RunStepDeltaStepDetailsToolCallsCodeObjectType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("code_interpreter"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    codeInterpreter = RunStepDeltaStepDetailsToolCallsCodeObjectCodeInterpreter.DeserializeRunStepDeltaStepDetailsToolCallsCodeObjectCodeInterpreter(property.Value, options);
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new RunStepDeltaStepDetailsToolCallsCodeObject(index, id, type, codeInterpreter, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<RunStepDeltaStepDetailsToolCallsCodeObject>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<RunStepDeltaStepDetailsToolCallsCodeObject>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(RunStepDeltaStepDetailsToolCallsCodeObject)} does not support writing '{options.Format}' format.");
            }
        }

        RunStepDeltaStepDetailsToolCallsCodeObject IPersistableModel<RunStepDeltaStepDetailsToolCallsCodeObject>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<RunStepDeltaStepDetailsToolCallsCodeObject>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeRunStepDeltaStepDetailsToolCallsCodeObject(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(RunStepDeltaStepDetailsToolCallsCodeObject)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<RunStepDeltaStepDetailsToolCallsCodeObject>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The result to deserialize the model from. </param>
        internal static RunStepDeltaStepDetailsToolCallsCodeObject FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeRunStepDeltaStepDetailsToolCallsCodeObject(document.RootElement);
        }

        /// <summary> Convert into a Utf8JsonRequestBody. </summary>
        internal virtual BinaryContent ToBinaryBody()
        {
            return BinaryContent.Create(this, new ModelReaderWriterOptions("W"));
        }
    }
}
