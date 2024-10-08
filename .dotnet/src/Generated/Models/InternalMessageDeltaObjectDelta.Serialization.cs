// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Assistants
{
    internal partial class InternalMessageDeltaObjectDelta : IJsonModel<InternalMessageDeltaObjectDelta>
    {
        void IJsonModel<InternalMessageDeltaObjectDelta>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalMessageDeltaObjectDelta>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalMessageDeltaObjectDelta)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            if (SerializedAdditionalRawData?.ContainsKey("role") != true)
            {
                writer.WritePropertyName("role"u8);
                writer.WriteStringValue(Role.ToSerialString());
            }
            if (SerializedAdditionalRawData?.ContainsKey("content") != true && Optional.IsCollectionDefined(Content))
            {
                writer.WritePropertyName("content"u8);
                writer.WriteStartArray();
                foreach (var item in Content)
                {
                    writer.WriteObjectValue(item, options);
                }
                writer.WriteEndArray();
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

        InternalMessageDeltaObjectDelta IJsonModel<InternalMessageDeltaObjectDelta>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalMessageDeltaObjectDelta>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalMessageDeltaObjectDelta)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalMessageDeltaObjectDelta(document.RootElement, options);
        }

        internal static InternalMessageDeltaObjectDelta DeserializeInternalMessageDeltaObjectDelta(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            MessageRole role = default;
            IReadOnlyList<InternalMessageDeltaContent> content = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("role"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    role = property.Value.GetString().ToMessageRole();
                    continue;
                }
                if (property.NameEquals("content"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<InternalMessageDeltaContent> array = new List<InternalMessageDeltaContent>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(InternalMessageDeltaContent.DeserializeInternalMessageDeltaContent(item, options));
                    }
                    content = array;
                    continue;
                }
                if (true)
                {
                    rawDataDictionary ??= new Dictionary<string, BinaryData>();
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new InternalMessageDeltaObjectDelta(role, content ?? new ChangeTrackingList<InternalMessageDeltaContent>(), serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<InternalMessageDeltaObjectDelta>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalMessageDeltaObjectDelta>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalMessageDeltaObjectDelta)} does not support writing '{options.Format}' format.");
            }
        }

        InternalMessageDeltaObjectDelta IPersistableModel<InternalMessageDeltaObjectDelta>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalMessageDeltaObjectDelta>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeInternalMessageDeltaObjectDelta(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalMessageDeltaObjectDelta)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalMessageDeltaObjectDelta>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        internal static InternalMessageDeltaObjectDelta FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeInternalMessageDeltaObjectDelta(document.RootElement);
        }

        internal virtual BinaryContent ToBinaryContent()
        {
            return BinaryContent.Create(this, ModelSerializationExtensions.WireOptions);
        }
    }
}
