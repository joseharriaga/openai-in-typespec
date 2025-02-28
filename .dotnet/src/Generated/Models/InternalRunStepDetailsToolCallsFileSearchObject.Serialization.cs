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
    internal partial class InternalRunStepDetailsToolCallsFileSearchObject : IJsonModel<InternalRunStepDetailsToolCallsFileSearchObject>
    {
        internal InternalRunStepDetailsToolCallsFileSearchObject()
        {
        }

        void IJsonModel<InternalRunStepDetailsToolCallsFileSearchObject>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRunStepDetailsToolCallsFileSearchObject>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalRunStepDetailsToolCallsFileSearchObject)} does not support writing '{format}' format.");
            }
            base.JsonModelWriteCore(writer, options);
            if (_additionalBinaryDataProperties?.ContainsKey("file_search") != true)
            {
                writer.WritePropertyName("file_search"u8);
                writer.WriteObjectValue(FileSearch, options);
            }
        }

        InternalRunStepDetailsToolCallsFileSearchObject IJsonModel<InternalRunStepDetailsToolCallsFileSearchObject>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => (InternalRunStepDetailsToolCallsFileSearchObject)JsonModelCreateCore(ref reader, options);

        protected override RunStepToolCall JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRunStepDetailsToolCallsFileSearchObject>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalRunStepDetailsToolCallsFileSearchObject)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalRunStepDetailsToolCallsFileSearchObject(document.RootElement, options);
        }

        internal static InternalRunStepDetailsToolCallsFileSearchObject DeserializeInternalRunStepDetailsToolCallsFileSearchObject(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string id = default;
            RunStepToolCallKind kind = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            InternalRunStepDetailsToolCallsFileSearchObjectFileSearch fileSearch = default;
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("id"u8))
                {
                    id = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("type"u8))
                {
                    kind = prop.Value.GetString().ToRunStepToolCallKind();
                    continue;
                }
                if (prop.NameEquals("file_search"u8))
                {
                    fileSearch = InternalRunStepDetailsToolCallsFileSearchObjectFileSearch.DeserializeInternalRunStepDetailsToolCallsFileSearchObjectFileSearch(prop.Value, options);
                    continue;
                }
                additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
            }
            return new InternalRunStepDetailsToolCallsFileSearchObject(id, kind, additionalBinaryDataProperties, fileSearch);
        }

        BinaryData IPersistableModel<InternalRunStepDetailsToolCallsFileSearchObject>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected override BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRunStepDetailsToolCallsFileSearchObject>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalRunStepDetailsToolCallsFileSearchObject)} does not support writing '{options.Format}' format.");
            }
        }

        InternalRunStepDetailsToolCallsFileSearchObject IPersistableModel<InternalRunStepDetailsToolCallsFileSearchObject>.Create(BinaryData data, ModelReaderWriterOptions options) => (InternalRunStepDetailsToolCallsFileSearchObject)PersistableModelCreateCore(data, options);

        protected override RunStepToolCall PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRunStepDetailsToolCallsFileSearchObject>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeInternalRunStepDetailsToolCallsFileSearchObject(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalRunStepDetailsToolCallsFileSearchObject)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalRunStepDetailsToolCallsFileSearchObject>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(InternalRunStepDetailsToolCallsFileSearchObject internalRunStepDetailsToolCallsFileSearchObject)
        {
            if (internalRunStepDetailsToolCallsFileSearchObject == null)
            {
                return null;
            }
            return BinaryContent.Create(internalRunStepDetailsToolCallsFileSearchObject, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator InternalRunStepDetailsToolCallsFileSearchObject(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeInternalRunStepDetailsToolCallsFileSearchObject(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
