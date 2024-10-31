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
    internal partial class InternalRunStepDeltaStepDetailsToolCallsObject : IJsonModel<InternalRunStepDeltaStepDetailsToolCallsObject>
    {
        void IJsonModel<InternalRunStepDeltaStepDetailsToolCallsObject>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRunStepDeltaStepDetailsToolCallsObject>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalRunStepDeltaStepDetailsToolCallsObject)} does not support writing '{format}' format.");
            }
            base.JsonModelWriteCore(writer, options);
            if (Optional.IsCollectionDefined(ToolCalls) && _additionalBinaryDataProperties?.ContainsKey("tool_calls") != true)
            {
                writer.WritePropertyName("tool_calls"u8);
                writer.WriteStartArray();
                foreach (InternalRunStepDeltaStepDetailsToolCallsObjectToolCallsObject item in ToolCalls)
                {
                    writer.WriteObjectValue(item, options);
                }
                writer.WriteEndArray();
            }
        }

        InternalRunStepDeltaStepDetailsToolCallsObject IJsonModel<InternalRunStepDeltaStepDetailsToolCallsObject>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => (InternalRunStepDeltaStepDetailsToolCallsObject)JsonModelCreateCore(ref reader, options);

        protected override InternalRunStepDeltaStepDetails JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRunStepDeltaStepDetailsToolCallsObject>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalRunStepDeltaStepDetailsToolCallsObject)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalRunStepDeltaStepDetailsToolCallsObject(document.RootElement, options);
        }

        internal static InternalRunStepDeltaStepDetailsToolCallsObject DeserializeInternalRunStepDeltaStepDetailsToolCallsObject(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IList<InternalRunStepDeltaStepDetailsToolCallsObjectToolCallsObject> toolCalls = default;
            string @type = "tool_calls";
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("tool_calls"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<InternalRunStepDeltaStepDetailsToolCallsObjectToolCallsObject> array = new List<InternalRunStepDeltaStepDetailsToolCallsObjectToolCallsObject>();
                    foreach (var item in prop.Value.EnumerateArray())
                    {
                        array.Add(InternalRunStepDeltaStepDetailsToolCallsObjectToolCallsObject.DeserializeInternalRunStepDeltaStepDetailsToolCallsObjectToolCallsObject(item, options));
                    }
                    toolCalls = array;
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
            return new InternalRunStepDeltaStepDetailsToolCallsObject(toolCalls ?? new ChangeTrackingList<InternalRunStepDeltaStepDetailsToolCallsObjectToolCallsObject>(), @type, additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<InternalRunStepDeltaStepDetailsToolCallsObject>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected override BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRunStepDeltaStepDetailsToolCallsObject>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalRunStepDeltaStepDetailsToolCallsObject)} does not support writing '{options.Format}' format.");
            }
        }

        InternalRunStepDeltaStepDetailsToolCallsObject IPersistableModel<InternalRunStepDeltaStepDetailsToolCallsObject>.Create(BinaryData data, ModelReaderWriterOptions options) => (InternalRunStepDeltaStepDetailsToolCallsObject)PersistableModelCreateCore(data, options);

        protected override InternalRunStepDeltaStepDetails PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRunStepDeltaStepDetailsToolCallsObject>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeInternalRunStepDeltaStepDetailsToolCallsObject(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalRunStepDeltaStepDetailsToolCallsObject)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalRunStepDeltaStepDetailsToolCallsObject>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(InternalRunStepDeltaStepDetailsToolCallsObject internalRunStepDeltaStepDetailsToolCallsObject)
        {
            if (internalRunStepDeltaStepDetailsToolCallsObject == null)
            {
                return null;
            }
            return BinaryContent.Create(internalRunStepDeltaStepDetailsToolCallsObject, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator InternalRunStepDeltaStepDetailsToolCallsObject(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeInternalRunStepDeltaStepDetailsToolCallsObject(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
