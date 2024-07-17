// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Assistants
{
    internal partial class InternalRunStepDeltaStepDetailsToolCallsCodeOutputImageObject : IJsonModel<InternalRunStepDeltaStepDetailsToolCallsCodeOutputImageObject>
    {
        void IJsonModel<InternalRunStepDeltaStepDetailsToolCallsCodeOutputImageObject>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalRunStepDeltaStepDetailsToolCallsCodeOutputImageObject>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalRunStepDeltaStepDetailsToolCallsCodeOutputImageObject)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            if (SerializedAdditionalRawData?.ContainsKey("index") != true)
            {
                writer.WritePropertyName("index"u8);
                writer.WriteNumberValue(Index);
            }
            if (SerializedAdditionalRawData?.ContainsKey("image") != true && Optional.IsDefined(Image))
            {
                writer.WritePropertyName("image"u8);
                writer.WriteObjectValue(Image, options);
            }
            if (SerializedAdditionalRawData?.ContainsKey("type") != true)
            {
                writer.WritePropertyName("type"u8);
                writer.WriteStringValue(Type);
            }
            foreach (var item in SerializedAdditionalRawData ?? new System.Collections.Generic.Dictionary<string, BinaryData>())
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
            writer.WriteEndObject();
        }

        InternalRunStepDeltaStepDetailsToolCallsCodeOutputImageObject IJsonModel<InternalRunStepDeltaStepDetailsToolCallsCodeOutputImageObject>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalRunStepDeltaStepDetailsToolCallsCodeOutputImageObject>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalRunStepDeltaStepDetailsToolCallsCodeOutputImageObject)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalRunStepDeltaStepDetailsToolCallsCodeOutputImageObject(document.RootElement, options);
        }

        internal static InternalRunStepDeltaStepDetailsToolCallsCodeOutputImageObject DeserializeInternalRunStepDeltaStepDetailsToolCallsCodeOutputImageObject(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            int index = default;
            InternalRunStepDeltaStepDetailsToolCallsCodeOutputImageObjectImage image = default;
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
                if (property.NameEquals("image"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    image = InternalRunStepDeltaStepDetailsToolCallsCodeOutputImageObjectImage.DeserializeInternalRunStepDeltaStepDetailsToolCallsCodeOutputImageObjectImage(property.Value, options);
                    continue;
                }
                if (property.NameEquals("type"u8))
                {
                    type = property.Value.GetString();
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary ??= new Dictionary<string, BinaryData>();
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new InternalRunStepDeltaStepDetailsToolCallsCodeOutputImageObject(type, serializedAdditionalRawData, index, image);
        }

        BinaryData IPersistableModel<InternalRunStepDeltaStepDetailsToolCallsCodeOutputImageObject>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalRunStepDeltaStepDetailsToolCallsCodeOutputImageObject>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalRunStepDeltaStepDetailsToolCallsCodeOutputImageObject)} does not support writing '{options.Format}' format.");
            }
        }

        InternalRunStepDeltaStepDetailsToolCallsCodeOutputImageObject IPersistableModel<InternalRunStepDeltaStepDetailsToolCallsCodeOutputImageObject>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalRunStepDeltaStepDetailsToolCallsCodeOutputImageObject>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeInternalRunStepDeltaStepDetailsToolCallsCodeOutputImageObject(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalRunStepDeltaStepDetailsToolCallsCodeOutputImageObject)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalRunStepDeltaStepDetailsToolCallsCodeOutputImageObject>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        internal static new InternalRunStepDeltaStepDetailsToolCallsCodeOutputImageObject FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeInternalRunStepDeltaStepDetailsToolCallsCodeOutputImageObject(document.RootElement);
        }

        internal override BinaryContent ToBinaryContent()
        {
            return BinaryContent.Create(this, ModelSerializationExtensions.WireOptions);
        }
    }
}
