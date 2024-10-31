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
    internal partial class InternalRealtimeRequestInputAudioBufferCommitCommand : IJsonModel<InternalRealtimeRequestInputAudioBufferCommitCommand>
    {
        void IJsonModel<InternalRealtimeRequestInputAudioBufferCommitCommand>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRealtimeRequestInputAudioBufferCommitCommand>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalRealtimeRequestInputAudioBufferCommitCommand)} does not support writing '{format}' format.");
            }
            base.JsonModelWriteCore(writer, options);
        }

        InternalRealtimeRequestInputAudioBufferCommitCommand IJsonModel<InternalRealtimeRequestInputAudioBufferCommitCommand>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => (InternalRealtimeRequestInputAudioBufferCommitCommand)JsonModelCreateCore(ref reader, options);

        protected override InternalRealtimeRequestCommand JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRealtimeRequestInputAudioBufferCommitCommand>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalRealtimeRequestInputAudioBufferCommitCommand)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalRealtimeRequestInputAudioBufferCommitCommand(document.RootElement, options);
        }

        internal static InternalRealtimeRequestInputAudioBufferCommitCommand DeserializeInternalRealtimeRequestInputAudioBufferCommitCommand(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            InternalRealtimeRequestCommandType kind = default;
            string eventId = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("type"u8))
                {
                    kind = new InternalRealtimeRequestCommandType(prop.Value.GetString());
                    continue;
                }
                if (prop.NameEquals("event_id"u8))
                {
                    eventId = prop.Value.GetString();
                    continue;
                }
                if (true)
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new InternalRealtimeRequestInputAudioBufferCommitCommand(kind, eventId, additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<InternalRealtimeRequestInputAudioBufferCommitCommand>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected override BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRealtimeRequestInputAudioBufferCommitCommand>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalRealtimeRequestInputAudioBufferCommitCommand)} does not support writing '{options.Format}' format.");
            }
        }

        InternalRealtimeRequestInputAudioBufferCommitCommand IPersistableModel<InternalRealtimeRequestInputAudioBufferCommitCommand>.Create(BinaryData data, ModelReaderWriterOptions options) => (InternalRealtimeRequestInputAudioBufferCommitCommand)PersistableModelCreateCore(data, options);

        protected override InternalRealtimeRequestCommand PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRealtimeRequestInputAudioBufferCommitCommand>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeInternalRealtimeRequestInputAudioBufferCommitCommand(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalRealtimeRequestInputAudioBufferCommitCommand)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalRealtimeRequestInputAudioBufferCommitCommand>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(InternalRealtimeRequestInputAudioBufferCommitCommand internalRealtimeRequestInputAudioBufferCommitCommand)
        {
            if (internalRealtimeRequestInputAudioBufferCommitCommand == null)
            {
                return null;
            }
            return BinaryContent.Create(internalRealtimeRequestInputAudioBufferCommitCommand, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator InternalRealtimeRequestInputAudioBufferCommitCommand(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeInternalRealtimeRequestInputAudioBufferCommitCommand(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
