// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.AI.OpenAI.Chat
{
    public partial class AzureChatRetrievedDocument : IJsonModel<AzureChatRetrievedDocument>
    {
        void IJsonModel<AzureChatRetrievedDocument>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<AzureChatRetrievedDocument>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(AzureChatRetrievedDocument)} does not support writing '{format}' format.");
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
            writer.WritePropertyName("search_queries"u8);
            writer.WriteStartArray();
            foreach (var item in SearchQueries)
            {
                writer.WriteStringValue(item);
            }
            writer.WriteEndArray();
            writer.WritePropertyName("data_source_index"u8);
            writer.WriteNumberValue(DataSourceIndex);
            if (Optional.IsDefined(OriginalSearchScore))
            {
                writer.WritePropertyName("original_search_score"u8);
                writer.WriteNumberValue(OriginalSearchScore.Value);
            }
            if (Optional.IsDefined(RerankScore))
            {
                writer.WritePropertyName("rerank_score"u8);
                writer.WriteNumberValue(RerankScore.Value);
            }
            if (Optional.IsDefined(FilterReason))
            {
                writer.WritePropertyName("filter_reason"u8);
                writer.WriteStringValue(FilterReason);
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

        AzureChatRetrievedDocument IJsonModel<AzureChatRetrievedDocument>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<AzureChatRetrievedDocument>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(AzureChatRetrievedDocument)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeAzureChatRetrievedDocument(document.RootElement, options);
        }

        internal static AzureChatRetrievedDocument DeserializeAzureChatRetrievedDocument(JsonElement element, ModelReaderWriterOptions options = null)
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
            IReadOnlyList<string> searchQueries = default;
            int dataSourceIndex = default;
            double? originalSearchScore = default;
            double? rerankScore = default;
            string filterReason = default;
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
                if (property.NameEquals("search_queries"u8))
                {
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    searchQueries = array;
                    continue;
                }
                if (property.NameEquals("data_source_index"u8))
                {
                    dataSourceIndex = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("original_search_score"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    originalSearchScore = property.Value.GetDouble();
                    continue;
                }
                if (property.NameEquals("rerank_score"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    rerankScore = property.Value.GetDouble();
                    continue;
                }
                if (property.NameEquals("filter_reason"u8))
                {
                    filterReason = property.Value.GetString();
                    continue;
                }
                if (true)
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new AzureChatRetrievedDocument(
                content,
                title,
                url,
                filepath,
                chunkId,
                searchQueries,
                dataSourceIndex,
                originalSearchScore,
                rerankScore,
                filterReason,
                serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<AzureChatRetrievedDocument>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<AzureChatRetrievedDocument>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(AzureChatRetrievedDocument)} does not support writing '{options.Format}' format.");
            }
        }

        AzureChatRetrievedDocument IPersistableModel<AzureChatRetrievedDocument>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<AzureChatRetrievedDocument>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeAzureChatRetrievedDocument(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(AzureChatRetrievedDocument)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<AzureChatRetrievedDocument>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The result to deserialize the model from. </param>
        internal static AzureChatRetrievedDocument FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeAzureChatRetrievedDocument(document.RootElement);
        }

        /// <summary> Convert into a <see cref="BinaryContent"/>. </summary>
        internal virtual BinaryContent ToBinaryContent()
        {
            return BinaryContent.Create(this, ModelSerializationExtensions.WireOptions);
        }
    }
}

