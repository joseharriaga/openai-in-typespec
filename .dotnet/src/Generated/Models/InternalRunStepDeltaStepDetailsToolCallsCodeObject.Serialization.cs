// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Assistants
{
    internal partial class InternalRunStepDeltaStepDetailsToolCallsCodeObject : IJsonModel<InternalRunStepDeltaStepDetailsToolCallsCodeObject>
    {
        void IJsonModel<InternalRunStepDeltaStepDetailsToolCallsCodeObject>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalRunStepDeltaStepDetailsToolCallsCodeObject>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalRunStepDeltaStepDetailsToolCallsCodeObject)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("index"u8);
            writer.WriteNumberValue(Index);
            if (Optional.IsDefined(Id))
            {
                writer.WritePropertyName("id"u8);
                writer.WriteStringValue(Id);
            }
            if (Optional.IsDefined(CodeInterpreter))
            {
                writer.WritePropertyName("code_interpreter"u8);
                writer.WriteObjectValue(CodeInterpreter, options);
            }
            writer.WritePropertyName("type"u8);
            writer.WriteStringValue(Type);
            if (true && _serializedAdditionalRawData != null)
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

        InternalRunStepDeltaStepDetailsToolCallsCodeObject IJsonModel<InternalRunStepDeltaStepDetailsToolCallsCodeObject>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalRunStepDeltaStepDetailsToolCallsCodeObject>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalRunStepDeltaStepDetailsToolCallsCodeObject)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalRunStepDeltaStepDetailsToolCallsCodeObject(document.RootElement, options);
        }

        internal static InternalRunStepDeltaStepDetailsToolCallsCodeObject DeserializeInternalRunStepDeltaStepDetailsToolCallsCodeObject(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            int index = default;
            string id = default;
            InternalRunStepDeltaStepDetailsToolCallsCodeObjectCodeInterpreter codeInterpreter = default;
            string type = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("index"u8))
                {
                    index = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("id"u8))
                {
                    id = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("code_interpreter"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    codeInterpreter = InternalRunStepDeltaStepDetailsToolCallsCodeObjectCodeInterpreter.DeserializeInternalRunStepDeltaStepDetailsToolCallsCodeObjectCodeInterpreter(property.Value, options);
                    continue;
                }
                if (property.NameEquals("type"u8))
                {
                    type = property.Value.GetString();
                    continue;
                }
                if (true)
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new InternalRunStepDeltaStepDetailsToolCallsCodeObject(type, serializedAdditionalRawData, index, id, codeInterpreter);
        }

        BinaryData IPersistableModel<InternalRunStepDeltaStepDetailsToolCallsCodeObject>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalRunStepDeltaStepDetailsToolCallsCodeObject>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalRunStepDeltaStepDetailsToolCallsCodeObject)} does not support writing '{options.Format}' format.");
            }
        }

        InternalRunStepDeltaStepDetailsToolCallsCodeObject IPersistableModel<InternalRunStepDeltaStepDetailsToolCallsCodeObject>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalRunStepDeltaStepDetailsToolCallsCodeObject>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeInternalRunStepDeltaStepDetailsToolCallsCodeObject(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalRunStepDeltaStepDetailsToolCallsCodeObject)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalRunStepDeltaStepDetailsToolCallsCodeObject>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        internal static new InternalRunStepDeltaStepDetailsToolCallsCodeObject FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeInternalRunStepDeltaStepDetailsToolCallsCodeObject(document.RootElement);
        }

        internal override BinaryContent ToBinaryContent()
        {
            return BinaryContent.Create(this, ModelSerializationExtensions.WireOptions);
        }
    }
}
