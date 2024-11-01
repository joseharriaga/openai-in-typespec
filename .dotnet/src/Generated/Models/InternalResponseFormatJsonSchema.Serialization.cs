// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using OpenAI;

namespace OpenAI.Internal
{
    internal partial class InternalResponseFormatJsonSchema : IJsonModel<InternalResponseFormatJsonSchema>
    {
        internal InternalResponseFormatJsonSchema()
        {
        }

        void IJsonModel<InternalResponseFormatJsonSchema>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalResponseFormatJsonSchema>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalResponseFormatJsonSchema)} does not support writing '{format}' format.");
            }
            base.JsonModelWriteCore(writer, options);
            if (_additionalBinaryDataProperties?.ContainsKey("json_schema") != true)
            {
                writer.WritePropertyName("json_schema"u8);
                writer.WriteObjectValue(JsonSchema, options);
            }
        }

        InternalResponseFormatJsonSchema IJsonModel<InternalResponseFormatJsonSchema>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => (InternalResponseFormatJsonSchema)JsonModelCreateCore(ref reader, options);

        protected override InternalOmniTypedResponseFormat JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalResponseFormatJsonSchema>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalResponseFormatJsonSchema)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalResponseFormatJsonSchema(document.RootElement, options);
        }

        internal static InternalResponseFormatJsonSchema DeserializeInternalResponseFormatJsonSchema(JsonElement element, ModelReaderWriterOptions options)
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
                if (true)
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new InternalResponseFormatJsonSchema(jsonSchema, @type, additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<InternalResponseFormatJsonSchema>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected override BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalResponseFormatJsonSchema>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalResponseFormatJsonSchema)} does not support writing '{options.Format}' format.");
            }
        }

        InternalResponseFormatJsonSchema IPersistableModel<InternalResponseFormatJsonSchema>.Create(BinaryData data, ModelReaderWriterOptions options) => (InternalResponseFormatJsonSchema)PersistableModelCreateCore(data, options);

        protected override InternalOmniTypedResponseFormat PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalResponseFormatJsonSchema>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeInternalResponseFormatJsonSchema(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalResponseFormatJsonSchema)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalResponseFormatJsonSchema>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(InternalResponseFormatJsonSchema internalResponseFormatJsonSchema)
        {
            if (internalResponseFormatJsonSchema == null)
            {
                return null;
            }
            return BinaryContent.Create(internalResponseFormatJsonSchema, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator InternalResponseFormatJsonSchema(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeInternalResponseFormatJsonSchema(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
