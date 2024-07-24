// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.AI.OpenAI.Chat
{
    internal partial class InternalAzureChatDataSourceEncodedApiKeyAuthenticationOptions : IJsonModel<InternalAzureChatDataSourceEncodedApiKeyAuthenticationOptions>
    {
        void IJsonModel<InternalAzureChatDataSourceEncodedApiKeyAuthenticationOptions>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalAzureChatDataSourceEncodedApiKeyAuthenticationOptions>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalAzureChatDataSourceEncodedApiKeyAuthenticationOptions)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            if (SerializedAdditionalRawData?.ContainsKey("encoded_api_key") != true)
            {
                writer.WritePropertyName("encoded_api_key"u8);
                writer.WriteStringValue(EncodedApiKey);
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

        InternalAzureChatDataSourceEncodedApiKeyAuthenticationOptions IJsonModel<InternalAzureChatDataSourceEncodedApiKeyAuthenticationOptions>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalAzureChatDataSourceEncodedApiKeyAuthenticationOptions>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalAzureChatDataSourceEncodedApiKeyAuthenticationOptions)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalAzureChatDataSourceEncodedApiKeyAuthenticationOptions(document.RootElement, options);
        }

        internal static InternalAzureChatDataSourceEncodedApiKeyAuthenticationOptions DeserializeInternalAzureChatDataSourceEncodedApiKeyAuthenticationOptions(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string encodedApiKey = default;
            string type = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("encoded_api_key"u8))
                {
                    encodedApiKey = property.Value.GetString();
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
            return new InternalAzureChatDataSourceEncodedApiKeyAuthenticationOptions(type, serializedAdditionalRawData, encodedApiKey);
        }

        BinaryData IPersistableModel<InternalAzureChatDataSourceEncodedApiKeyAuthenticationOptions>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalAzureChatDataSourceEncodedApiKeyAuthenticationOptions>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalAzureChatDataSourceEncodedApiKeyAuthenticationOptions)} does not support writing '{options.Format}' format.");
            }
        }

        InternalAzureChatDataSourceEncodedApiKeyAuthenticationOptions IPersistableModel<InternalAzureChatDataSourceEncodedApiKeyAuthenticationOptions>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalAzureChatDataSourceEncodedApiKeyAuthenticationOptions>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeInternalAzureChatDataSourceEncodedApiKeyAuthenticationOptions(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalAzureChatDataSourceEncodedApiKeyAuthenticationOptions)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalAzureChatDataSourceEncodedApiKeyAuthenticationOptions>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The result to deserialize the model from. </param>
        internal static new InternalAzureChatDataSourceEncodedApiKeyAuthenticationOptions FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeInternalAzureChatDataSourceEncodedApiKeyAuthenticationOptions(document.RootElement);
        }

        /// <summary> Convert into a <see cref="BinaryContent"/>. </summary>
        internal override BinaryContent ToBinaryContent()
        {
            return BinaryContent.Create(this, ModelSerializationExtensions.WireOptions);
        }
    }
}

