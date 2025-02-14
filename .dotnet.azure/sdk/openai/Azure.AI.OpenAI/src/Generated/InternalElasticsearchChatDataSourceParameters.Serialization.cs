// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.AI.OpenAI;

namespace Azure.AI.OpenAI.Chat
{
    internal partial class InternalElasticsearchChatDataSourceParameters : IJsonModel<InternalElasticsearchChatDataSourceParameters>
    {
        internal InternalElasticsearchChatDataSourceParameters()
        {
        }

        void IJsonModel<InternalElasticsearchChatDataSourceParameters>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalElasticsearchChatDataSourceParameters>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalElasticsearchChatDataSourceParameters)} does not support writing '{format}' format.");
            }
            if (Optional.IsDefined(TopNDocuments) && _additionalBinaryDataProperties?.ContainsKey("top_n_documents") != true)
            {
                writer.WritePropertyName("top_n_documents"u8);
                writer.WriteNumberValue(TopNDocuments.Value);
            }
            if (Optional.IsDefined(InScope) && _additionalBinaryDataProperties?.ContainsKey("in_scope") != true)
            {
                writer.WritePropertyName("in_scope"u8);
                writer.WriteBooleanValue(InScope.Value);
            }
            if (Optional.IsDefined(Strictness) && _additionalBinaryDataProperties?.ContainsKey("strictness") != true)
            {
                writer.WritePropertyName("strictness"u8);
                writer.WriteNumberValue(Strictness.Value);
            }
            if (Optional.IsDefined(MaxSearchQueries) && _additionalBinaryDataProperties?.ContainsKey("max_search_queries") != true)
            {
                writer.WritePropertyName("max_search_queries"u8);
                writer.WriteNumberValue(MaxSearchQueries.Value);
            }
            if (Optional.IsDefined(AllowPartialResult) && _additionalBinaryDataProperties?.ContainsKey("allow_partial_result") != true)
            {
                writer.WritePropertyName("allow_partial_result"u8);
                writer.WriteBooleanValue(AllowPartialResult.Value);
            }
            if (_additionalBinaryDataProperties?.ContainsKey("endpoint") != true)
            {
                writer.WritePropertyName("endpoint"u8);
                writer.WriteStringValue(Endpoint.AbsoluteUri);
            }
            if (_additionalBinaryDataProperties?.ContainsKey("index_name") != true)
            {
                writer.WritePropertyName("index_name"u8);
                writer.WriteStringValue(IndexName);
            }
            if (Optional.IsCollectionDefined(_internalIncludeContexts) && _additionalBinaryDataProperties?.ContainsKey("include_contexts") != true)
            {
                writer.WritePropertyName("include_contexts"u8);
                writer.WriteStartArray();
                foreach (string item in _internalIncludeContexts)
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
            if (_additionalBinaryDataProperties?.ContainsKey("authentication") != true)
            {
                writer.WritePropertyName("authentication"u8);
                writer.WriteObjectValue<DataSourceAuthentication>(Authentication, options);
            }
            if (Optional.IsDefined(FieldMappings) && _additionalBinaryDataProperties?.ContainsKey("fields_mapping") != true)
            {
                writer.WritePropertyName("fields_mapping"u8);
                writer.WriteObjectValue<DataSourceFieldMappings>(FieldMappings, options);
            }
            if (Optional.IsDefined(QueryType) && _additionalBinaryDataProperties?.ContainsKey("query_type") != true)
            {
                writer.WritePropertyName("query_type"u8);
                writer.WriteStringValue(QueryType.Value.ToString());
            }
            if (Optional.IsDefined(VectorizationSource) && _additionalBinaryDataProperties?.ContainsKey("embedding_dependency") != true)
            {
                writer.WritePropertyName("embedding_dependency"u8);
                writer.WriteObjectValue<DataSourceVectorizer>(VectorizationSource, options);
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

        InternalElasticsearchChatDataSourceParameters IJsonModel<InternalElasticsearchChatDataSourceParameters>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual InternalElasticsearchChatDataSourceParameters JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalElasticsearchChatDataSourceParameters>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalElasticsearchChatDataSourceParameters)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalElasticsearchChatDataSourceParameters(document.RootElement, options);
        }

        internal static InternalElasticsearchChatDataSourceParameters DeserializeInternalElasticsearchChatDataSourceParameters(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            int? topNDocuments = default;
            bool? inScope = default;
            int? strictness = default;
            int? maxSearchQueries = default;
            bool? allowPartialResult = default;
            Uri endpoint = default;
            string indexName = default;
            IList<string> internalIncludeContexts = default;
            DataSourceAuthentication authentication = default;
            DataSourceFieldMappings fieldMappings = default;
            DataSourceQueryType? queryType = default;
            DataSourceVectorizer vectorizationSource = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("top_n_documents"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    topNDocuments = prop.Value.GetInt32();
                    continue;
                }
                if (prop.NameEquals("in_scope"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    inScope = prop.Value.GetBoolean();
                    continue;
                }
                if (prop.NameEquals("strictness"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    strictness = prop.Value.GetInt32();
                    continue;
                }
                if (prop.NameEquals("max_search_queries"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    maxSearchQueries = prop.Value.GetInt32();
                    continue;
                }
                if (prop.NameEquals("allow_partial_result"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    allowPartialResult = prop.Value.GetBoolean();
                    continue;
                }
                if (prop.NameEquals("endpoint"u8))
                {
                    endpoint = new Uri(prop.Value.GetString());
                    continue;
                }
                if (prop.NameEquals("index_name"u8))
                {
                    indexName = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("include_contexts"u8))
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
                    internalIncludeContexts = array;
                    continue;
                }
                if (prop.NameEquals("authentication"u8))
                {
                    authentication = DataSourceAuthentication.DeserializeDataSourceAuthentication(prop.Value, options);
                    continue;
                }
                if (prop.NameEquals("fields_mapping"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    fieldMappings = DataSourceFieldMappings.DeserializeDataSourceFieldMappings(prop.Value, options);
                    continue;
                }
                if (prop.NameEquals("query_type"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    queryType = new DataSourceQueryType(prop.Value.GetString());
                    continue;
                }
                if (prop.NameEquals("embedding_dependency"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    vectorizationSource = DataSourceVectorizer.DeserializeDataSourceVectorizer(prop.Value, options);
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new InternalElasticsearchChatDataSourceParameters(
                topNDocuments,
                inScope,
                strictness,
                maxSearchQueries,
                allowPartialResult,
                endpoint,
                indexName,
                internalIncludeContexts ?? new ChangeTrackingList<string>(),
                authentication,
                fieldMappings,
                queryType,
                vectorizationSource,
                additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<InternalElasticsearchChatDataSourceParameters>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalElasticsearchChatDataSourceParameters>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalElasticsearchChatDataSourceParameters)} does not support writing '{options.Format}' format.");
            }
        }

        InternalElasticsearchChatDataSourceParameters IPersistableModel<InternalElasticsearchChatDataSourceParameters>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        protected virtual InternalElasticsearchChatDataSourceParameters PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalElasticsearchChatDataSourceParameters>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeInternalElasticsearchChatDataSourceParameters(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalElasticsearchChatDataSourceParameters)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalElasticsearchChatDataSourceParameters>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(InternalElasticsearchChatDataSourceParameters internalElasticsearchChatDataSourceParameters)
        {
            if (internalElasticsearchChatDataSourceParameters == null)
            {
                return null;
            }
            return BinaryContent.Create(internalElasticsearchChatDataSourceParameters, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator InternalElasticsearchChatDataSourceParameters(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeInternalElasticsearchChatDataSourceParameters(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
