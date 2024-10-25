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
    internal partial class InternalMessageDeltaContentImageUrlObject : IJsonModel<InternalMessageDeltaContentImageUrlObject>
    {
        internal InternalMessageDeltaContentImageUrlObject()
        {
        }

        void IJsonModel<InternalMessageDeltaContentImageUrlObject>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalMessageDeltaContentImageUrlObject>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalMessageDeltaContentImageUrlObject)} does not support writing '{format}' format.");
            }
            base.JsonModelWriteCore(writer, options);
            if (_additionalBinaryDataProperties?.ContainsKey("index") != true)
            {
                writer.WritePropertyName("index"u8);
            }
            writer.WriteNumberValue(Index);
            if (Optional.IsDefined(ImageUrl) && _additionalBinaryDataProperties?.ContainsKey("image_url") != true)
            {
                writer.WritePropertyName("image_url"u8);
                writer.WriteObjectValue(ImageUrl, options);
            }
        }

        InternalMessageDeltaContentImageUrlObject IJsonModel<InternalMessageDeltaContentImageUrlObject>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => (InternalMessageDeltaContentImageUrlObject)JsonModelCreateCore(ref reader, options);

        protected override InternalMessageDeltaContent JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalMessageDeltaContentImageUrlObject>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalMessageDeltaContentImageUrlObject)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalMessageDeltaContentImageUrlObject(document.RootElement, options);
        }

        internal static InternalMessageDeltaContentImageUrlObject DeserializeInternalMessageDeltaContentImageUrlObject(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            int index = default;
            InternalMessageDeltaContentImageUrlObjectImageUrl imageUrl = default;
            string @type = "image_url";
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("index"u8))
                {
                    index = prop.Value.GetInt32();
                    continue;
                }
                if (prop.NameEquals("image_url"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    imageUrl = InternalMessageDeltaContentImageUrlObjectImageUrl.DeserializeInternalMessageDeltaContentImageUrlObjectImageUrl(prop.Value, options);
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
            return new InternalMessageDeltaContentImageUrlObject(index, imageUrl, @type, additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<InternalMessageDeltaContentImageUrlObject>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected override BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalMessageDeltaContentImageUrlObject>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalMessageDeltaContentImageUrlObject)} does not support writing '{options.Format}' format.");
            }
        }

        InternalMessageDeltaContentImageUrlObject IPersistableModel<InternalMessageDeltaContentImageUrlObject>.Create(BinaryData data, ModelReaderWriterOptions options) => (InternalMessageDeltaContentImageUrlObject)PersistableModelCreateCore(data, options);

        protected override InternalMessageDeltaContent PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalMessageDeltaContentImageUrlObject>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeInternalMessageDeltaContentImageUrlObject(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalMessageDeltaContentImageUrlObject)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalMessageDeltaContentImageUrlObject>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(InternalMessageDeltaContentImageUrlObject internalMessageDeltaContentImageUrlObject)
        {
            return BinaryContent.Create(internalMessageDeltaContentImageUrlObject, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator InternalMessageDeltaContentImageUrlObject(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeInternalMessageDeltaContentImageUrlObject(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
