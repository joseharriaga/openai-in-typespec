// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using OpenAI;
using OpenAI.Chat;

namespace OpenAI.LegacyCompletions
{
    internal partial class InternalCreateCompletionResponse : IJsonModel<InternalCreateCompletionResponse>
    {
        internal InternalCreateCompletionResponse()
        {
        }

        void IJsonModel<InternalCreateCompletionResponse>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalCreateCompletionResponse>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalCreateCompletionResponse)} does not support writing '{format}' format.");
            }
            if (_additionalBinaryDataProperties?.ContainsKey("id") != true)
            {
                writer.WritePropertyName("id"u8);
                writer.WriteStringValue(Id);
            }
            if (_additionalBinaryDataProperties?.ContainsKey("choices") != true)
            {
                writer.WritePropertyName("choices"u8);
                writer.WriteStartArray();
                foreach (InternalCreateCompletionResponseChoice item in Choices)
                {
                    writer.WriteObjectValue(item, options);
                }
                writer.WriteEndArray();
            }
            if (_additionalBinaryDataProperties?.ContainsKey("created") != true)
            {
                writer.WritePropertyName("created"u8);
                writer.WriteNumberValue(Created, "U");
            }
            if (_additionalBinaryDataProperties?.ContainsKey("model") != true)
            {
                writer.WritePropertyName("model"u8);
                writer.WriteStringValue(Model);
            }
            if (Optional.IsDefined(SystemFingerprint) && _additionalBinaryDataProperties?.ContainsKey("system_fingerprint") != true)
            {
                writer.WritePropertyName("system_fingerprint"u8);
                writer.WriteStringValue(SystemFingerprint);
            }
            if (_additionalBinaryDataProperties?.ContainsKey("object") != true)
            {
                writer.WritePropertyName("object"u8);
                writer.WriteStringValue(Object.ToString());
            }
            if (Optional.IsDefined(Usage) && _additionalBinaryDataProperties?.ContainsKey("usage") != true)
            {
                writer.WritePropertyName("usage"u8);
                writer.WriteObjectValue(Usage, options);
            }
            if (_additionalBinaryDataProperties != null)
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

        InternalCreateCompletionResponse IJsonModel<InternalCreateCompletionResponse>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual InternalCreateCompletionResponse JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalCreateCompletionResponse>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalCreateCompletionResponse)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalCreateCompletionResponse(document.RootElement, options);
        }

        internal static InternalCreateCompletionResponse DeserializeInternalCreateCompletionResponse(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string id = default;
            IList<InternalCreateCompletionResponseChoice> choices = default;
            DateTimeOffset created = default;
            string model = default;
            string systemFingerprint = default;
            InternalCreateCompletionResponseObject @object = default;
            ChatTokenUsage usage = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("id"u8))
                {
                    id = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("choices"u8))
                {
                    List<InternalCreateCompletionResponseChoice> array = new List<InternalCreateCompletionResponseChoice>();
                    foreach (var item in prop.Value.EnumerateArray())
                    {
                        array.Add(InternalCreateCompletionResponseChoice.DeserializeInternalCreateCompletionResponseChoice(item, options));
                    }
                    choices = array;
                    continue;
                }
                if (prop.NameEquals("created"u8))
                {
                    created = DateTimeOffset.FromUnixTimeSeconds(prop.Value.GetInt64());
                    continue;
                }
                if (prop.NameEquals("model"u8))
                {
                    model = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("system_fingerprint"u8))
                {
                    systemFingerprint = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("object"u8))
                {
                    @object = new InternalCreateCompletionResponseObject(prop.Value.GetString());
                    continue;
                }
                if (prop.NameEquals("usage"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    usage = ChatTokenUsage.DeserializeChatTokenUsage(prop.Value, options);
                    continue;
                }
                additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
            }
            return new InternalCreateCompletionResponse(
                id,
                choices,
                created,
                model,
                systemFingerprint,
                @object,
                usage,
                additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<InternalCreateCompletionResponse>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalCreateCompletionResponse>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalCreateCompletionResponse)} does not support writing '{options.Format}' format.");
            }
        }

        InternalCreateCompletionResponse IPersistableModel<InternalCreateCompletionResponse>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        protected virtual InternalCreateCompletionResponse PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalCreateCompletionResponse>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeInternalCreateCompletionResponse(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalCreateCompletionResponse)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalCreateCompletionResponse>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(InternalCreateCompletionResponse internalCreateCompletionResponse)
        {
            if (internalCreateCompletionResponse == null)
            {
                return null;
            }
            return BinaryContent.Create(internalCreateCompletionResponse, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator InternalCreateCompletionResponse(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeInternalCreateCompletionResponse(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
