// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Internal.Models
{
    internal partial class CreateThreadAndRunRequestToolResources : IJsonModel<CreateThreadAndRunRequestToolResources>
    {
        void IJsonModel<CreateThreadAndRunRequestToolResources>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<CreateThreadAndRunRequestToolResources>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(CreateThreadAndRunRequestToolResources)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            if (Optional.IsDefined(CodeInterpreter))
            {
                writer.WritePropertyName("code_interpreter"u8);
                writer.WriteObjectValue(CodeInterpreter, options);
            }
            if (Optional.IsDefined(FileSearch))
            {
                writer.WritePropertyName("file_search"u8);
                writer.WriteObjectValue(FileSearch, options);
            }
            if (options.Format != "W" && _serializedAdditionalRawData != null)
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

        CreateThreadAndRunRequestToolResources IJsonModel<CreateThreadAndRunRequestToolResources>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<CreateThreadAndRunRequestToolResources>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(CreateThreadAndRunRequestToolResources)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeCreateThreadAndRunRequestToolResources(document.RootElement, options);
        }

        internal static CreateThreadAndRunRequestToolResources DeserializeCreateThreadAndRunRequestToolResources(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            CreateThreadAndRunRequestToolResourcesCodeInterpreter codeInterpreter = default;
            CreateThreadAndRunRequestToolResourcesFileSearch fileSearch = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("code_interpreter"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    codeInterpreter = CreateThreadAndRunRequestToolResourcesCodeInterpreter.DeserializeCreateThreadAndRunRequestToolResourcesCodeInterpreter(property.Value, options);
                    continue;
                }
                if (property.NameEquals("file_search"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    fileSearch = CreateThreadAndRunRequestToolResourcesFileSearch.DeserializeCreateThreadAndRunRequestToolResourcesFileSearch(property.Value, options);
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new CreateThreadAndRunRequestToolResources(codeInterpreter, fileSearch, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<CreateThreadAndRunRequestToolResources>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<CreateThreadAndRunRequestToolResources>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(CreateThreadAndRunRequestToolResources)} does not support writing '{options.Format}' format.");
            }
        }

        CreateThreadAndRunRequestToolResources IPersistableModel<CreateThreadAndRunRequestToolResources>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<CreateThreadAndRunRequestToolResources>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeCreateThreadAndRunRequestToolResources(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(CreateThreadAndRunRequestToolResources)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<CreateThreadAndRunRequestToolResources>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The result to deserialize the model from. </param>
        internal static CreateThreadAndRunRequestToolResources FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeCreateThreadAndRunRequestToolResources(document.RootElement);
        }

        /// <summary> Convert into a <see cref="BinaryContent"/>. </summary>
        internal virtual BinaryContent ToBinaryContent()
        {
            return BinaryContent.Create(this, ModelSerializationExtensions.WireOptions);
        }
    }
}
