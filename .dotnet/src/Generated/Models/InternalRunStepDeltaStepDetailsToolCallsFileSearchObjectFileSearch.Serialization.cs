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
    internal partial class InternalRunStepDeltaStepDetailsToolCallsFileSearchObjectFileSearch : IJsonModel<InternalRunStepDeltaStepDetailsToolCallsFileSearchObjectFileSearch>
    {
        void IJsonModel<InternalRunStepDeltaStepDetailsToolCallsFileSearchObjectFileSearch>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRunStepDeltaStepDetailsToolCallsFileSearchObjectFileSearch>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalRunStepDeltaStepDetailsToolCallsFileSearchObjectFileSearch)} does not support writing '{format}' format.");
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
                writer.WriteObjectValue<FileSearchRankingOptions>(RankingOptions, options);
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

        InternalRunStepDeltaStepDetailsToolCallsFileSearchObjectFileSearch IJsonModel<InternalRunStepDeltaStepDetailsToolCallsFileSearchObjectFileSearch>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual InternalRunStepDeltaStepDetailsToolCallsFileSearchObjectFileSearch JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRunStepDeltaStepDetailsToolCallsFileSearchObjectFileSearch>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalRunStepDeltaStepDetailsToolCallsFileSearchObjectFileSearch)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalRunStepDeltaStepDetailsToolCallsFileSearchObjectFileSearch(document.RootElement, options);
        }

        internal static InternalRunStepDeltaStepDetailsToolCallsFileSearchObjectFileSearch DeserializeInternalRunStepDeltaStepDetailsToolCallsFileSearchObjectFileSearch(JsonElement element, ModelReaderWriterOptions options)
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
            return new InternalRunStepDeltaStepDetailsToolCallsFileSearchObjectFileSearch(results ?? new ChangeTrackingList<RunStepFileSearchResult>(), rankingOptions, additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<InternalRunStepDeltaStepDetailsToolCallsFileSearchObjectFileSearch>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRunStepDeltaStepDetailsToolCallsFileSearchObjectFileSearch>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalRunStepDeltaStepDetailsToolCallsFileSearchObjectFileSearch)} does not support writing '{options.Format}' format.");
            }
        }

        InternalRunStepDeltaStepDetailsToolCallsFileSearchObjectFileSearch IPersistableModel<InternalRunStepDeltaStepDetailsToolCallsFileSearchObjectFileSearch>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        protected virtual InternalRunStepDeltaStepDetailsToolCallsFileSearchObjectFileSearch PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRunStepDeltaStepDetailsToolCallsFileSearchObjectFileSearch>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeInternalRunStepDeltaStepDetailsToolCallsFileSearchObjectFileSearch(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalRunStepDeltaStepDetailsToolCallsFileSearchObjectFileSearch)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalRunStepDeltaStepDetailsToolCallsFileSearchObjectFileSearch>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(InternalRunStepDeltaStepDetailsToolCallsFileSearchObjectFileSearch internalRunStepDeltaStepDetailsToolCallsFileSearchObjectFileSearch)
        {
            if (internalRunStepDeltaStepDetailsToolCallsFileSearchObjectFileSearch == null)
            {
                return null;
            }
            return BinaryContent.Create(internalRunStepDeltaStepDetailsToolCallsFileSearchObjectFileSearch, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator InternalRunStepDeltaStepDetailsToolCallsFileSearchObjectFileSearch(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeInternalRunStepDeltaStepDetailsToolCallsFileSearchObjectFileSearch(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}