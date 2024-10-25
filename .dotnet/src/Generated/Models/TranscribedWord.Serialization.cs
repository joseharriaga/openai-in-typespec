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
    public readonly partial struct TranscribedWord : IJsonModel<TranscribedWord>, IJsonModel<object>
    {
        public TranscribedWord()
        {
        }

        void IJsonModel<TranscribedWord>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        private void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<TranscribedWord>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(TranscribedWord)} does not support writing '{format}' format.");
            }
            if (_additionalBinaryDataProperties?.ContainsKey("word") != true)
            {
                writer.WritePropertyName("word"u8);
            }
            writer.WriteStringValue(Word);
            if (_additionalBinaryDataProperties?.ContainsKey("start") != true)
            {
                writer.WritePropertyName("start"u8);
            }
            writer.WriteNumberValue(Convert.ToDouble(StartTime.ToString("s\\.FFF")));
            if (_additionalBinaryDataProperties?.ContainsKey("end") != true)
            {
                writer.WritePropertyName("end"u8);
            }
            writer.WriteNumberValue(Convert.ToDouble(EndTime.ToString("s\\.FFF")));
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

        TranscribedWord IJsonModel<TranscribedWord>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        private TranscribedWord JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<TranscribedWord>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(TranscribedWord)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeTranscribedWord(document.RootElement, options);
        }

        internal static TranscribedWord DeserializeTranscribedWord(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return default;
            }
            string word = default;
            TimeSpan startTime = default;
            TimeSpan endTime = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("word"u8))
                {
                    word = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("start"u8))
                {
                    startTime = TimeSpan.FromSeconds(prop.Value.GetDouble());
                    continue;
                }
                if (prop.NameEquals("end"u8))
                {
                    endTime = TimeSpan.FromSeconds(prop.Value.GetDouble());
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new TranscribedWord(word, startTime, endTime, additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<TranscribedWord>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        private BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<TranscribedWord>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(TranscribedWord)} does not support writing '{options.Format}' format.");
            }
        }

        TranscribedWord IPersistableModel<TranscribedWord>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        private TranscribedWord PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<TranscribedWord>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeTranscribedWord(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(TranscribedWord)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<TranscribedWord>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(TranscribedWord transcribedWord)
        {
            return BinaryContent.Create(transcribedWord, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator TranscribedWord(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeTranscribedWord(document.RootElement, ModelSerializationExtensions.WireOptions);
        }

        void IJsonModel<object>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => ((IJsonModel<TranscribedWord>)this).Write(writer, options);

        object IJsonModel<object>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => ((IJsonModel<TranscribedWord>)this).Create(ref reader, options);

        BinaryData IPersistableModel<object>.Write(ModelReaderWriterOptions options) => ((IPersistableModel<TranscribedWord>)this).Write(options);

        string IPersistableModel<object>.GetFormatFromOptions(ModelReaderWriterOptions options) => ((IPersistableModel<TranscribedWord>)this).GetFormatFromOptions(options);

        object IPersistableModel<object>.Create(BinaryData data, ModelReaderWriterOptions options) => ((IPersistableModel<TranscribedWord>)this).Create(data, options);
    }
}
