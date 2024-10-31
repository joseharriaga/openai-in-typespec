// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using OpenAI;

namespace OpenAI.Chat
{
    internal partial class InternalChatResponseFormatJsonObject : IJsonModel<InternalChatResponseFormatJsonObject>
    {
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalChatResponseFormatJsonObject>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalChatResponseFormatJsonObject)} does not support writing '{format}' format.");
            }
            base.JsonModelWriteCore(writer, options);
        }

        InternalChatResponseFormatJsonObject IJsonModel<InternalChatResponseFormatJsonObject>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => (InternalChatResponseFormatJsonObject)JsonModelCreateCore(ref reader, options);

        protected override ChatResponseFormat JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalChatResponseFormatJsonObject>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalChatResponseFormatJsonObject)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalChatResponseFormatJsonObject(document.RootElement, options);
        }

        internal static InternalChatResponseFormatJsonObject DeserializeInternalChatResponseFormatJsonObject(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string @type = "json_object";
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
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
            return new InternalChatResponseFormatJsonObject(@type, additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<InternalChatResponseFormatJsonObject>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected override BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalChatResponseFormatJsonObject>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalChatResponseFormatJsonObject)} does not support writing '{options.Format}' format.");
            }
        }

        InternalChatResponseFormatJsonObject IPersistableModel<InternalChatResponseFormatJsonObject>.Create(BinaryData data, ModelReaderWriterOptions options) => (InternalChatResponseFormatJsonObject)PersistableModelCreateCore(data, options);

        protected override ChatResponseFormat PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalChatResponseFormatJsonObject>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeInternalChatResponseFormatJsonObject(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalChatResponseFormatJsonObject)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalChatResponseFormatJsonObject>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(InternalChatResponseFormatJsonObject internalChatResponseFormatJsonObject)
        {
            if (internalChatResponseFormatJsonObject == null)
            {
                return null;
            }
            return BinaryContent.Create(internalChatResponseFormatJsonObject, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator InternalChatResponseFormatJsonObject(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeInternalChatResponseFormatJsonObject(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
