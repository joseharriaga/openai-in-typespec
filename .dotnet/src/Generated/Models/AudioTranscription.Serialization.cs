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
    public partial class AudioTranscription : IJsonModel<AudioTranscription>
    {
        internal AudioTranscription()
        {
        }

        void IJsonModel<AudioTranscription>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<AudioTranscription>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(AudioTranscription)} does not support writing '{format}' format.");
            }
            if (_additionalBinaryDataProperties?.ContainsKey("language") != true)
            {
                writer.WritePropertyName("language"u8);
            }
            writer.WriteStringValue(Language);
            if (_additionalBinaryDataProperties?.ContainsKey("text") != true)
            {
                writer.WritePropertyName("text"u8);
            }
            writer.WriteStringValue(Text);
            if (Optional.IsCollectionDefined(Words) && _additionalBinaryDataProperties?.ContainsKey("words") != true)
            {
                writer.WritePropertyName("words"u8);
                writer.WriteStartArray();
                foreach (TranscribedWord item in Words)
                {
                    writer.WriteObjectValue(item, options);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(Segments) && _additionalBinaryDataProperties?.ContainsKey("segments") != true)
            {
                writer.WritePropertyName("segments"u8);
                writer.WriteStartArray();
                foreach (TranscribedSegment item in Segments)
                {
                    writer.WriteObjectValue(item, options);
                }
                writer.WriteEndArray();
            }
            if (_additionalBinaryDataProperties?.ContainsKey("task") != true)
            {
                writer.WritePropertyName("task"u8);
            }
            writer.WriteStringValue(Task.ToString());
            if (_additionalBinaryDataProperties?.ContainsKey("duration") != true)
            {
                writer.WritePropertyName("duration"u8);
            }
            writer.WriteNumberValue(Convert.ToDouble(Duration.Value.ToString("s\\.FFF")));
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

        AudioTranscription IJsonModel<AudioTranscription>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual AudioTranscription JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<AudioTranscription>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(AudioTranscription)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeAudioTranscription(document.RootElement, options);
        }

        internal static AudioTranscription DeserializeAudioTranscription(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string language = default;
            string text = default;
            IList<TranscribedWord> words = default;
            IList<TranscribedSegment> segments = default;
            InternalCreateTranscriptionResponseVerboseJsonTask task = default;
            TimeSpan? duration = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("language"u8))
                {
                    language = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("text"u8))
                {
                    text = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("words"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<TranscribedWord> array = new List<TranscribedWord>();
                    foreach (var item in prop.Value.EnumerateArray())
                    {
                        array.Add(TranscribedWord.DeserializeTranscribedWord(item, options));
                    }
                    words = array;
                    continue;
                }
                if (prop.NameEquals("segments"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<TranscribedSegment> array = new List<TranscribedSegment>();
                    foreach (var item in prop.Value.EnumerateArray())
                    {
                        array.Add(TranscribedSegment.DeserializeTranscribedSegment(item, options));
                    }
                    segments = array;
                    continue;
                }
                if (prop.NameEquals("task"u8))
                {
                    task = new InternalCreateTranscriptionResponseVerboseJsonTask(prop.Value.GetString());
                    continue;
                }
                if (prop.NameEquals("duration"u8))
                {
                    duration = TimeSpan.FromSeconds(prop.Value.GetDouble());
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new AudioTranscription(
                language,
                text,
                words ?? new ChangeTrackingList<TranscribedWord>(),
                segments ?? new ChangeTrackingList<TranscribedSegment>(),
                task,
                duration,
                additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<AudioTranscription>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<AudioTranscription>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(AudioTranscription)} does not support writing '{options.Format}' format.");
            }
        }

        AudioTranscription IPersistableModel<AudioTranscription>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        protected virtual AudioTranscription PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<AudioTranscription>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeAudioTranscription(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(AudioTranscription)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<AudioTranscription>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(AudioTranscription audioTranscription)
        {
            return BinaryContent.Create(audioTranscription, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator AudioTranscription(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeAudioTranscription(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
