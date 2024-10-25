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
    internal partial class InternalRunStepDeltaStepDetailsToolCallsCodeOutputImageObject : IJsonModel<InternalRunStepDeltaStepDetailsToolCallsCodeOutputImageObject>
    {
        internal InternalRunStepDeltaStepDetailsToolCallsCodeOutputImageObject()
        {
        }

        void IJsonModel<InternalRunStepDeltaStepDetailsToolCallsCodeOutputImageObject>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRunStepDeltaStepDetailsToolCallsCodeOutputImageObject>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalRunStepDeltaStepDetailsToolCallsCodeOutputImageObject)} does not support writing '{format}' format.");
            }
            base.JsonModelWriteCore(writer, options);
            if (_additionalBinaryDataProperties?.ContainsKey("index") != true)
            {
                writer.WritePropertyName("index"u8);
                writer.WriteNumberValue(Index);
            }
            if (Optional.IsDefined(Image) && _additionalBinaryDataProperties?.ContainsKey("image") != true)
            {
                writer.WritePropertyName("image"u8);
                writer.WriteObjectValue(Image, options);
            }
        }

        InternalRunStepDeltaStepDetailsToolCallsCodeOutputImageObject IJsonModel<InternalRunStepDeltaStepDetailsToolCallsCodeOutputImageObject>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => (InternalRunStepDeltaStepDetailsToolCallsCodeOutputImageObject)JsonModelCreateCore(ref reader, options);

        protected override RunStepUpdateCodeInterpreterOutput JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRunStepDeltaStepDetailsToolCallsCodeOutputImageObject>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalRunStepDeltaStepDetailsToolCallsCodeOutputImageObject)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalRunStepDeltaStepDetailsToolCallsCodeOutputImageObject(document.RootElement, options);
        }

        internal static InternalRunStepDeltaStepDetailsToolCallsCodeOutputImageObject DeserializeInternalRunStepDeltaStepDetailsToolCallsCodeOutputImageObject(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            int index = default;
            InternalRunStepDeltaStepDetailsToolCallsCodeOutputImageObjectImage image = default;
            string @type = "image";
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("index"u8))
                {
                    index = prop.Value.GetInt32();
                    continue;
                }
                if (prop.NameEquals("image"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    image = InternalRunStepDeltaStepDetailsToolCallsCodeOutputImageObjectImage.DeserializeInternalRunStepDeltaStepDetailsToolCallsCodeOutputImageObjectImage(prop.Value, options);
                    continue;
                }
                if (prop.NameEquals("type"u8))
                {
                    @type = prop.Value.GetString();
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new InternalRunStepDeltaStepDetailsToolCallsCodeOutputImageObject(index, image, @type, additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<InternalRunStepDeltaStepDetailsToolCallsCodeOutputImageObject>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected override BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRunStepDeltaStepDetailsToolCallsCodeOutputImageObject>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalRunStepDeltaStepDetailsToolCallsCodeOutputImageObject)} does not support writing '{options.Format}' format.");
            }
        }

        InternalRunStepDeltaStepDetailsToolCallsCodeOutputImageObject IPersistableModel<InternalRunStepDeltaStepDetailsToolCallsCodeOutputImageObject>.Create(BinaryData data, ModelReaderWriterOptions options) => (InternalRunStepDeltaStepDetailsToolCallsCodeOutputImageObject)PersistableModelCreateCore(data, options);

        protected override RunStepUpdateCodeInterpreterOutput PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRunStepDeltaStepDetailsToolCallsCodeOutputImageObject>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeInternalRunStepDeltaStepDetailsToolCallsCodeOutputImageObject(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalRunStepDeltaStepDetailsToolCallsCodeOutputImageObject)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalRunStepDeltaStepDetailsToolCallsCodeOutputImageObject>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(InternalRunStepDeltaStepDetailsToolCallsCodeOutputImageObject internalRunStepDeltaStepDetailsToolCallsCodeOutputImageObject)
        {
            return BinaryContent.Create(internalRunStepDeltaStepDetailsToolCallsCodeOutputImageObject, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator InternalRunStepDeltaStepDetailsToolCallsCodeOutputImageObject(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeInternalRunStepDeltaStepDetailsToolCallsCodeOutputImageObject(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
