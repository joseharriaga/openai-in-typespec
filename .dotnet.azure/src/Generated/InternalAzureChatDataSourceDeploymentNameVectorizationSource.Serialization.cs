// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.AI.OpenAI.Chat
{
    internal partial class InternalAzureChatDataSourceDeploymentNameVectorizationSource : IJsonModel<InternalAzureChatDataSourceDeploymentNameVectorizationSource>
    {
        void IJsonModel<InternalAzureChatDataSourceDeploymentNameVectorizationSource>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalAzureChatDataSourceDeploymentNameVectorizationSource>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalAzureChatDataSourceDeploymentNameVectorizationSource)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            if (SerializedAdditionalRawData?.ContainsKey("deployment_name") != true)
            {
                writer.WritePropertyName("deployment_name"u8);
                writer.WriteStringValue(DeploymentName);
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
            foreach (var item in SerializedAdditionalRawData ?? new System.Collections.Generic.Dictionary<string, BinaryData>())
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
            writer.WriteEndObject();
        }

        InternalAzureChatDataSourceDeploymentNameVectorizationSource IJsonModel<InternalAzureChatDataSourceDeploymentNameVectorizationSource>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalAzureChatDataSourceDeploymentNameVectorizationSource>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalAzureChatDataSourceDeploymentNameVectorizationSource)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalAzureChatDataSourceDeploymentNameVectorizationSource(document.RootElement, options);
        }

        internal static InternalAzureChatDataSourceDeploymentNameVectorizationSource DeserializeInternalAzureChatDataSourceDeploymentNameVectorizationSource(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string deploymentName = default;
            int? dimensions = default;
            string type = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("deployment_name"u8))
                {
                    deploymentName = property.Value.GetString();
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
            return new InternalAzureChatDataSourceDeploymentNameVectorizationSource(type, serializedAdditionalRawData, deploymentName, dimensions);
        }

        BinaryData IPersistableModel<InternalAzureChatDataSourceDeploymentNameVectorizationSource>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalAzureChatDataSourceDeploymentNameVectorizationSource>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalAzureChatDataSourceDeploymentNameVectorizationSource)} does not support writing '{options.Format}' format.");
            }
        }

        InternalAzureChatDataSourceDeploymentNameVectorizationSource IPersistableModel<InternalAzureChatDataSourceDeploymentNameVectorizationSource>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalAzureChatDataSourceDeploymentNameVectorizationSource>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeInternalAzureChatDataSourceDeploymentNameVectorizationSource(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalAzureChatDataSourceDeploymentNameVectorizationSource)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalAzureChatDataSourceDeploymentNameVectorizationSource>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The result to deserialize the model from. </param>
        internal static new InternalAzureChatDataSourceDeploymentNameVectorizationSource FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeInternalAzureChatDataSourceDeploymentNameVectorizationSource(document.RootElement);
        }

        /// <summary> Convert into a <see cref="BinaryContent"/>. </summary>
        internal override BinaryContent ToBinaryContent()
        {
            return BinaryContent.Create(this, ModelSerializationExtensions.WireOptions);
        }
    }
}

