// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Assistants
{
    internal partial class InternalCreateAssistantRequestToolResourcesFileSearchBase : IJsonModel<InternalCreateAssistantRequestToolResourcesFileSearchBase>
    {
        void IJsonModel<InternalCreateAssistantRequestToolResourcesFileSearchBase>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalCreateAssistantRequestToolResourcesFileSearchBase>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalCreateAssistantRequestToolResourcesFileSearchBase)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
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

        InternalCreateAssistantRequestToolResourcesFileSearchBase IJsonModel<InternalCreateAssistantRequestToolResourcesFileSearchBase>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalCreateAssistantRequestToolResourcesFileSearchBase>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalCreateAssistantRequestToolResourcesFileSearchBase)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalCreateAssistantRequestToolResourcesFileSearchBase(document.RootElement, options);
        }

        internal static InternalCreateAssistantRequestToolResourcesFileSearchBase DeserializeInternalCreateAssistantRequestToolResourcesFileSearchBase(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (options.Format != "W")
                {
                    rawDataDictionary ??= new Dictionary<string, BinaryData>();
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new InternalCreateAssistantRequestToolResourcesFileSearchBase(serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<InternalCreateAssistantRequestToolResourcesFileSearchBase>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalCreateAssistantRequestToolResourcesFileSearchBase>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalCreateAssistantRequestToolResourcesFileSearchBase)} does not support writing '{options.Format}' format.");
            }
        }

        InternalCreateAssistantRequestToolResourcesFileSearchBase IPersistableModel<InternalCreateAssistantRequestToolResourcesFileSearchBase>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalCreateAssistantRequestToolResourcesFileSearchBase>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeInternalCreateAssistantRequestToolResourcesFileSearchBase(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalCreateAssistantRequestToolResourcesFileSearchBase)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalCreateAssistantRequestToolResourcesFileSearchBase>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        internal static InternalCreateAssistantRequestToolResourcesFileSearchBase FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeInternalCreateAssistantRequestToolResourcesFileSearchBase(document.RootElement);
        }

        internal virtual BinaryContent ToBinaryContent()
        {
            return BinaryContent.Create(this, ModelSerializationExtensions.WireOptions);
        }
    }
}
