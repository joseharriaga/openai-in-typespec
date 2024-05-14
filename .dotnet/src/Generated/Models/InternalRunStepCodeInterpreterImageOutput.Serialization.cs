// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Assistants
{
    internal partial class InternalRunStepCodeInterpreterImageOutput : IJsonModel<InternalRunStepCodeInterpreterImageOutput>
    {
        void IJsonModel<InternalRunStepCodeInterpreterImageOutput>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalRunStepCodeInterpreterImageOutput>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalRunStepCodeInterpreterImageOutput)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("image"u8);
            writer.WriteObjectValue<InternalRunStepDetailsToolCallsCodeOutputImageObjectImage>(_image, options);
            writer.WritePropertyName("type"u8);
            writer.WriteStringValue(Type);
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

        InternalRunStepCodeInterpreterImageOutput IJsonModel<InternalRunStepCodeInterpreterImageOutput>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalRunStepCodeInterpreterImageOutput>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalRunStepCodeInterpreterImageOutput)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalRunStepCodeInterpreterImageOutput(document.RootElement, options);
        }

        internal static InternalRunStepCodeInterpreterImageOutput DeserializeInternalRunStepCodeInterpreterImageOutput(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            InternalRunStepDetailsToolCallsCodeOutputImageObjectImage image = default;
            string type = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("image"u8))
                {
                    image = InternalRunStepDetailsToolCallsCodeOutputImageObjectImage.DeserializeInternalRunStepDetailsToolCallsCodeOutputImageObjectImage(property.Value, options);
                    continue;
                }
                if (property.NameEquals("type"u8))
                {
                    type = property.Value.GetString();
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new InternalRunStepCodeInterpreterImageOutput(type, serializedAdditionalRawData, image);
        }

        BinaryData IPersistableModel<InternalRunStepCodeInterpreterImageOutput>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalRunStepCodeInterpreterImageOutput>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalRunStepCodeInterpreterImageOutput)} does not support writing '{options.Format}' format.");
            }
        }

        InternalRunStepCodeInterpreterImageOutput IPersistableModel<InternalRunStepCodeInterpreterImageOutput>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalRunStepCodeInterpreterImageOutput>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeInternalRunStepCodeInterpreterImageOutput(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalRunStepCodeInterpreterImageOutput)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalRunStepCodeInterpreterImageOutput>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The result to deserialize the model from. </param>
        internal static new InternalRunStepCodeInterpreterImageOutput FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeInternalRunStepCodeInterpreterImageOutput(document.RootElement);
        }

        /// <summary> Convert into a <see cref="BinaryContent"/>. </summary>
        internal override BinaryContent ToBinaryContent()
        {
            return BinaryContent.Create(this, ModelSerializationExtensions.WireOptions);
        }
    }
}
