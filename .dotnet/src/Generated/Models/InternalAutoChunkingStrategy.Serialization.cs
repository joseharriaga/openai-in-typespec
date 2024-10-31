// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using OpenAI;

namespace OpenAI.VectorStores
{
    internal partial class InternalAutoChunkingStrategy : IJsonModel<InternalAutoChunkingStrategy>
    {
        void IJsonModel<InternalAutoChunkingStrategy>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalAutoChunkingStrategy>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalAutoChunkingStrategy)} does not support writing '{format}' format.");
            }
            base.JsonModelWriteCore(writer, options);
        }

        InternalAutoChunkingStrategy IJsonModel<InternalAutoChunkingStrategy>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => (InternalAutoChunkingStrategy)JsonModelCreateCore(ref reader, options);

        protected override FileChunkingStrategy JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalAutoChunkingStrategy>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalAutoChunkingStrategy)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalAutoChunkingStrategy(document.RootElement, options);
        }

        internal static InternalAutoChunkingStrategy DeserializeInternalAutoChunkingStrategy(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string @type = "auto";
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
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
            return new InternalAutoChunkingStrategy(@type, additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<InternalAutoChunkingStrategy>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected override BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalAutoChunkingStrategy>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalAutoChunkingStrategy)} does not support writing '{options.Format}' format.");
            }
        }

        InternalAutoChunkingStrategy IPersistableModel<InternalAutoChunkingStrategy>.Create(BinaryData data, ModelReaderWriterOptions options) => (InternalAutoChunkingStrategy)PersistableModelCreateCore(data, options);

        protected override FileChunkingStrategy PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalAutoChunkingStrategy>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeInternalAutoChunkingStrategy(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalAutoChunkingStrategy)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalAutoChunkingStrategy>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(InternalAutoChunkingStrategy internalAutoChunkingStrategy)
        {
            if (internalAutoChunkingStrategy == null)
            {
                return null;
            }
            return BinaryContent.Create(internalAutoChunkingStrategy, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator InternalAutoChunkingStrategy(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeInternalAutoChunkingStrategy(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
