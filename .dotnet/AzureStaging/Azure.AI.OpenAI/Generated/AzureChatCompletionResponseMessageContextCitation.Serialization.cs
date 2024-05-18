// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using OpenAI;
using OpenAI.Chat;

namespace Azure.AI.OpenAI
{
    public partial class AzureChatCompletionResponseMessageContextCitation : IJsonModel<AzureChatCompletionResponseMessageContextCitation>
    {
        void IJsonModel<AzureChatCompletionResponseMessageContextCitation>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<AzureChatCompletionResponseMessageContextCitation>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(AzureChatCompletionResponseMessageContextCitation)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("content"u8);
            writer.WriteStringValue(Content);
            if (Optional.IsDefined(Title))
            {
                writer.WritePropertyName("title"u8);
                writer.WriteStringValue(Title);
            }
            if (Optional.IsDefined(Url))
            {
                writer.WritePropertyName("url"u8);
                writer.WriteStringValue(Url);
            }
            if (Optional.IsDefined(Filepath))
            {
                writer.WritePropertyName("filepath"u8);
                writer.WriteStringValue(Filepath);
            }
            if (Optional.IsDefined(ChunkId))
            {
                writer.WritePropertyName("chunk_id"u8);
                writer.WriteStringValue(ChunkId);
            }
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

        AzureChatCompletionResponseMessageContextCitation IJsonModel<AzureChatCompletionResponseMessageContextCitation>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<AzureChatCompletionResponseMessageContextCitation>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(AzureChatCompletionResponseMessageContextCitation)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeAzureChatCompletionResponseMessageContextCitation(document.RootElement, options);
        }

        internal static AzureChatCompletionResponseMessageContextCitation DeserializeAzureChatCompletionResponseMessageContextCitation(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string content = default;
            string title = default;
            string url = default;
            string filepath = default;
            string chunkId = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("content"u8))
                {
                    content = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("title"u8))
                {
                    title = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("url"u8))
                {
                    url = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("filepath"u8))
                {
                    filepath = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("chunk_id"u8))
                {
                    chunkId = property.Value.GetString();
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new AzureChatCompletionResponseMessageContextCitation(
                content,
                title,
                url,
                filepath,
                chunkId,
                serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<AzureChatCompletionResponseMessageContextCitation>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<AzureChatCompletionResponseMessageContextCitation>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(AzureChatCompletionResponseMessageContextCitation)} does not support writing '{options.Format}' format.");
            }
        }

        AzureChatCompletionResponseMessageContextCitation IPersistableModel<AzureChatCompletionResponseMessageContextCitation>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<AzureChatCompletionResponseMessageContextCitation>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeAzureChatCompletionResponseMessageContextCitation(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(AzureChatCompletionResponseMessageContextCitation)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<AzureChatCompletionResponseMessageContextCitation>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The result to deserialize the model from. </param>
        internal static AzureChatCompletionResponseMessageContextCitation FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeAzureChatCompletionResponseMessageContextCitation(document.RootElement);
        }

        /// <summary> Convert into a <see cref="BinaryContent"/>. </summary>
        internal virtual BinaryContent ToBinaryContent()
        {
            return BinaryContent.Create(this, ModelSerializationExtensions.WireOptions);
        }
    }
}
