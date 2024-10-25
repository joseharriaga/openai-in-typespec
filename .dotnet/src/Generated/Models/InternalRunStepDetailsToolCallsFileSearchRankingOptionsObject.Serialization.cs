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
    internal partial class InternalRunStepDetailsToolCallsFileSearchRankingOptionsObject : IJsonModel<InternalRunStepDetailsToolCallsFileSearchRankingOptionsObject>
    {
        internal InternalRunStepDetailsToolCallsFileSearchRankingOptionsObject()
        {
        }

        void IJsonModel<InternalRunStepDetailsToolCallsFileSearchRankingOptionsObject>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRunStepDetailsToolCallsFileSearchRankingOptionsObject>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalRunStepDetailsToolCallsFileSearchRankingOptionsObject)} does not support writing '{format}' format.");
            }
            if (_additionalBinaryDataProperties?.ContainsKey("ranker") != true)
            {
                writer.WritePropertyName("ranker"u8);
                writer.WriteStringValue(Ranker.ToString());
            }
            if (_additionalBinaryDataProperties?.ContainsKey("score_threshold") != true)
            {
                writer.WritePropertyName("score_threshold"u8);
                writer.WriteNumberValue(ScoreThreshold);
            }
            if (options.Format != "W" && _additionalBinaryDataProperties != null)
            {
                foreach (var item in _additionalBinaryDataProperties)
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
        }

        InternalRunStepDetailsToolCallsFileSearchRankingOptionsObject IJsonModel<InternalRunStepDetailsToolCallsFileSearchRankingOptionsObject>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual InternalRunStepDetailsToolCallsFileSearchRankingOptionsObject JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRunStepDetailsToolCallsFileSearchRankingOptionsObject>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalRunStepDetailsToolCallsFileSearchRankingOptionsObject)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalRunStepDetailsToolCallsFileSearchRankingOptionsObject(document.RootElement, options);
        }

        internal static InternalRunStepDetailsToolCallsFileSearchRankingOptionsObject DeserializeInternalRunStepDetailsToolCallsFileSearchRankingOptionsObject(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            InternalRunStepDetailsToolCallsFileSearchRankingOptionsObjectRanker ranker = default;
            float scoreThreshold = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("ranker"u8))
                {
                    ranker = new InternalRunStepDetailsToolCallsFileSearchRankingOptionsObjectRanker(prop.Value.GetString());
                    continue;
                }
                if (prop.NameEquals("score_threshold"u8))
                {
                    scoreThreshold = prop.Value.GetSingle();
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new InternalRunStepDetailsToolCallsFileSearchRankingOptionsObject(ranker, scoreThreshold, additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<InternalRunStepDetailsToolCallsFileSearchRankingOptionsObject>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRunStepDetailsToolCallsFileSearchRankingOptionsObject>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalRunStepDetailsToolCallsFileSearchRankingOptionsObject)} does not support writing '{options.Format}' format.");
            }
        }

        InternalRunStepDetailsToolCallsFileSearchRankingOptionsObject IPersistableModel<InternalRunStepDetailsToolCallsFileSearchRankingOptionsObject>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        protected virtual InternalRunStepDetailsToolCallsFileSearchRankingOptionsObject PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRunStepDetailsToolCallsFileSearchRankingOptionsObject>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeInternalRunStepDetailsToolCallsFileSearchRankingOptionsObject(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalRunStepDetailsToolCallsFileSearchRankingOptionsObject)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalRunStepDetailsToolCallsFileSearchRankingOptionsObject>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(InternalRunStepDetailsToolCallsFileSearchRankingOptionsObject internalRunStepDetailsToolCallsFileSearchRankingOptionsObject)
        {
            return BinaryContent.Create(internalRunStepDetailsToolCallsFileSearchRankingOptionsObject, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator InternalRunStepDetailsToolCallsFileSearchRankingOptionsObject(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeInternalRunStepDetailsToolCallsFileSearchRankingOptionsObject(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
