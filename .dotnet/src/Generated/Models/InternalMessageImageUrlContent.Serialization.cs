// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Assistants
{
    internal partial class InternalMessageImageUrlContent : IJsonModel<InternalMessageImageUrlContent>
    {
        InternalMessageImageUrlContent IJsonModel<InternalMessageImageUrlContent>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalMessageImageUrlContent>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalMessageImageUrlContent)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalMessageImageUrlContent(document.RootElement, options);
        }

        internal static InternalMessageImageUrlContent DeserializeInternalMessageImageUrlContent(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string type = default;
            InternalMessageContentImageUrlObjectImageUrl imageUrl = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("type"u8))
                {
                    type = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("image_url"u8))
                {
                    imageUrl = InternalMessageContentImageUrlObjectImageUrl.DeserializeInternalMessageContentImageUrlObjectImageUrl(property.Value, options);
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new InternalMessageImageUrlContent(serializedAdditionalRawData, type, imageUrl);
        }

        BinaryData IPersistableModel<InternalMessageImageUrlContent>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalMessageImageUrlContent>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalMessageImageUrlContent)} does not support writing '{options.Format}' format.");
            }
        }

        InternalMessageImageUrlContent IPersistableModel<InternalMessageImageUrlContent>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalMessageImageUrlContent>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeInternalMessageImageUrlContent(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalMessageImageUrlContent)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalMessageImageUrlContent>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        internal static new InternalMessageImageUrlContent FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeInternalMessageImageUrlContent(document.RootElement);
        }

        internal override BinaryContent ToBinaryContent()
        {
            return BinaryContent.Create(this, ModelSerializationExtensions.WireOptions);
        }
    }
}
