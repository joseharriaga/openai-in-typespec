// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Internal.Models
{
    internal partial class MessageIncompleteStreamEvent : IJsonModel<MessageIncompleteStreamEvent>
    {
        void IJsonModel<MessageIncompleteStreamEvent>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<MessageIncompleteStreamEvent>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(MessageIncompleteStreamEvent)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("event"u8);
            writer.WriteStringValue(Event.ToString());
            writer.WritePropertyName("data"u8);
            writer.WriteObjectValue<MessageObject>(Data, options);
            if (options.Format != "W" && _serializedAdditionalRawData != null)
            {
                foreach (var item in _serializedAdditionalRawData)
                {
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(item.Value);
#else
                    using (JsonDocument document = JsonDocument.Parse(item.Value))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
            writer.WriteEndObject();
        }

        MessageIncompleteStreamEvent IJsonModel<MessageIncompleteStreamEvent>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<MessageIncompleteStreamEvent>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(MessageIncompleteStreamEvent)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeMessageIncompleteStreamEvent(document.RootElement, options);
        }

        internal static MessageIncompleteStreamEvent DeserializeMessageIncompleteStreamEvent(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            MessageIncompleteStreamEventEvent @event = default;
            MessageObject data = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("event"u8))
                {
                    @event = new MessageIncompleteStreamEventEvent(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("data"u8))
                {
                    data = MessageObject.DeserializeMessageObject(property.Value, options);
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new MessageIncompleteStreamEvent(@event, data, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<MessageIncompleteStreamEvent>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<MessageIncompleteStreamEvent>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(MessageIncompleteStreamEvent)} does not support writing '{options.Format}' format.");
            }
        }

        MessageIncompleteStreamEvent IPersistableModel<MessageIncompleteStreamEvent>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<MessageIncompleteStreamEvent>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeMessageIncompleteStreamEvent(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(MessageIncompleteStreamEvent)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<MessageIncompleteStreamEvent>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The result to deserialize the model from. </param>
        internal static MessageIncompleteStreamEvent FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeMessageIncompleteStreamEvent(document.RootElement);
        }

        /// <summary> Convert into a Utf8JsonRequestBody. </summary>
        internal virtual BinaryContent ToBinaryBody()
        {
            return BinaryContent.Create(this, new ModelReaderWriterOptions("W"));
        }
    }
}
