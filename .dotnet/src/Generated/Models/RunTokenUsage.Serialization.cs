// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using OpenAI;

namespace OpenAI.Assistants
{
    public partial class RunTokenUsage : IJsonModel<RunTokenUsage>
    {
        internal RunTokenUsage()
        {
        }

        void IJsonModel<RunTokenUsage>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<RunTokenUsage>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(RunTokenUsage)} does not support writing '{format}' format.");
            }
            writer.WritePropertyName("completion_tokens"u8);
            writer.WriteNumberValue(OutputTokenCount);
            writer.WritePropertyName("prompt_tokens"u8);
            writer.WriteNumberValue(InputTokenCount);
            writer.WritePropertyName("total_tokens"u8);
            writer.WriteNumberValue(TotalTokenCount);
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

        RunTokenUsage IJsonModel<RunTokenUsage>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual RunTokenUsage JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<RunTokenUsage>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(RunTokenUsage)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeRunTokenUsage(document.RootElement, options);
        }

        internal static RunTokenUsage DeserializeRunTokenUsage(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            int outputTokenCount = default;
            int inputTokenCount = default;
            int totalTokenCount = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("completion_tokens"u8))
                {
                    outputTokenCount = prop.Value.GetInt32();
                    continue;
                }
                if (prop.NameEquals("prompt_tokens"u8))
                {
                    inputTokenCount = prop.Value.GetInt32();
                    continue;
                }
                if (prop.NameEquals("total_tokens"u8))
                {
                    totalTokenCount = prop.Value.GetInt32();
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new RunTokenUsage(outputTokenCount, inputTokenCount, totalTokenCount, additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<RunTokenUsage>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<RunTokenUsage>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(RunTokenUsage)} does not support writing '{options.Format}' format.");
            }
        }

        RunTokenUsage IPersistableModel<RunTokenUsage>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        protected virtual RunTokenUsage PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<RunTokenUsage>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeRunTokenUsage(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(RunTokenUsage)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<RunTokenUsage>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(RunTokenUsage runTokenUsage)
        {
            return BinaryContent.Create(runTokenUsage, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator RunTokenUsage(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeRunTokenUsage(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
