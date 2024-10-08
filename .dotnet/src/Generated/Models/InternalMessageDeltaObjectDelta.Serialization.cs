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
    internal partial class InternalMessageDeltaObjectDelta : IJsonModel<InternalMessageDeltaObjectDelta>
    {
        void IJsonModel<InternalMessageDeltaObjectDelta>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalMessageDeltaObjectDelta>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalMessageDeltaObjectDelta)} does not support writing '{format}' format.");
            }
            if (Optional.IsCollectionDefined(Content))
            {
                writer.WritePropertyName("content"u8);
                writer.WriteStartArray();
                foreach (InternalMessageDeltaContent item in Content)
                {
                    writer.WriteObjectValue(item, options);
                }
                writer.WriteEndArray();
            }
            writer.WritePropertyName("role"u8);
            writer.WriteNumberValue((int)Role);
            if (options.Format != "W" && _additionalBinaryDataProperties != null)
            {
                foreach (var item in _additionalBinaryDataProperties)
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
        }

        InternalMessageDeltaObjectDelta IJsonModel<InternalMessageDeltaObjectDelta>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual InternalMessageDeltaObjectDelta JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalMessageDeltaObjectDelta>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalMessageDeltaObjectDelta)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalMessageDeltaObjectDelta(document.RootElement, options);
        }

        internal static InternalMessageDeltaObjectDelta DeserializeInternalMessageDeltaObjectDelta(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IList<InternalMessageDeltaContent> content = default;
            Assistants.MessageRole role = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("content"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<InternalMessageDeltaContent> array = new List<InternalMessageDeltaContent>();
                    foreach (var item in prop.Value.EnumerateArray())
                    {
                        array.Add(InternalMessageDeltaContent.DeserializeInternalMessageDeltaContent(item, options));
                    }
                    content = array;
                    continue;
                }
                if (prop.NameEquals("role"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        role = null;
                        continue;
                    }
                    role = prop.Value.GetInt32().ToMessageRole();
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new InternalMessageDeltaObjectDelta(content ?? new ChangeTrackingList<InternalMessageDeltaContent>(), role, additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<InternalMessageDeltaObjectDelta>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalMessageDeltaObjectDelta>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalMessageDeltaObjectDelta)} does not support writing '{options.Format}' format.");
            }
        }

        InternalMessageDeltaObjectDelta IPersistableModel<InternalMessageDeltaObjectDelta>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        protected virtual InternalMessageDeltaObjectDelta PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalMessageDeltaObjectDelta>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeInternalMessageDeltaObjectDelta(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalMessageDeltaObjectDelta)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalMessageDeltaObjectDelta>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(InternalMessageDeltaObjectDelta internalMessageDeltaObjectDelta)
        {
            return BinaryContent.Create(internalMessageDeltaObjectDelta, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator InternalMessageDeltaObjectDelta(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeInternalMessageDeltaObjectDelta(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
