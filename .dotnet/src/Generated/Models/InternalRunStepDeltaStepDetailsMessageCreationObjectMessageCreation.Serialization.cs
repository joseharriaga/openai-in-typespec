// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Assistants
{
    internal partial class InternalRunStepDeltaStepDetailsMessageCreationObjectMessageCreation : IJsonModel<InternalRunStepDeltaStepDetailsMessageCreationObjectMessageCreation>
    {
        void IJsonModel<InternalRunStepDeltaStepDetailsMessageCreationObjectMessageCreation>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalRunStepDeltaStepDetailsMessageCreationObjectMessageCreation>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalRunStepDeltaStepDetailsMessageCreationObjectMessageCreation)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            if (Optional.IsDefined(MessageId))
            {
                writer.WritePropertyName("message_id"u8);
                writer.WriteStringValue(MessageId);
            }
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

        InternalRunStepDeltaStepDetailsMessageCreationObjectMessageCreation IJsonModel<InternalRunStepDeltaStepDetailsMessageCreationObjectMessageCreation>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalRunStepDeltaStepDetailsMessageCreationObjectMessageCreation>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalRunStepDeltaStepDetailsMessageCreationObjectMessageCreation)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalRunStepDeltaStepDetailsMessageCreationObjectMessageCreation(document.RootElement, options);
        }

        internal static InternalRunStepDeltaStepDetailsMessageCreationObjectMessageCreation DeserializeInternalRunStepDeltaStepDetailsMessageCreationObjectMessageCreation(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string messageId = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("message_id"u8))
                {
                    messageId = property.Value.GetString();
                    continue;
                }
                if (true)
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new InternalRunStepDeltaStepDetailsMessageCreationObjectMessageCreation(messageId, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<InternalRunStepDeltaStepDetailsMessageCreationObjectMessageCreation>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalRunStepDeltaStepDetailsMessageCreationObjectMessageCreation>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalRunStepDeltaStepDetailsMessageCreationObjectMessageCreation)} does not support writing '{options.Format}' format.");
            }
        }

        InternalRunStepDeltaStepDetailsMessageCreationObjectMessageCreation IPersistableModel<InternalRunStepDeltaStepDetailsMessageCreationObjectMessageCreation>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalRunStepDeltaStepDetailsMessageCreationObjectMessageCreation>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeInternalRunStepDeltaStepDetailsMessageCreationObjectMessageCreation(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalRunStepDeltaStepDetailsMessageCreationObjectMessageCreation)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalRunStepDeltaStepDetailsMessageCreationObjectMessageCreation>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        internal static InternalRunStepDeltaStepDetailsMessageCreationObjectMessageCreation FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeInternalRunStepDeltaStepDetailsMessageCreationObjectMessageCreation(document.RootElement);
        }

        internal virtual BinaryContent ToBinaryContent()
        {
            return BinaryContent.Create(this, ModelSerializationExtensions.WireOptions);
        }
    }
}
