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
    internal partial class InternalMessageDeltaContentTextObject : IJsonModel<InternalMessageDeltaContentTextObject>
    {
        internal InternalMessageDeltaContentTextObject()
        {
        }

        void IJsonModel<InternalMessageDeltaContentTextObject>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalMessageDeltaContentTextObject>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalMessageDeltaContentTextObject)} does not support writing '{format}' format.");
            }
            base.JsonModelWriteCore(writer, options);
            if (_additionalBinaryDataProperties?.ContainsKey("index") != true)
            {
                writer.WritePropertyName("index"u8);
                writer.WriteNumberValue(Index);
            }
            if (Optional.IsDefined(Text) && _additionalBinaryDataProperties?.ContainsKey("text") != true)
            {
                writer.WritePropertyName("text"u8);
                writer.WriteObjectValue(Text, options);
            }
        }

        InternalMessageDeltaContentTextObject IJsonModel<InternalMessageDeltaContentTextObject>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => (InternalMessageDeltaContentTextObject)JsonModelCreateCore(ref reader, options);

        protected override InternalMessageDeltaContent JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalMessageDeltaContentTextObject>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalMessageDeltaContentTextObject)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalMessageDeltaContentTextObject(document.RootElement, options);
        }

        internal static InternalMessageDeltaContentTextObject DeserializeInternalMessageDeltaContentTextObject(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string @type = "text";
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            int index = default;
            InternalMessageDeltaContentTextObjectText text = default;
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("type"u8))
                {
                    @type = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("index"u8))
                {
                    index = prop.Value.GetInt32();
                    continue;
                }
                if (prop.NameEquals("text"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    text = InternalMessageDeltaContentTextObjectText.DeserializeInternalMessageDeltaContentTextObjectText(prop.Value, options);
                    continue;
                }
                additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
            }
            return new InternalMessageDeltaContentTextObject(@type, additionalBinaryDataProperties, index, text);
        }

        BinaryData IPersistableModel<InternalMessageDeltaContentTextObject>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected override BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalMessageDeltaContentTextObject>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalMessageDeltaContentTextObject)} does not support writing '{options.Format}' format.");
            }
        }

        InternalMessageDeltaContentTextObject IPersistableModel<InternalMessageDeltaContentTextObject>.Create(BinaryData data, ModelReaderWriterOptions options) => (InternalMessageDeltaContentTextObject)PersistableModelCreateCore(data, options);

        protected override InternalMessageDeltaContent PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalMessageDeltaContentTextObject>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeInternalMessageDeltaContentTextObject(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalMessageDeltaContentTextObject)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalMessageDeltaContentTextObject>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(InternalMessageDeltaContentTextObject internalMessageDeltaContentTextObject)
        {
            if (internalMessageDeltaContentTextObject == null)
            {
                return null;
            }
            return BinaryContent.Create(internalMessageDeltaContentTextObject, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator InternalMessageDeltaContentTextObject(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeInternalMessageDeltaContentTextObject(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
