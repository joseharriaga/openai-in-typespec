// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using OpenAI;

namespace OpenAI.Models
{
    public partial class ModelDeletionResult : IJsonModel<ModelDeletionResult>
    {
        internal ModelDeletionResult()
        {
        }

        void IJsonModel<ModelDeletionResult>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ModelDeletionResult>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ModelDeletionResult)} does not support writing '{format}' format.");
            }
            if (_additionalBinaryDataProperties?.ContainsKey("deleted") != true)
            {
                writer.WritePropertyName("deleted"u8);
                writer.WriteBooleanValue(Deleted);
            }
            if (_additionalBinaryDataProperties?.ContainsKey("id") != true)
            {
                writer.WritePropertyName("id"u8);
                writer.WriteStringValue(ModelId);
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

        ModelDeletionResult IJsonModel<ModelDeletionResult>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual ModelDeletionResult JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ModelDeletionResult>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ModelDeletionResult)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeModelDeletionResult(document.RootElement, options);
        }

        internal static ModelDeletionResult DeserializeModelDeletionResult(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            bool deleted = default;
            string modelId = default;
            InternalDeleteModelResponseObject @object = default;
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
                    modelId = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("object"u8))
                {
                    @object = new InternalDeleteModelResponseObject(prop.Value.GetString());
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new ModelDeletionResult(deleted, modelId, @object, additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<ModelDeletionResult>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ModelDeletionResult>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(ModelDeletionResult)} does not support writing '{options.Format}' format.");
            }
        }

        ModelDeletionResult IPersistableModel<ModelDeletionResult>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        protected virtual ModelDeletionResult PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ModelDeletionResult>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeModelDeletionResult(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(ModelDeletionResult)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<ModelDeletionResult>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(ModelDeletionResult modelDeletionResult)
        {
            if (modelDeletionResult == null)
            {
                return null;
            }
            return BinaryContent.Create(modelDeletionResult, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator ModelDeletionResult(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeModelDeletionResult(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
