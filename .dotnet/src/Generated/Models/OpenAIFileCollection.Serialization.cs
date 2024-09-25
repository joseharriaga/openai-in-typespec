// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace OpenAI.Files
{
    public partial class OpenAIFileCollection : IJsonModel<OpenAIFileCollection>
    {
        OpenAIFileCollection IJsonModel<OpenAIFileCollection>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<OpenAIFileCollection>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(OpenAIFileCollection)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeOpenAIFileCollection(document.RootElement, options);
        }

        BinaryData IPersistableModel<OpenAIFileCollection>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<OpenAIFileCollection>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(OpenAIFileCollection)} does not support writing '{options.Format}' format.");
            }
        }

        OpenAIFileCollection IPersistableModel<OpenAIFileCollection>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<OpenAIFileCollection>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeOpenAIFileCollection(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(OpenAIFileCollection)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<OpenAIFileCollection>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        internal static OpenAIFileCollection FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeOpenAIFileCollection(document.RootElement);
        }

        internal virtual BinaryContent ToBinaryContent()
        {
            return BinaryContent.Create(this, ModelSerializationExtensions.WireOptions);
        }
    }
}
