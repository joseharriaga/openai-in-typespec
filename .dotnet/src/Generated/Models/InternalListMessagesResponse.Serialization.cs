// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Assistants
{
    internal partial class InternalListMessagesResponse : IJsonModel<InternalListMessagesResponse>
    {
        void IJsonModel<InternalListMessagesResponse>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalListMessagesResponse>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalListMessagesResponse)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            if (SerializedAdditionalRawData?.ContainsKey("object") != true)
            {
                writer.WritePropertyName("object"u8);
                writer.WriteStringValue(Object.ToString());
            }
            if (SerializedAdditionalRawData?.ContainsKey("data") != true)
            {
                writer.WritePropertyName("data"u8);
                writer.WriteStartArray();
                foreach (var item in Data)
                {
                    writer.WriteObjectValue(item, options);
                }
                writer.WriteEndArray();
            }
            if (SerializedAdditionalRawData?.ContainsKey("first_id") != true)
            {
                writer.WritePropertyName("first_id"u8);
                writer.WriteStringValue(FirstId);
            }
            if (SerializedAdditionalRawData?.ContainsKey("last_id") != true)
            {
                writer.WritePropertyName("last_id"u8);
                writer.WriteStringValue(LastId);
            }
            if (SerializedAdditionalRawData?.ContainsKey("has_more") != true)
            {
                writer.WritePropertyName("has_more"u8);
                writer.WriteBooleanValue(HasMore);
            }
            foreach (var item in SerializedAdditionalRawData ?? new System.Collections.Generic.Dictionary<string, BinaryData>())
            {
                if (ModelSerializationExtensions.IsSentinelValue(item.Value))
                {
                    continue;
                }
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
            writer.WriteEndObject();
        }

        InternalListMessagesResponse IJsonModel<InternalListMessagesResponse>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalListMessagesResponse>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalListMessagesResponse)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalListMessagesResponse(document.RootElement, options);
        }

        internal static InternalListMessagesResponse DeserializeInternalListMessagesResponse(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            InternalListMessagesResponseObject @object = default;
            IReadOnlyList<ThreadMessage> data = default;
            string firstId = default;
            string lastId = default;
            bool hasMore = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("object"u8))
                {
                    @object = new InternalListMessagesResponseObject(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("data"u8))
                {
                    List<ThreadMessage> array = new List<ThreadMessage>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(ThreadMessage.DeserializeThreadMessage(item, options));
                    }
                    data = array;
                    continue;
                }
                if (property.NameEquals("first_id"u8))
                {
                    firstId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("last_id"u8))
                {
                    lastId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("has_more"u8))
                {
                    hasMore = property.Value.GetBoolean();
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary ??= new Dictionary<string, BinaryData>();
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new InternalListMessagesResponse(
                @object,
                data,
                firstId,
                lastId,
                hasMore,
                serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<InternalListMessagesResponse>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalListMessagesResponse>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalListMessagesResponse)} does not support writing '{options.Format}' format.");
            }
        }

        InternalListMessagesResponse IPersistableModel<InternalListMessagesResponse>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalListMessagesResponse>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeInternalListMessagesResponse(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalListMessagesResponse)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalListMessagesResponse>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        internal static InternalListMessagesResponse FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeInternalListMessagesResponse(document.RootElement);
        }

        internal virtual BinaryContent ToBinaryContent()
        {
            return BinaryContent.Create(this, ModelSerializationExtensions.WireOptions);
        }
    }
}
