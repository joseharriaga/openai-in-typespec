// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using OpenAI;

namespace OpenAI.LegacyCompletions
{
    internal partial class InternalCreateCompletionResponseChoiceLogprobs : IJsonModel<InternalCreateCompletionResponseChoiceLogprobs>
    {
        void IJsonModel<InternalCreateCompletionResponseChoiceLogprobs>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalCreateCompletionResponseChoiceLogprobs>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalCreateCompletionResponseChoiceLogprobs)} does not support writing '{format}' format.");
            }
            if (Optional.IsCollectionDefined(TextOffset) && _additionalBinaryDataProperties?.ContainsKey("text_offset") != true)
            {
                writer.WritePropertyName("text_offset"u8);
                writer.WriteStartArray();
                foreach (int item in TextOffset)
                {
                    writer.WriteNumberValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(TokenLogprobs) && _additionalBinaryDataProperties?.ContainsKey("token_logprobs") != true)
            {
                writer.WritePropertyName("token_logprobs"u8);
                writer.WriteStartArray();
                foreach (float item in TokenLogprobs)
                {
                    writer.WriteNumberValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(Tokens) && _additionalBinaryDataProperties?.ContainsKey("tokens") != true)
            {
                writer.WritePropertyName("tokens"u8);
                writer.WriteStartArray();
                foreach (string item in Tokens)
                {
                    if (item == null)
                    {
                        writer.WriteNullValue();
                        continue;
                    }
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(TopLogprobs) && _additionalBinaryDataProperties?.ContainsKey("top_logprobs") != true)
            {
                writer.WritePropertyName("top_logprobs"u8);
                writer.WriteStartArray();
                foreach (IDictionary<string, float> item in TopLogprobs)
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
            if (options.Format != "W" && _additionalBinaryDataProperties != null)
            {
                foreach (var item in _additionalBinaryDataProperties)
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
        }

        InternalCreateCompletionResponseChoiceLogprobs IJsonModel<InternalCreateCompletionResponseChoiceLogprobs>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual InternalCreateCompletionResponseChoiceLogprobs JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalCreateCompletionResponseChoiceLogprobs>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalCreateCompletionResponseChoiceLogprobs)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalCreateCompletionResponseChoiceLogprobs(document.RootElement, options);
        }

        internal static InternalCreateCompletionResponseChoiceLogprobs DeserializeInternalCreateCompletionResponseChoiceLogprobs(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IList<int> textOffset = default;
            IList<float> tokenLogprobs = default;
            IList<string> tokens = default;
            IList<IDictionary<string, float>> topLogprobs = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("text_offset"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<int> array = new List<int>();
                    foreach (var item in prop.Value.EnumerateArray())
                    {
                        array.Add(item.GetInt32());
                    }
                    textOffset = array;
                    continue;
                }
                if (prop.NameEquals("token_logprobs"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<float> array = new List<float>();
                    foreach (var item in prop.Value.EnumerateArray())
                    {
                        array.Add(item.GetSingle());
                    }
                    tokenLogprobs = array;
                    continue;
                }
                if (prop.NameEquals("tokens"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<string> array = new List<string>();
                    foreach (var item in prop.Value.EnumerateArray())
                    {
                        if (item.ValueKind == JsonValueKind.Null)
                        {
                            array.Add(null);
                        }
                        else
                        {
                            array.Add(item.GetString());
                        }
                    }
                    tokens = array;
                    continue;
                }
                if (prop.NameEquals("top_logprobs"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<IDictionary<string, float>> array = new List<IDictionary<string, float>>();
                    foreach (var item in prop.Value.EnumerateArray())
                    {
                        if (item.ValueKind == JsonValueKind.Null)
                        {
                            array.Add(null);
                        }
                        else
                        {
                            Dictionary<string, float> dictionary = new Dictionary<string, float>();
                            foreach (var prop0 in item.EnumerateObject())
                            {
                                dictionary.Add(prop0.Name, prop0.Value.GetSingle());
                            }
                            array.Add(dictionary);
                        }
                    }
                    topLogprobs = array;
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new InternalCreateCompletionResponseChoiceLogprobs(textOffset ?? new ChangeTrackingList<int>(), tokenLogprobs ?? new ChangeTrackingList<float>(), tokens ?? new ChangeTrackingList<string>(), topLogprobs ?? new ChangeTrackingList<IDictionary<string, float>>(), additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<InternalCreateCompletionResponseChoiceLogprobs>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalCreateCompletionResponseChoiceLogprobs>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalCreateCompletionResponseChoiceLogprobs)} does not support writing '{options.Format}' format.");
            }
        }

        InternalCreateCompletionResponseChoiceLogprobs IPersistableModel<InternalCreateCompletionResponseChoiceLogprobs>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        protected virtual InternalCreateCompletionResponseChoiceLogprobs PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalCreateCompletionResponseChoiceLogprobs>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeInternalCreateCompletionResponseChoiceLogprobs(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalCreateCompletionResponseChoiceLogprobs)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalCreateCompletionResponseChoiceLogprobs>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(InternalCreateCompletionResponseChoiceLogprobs internalCreateCompletionResponseChoiceLogprobs)
        {
            return BinaryContent.Create(internalCreateCompletionResponseChoiceLogprobs, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator InternalCreateCompletionResponseChoiceLogprobs(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeInternalCreateCompletionResponseChoiceLogprobs(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
