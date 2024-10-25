// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using OpenAI;

namespace OpenAI.RealtimeConversation
{
    internal partial class InternalRealtimeResponseTextContentPart : IJsonModel<InternalRealtimeResponseTextContentPart>
    {
        internal InternalRealtimeResponseTextContentPart()
        {
        }

        void IJsonModel<InternalRealtimeResponseTextContentPart>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRealtimeResponseTextContentPart>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalRealtimeResponseTextContentPart)} does not support writing '{format}' format.");
            }
            base.JsonModelWriteCore(writer, options);
            if (_additionalBinaryDataProperties?.ContainsKey("text") != true)
            {
                writer.WritePropertyName("text"u8);
            }
            writer.WriteStringValue(Text);
        }

        InternalRealtimeResponseTextContentPart IJsonModel<InternalRealtimeResponseTextContentPart>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => (InternalRealtimeResponseTextContentPart)JsonModelCreateCore(ref reader, options);

        protected override ConversationContentPart JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRealtimeResponseTextContentPart>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalRealtimeResponseTextContentPart)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalRealtimeResponseTextContentPart(document.RootElement, options);
        }

        internal static InternalRealtimeResponseTextContentPart DeserializeInternalRealtimeResponseTextContentPart(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string text = default;
            ConversationContentPartKind @type = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("text"u8))
                {
                    text = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("type"u8))
                {
                    @type = new ConversationContentPartKind(prop.Value.GetString());
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new InternalRealtimeResponseTextContentPart(text, @type, additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<InternalRealtimeResponseTextContentPart>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected override BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRealtimeResponseTextContentPart>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalRealtimeResponseTextContentPart)} does not support writing '{options.Format}' format.");
            }
        }

        InternalRealtimeResponseTextContentPart IPersistableModel<InternalRealtimeResponseTextContentPart>.Create(BinaryData data, ModelReaderWriterOptions options) => (InternalRealtimeResponseTextContentPart)PersistableModelCreateCore(data, options);

        protected override ConversationContentPart PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRealtimeResponseTextContentPart>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeInternalRealtimeResponseTextContentPart(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalRealtimeResponseTextContentPart)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalRealtimeResponseTextContentPart>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(InternalRealtimeResponseTextContentPart internalRealtimeResponseTextContentPart)
        {
            return BinaryContent.Create(internalRealtimeResponseTextContentPart, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator InternalRealtimeResponseTextContentPart(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeInternalRealtimeResponseTextContentPart(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
