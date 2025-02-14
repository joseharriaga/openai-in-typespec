// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.AI.OpenAI
{
    internal partial class AzureOpenAIChatError : IJsonModel<AzureOpenAIChatError>
    {
        void IJsonModel<AzureOpenAIChatError>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<AzureOpenAIChatError>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(AzureOpenAIChatError)} does not support writing '{format}' format.");
            }
            if (Optional.IsDefined(Code) && _additionalBinaryDataProperties?.ContainsKey("code") != true)
            {
                writer.WritePropertyName("code"u8);
                writer.WriteStringValue(Code);
            }
            if (Optional.IsDefined(Message) && _additionalBinaryDataProperties?.ContainsKey("message") != true)
            {
                writer.WritePropertyName("message"u8);
                writer.WriteStringValue(Message);
            }
            if (Optional.IsDefined(Param) && _additionalBinaryDataProperties?.ContainsKey("param") != true)
            {
                writer.WritePropertyName("param"u8);
                writer.WriteStringValue(Param);
            }
            if (Optional.IsDefined(Type) && _additionalBinaryDataProperties?.ContainsKey("type") != true)
            {
                writer.WritePropertyName("type"u8);
                writer.WriteStringValue(Type);
            }
            if (Optional.IsDefined(InnerError) && _additionalBinaryDataProperties?.ContainsKey("inner_error") != true)
            {
                writer.WritePropertyName("inner_error"u8);
                writer.WriteObjectValue(InnerError, options);
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

        AzureOpenAIChatError IJsonModel<AzureOpenAIChatError>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual AzureOpenAIChatError JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<AzureOpenAIChatError>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(AzureOpenAIChatError)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeAzureOpenAIChatError(document.RootElement, options);
        }

        internal static AzureOpenAIChatError DeserializeAzureOpenAIChatError(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string code = default;
            string message = default;
            string @param = default;
            string @type = default;
            InternalAzureOpenAIChatErrorInnerError innerError = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("code"u8))
                {
                    code = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("message"u8))
                {
                    message = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("param"u8))
                {
                    @param = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("type"u8))
                {
                    @type = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("inner_error"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    innerError = InternalAzureOpenAIChatErrorInnerError.DeserializeInternalAzureOpenAIChatErrorInnerError(prop.Value, options);
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new AzureOpenAIChatError(
                code,
                message,
                @param,
                @type,
                innerError,
                additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<AzureOpenAIChatError>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<AzureOpenAIChatError>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(AzureOpenAIChatError)} does not support writing '{options.Format}' format.");
            }
        }

        AzureOpenAIChatError IPersistableModel<AzureOpenAIChatError>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        protected virtual AzureOpenAIChatError PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<AzureOpenAIChatError>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeAzureOpenAIChatError(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(AzureOpenAIChatError)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<AzureOpenAIChatError>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(AzureOpenAIChatError azureOpenAIChatError)
        {
            if (azureOpenAIChatError == null)
            {
                return null;
            }
            return BinaryContent.Create(azureOpenAIChatError, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator AzureOpenAIChatError(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeAzureOpenAIChatError(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
