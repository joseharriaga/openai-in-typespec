// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using OpenAI;

namespace OpenAI.RealtimeConversation
{
    internal partial class UnknownRealtimeRequestCommand : IJsonModel<InternalRealtimeRequestCommand>
    {
        internal UnknownRealtimeRequestCommand()
        {
        }

        void IJsonModel<InternalRealtimeRequestCommand>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRealtimeRequestCommand>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalRealtimeRequestCommand)} does not support writing '{format}' format.");
            }
            base.JsonModelWriteCore(writer, options);
        }

        InternalRealtimeRequestCommand IJsonModel<InternalRealtimeRequestCommand>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => (UnknownRealtimeRequestCommand)JsonModelCreateCore(ref reader, options);

        protected override InternalRealtimeRequestCommand JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRealtimeRequestCommand>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalRealtimeRequestCommand)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalRealtimeRequestCommand(document.RootElement, options);
        }

        internal static UnknownRealtimeRequestCommand DeserializeUnknownRealtimeRequestCommand(JsonElement element, ModelReaderWriterOptions options)
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
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        eventId = null;
                        continue;
                    }
                    eventId = prop.Value.GetString();
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new UnknownRealtimeRequestCommand(kind, eventId, additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<InternalRealtimeRequestCommand>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected override BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRealtimeRequestCommand>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalRealtimeRequestCommand)} does not support writing '{options.Format}' format.");
            }
        }

        InternalRealtimeRequestCommand IPersistableModel<InternalRealtimeRequestCommand>.Create(BinaryData data, ModelReaderWriterOptions options) => (UnknownRealtimeRequestCommand)PersistableModelCreateCore(data, options);

        protected override InternalRealtimeRequestCommand PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRealtimeRequestCommand>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeInternalRealtimeRequestCommand(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalRealtimeRequestCommand)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalRealtimeRequestCommand>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
