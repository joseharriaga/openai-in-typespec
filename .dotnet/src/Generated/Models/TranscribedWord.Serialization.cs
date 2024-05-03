// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Audio
{
    public partial struct TranscribedWord : IJsonModel<TranscribedWord>, IJsonModel<object>
    {
        void IJsonModel<TranscribedWord>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<TranscribedWord>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(TranscribedWord)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("word"u8);
            writer.WriteStringValue(Word);
            writer.WritePropertyName("start"u8);
            writer.WriteNumberValue(Convert.ToInt32(Start.ToString("%s")));
            writer.WritePropertyName("end"u8);
            writer.WriteNumberValue(Convert.ToInt32(End.ToString("%s")));
            if (options.Format != "W" && _serializedAdditionalRawData != null)
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

        TranscribedWord IJsonModel<TranscribedWord>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<TranscribedWord>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(TranscribedWord)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeTranscribedWord(document.RootElement, options);
        }

        void IJsonModel<object>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => ((IJsonModel<TranscribedWord>)this).Write(writer, options);

        object IJsonModel<object>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => ((IJsonModel<TranscribedWord>)this).Create(ref reader, options);

        internal static TranscribedWord DeserializeTranscribedWord(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            string word = default;
            TimeSpan start = default;
            TimeSpan end = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("word"u8))
                {
                    word = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("start"u8))
                {
                    DeserializeTimeSpan(property, ref start);
                    continue;
                }
                if (property.NameEquals("end"u8))
                {
                    DeserializeTimeSpan(property, ref end);
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new TranscribedWord(word, start, end, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<TranscribedWord>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<TranscribedWord>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(TranscribedWord)} does not support writing '{options.Format}' format.");
            }
        }

        TranscribedWord IPersistableModel<TranscribedWord>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<TranscribedWord>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeTranscribedWord(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(TranscribedWord)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<TranscribedWord>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        BinaryData IPersistableModel<object>.Write(ModelReaderWriterOptions options) => ((IPersistableModel<TranscribedWord>)this).Write(options);

        object IPersistableModel<object>.Create(BinaryData data, ModelReaderWriterOptions options) => ((IPersistableModel<TranscribedWord>)this).Create(data, options);

        string IPersistableModel<object>.GetFormatFromOptions(ModelReaderWriterOptions options) => ((IPersistableModel<TranscribedWord>)this).GetFormatFromOptions(options);

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The result to deserialize the model from. </param>
        internal static TranscribedWord FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeTranscribedWord(document.RootElement);
        }

        /// <summary> Convert into a <see cref="BinaryContent"/>. </summary>
        internal BinaryContent ToBinaryContent()
        {
            return BinaryContent.Create(this, ModelSerializationExtensions.WireOptions);
        }
    }
}
