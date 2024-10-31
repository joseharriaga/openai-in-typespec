// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using OpenAI;

namespace OpenAI.Assistants
{
    internal partial class UnknownRunStepDetailsToolCallsObjectToolCallsObject : IJsonModel<RunStepToolCall>
    {
        internal UnknownRunStepDetailsToolCallsObjectToolCallsObject()
        {
        }

        void IJsonModel<RunStepToolCall>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<RunStepToolCall>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(RunStepToolCall)} does not support writing '{format}' format.");
            }
            base.JsonModelWriteCore(writer, options);
        }

        RunStepToolCall IJsonModel<RunStepToolCall>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => (UnknownRunStepDetailsToolCallsObjectToolCallsObject)JsonModelCreateCore(ref reader, options);

        protected override RunStepToolCall JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<RunStepToolCall>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(RunStepToolCall)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeRunStepToolCall(document.RootElement, options);
        }

        internal static UnknownRunStepDetailsToolCallsObjectToolCallsObject DeserializeUnknownRunStepDetailsToolCallsObjectToolCallsObject(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string @type = "unknown";
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("type"u8))
                {
                    @type = prop.Value.GetString();
                    continue;
                }
                if (true)
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new UnknownRunStepDetailsToolCallsObjectToolCallsObject(@type, additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<RunStepToolCall>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected override BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<RunStepToolCall>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(RunStepToolCall)} does not support writing '{options.Format}' format.");
            }
        }

        RunStepToolCall IPersistableModel<RunStepToolCall>.Create(BinaryData data, ModelReaderWriterOptions options) => (UnknownRunStepDetailsToolCallsObjectToolCallsObject)PersistableModelCreateCore(data, options);

        protected override RunStepToolCall PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<RunStepToolCall>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeRunStepToolCall(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(RunStepToolCall)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<RunStepToolCall>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
