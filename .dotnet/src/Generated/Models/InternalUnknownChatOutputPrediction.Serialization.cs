// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using OpenAI;

namespace OpenAI.Chat
{
    internal partial class InternalUnknownChatOutputPrediction : IJsonModel<ChatOutputPrediction>
    {
        internal InternalUnknownChatOutputPrediction()
        {
        }

        void IJsonModel<ChatOutputPrediction>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ChatOutputPrediction>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ChatOutputPrediction)} does not support writing '{format}' format.");
            }
            base.JsonModelWriteCore(writer, options);
        }

        ChatOutputPrediction IJsonModel<ChatOutputPrediction>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected override ChatOutputPrediction JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ChatOutputPrediction>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ChatOutputPrediction)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeChatOutputPrediction(document.RootElement, options);
        }

        internal static InternalUnknownChatOutputPrediction DeserializeInternalUnknownChatOutputPrediction(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            ChatOutputPredictionKind kind = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("type"u8))
                {
                    kind = new ChatOutputPredictionKind(prop.Value.GetString());
                    continue;
                }
                if (true)
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new InternalUnknownChatOutputPrediction(kind, additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<ChatOutputPrediction>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected override BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ChatOutputPrediction>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(ChatOutputPrediction)} does not support writing '{options.Format}' format.");
            }
        }

        ChatOutputPrediction IPersistableModel<ChatOutputPrediction>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        protected override ChatOutputPrediction PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ChatOutputPrediction>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeChatOutputPrediction(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(ChatOutputPrediction)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<ChatOutputPrediction>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
