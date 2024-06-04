// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using OpenAI.Chat;

namespace OpenAI.Internal.Models
{
    internal partial class FinetuneChatRequestInput : IJsonModel<FinetuneChatRequestInput>
    {
        void IJsonModel<FinetuneChatRequestInput>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<FinetuneChatRequestInput>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(FinetuneChatRequestInput)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            if (Optional.IsCollectionDefined(Messages))
            {
                writer.WritePropertyName("messages"u8);
                writer.WriteStartArray();
                foreach (var item in Messages)
                {
                    if (item == null)
                    {
                        writer.WriteNullValue();
                        continue;
                    }
#if NET6_0_OR_GREATER
				writer.WriteRawValue(item);
#else
                    using (JsonDocument document = JsonDocument.Parse(item))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(Functions))
            {
                writer.WritePropertyName("functions"u8);
                writer.WriteStartArray();
                foreach (var item in Functions)
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

        FinetuneChatRequestInput IJsonModel<FinetuneChatRequestInput>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<FinetuneChatRequestInput>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(FinetuneChatRequestInput)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeFinetuneChatRequestInput(document.RootElement, options);
        }

        internal static FinetuneChatRequestInput DeserializeFinetuneChatRequestInput(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IReadOnlyList<BinaryData> messages = default;
            IReadOnlyList<ChatFunction> functions = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("messages"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<BinaryData> array = new List<BinaryData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        if (item.ValueKind == JsonValueKind.Null)
                        {
                            array.Add(null);
                        }
                        else
                        {
                            array.Add(BinaryData.FromString(item.GetRawText()));
                        }
                    }
                    messages = array;
                    continue;
                }
                if (property.NameEquals("functions"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<ChatFunction> array = new List<ChatFunction>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(ChatFunction.DeserializeChatFunction(item, options));
                    }
                    functions = array;
                    continue;
                }
                if (true)
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new FinetuneChatRequestInput(messages ?? new ChangeTrackingList<BinaryData>(), functions ?? new ChangeTrackingList<ChatFunction>(), serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<FinetuneChatRequestInput>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<FinetuneChatRequestInput>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(FinetuneChatRequestInput)} does not support writing '{options.Format}' format.");
            }
        }

        FinetuneChatRequestInput IPersistableModel<FinetuneChatRequestInput>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<FinetuneChatRequestInput>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeFinetuneChatRequestInput(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(FinetuneChatRequestInput)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<FinetuneChatRequestInput>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        internal static FinetuneChatRequestInput FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeFinetuneChatRequestInput(document.RootElement);
        }

        internal virtual BinaryContent ToBinaryContent()
        {
            return BinaryContent.Create(this, ModelSerializationExtensions.WireOptions);
        }
    }
}