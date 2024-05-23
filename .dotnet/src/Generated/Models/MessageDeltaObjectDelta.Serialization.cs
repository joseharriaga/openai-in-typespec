// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Assistants
{
    internal partial class MessageDeltaObjectDelta : IJsonModel<MessageDeltaObjectDelta>
    {
        void IJsonModel<MessageDeltaObjectDelta>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<MessageDeltaObjectDelta>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(MessageDeltaObjectDelta)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("role"u8);
            writer.WriteStringValue(Role.ToSerialString());
            if (Optional.IsCollectionDefined(Content))
            {
                writer.WritePropertyName("content"u8);
                writer.WriteStartArray();
                foreach (var item in Content)
                {
                    writer.WriteObjectValue(item, options);
                }
                writer.WriteEndArray();
            }
            if (true && _serializedAdditionalRawData != null)
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

        MessageDeltaObjectDelta IJsonModel<MessageDeltaObjectDelta>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<MessageDeltaObjectDelta>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(MessageDeltaObjectDelta)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeMessageDeltaObjectDelta(document.RootElement, options);
        }

        internal static MessageDeltaObjectDelta DeserializeMessageDeltaObjectDelta(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            MessageRole role = default;
            IReadOnlyList<MessageDeltaContent> content = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("role"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    role = property.Value.GetString().ToMessageRole();
                    continue;
                }
                if (property.NameEquals("content"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<MessageDeltaContent> array = new List<MessageDeltaContent>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(MessageDeltaContent.DeserializeMessageDeltaContent(item, options));
                    }
                    content = array;
                    continue;
                }
                if (true)
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new MessageDeltaObjectDelta(role, content ?? new ChangeTrackingList<MessageDeltaContent>(), serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<MessageDeltaObjectDelta>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<MessageDeltaObjectDelta>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(MessageDeltaObjectDelta)} does not support writing '{options.Format}' format.");
            }
        }

        MessageDeltaObjectDelta IPersistableModel<MessageDeltaObjectDelta>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<MessageDeltaObjectDelta>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeMessageDeltaObjectDelta(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(MessageDeltaObjectDelta)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<MessageDeltaObjectDelta>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The result to deserialize the model from. </param>
        internal static MessageDeltaObjectDelta FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeMessageDeltaObjectDelta(document.RootElement);
        }

        /// <summary> Convert into a <see cref="BinaryContent"/>. </summary>
        internal virtual BinaryContent ToBinaryContent()
        {
            return BinaryContent.Create(this, ModelSerializationExtensions.WireOptions);
        }
    }
}
