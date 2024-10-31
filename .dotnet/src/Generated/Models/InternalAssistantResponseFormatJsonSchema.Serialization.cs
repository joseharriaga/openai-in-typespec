// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using OpenAI;
using OpenAI.Internal;

namespace OpenAI.Assistants
{
    internal partial class InternalAssistantResponseFormatJsonSchema : IJsonModel<InternalAssistantResponseFormatJsonSchema>
    {
        internal InternalAssistantResponseFormatJsonSchema()
        {
        }

        void IJsonModel<InternalAssistantResponseFormatJsonSchema>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalAssistantResponseFormatJsonSchema>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalAssistantResponseFormatJsonSchema)} does not support writing '{format}' format.");
            }
            base.JsonModelWriteCore(writer, options);
            if (_additionalBinaryDataProperties?.ContainsKey("json_schema") != true)
            {
                writer.WritePropertyName("json_schema"u8);
                writer.WriteObjectValue(JsonSchema, options);
            }
        }

        InternalAssistantResponseFormatJsonSchema IJsonModel<InternalAssistantResponseFormatJsonSchema>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => (InternalAssistantResponseFormatJsonSchema)JsonModelCreateCore(ref reader, options);

        protected override AssistantResponseFormat JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalAssistantResponseFormatJsonSchema>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalAssistantResponseFormatJsonSchema)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalAssistantResponseFormatJsonSchema(document.RootElement, options);
        }

        internal static InternalAssistantResponseFormatJsonSchema DeserializeInternalAssistantResponseFormatJsonSchema(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            InternalResponseFormatJsonSchemaJsonSchema jsonSchema = default;
            string @type = "json_schema";
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("json_schema"u8))
                {
                    jsonSchema = InternalResponseFormatJsonSchemaJsonSchema.DeserializeInternalResponseFormatJsonSchemaJsonSchema(prop.Value, options);
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
            return new InternalAssistantResponseFormatJsonSchema(jsonSchema, @type, additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<InternalAssistantResponseFormatJsonSchema>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected override BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalAssistantResponseFormatJsonSchema>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalAssistantResponseFormatJsonSchema)} does not support writing '{options.Format}' format.");
            }
        }

        InternalAssistantResponseFormatJsonSchema IPersistableModel<InternalAssistantResponseFormatJsonSchema>.Create(BinaryData data, ModelReaderWriterOptions options) => (InternalAssistantResponseFormatJsonSchema)PersistableModelCreateCore(data, options);

        protected override AssistantResponseFormat PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalAssistantResponseFormatJsonSchema>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeInternalAssistantResponseFormatJsonSchema(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalAssistantResponseFormatJsonSchema)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalAssistantResponseFormatJsonSchema>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(InternalAssistantResponseFormatJsonSchema internalAssistantResponseFormatJsonSchema)
        {
            if (internalAssistantResponseFormatJsonSchema == null)
            {
                return null;
            }
            return BinaryContent.Create(internalAssistantResponseFormatJsonSchema, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator InternalAssistantResponseFormatJsonSchema(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeInternalAssistantResponseFormatJsonSchema(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
