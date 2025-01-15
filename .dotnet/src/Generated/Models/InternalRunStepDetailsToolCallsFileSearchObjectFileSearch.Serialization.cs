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
    internal partial class InternalRunStepDetailsToolCallsFileSearchObjectFileSearch : IJsonModel<InternalRunStepDetailsToolCallsFileSearchObjectFileSearch>
    {
        void IJsonModel<InternalRunStepDetailsToolCallsFileSearchObjectFileSearch>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRunStepDetailsToolCallsFileSearchObjectFileSearch>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalRunStepDetailsToolCallsFileSearchObjectFileSearch)} does not support writing '{format}' format.");
            }
            if (true && Optional.IsCollectionDefined(Results) && _additionalBinaryDataProperties?.ContainsKey("results") != true)
            {
                writer.WritePropertyName("results"u8);
                writer.WriteStartArray();
                foreach (RunStepFileSearchResult item in Results)
                {
                    writer.WriteObjectValue(item, options);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(RankingOptions) && _additionalBinaryDataProperties?.ContainsKey("ranking_options") != true)
            {
                writer.WritePropertyName("ranking_options"u8);
                writer.WriteObjectValue(RankingOptions, options);
            }
            if (true && _additionalBinaryDataProperties != null)
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

        InternalRunStepDetailsToolCallsFileSearchObjectFileSearch IJsonModel<InternalRunStepDetailsToolCallsFileSearchObjectFileSearch>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual InternalRunStepDetailsToolCallsFileSearchObjectFileSearch JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRunStepDetailsToolCallsFileSearchObjectFileSearch>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalRunStepDetailsToolCallsFileSearchObjectFileSearch)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalRunStepDetailsToolCallsFileSearchObjectFileSearch(document.RootElement, options);
        }

        internal static InternalRunStepDetailsToolCallsFileSearchObjectFileSearch DeserializeInternalRunStepDetailsToolCallsFileSearchObjectFileSearch(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IReadOnlyList<RunStepFileSearchResult> results = default;
            FileSearchRankingOptions rankingOptions = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("results"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<RunStepFileSearchResult> array = new List<RunStepFileSearchResult>();
                    foreach (var item in prop.Value.EnumerateArray())
                    {
                        array.Add(RunStepFileSearchResult.DeserializeRunStepFileSearchResult(item, options));
                    }
                    results = array;
                    continue;
                }
                if (prop.NameEquals("ranking_options"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    rankingOptions = FileSearchRankingOptions.DeserializeFileSearchRankingOptions(prop.Value, options);
                    continue;
                }
                if (true)
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new InternalRunStepDetailsToolCallsFileSearchObjectFileSearch(results ?? new ChangeTrackingList<RunStepFileSearchResult>(), rankingOptions, additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<InternalRunStepDetailsToolCallsFileSearchObjectFileSearch>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRunStepDetailsToolCallsFileSearchObjectFileSearch>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalRunStepDetailsToolCallsFileSearchObjectFileSearch)} does not support writing '{options.Format}' format.");
            }
        }

        InternalRunStepDetailsToolCallsFileSearchObjectFileSearch IPersistableModel<InternalRunStepDetailsToolCallsFileSearchObjectFileSearch>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        protected virtual InternalRunStepDetailsToolCallsFileSearchObjectFileSearch PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRunStepDetailsToolCallsFileSearchObjectFileSearch>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeInternalRunStepDetailsToolCallsFileSearchObjectFileSearch(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalRunStepDetailsToolCallsFileSearchObjectFileSearch)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalRunStepDetailsToolCallsFileSearchObjectFileSearch>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(InternalRunStepDetailsToolCallsFileSearchObjectFileSearch internalRunStepDetailsToolCallsFileSearchObjectFileSearch)
        {
            if (internalRunStepDetailsToolCallsFileSearchObjectFileSearch == null)
            {
                return null;
            }
            return BinaryContent.Create(internalRunStepDetailsToolCallsFileSearchObjectFileSearch, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator InternalRunStepDetailsToolCallsFileSearchObjectFileSearch(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeInternalRunStepDetailsToolCallsFileSearchObjectFileSearch(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
