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
    internal partial class InternalRunStepCodeInterpreterLogOutput : IJsonModel<InternalRunStepCodeInterpreterLogOutput>
    {
        internal InternalRunStepCodeInterpreterLogOutput()
        {
        }

        void IJsonModel<InternalRunStepCodeInterpreterLogOutput>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRunStepCodeInterpreterLogOutput>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalRunStepCodeInterpreterLogOutput)} does not support writing '{format}' format.");
            }
            base.JsonModelWriteCore(writer, options);
            if (_additionalBinaryDataProperties?.ContainsKey("logs") != true)
            {
                writer.WritePropertyName("logs"u8);
                writer.WriteStringValue(InternalLogs);
            }
        }

        InternalRunStepCodeInterpreterLogOutput IJsonModel<InternalRunStepCodeInterpreterLogOutput>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => (InternalRunStepCodeInterpreterLogOutput)JsonModelCreateCore(ref reader, options);

        protected override RunStepCodeInterpreterOutput JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRunStepCodeInterpreterLogOutput>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalRunStepCodeInterpreterLogOutput)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalRunStepCodeInterpreterLogOutput(document.RootElement, options);
        }

        internal static InternalRunStepCodeInterpreterLogOutput DeserializeInternalRunStepCodeInterpreterLogOutput(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string internalLogs = default;
            string @type = "logs";
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("logs"u8))
                {
                    internalLogs = prop.Value.GetString();
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
            return new InternalRunStepCodeInterpreterLogOutput(internalLogs, @type, additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<InternalRunStepCodeInterpreterLogOutput>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected override BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRunStepCodeInterpreterLogOutput>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalRunStepCodeInterpreterLogOutput)} does not support writing '{options.Format}' format.");
            }
        }

        InternalRunStepCodeInterpreterLogOutput IPersistableModel<InternalRunStepCodeInterpreterLogOutput>.Create(BinaryData data, ModelReaderWriterOptions options) => (InternalRunStepCodeInterpreterLogOutput)PersistableModelCreateCore(data, options);

        protected override RunStepCodeInterpreterOutput PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRunStepCodeInterpreterLogOutput>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeInternalRunStepCodeInterpreterLogOutput(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalRunStepCodeInterpreterLogOutput)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalRunStepCodeInterpreterLogOutput>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(InternalRunStepCodeInterpreterLogOutput internalRunStepCodeInterpreterLogOutput)
        {
            if (internalRunStepCodeInterpreterLogOutput == null)
            {
                return null;
            }
            return BinaryContent.Create(internalRunStepCodeInterpreterLogOutput, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator InternalRunStepCodeInterpreterLogOutput(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeInternalRunStepCodeInterpreterLogOutput(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
