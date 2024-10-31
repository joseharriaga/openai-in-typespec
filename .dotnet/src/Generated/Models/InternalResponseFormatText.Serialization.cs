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
    internal partial class InternalResponseFormatText : IJsonModel<InternalResponseFormatText>
    {
        void IJsonModel<InternalResponseFormatText>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalResponseFormatText>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalResponseFormatText)} does not support writing '{format}' format.");
            }
            base.JsonModelWriteCore(writer, options);
        }

        InternalResponseFormatText IJsonModel<InternalResponseFormatText>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => (InternalResponseFormatText)JsonModelCreateCore(ref reader, options);

        protected override InternalOmniTypedResponseFormat JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalResponseFormatText>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalResponseFormatText)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalResponseFormatText(document.RootElement, options);
        }

        internal static InternalResponseFormatText DeserializeInternalResponseFormatText(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string @type = "text";
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
            return new InternalResponseFormatText(@type, additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<InternalResponseFormatText>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected override BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalResponseFormatText>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalResponseFormatText)} does not support writing '{options.Format}' format.");
            }
        }

        InternalResponseFormatText IPersistableModel<InternalResponseFormatText>.Create(BinaryData data, ModelReaderWriterOptions options) => (InternalResponseFormatText)PersistableModelCreateCore(data, options);

        protected override InternalOmniTypedResponseFormat PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalResponseFormatText>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeInternalResponseFormatText(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalResponseFormatText)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalResponseFormatText>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(InternalResponseFormatText internalResponseFormatText)
        {
            if (internalResponseFormatText == null)
            {
                return null;
            }
            return BinaryContent.Create(internalResponseFormatText, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator InternalResponseFormatText(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeInternalResponseFormatText(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
