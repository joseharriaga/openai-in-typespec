// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.LegacyCompletions
{
    internal partial class InternalCreateCompletionResponseChoiceLogprobs : IJsonModel<InternalCreateCompletionResponseChoiceLogprobs>
    {
        void IJsonModel<InternalCreateCompletionResponseChoiceLogprobs>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalCreateCompletionResponseChoiceLogprobs>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalCreateCompletionResponseChoiceLogprobs)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            if (Optional.IsCollectionDefined(TextOffset))
            {
                writer.WritePropertyName("text_offset"u8);
                writer.WriteStartArray();
                foreach (var item in TextOffset)
                {
                    writer.WriteNumberValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(TokenLogprobs))
            {
                writer.WritePropertyName("token_logprobs"u8);
                writer.WriteStartArray();
                foreach (var item in TokenLogprobs)
                {
                    writer.WriteNumberValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(Tokens))
            {
                writer.WritePropertyName("tokens"u8);
                writer.WriteStartArray();
                foreach (var item in Tokens)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(TopLogprobs))
            {
                writer.WritePropertyName("top_logprobs"u8);
                writer.WriteStartArray();
                foreach (var item in TopLogprobs)
                {
                    if (item == null)
                    {
                        writer.WriteNullValue();
                        continue;
                    }
                    writer.WriteStartObject();
                    foreach (var item0 in item)
                    {
                        writer.WritePropertyName(item0.Key);
                        writer.WriteNumberValue(item0.Value);
                    }
                    writer.WriteEndObject();
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

        InternalCreateCompletionResponseChoiceLogprobs IJsonModel<InternalCreateCompletionResponseChoiceLogprobs>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalCreateCompletionResponseChoiceLogprobs>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalCreateCompletionResponseChoiceLogprobs)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalCreateCompletionResponseChoiceLogprobs(document.RootElement, options);
        }

        internal static InternalCreateCompletionResponseChoiceLogprobs DeserializeInternalCreateCompletionResponseChoiceLogprobs(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IReadOnlyList<int> textOffset = default;
            IReadOnlyList<float> tokenLogprobs = default;
            IReadOnlyList<string> tokens = default;
            IReadOnlyList<IDictionary<string, float>> topLogprobs = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("text_offset"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<int> array = new List<int>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetInt32());
                    }
                    textOffset = array;
                    continue;
                }
                if (property.NameEquals("token_logprobs"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<float> array = new List<float>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetSingle());
                    }
                    tokenLogprobs = array;
                    continue;
                }
                if (property.NameEquals("tokens"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    tokens = array;
                    continue;
                }
                if (property.NameEquals("top_logprobs"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<IDictionary<string, float>> array = new List<IDictionary<string, float>>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        if (item.ValueKind == JsonValueKind.Null)
                        {
                            array.Add(null);
                        }
                        else
                        {
                            Dictionary<string, float> dictionary = new Dictionary<string, float>();
                            foreach (var property0 in item.EnumerateObject())
                            {
                                dictionary.Add(property0.Name, property0.Value.GetSingle());
                            }
                            array.Add(dictionary);
                        }
                    }
                    topLogprobs = array;
                    continue;
                }
                if (true)
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new InternalCreateCompletionResponseChoiceLogprobs(textOffset ?? new ChangeTrackingList<int>(), tokenLogprobs ?? new ChangeTrackingList<float>(), tokens ?? new ChangeTrackingList<string>(), topLogprobs ?? new ChangeTrackingList<IDictionary<string, float>>(), serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<InternalCreateCompletionResponseChoiceLogprobs>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalCreateCompletionResponseChoiceLogprobs>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalCreateCompletionResponseChoiceLogprobs)} does not support writing '{options.Format}' format.");
            }
        }

        InternalCreateCompletionResponseChoiceLogprobs IPersistableModel<InternalCreateCompletionResponseChoiceLogprobs>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalCreateCompletionResponseChoiceLogprobs>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeInternalCreateCompletionResponseChoiceLogprobs(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalCreateCompletionResponseChoiceLogprobs)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalCreateCompletionResponseChoiceLogprobs>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        internal static InternalCreateCompletionResponseChoiceLogprobs FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeInternalCreateCompletionResponseChoiceLogprobs(document.RootElement);
        }

        internal virtual BinaryContent ToBinaryContent()
        {
            return BinaryContent.Create(this, ModelSerializationExtensions.WireOptions);
        }
    }
}
