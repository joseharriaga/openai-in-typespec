// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using OpenAI;

namespace OpenAI.Audio
{
    public partial class AudioTranscriptionOptions : IJsonModel<AudioTranscriptionOptions>
    {
        void IJsonModel<AudioTranscriptionOptions>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<AudioTranscriptionOptions>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(AudioTranscriptionOptions)} does not support writing '{format}' format.");
            }
            if (Optional.IsDefined(Language))
            {
                writer.WritePropertyName("language"u8);
                writer.WriteStringValue(Language);
            }
            if (Optional.IsDefined(Prompt))
            {
                writer.WritePropertyName("prompt"u8);
                writer.WriteStringValue(Prompt);
            }
            if (Optional.IsDefined(ResponseFormat))
            {
                writer.WritePropertyName("response_format"u8);
                writer.WriteStringValue(ResponseFormat.Value.ToString());
            }
            if (Optional.IsDefined(Temperature))
            {
                writer.WritePropertyName("temperature"u8);
                writer.WriteNumberValue(Temperature.Value);
            }
            writer.WritePropertyName("file"u8);
            writer.WriteBase64StringValue(File.ToArray(), "D");
            writer.WritePropertyName("model"u8);
            writer.WriteObjectValue<InternalCreateTranscriptionRequestModel>(Model, options);
            if (Optional.IsCollectionDefined(InternalTimestampGranularities))
            {
                writer.WritePropertyName("timestamp_granularities"u8);
                writer.WriteStartArray();
                foreach (BinaryData item in InternalTimestampGranularities)
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
            if (options.Format != "W" && _additionalBinaryDataProperties != null)
            {
                foreach (var item in _additionalBinaryDataProperties)
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
        }

        AudioTranscriptionOptions IJsonModel<AudioTranscriptionOptions>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual AudioTranscriptionOptions JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<AudioTranscriptionOptions>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(AudioTranscriptionOptions)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeAudioTranscriptionOptions(document.RootElement, options);
        }

        internal static AudioTranscriptionOptions DeserializeAudioTranscriptionOptions(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string language = default;
            string prompt = default;
            AudioTranscriptionFormat? responseFormat = default;
            float? temperature = default;
            BinaryData @file = default;
            InternalCreateTranscriptionRequestModel model = default;
            IList<BinaryData> internalTimestampGranularities = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("language"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        language = null;
                        continue;
                    }
                    language = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("prompt"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        prompt = null;
                        continue;
                    }
                    prompt = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("response_format"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        responseFormat = null;
                        continue;
                    }
                    responseFormat = new AudioTranscriptionFormat(prop.Value.GetString());
                    continue;
                }
                if (prop.NameEquals("temperature"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        temperature = null;
                        continue;
                    }
                    temperature = prop.Value.GetSingle();
                    continue;
                }
                if (prop.NameEquals("file"u8))
                {
                    @file = BinaryData.FromBytes(prop.Value.GetBytesFromBase64("D"));
                    continue;
                }
                if (prop.NameEquals("model"u8))
                {
                    model = InternalCreateTranscriptionRequestModel.DeserializeInternalCreateTranscriptionRequestModel(prop.Value, options);
                    continue;
                }
                if (prop.NameEquals("timestamp_granularities"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<BinaryData> array = new List<BinaryData>();
                    foreach (var item in prop.Value.EnumerateArray())
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
                    internalTimestampGranularities = array;
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new AudioTranscriptionOptions(
                language,
                prompt,
                responseFormat,
                temperature,
                @file,
                model,
                internalTimestampGranularities ?? new ChangeTrackingList<BinaryData>(),
                additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<AudioTranscriptionOptions>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<AudioTranscriptionOptions>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(AudioTranscriptionOptions)} does not support writing '{options.Format}' format.");
            }
        }

        AudioTranscriptionOptions IPersistableModel<AudioTranscriptionOptions>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        protected virtual AudioTranscriptionOptions PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<AudioTranscriptionOptions>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeAudioTranscriptionOptions(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(AudioTranscriptionOptions)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<AudioTranscriptionOptions>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(AudioTranscriptionOptions audioTranscriptionOptions)
        {
            return BinaryContent.Create(audioTranscriptionOptions, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator AudioTranscriptionOptions(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeAudioTranscriptionOptions(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
