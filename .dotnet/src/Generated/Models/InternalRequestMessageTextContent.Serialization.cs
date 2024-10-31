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
    internal partial class InternalRequestMessageTextContent : IJsonModel<InternalRequestMessageTextContent>
    {
        internal InternalRequestMessageTextContent()
        {
        }

        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRequestMessageTextContent>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalRequestMessageTextContent)} does not support writing '{format}' format.");
            }
            base.JsonModelWriteCore(writer, options);
            if (_additionalBinaryDataProperties?.ContainsKey("type") != true)
            {
                writer.WritePropertyName("type"u8);
                writer.WriteStringValue(Type.ToString());
            }
            if (_additionalBinaryDataProperties?.ContainsKey("text") != true)
            {
                writer.WritePropertyName("text"u8);
                writer.WriteStringValue(InternalText);
            }
        }

        InternalRequestMessageTextContent IJsonModel<InternalRequestMessageTextContent>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => (InternalRequestMessageTextContent)JsonModelCreateCore(ref reader, options);

        protected override MessageContent JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRequestMessageTextContent>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalRequestMessageTextContent)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalRequestMessageTextContent(document.RootElement, options);
        }

        internal static InternalRequestMessageTextContent DeserializeInternalRequestMessageTextContent(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            InternalMessageRequestContentTextObjectType @type = default;
            string internalText = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("type"u8))
                {
                    @type = new InternalMessageRequestContentTextObjectType(prop.Value.GetString());
                    continue;
                }
                if (prop.NameEquals("text"u8))
                {
                    internalText = prop.Value.GetString();
                    continue;
                }
                if (true)
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new InternalRequestMessageTextContent(@type, internalText, additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<InternalRequestMessageTextContent>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected override BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRequestMessageTextContent>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalRequestMessageTextContent)} does not support writing '{options.Format}' format.");
            }
        }

        InternalRequestMessageTextContent IPersistableModel<InternalRequestMessageTextContent>.Create(BinaryData data, ModelReaderWriterOptions options) => (InternalRequestMessageTextContent)PersistableModelCreateCore(data, options);

        protected override MessageContent PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRequestMessageTextContent>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeInternalRequestMessageTextContent(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalRequestMessageTextContent)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalRequestMessageTextContent>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(InternalRequestMessageTextContent internalRequestMessageTextContent)
        {
            if (internalRequestMessageTextContent == null)
            {
                return null;
            }
            return BinaryContent.Create(internalRequestMessageTextContent, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator InternalRequestMessageTextContent(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeInternalRequestMessageTextContent(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
