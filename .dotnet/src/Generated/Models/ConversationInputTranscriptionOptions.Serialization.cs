// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.RealtimeConversation
{
    public partial class ConversationInputTranscriptionOptions : IJsonModel<ConversationInputTranscriptionOptions>
    {
        void IJsonModel<ConversationInputTranscriptionOptions>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ConversationInputTranscriptionOptions>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ConversationInputTranscriptionOptions)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            if (SerializedAdditionalRawData?.ContainsKey("model") != true && Optional.IsDefined(Model))
            {
                writer.WritePropertyName("model"u8);
                writer.WriteStringValue(Model.Value.ToString());
            }
            if (SerializedAdditionalRawData?.ContainsKey("enabled") != true && Optional.IsDefined(Enabled))
            {
                writer.WritePropertyName("enabled"u8);
                writer.WriteBooleanValue(Enabled.Value);
            }
            if (SerializedAdditionalRawData != null)
            {
                foreach (var item in SerializedAdditionalRawData)
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
            }
            writer.WriteEndObject();
        }

        ConversationInputTranscriptionOptions IJsonModel<ConversationInputTranscriptionOptions>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ConversationInputTranscriptionOptions>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ConversationInputTranscriptionOptions)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeConversationInputTranscriptionOptions(document.RootElement, options);
        }

        internal static ConversationInputTranscriptionOptions DeserializeConversationInputTranscriptionOptions(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            ConversationTranscriptionModel? model = default;
            bool? enabled = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("model"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    model = new ConversationTranscriptionModel(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("enabled"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    enabled = property.Value.GetBoolean();
                    continue;
                }
                if (true)
                {
                    rawDataDictionary ??= new Dictionary<string, BinaryData>();
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new ConversationInputTranscriptionOptions(model, enabled, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<ConversationInputTranscriptionOptions>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ConversationInputTranscriptionOptions>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(ConversationInputTranscriptionOptions)} does not support writing '{options.Format}' format.");
            }
        }

        ConversationInputTranscriptionOptions IPersistableModel<ConversationInputTranscriptionOptions>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ConversationInputTranscriptionOptions>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeConversationInputTranscriptionOptions(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(ConversationInputTranscriptionOptions)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<ConversationInputTranscriptionOptions>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        internal static ConversationInputTranscriptionOptions FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeConversationInputTranscriptionOptions(document.RootElement);
        }

        internal virtual BinaryContent ToBinaryContent()
        {
            return BinaryContent.Create(this, ModelSerializationExtensions.WireOptions);
        }
    }
}
