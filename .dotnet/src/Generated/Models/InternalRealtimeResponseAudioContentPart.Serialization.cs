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
            if (_additionalBinaryDataProperties?.ContainsKey("type") != true)
            {
                writer.WritePropertyName("type"u8);
                writer.WriteStringValue(Type);
            }
            if (_additionalBinaryDataProperties?.ContainsKey("transcript") != true)
            {
                if (InternalTranscriptValue != null)
                {
                    writer.WritePropertyName("transcript"u8);
                    writer.WriteStringValue(InternalTranscriptValue);
                }
                else
                {
                    writer.WriteNull("transcript"u8);
                }
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
            ConversationContentPartKind kind = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            string @type = "audio";
            string internalTranscriptValue = default;
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("type"u8))
                {
                    kind = new ConversationContentPartKind(prop.Value.GetString());
                    continue;
                }
                if (prop.NameEquals("type"u8))
                {
                    @type = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("transcript"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        internalTranscriptValue = null;
                        continue;
                    }
                    internalTranscriptValue = prop.Value.GetString();
                    continue;
                }
                additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
            }
            return new InternalRealtimeResponseAudioContentPart(kind, additionalBinaryDataProperties, @type, internalTranscriptValue);
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
            if (internalRealtimeResponseAudioContentPart == null)
            {
                return null;
            }
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
