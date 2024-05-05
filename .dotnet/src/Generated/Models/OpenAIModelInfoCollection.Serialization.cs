// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace OpenAI.Models
{
    public partial class OpenAIModelInfoCollection : IJsonModel<OpenAIModelInfoCollection>
    {
        OpenAIModelInfoCollection IJsonModel<OpenAIModelInfoCollection>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<OpenAIModelInfoCollection>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(OpenAIModelInfoCollection)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeOpenAIModelInfoCollection(document.RootElement, options);
        }

        BinaryData IPersistableModel<OpenAIModelInfoCollection>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<OpenAIModelInfoCollection>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(OpenAIModelInfoCollection)} does not support writing '{options.Format}' format.");
            }
        }

        OpenAIModelInfoCollection IPersistableModel<OpenAIModelInfoCollection>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<OpenAIModelInfoCollection>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeOpenAIModelInfoCollection(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(OpenAIModelInfoCollection)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<OpenAIModelInfoCollection>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The result to deserialize the model from. </param>
        internal static OpenAIModelInfoCollection FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeOpenAIModelInfoCollection(document.RootElement);
        }

        /// <summary> Convert into a <see cref="BinaryContent"/>. </summary>
        internal virtual BinaryContent ToBinaryContent()
        {
            return BinaryContent.Create(this, ModelSerializationExtensions.WireOptions);
        }
    }
}
