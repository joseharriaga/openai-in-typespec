// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Assistants
{
    internal partial class InternalCreateThreadAndRunRequestToolResources : IJsonModel<InternalCreateThreadAndRunRequestToolResources>
    {
        void IJsonModel<InternalCreateThreadAndRunRequestToolResources>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalCreateThreadAndRunRequestToolResources>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalCreateThreadAndRunRequestToolResources)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            if (SerializedAdditionalRawData?.ContainsKey("code_interpreter") != true && Optional.IsDefined(CodeInterpreter))
            {
                writer.WritePropertyName("code_interpreter"u8);
                writer.WriteObjectValue(CodeInterpreter, options);
            }
            if (SerializedAdditionalRawData?.ContainsKey("file_search") != true && Optional.IsDefined(FileSearch))
            {
                writer.WritePropertyName("file_search"u8);
                writer.WriteObjectValue(FileSearch, options);
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

        InternalCreateThreadAndRunRequestToolResources IJsonModel<InternalCreateThreadAndRunRequestToolResources>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalCreateThreadAndRunRequestToolResources>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalCreateThreadAndRunRequestToolResources)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalCreateThreadAndRunRequestToolResources(document.RootElement, options);
        }

        internal static InternalCreateThreadAndRunRequestToolResources DeserializeInternalCreateThreadAndRunRequestToolResources(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            InternalCreateThreadAndRunRequestToolResourcesCodeInterpreter codeInterpreter = default;
            InternalToolResourcesFileSearchIdsOnly fileSearch = default;
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
                    codeInterpreter = InternalCreateThreadAndRunRequestToolResourcesCodeInterpreter.DeserializeInternalCreateThreadAndRunRequestToolResourcesCodeInterpreter(property.Value, options);
                    continue;
                }
                if (property.NameEquals("file_search"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    fileSearch = InternalToolResourcesFileSearchIdsOnly.DeserializeInternalToolResourcesFileSearchIdsOnly(property.Value, options);
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary ??= new Dictionary<string, BinaryData>();
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new InternalCreateThreadAndRunRequestToolResources(codeInterpreter, fileSearch, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<InternalCreateThreadAndRunRequestToolResources>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalCreateThreadAndRunRequestToolResources>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalCreateThreadAndRunRequestToolResources)} does not support writing '{options.Format}' format.");
            }
        }

        InternalCreateThreadAndRunRequestToolResources IPersistableModel<InternalCreateThreadAndRunRequestToolResources>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalCreateThreadAndRunRequestToolResources>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeInternalCreateThreadAndRunRequestToolResources(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalCreateThreadAndRunRequestToolResources)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalCreateThreadAndRunRequestToolResources>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        internal static InternalCreateThreadAndRunRequestToolResources FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeInternalCreateThreadAndRunRequestToolResources(document.RootElement);
        }

        internal virtual BinaryContent ToBinaryContent()
        {
            return BinaryContent.Create(this, ModelSerializationExtensions.WireOptions);
        }
    }
}
