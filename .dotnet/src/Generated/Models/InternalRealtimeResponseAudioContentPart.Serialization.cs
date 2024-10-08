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
    internal partial class InternalRealtimeResponseAudioContentPart : IJsonModel<InternalRealtimeResponseAudioContentPart>
    {
        internal InternalRealtimeResponseAudioContentPart()
        {
        }

        void IJsonModel<InternalRealtimeResponseAudioContentPart>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRealtimeResponseAudioContentPart>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalRealtimeResponseAudioContentPart)} does not support writing '{format}' format.");
            }
            base.JsonModelWriteCore(writer, options);
            if (Transcript != null)
            {
                writer.WritePropertyName("transcript"u8);
                writer.WriteStringValue(Transcript);
            }
            else
            {
                writer.WriteNull("transcript"u8);
            }
        }

        InternalRealtimeResponseAudioContentPart IJsonModel<InternalRealtimeResponseAudioContentPart>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => (InternalRealtimeResponseAudioContentPart)JsonModelCreateCore(ref reader, options);

        protected override ConversationContentPart JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRealtimeResponseAudioContentPart>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalRealtimeResponseAudioContentPart)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalRealtimeResponseAudioContentPart(document.RootElement, options);
        }

        internal static InternalRealtimeResponseAudioContentPart DeserializeInternalRealtimeResponseAudioContentPart(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string transcript = default;
            ConversationContentPartKind @type = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("transcript"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        transcript = null;
                        continue;
                    }
                    transcript = prop.Value.GetString();
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
            return new InternalRealtimeResponseAudioContentPart(transcript, @type, additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<InternalRealtimeResponseAudioContentPart>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected override BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRealtimeResponseAudioContentPart>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalRealtimeResponseAudioContentPart)} does not support writing '{options.Format}' format.");
            }
        }

        InternalRealtimeResponseAudioContentPart IPersistableModel<InternalRealtimeResponseAudioContentPart>.Create(BinaryData data, ModelReaderWriterOptions options) => (InternalRealtimeResponseAudioContentPart)PersistableModelCreateCore(data, options);

        protected override ConversationContentPart PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRealtimeResponseAudioContentPart>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeInternalRealtimeResponseAudioContentPart(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalRealtimeResponseAudioContentPart)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalRealtimeResponseAudioContentPart>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(InternalRealtimeResponseAudioContentPart internalRealtimeResponseAudioContentPart)
        {
            return BinaryContent.Create(internalRealtimeResponseAudioContentPart, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator InternalRealtimeResponseAudioContentPart(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeInternalRealtimeResponseAudioContentPart(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
