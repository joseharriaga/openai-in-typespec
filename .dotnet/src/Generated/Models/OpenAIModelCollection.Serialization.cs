// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Text.Json;
using OpenAI;

namespace OpenAI.Models
{
    public partial class OpenAIModelCollection : IJsonModel<OpenAIModelCollection>
    {
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<OpenAIModelCollection>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(OpenAIModelCollection)} does not support writing '{format}' format.");
            }
            writer.WritePropertyName("object"u8);
            writer.WriteObjectValue<InternalListModelsResponseObject>(Object, options);
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

        OpenAIModelCollection IJsonModel<OpenAIModelCollection>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual OpenAIModelCollection JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<OpenAIModelCollection>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(OpenAIModelCollection)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return OpenAIModelCollection.DeserializeOpenAIModelCollection(document.RootElement, options);
        }

        BinaryData IPersistableModel<OpenAIModelCollection>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<OpenAIModelCollection>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(OpenAIModelCollection)} does not support writing '{options.Format}' format.");
            }
        }

        OpenAIModelCollection IPersistableModel<OpenAIModelCollection>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        protected virtual OpenAIModelCollection PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<OpenAIModelCollection>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return OpenAIModelCollection.DeserializeOpenAIModelCollection(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(OpenAIModelCollection)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<OpenAIModelCollection>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(OpenAIModelCollection openAIModelCollection)
        {
            return BinaryContent.Create(openAIModelCollection, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator OpenAIModelCollection(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return OpenAIModelCollection.DeserializeOpenAIModelCollection(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
