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
    internal partial class InternalRunStepFileSearchToolCallDetails : IJsonModel<InternalRunStepFileSearchToolCallDetails>
    {
        internal InternalRunStepFileSearchToolCallDetails()
        {
        }

        void IJsonModel<InternalRunStepFileSearchToolCallDetails>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRunStepFileSearchToolCallDetails>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalRunStepFileSearchToolCallDetails)} does not support writing '{format}' format.");
            }
            base.JsonModelWriteCore(writer, options);
            if (_additionalBinaryDataProperties?.ContainsKey("id") != true)
            {
                writer.WritePropertyName("id"u8);
                writer.WriteStringValue(Id);
            }
            if (_additionalBinaryDataProperties?.ContainsKey("file_search") != true)
            {
                writer.WritePropertyName("file_search"u8);
                writer.WriteObjectValue(FileSearch, options);
            }
        }

        InternalRunStepFileSearchToolCallDetails IJsonModel<InternalRunStepFileSearchToolCallDetails>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => (InternalRunStepFileSearchToolCallDetails)JsonModelCreateCore(ref reader, options);

        protected override RunStepToolCall JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRunStepFileSearchToolCallDetails>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalRunStepFileSearchToolCallDetails)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalRunStepFileSearchToolCallDetails(document.RootElement, options);
        }

        internal static InternalRunStepFileSearchToolCallDetails DeserializeInternalRunStepFileSearchToolCallDetails(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string id = default;
            InternalRunStepDetailsToolCallsFileSearchObjectFileSearch fileSearch = default;
            string @type = "file_search";
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("id"u8))
                {
                    id = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("file_search"u8))
                {
                    fileSearch = InternalRunStepDetailsToolCallsFileSearchObjectFileSearch.DeserializeInternalRunStepDetailsToolCallsFileSearchObjectFileSearch(prop.Value, options);
                    continue;
                }
                if (prop.NameEquals("type"u8))
                {
                    @type = prop.Value.GetString();
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new InternalRunStepFileSearchToolCallDetails(id, fileSearch, @type, additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<InternalRunStepFileSearchToolCallDetails>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected override BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRunStepFileSearchToolCallDetails>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalRunStepFileSearchToolCallDetails)} does not support writing '{options.Format}' format.");
            }
        }

        InternalRunStepFileSearchToolCallDetails IPersistableModel<InternalRunStepFileSearchToolCallDetails>.Create(BinaryData data, ModelReaderWriterOptions options) => (InternalRunStepFileSearchToolCallDetails)PersistableModelCreateCore(data, options);

        protected override RunStepToolCall PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRunStepFileSearchToolCallDetails>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeInternalRunStepFileSearchToolCallDetails(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalRunStepFileSearchToolCallDetails)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalRunStepFileSearchToolCallDetails>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(InternalRunStepFileSearchToolCallDetails internalRunStepFileSearchToolCallDetails)
        {
            if (internalRunStepFileSearchToolCallDetails == null)
            {
                return null;
            }
            return BinaryContent.Create(internalRunStepFileSearchToolCallDetails, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator InternalRunStepFileSearchToolCallDetails(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeInternalRunStepFileSearchToolCallDetails(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
