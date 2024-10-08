// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Text.Json;
using OpenAI;

namespace OpenAI.Files
{
    public partial class OpenAIFileCollection : IJsonModel<OpenAIFileCollection>
    {
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<OpenAIFileCollection>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(OpenAIFileCollection)} does not support writing '{format}' format.");
            }
            writer.WritePropertyName("object"u8);
            writer.WriteObjectValue<InternalListFilesResponseObject>(Object, options);
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

        OpenAIFileCollection IJsonModel<OpenAIFileCollection>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual OpenAIFileCollection JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<OpenAIFileCollection>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(OpenAIFileCollection)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return OpenAIFileCollection.DeserializeOpenAIFileCollection(document.RootElement, options);
        }

        BinaryData IPersistableModel<OpenAIFileCollection>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<OpenAIFileCollection>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(OpenAIFileCollection)} does not support writing '{options.Format}' format.");
            }
        }

        OpenAIFileCollection IPersistableModel<OpenAIFileCollection>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        protected virtual OpenAIFileCollection PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<OpenAIFileCollection>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return OpenAIFileCollection.DeserializeOpenAIFileCollection(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(OpenAIFileCollection)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<OpenAIFileCollection>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(OpenAIFileCollection openAIFileCollection)
        {
            return BinaryContent.Create(openAIFileCollection, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator OpenAIFileCollection(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return OpenAIFileCollection.DeserializeOpenAIFileCollection(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
