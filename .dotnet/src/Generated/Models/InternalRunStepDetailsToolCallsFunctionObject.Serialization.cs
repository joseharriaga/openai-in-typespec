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
    internal partial class InternalRunStepDetailsToolCallsFunctionObject : IJsonModel<InternalRunStepDetailsToolCallsFunctionObject>
    {
        internal InternalRunStepDetailsToolCallsFunctionObject()
        {
        }

        void IJsonModel<InternalRunStepDetailsToolCallsFunctionObject>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRunStepDetailsToolCallsFunctionObject>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalRunStepDetailsToolCallsFunctionObject)} does not support writing '{format}' format.");
            }
            base.JsonModelWriteCore(writer, options);
            if (_additionalBinaryDataProperties?.ContainsKey("function") != true)
            {
                writer.WritePropertyName("function"u8);
                writer.WriteObjectValue(Function, options);
            }
        }

        InternalRunStepDetailsToolCallsFunctionObject IJsonModel<InternalRunStepDetailsToolCallsFunctionObject>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => (InternalRunStepDetailsToolCallsFunctionObject)JsonModelCreateCore(ref reader, options);

        protected override RunStepToolCall JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRunStepDetailsToolCallsFunctionObject>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalRunStepDetailsToolCallsFunctionObject)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalRunStepDetailsToolCallsFunctionObject(document.RootElement, options);
        }

        internal static InternalRunStepDetailsToolCallsFunctionObject DeserializeInternalRunStepDetailsToolCallsFunctionObject(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string id = default;
            Assistants.RunStepToolCallKind kind = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            InternalRunStepDetailsToolCallsFunctionObjectFunction function = default;
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("id"u8))
                {
                    id = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("type"u8))
                {
                    kind = prop.Value.GetString().ToRunStepToolCallKind();
                    continue;
                }
                if (prop.NameEquals("function"u8))
                {
                    function = InternalRunStepDetailsToolCallsFunctionObjectFunction.DeserializeInternalRunStepDetailsToolCallsFunctionObjectFunction(prop.Value, options);
                    continue;
                }
                if (true)
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new InternalRunStepDetailsToolCallsFunctionObject(id, kind, additionalBinaryDataProperties, function);
        }

        BinaryData IPersistableModel<InternalRunStepDetailsToolCallsFunctionObject>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected override BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRunStepDetailsToolCallsFunctionObject>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalRunStepDetailsToolCallsFunctionObject)} does not support writing '{options.Format}' format.");
            }
        }

        InternalRunStepDetailsToolCallsFunctionObject IPersistableModel<InternalRunStepDetailsToolCallsFunctionObject>.Create(BinaryData data, ModelReaderWriterOptions options) => (InternalRunStepDetailsToolCallsFunctionObject)PersistableModelCreateCore(data, options);

        protected override RunStepToolCall PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRunStepDetailsToolCallsFunctionObject>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeInternalRunStepDetailsToolCallsFunctionObject(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalRunStepDetailsToolCallsFunctionObject)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalRunStepDetailsToolCallsFunctionObject>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(InternalRunStepDetailsToolCallsFunctionObject internalRunStepDetailsToolCallsFunctionObject)
        {
            if (internalRunStepDetailsToolCallsFunctionObject == null)
            {
                return null;
            }
            return BinaryContent.Create(internalRunStepDetailsToolCallsFunctionObject, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator InternalRunStepDetailsToolCallsFunctionObject(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeInternalRunStepDetailsToolCallsFunctionObject(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}