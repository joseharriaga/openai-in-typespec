// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Audio
{
    public partial class AudioTranslation : IJsonModel<AudioTranslation>
    {
        void IJsonModel<AudioTranslation>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<AudioTranslation>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(AudioTranslation)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("task"u8);
            writer.WriteStringValue(Task.ToString());
            writer.WritePropertyName("language"u8);
            writer.WriteStringValue(Language);
            writer.WritePropertyName("duration"u8);
            writer.WriteNumberValue(Convert.ToDouble(Duration.Value.ToString("s\\.fff")));
            writer.WritePropertyName("text"u8);
            writer.WriteStringValue(Text);
            if (Optional.IsCollectionDefined(Segments))
            {
                writer.WritePropertyName("segments"u8);
                writer.WriteStartArray();
                foreach (var item in Segments)
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

        AudioTranslation IJsonModel<AudioTranslation>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<AudioTranslation>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(AudioTranslation)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeAudioTranslation(document.RootElement, options);
        }

        internal static AudioTranslation DeserializeAudioTranslation(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            InternalCreateTranslationResponseVerboseJsonTask task = default;
            string language = default;
            TimeSpan? duration = default;
            string text = default;
            IReadOnlyList<TranscribedSegment> segments = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("task"u8))
                {
                    task = new InternalCreateTranslationResponseVerboseJsonTask(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("language"u8))
                {
                    language = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("duration"u8))
                {
                    duration = TimeSpan.FromSeconds(property.Value.GetDouble());
                    continue;
                }
                if (property.NameEquals("text"u8))
                {
                    text = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("segments"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<TranscribedSegment> array = new List<TranscribedSegment>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(TranscribedSegment.DeserializeTranscribedSegment(item, options));
                    }
                    segments = array;
                    continue;
                }
                if (true)
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new AudioTranslation(
                task,
                language,
                duration,
                text,
                segments ?? new ChangeTrackingList<TranscribedSegment>(),
                serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<AudioTranslation>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<AudioTranslation>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(AudioTranslation)} does not support writing '{options.Format}' format.");
            }
        }

        AudioTranslation IPersistableModel<AudioTranslation>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<AudioTranslation>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeAudioTranslation(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(AudioTranslation)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<AudioTranslation>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The result to deserialize the model from. </param>
        internal static AudioTranslation FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeAudioTranslation(document.RootElement);
        }

        /// <summary> Convert into a <see cref="BinaryContent"/>. </summary>
        internal virtual BinaryContent ToBinaryContent()
        {
            return BinaryContent.Create(this, ModelSerializationExtensions.WireOptions);
        }
    }
}

