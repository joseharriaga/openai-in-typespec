// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Internal.Models
{
    internal partial class CreateAssistantRequestToolResourcesFileSearchBase : IJsonModel<CreateAssistantRequestToolResourcesFileSearchBase>
    {
        void IJsonModel<CreateAssistantRequestToolResourcesFileSearchBase>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<CreateAssistantRequestToolResourcesFileSearchBase>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(CreateAssistantRequestToolResourcesFileSearchBase)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            if (true && _serializedAdditionalRawData != null)
            {
                foreach (var item in _serializedAdditionalRawData)
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
            writer.WriteEndObject();
        }

        CreateAssistantRequestToolResourcesFileSearchBase IJsonModel<CreateAssistantRequestToolResourcesFileSearchBase>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<CreateAssistantRequestToolResourcesFileSearchBase>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(CreateAssistantRequestToolResourcesFileSearchBase)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeCreateAssistantRequestToolResourcesFileSearchBase(document.RootElement, options);
        }

        internal static CreateAssistantRequestToolResourcesFileSearchBase DeserializeCreateAssistantRequestToolResourcesFileSearchBase(JsonElement element, ModelReaderWriterOptions options = null)
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
                if (true)
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new CreateAssistantRequestToolResourcesFileSearchBase(serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<CreateAssistantRequestToolResourcesFileSearchBase>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<CreateAssistantRequestToolResourcesFileSearchBase>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(CreateAssistantRequestToolResourcesFileSearchBase)} does not support writing '{options.Format}' format.");
            }
        }

        CreateAssistantRequestToolResourcesFileSearchBase IPersistableModel<CreateAssistantRequestToolResourcesFileSearchBase>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<CreateAssistantRequestToolResourcesFileSearchBase>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeCreateAssistantRequestToolResourcesFileSearchBase(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(CreateAssistantRequestToolResourcesFileSearchBase)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<CreateAssistantRequestToolResourcesFileSearchBase>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        internal static CreateAssistantRequestToolResourcesFileSearchBase FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeCreateAssistantRequestToolResourcesFileSearchBase(document.RootElement);
        }

        internal virtual BinaryContent ToBinaryContent()
        {
            return BinaryContent.Create(this, ModelSerializationExtensions.WireOptions);
        }
    }
}