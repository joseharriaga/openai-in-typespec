// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using OpenAI;

namespace OpenAI.Assistants
{
    public partial class AssistantDeletionResult : IJsonModel<AssistantDeletionResult>
    {
        internal AssistantDeletionResult()
        {
        }

        void IJsonModel<AssistantDeletionResult>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<AssistantDeletionResult>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(AssistantDeletionResult)} does not support writing '{format}' format.");
            }
            if (_additionalBinaryDataProperties?.ContainsKey("deleted") != true)
            {
                writer.WritePropertyName("deleted"u8);
                writer.WriteBooleanValue(Deleted);
            }
            if (_additionalBinaryDataProperties?.ContainsKey("id") != true)
            {
                writer.WritePropertyName("id"u8);
                writer.WriteStringValue(AssistantId);
            }
            if (_additionalBinaryDataProperties?.ContainsKey("object") != true)
            {
                writer.WritePropertyName("object"u8);
                writer.WriteStringValue(this.Object.ToString());
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

        AssistantDeletionResult IJsonModel<AssistantDeletionResult>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual AssistantDeletionResult JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<AssistantDeletionResult>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(AssistantDeletionResult)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeAssistantDeletionResult(document.RootElement, options);
        }

        internal static AssistantDeletionResult DeserializeAssistantDeletionResult(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            bool deleted = default;
            string assistantId = default;
            InternalDeleteAssistantResponseObject @object = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("deleted"u8))
                {
                    deleted = prop.Value.GetBoolean();
                    continue;
                }
                if (prop.NameEquals("id"u8))
                {
                    assistantId = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("object"u8))
                {
                    @object = new InternalDeleteAssistantResponseObject(prop.Value.GetString());
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new AssistantDeletionResult(deleted, assistantId, @object, additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<AssistantDeletionResult>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<AssistantDeletionResult>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(AssistantDeletionResult)} does not support writing '{options.Format}' format.");
            }
        }

        AssistantDeletionResult IPersistableModel<AssistantDeletionResult>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        protected virtual AssistantDeletionResult PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<AssistantDeletionResult>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeAssistantDeletionResult(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(AssistantDeletionResult)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<AssistantDeletionResult>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(AssistantDeletionResult assistantDeletionResult)
        {
            return BinaryContent.Create(assistantDeletionResult, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator AssistantDeletionResult(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeAssistantDeletionResult(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
