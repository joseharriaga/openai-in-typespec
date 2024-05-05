// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Internal.Models
{
    internal partial class RunStepDetailsToolCallsRetrievalObject : IJsonModel<RunStepDetailsToolCallsRetrievalObject>
    {
        void IJsonModel<RunStepDetailsToolCallsRetrievalObject>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<RunStepDetailsToolCallsRetrievalObject>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(RunStepDetailsToolCallsRetrievalObject)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("id"u8);
            writer.WriteStringValue(Id);
            writer.WritePropertyName("type"u8);
            writer.WriteStringValue(Type.ToString());
            writer.WritePropertyName("retrieval"u8);
            writer.WriteObjectValue(Retrieval, options);
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

        RunStepDetailsToolCallsRetrievalObject IJsonModel<RunStepDetailsToolCallsRetrievalObject>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<RunStepDetailsToolCallsRetrievalObject>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(RunStepDetailsToolCallsRetrievalObject)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeRunStepDetailsToolCallsRetrievalObject(document.RootElement, options);
        }

        internal static RunStepDetailsToolCallsRetrievalObject DeserializeRunStepDetailsToolCallsRetrievalObject(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string id = default;
            RunStepDetailsToolCallsRetrievalObjectType type = default;
            RunStepDetailsToolCallsRetrievalObjectRetrieval retrieval = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"u8))
                {
                    id = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"u8))
                {
                    type = new RunStepDetailsToolCallsRetrievalObjectType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("retrieval"u8))
                {
                    retrieval = RunStepDetailsToolCallsRetrievalObjectRetrieval.DeserializeRunStepDetailsToolCallsRetrievalObjectRetrieval(property.Value, options);
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new RunStepDetailsToolCallsRetrievalObject(id, type, retrieval, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<RunStepDetailsToolCallsRetrievalObject>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<RunStepDetailsToolCallsRetrievalObject>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(RunStepDetailsToolCallsRetrievalObject)} does not support writing '{options.Format}' format.");
            }
        }

        RunStepDetailsToolCallsRetrievalObject IPersistableModel<RunStepDetailsToolCallsRetrievalObject>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<RunStepDetailsToolCallsRetrievalObject>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeRunStepDetailsToolCallsRetrievalObject(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(RunStepDetailsToolCallsRetrievalObject)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<RunStepDetailsToolCallsRetrievalObject>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The result to deserialize the model from. </param>
        internal static RunStepDetailsToolCallsRetrievalObject FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeRunStepDetailsToolCallsRetrievalObject(document.RootElement);
        }

        /// <summary> Convert into a <see cref="BinaryContent"/>. </summary>
        internal virtual BinaryContent ToBinaryContent()
        {
            return BinaryContent.Create(this, ModelSerializationExtensions.WireOptions);
        }
    }
}
