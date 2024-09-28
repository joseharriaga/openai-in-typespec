// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.AI.OpenAI.Chat
{
    internal partial class InternalAzureChatDataSourceEndpointVectorizationSource : IJsonModel<InternalAzureChatDataSourceEndpointVectorizationSource>
    {
        void IJsonModel<InternalAzureChatDataSourceEndpointVectorizationSource>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalAzureChatDataSourceEndpointVectorizationSource>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalAzureChatDataSourceEndpointVectorizationSource)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            if (SerializedAdditionalRawData?.ContainsKey("endpoint") != true)
            {
                writer.WritePropertyName("endpoint"u8);
                writer.WriteStringValue(Endpoint.AbsoluteUri);
            }
            if (SerializedAdditionalRawData?.ContainsKey("authentication") != true)
            {
                writer.WritePropertyName("authentication"u8);
                writer.WriteObjectValue<DataSourceAuthentication>(Authentication, options);
            }
            if (SerializedAdditionalRawData?.ContainsKey("dimensions") != true && Optional.IsDefined(Dimensions))
            {
                writer.WritePropertyName("dimensions"u8);
                writer.WriteNumberValue(Dimensions.Value);
            }
            if (SerializedAdditionalRawData?.ContainsKey("type") != true)
            {
                writer.WritePropertyName("type"u8);
                writer.WriteStringValue(Type);
            }
            if (SerializedAdditionalRawData != null)
            {
                foreach (var item in SerializedAdditionalRawData)
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
            writer.WriteEndObject();
        }

        InternalAzureChatDataSourceEndpointVectorizationSource IJsonModel<InternalAzureChatDataSourceEndpointVectorizationSource>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalAzureChatDataSourceEndpointVectorizationSource>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalAzureChatDataSourceEndpointVectorizationSource)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalAzureChatDataSourceEndpointVectorizationSource(document.RootElement, options);
        }

        internal static InternalAzureChatDataSourceEndpointVectorizationSource DeserializeInternalAzureChatDataSourceEndpointVectorizationSource(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Uri endpoint = default;
            DataSourceAuthentication authentication = default;
            int? dimensions = default;
            string type = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("endpoint"u8))
                {
                    endpoint = new Uri(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("authentication"u8))
                {
                    authentication = DataSourceAuthentication.DeserializeDataSourceAuthentication(property.Value, options);
                    continue;
                }
                if (property.NameEquals("dimensions"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    dimensions = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("type"u8))
                {
                    type = property.Value.GetString();
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary ??= new Dictionary<string, BinaryData>();
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new InternalAzureChatDataSourceEndpointVectorizationSource(type, serializedAdditionalRawData, endpoint, authentication, dimensions);
        }

        BinaryData IPersistableModel<InternalAzureChatDataSourceEndpointVectorizationSource>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalAzureChatDataSourceEndpointVectorizationSource>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalAzureChatDataSourceEndpointVectorizationSource)} does not support writing '{options.Format}' format.");
            }
        }

        InternalAzureChatDataSourceEndpointVectorizationSource IPersistableModel<InternalAzureChatDataSourceEndpointVectorizationSource>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalAzureChatDataSourceEndpointVectorizationSource>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeInternalAzureChatDataSourceEndpointVectorizationSource(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalAzureChatDataSourceEndpointVectorizationSource)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalAzureChatDataSourceEndpointVectorizationSource>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The result to deserialize the model from. </param>
        internal static new InternalAzureChatDataSourceEndpointVectorizationSource FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeInternalAzureChatDataSourceEndpointVectorizationSource(document.RootElement);
        }

        /// <summary> Convert into a <see cref="BinaryContent"/>. </summary>
        internal override BinaryContent ToBinaryContent()
        {
            return BinaryContent.Create(this, ModelSerializationExtensions.WireOptions);
        }
    }
}



