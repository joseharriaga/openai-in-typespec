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
    public partial class StaticFileChunkingStrategy : IJsonModel<StaticFileChunkingStrategy>
    {
        internal StaticFileChunkingStrategy()
        {
        }

        void IJsonModel<StaticFileChunkingStrategy>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<StaticFileChunkingStrategy>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(StaticFileChunkingStrategy)} does not support writing '{format}' format.");
            }
            base.JsonModelWriteCore(writer, options);
            if (_additionalBinaryDataProperties?.ContainsKey("static") != true)
            {
                writer.WritePropertyName("static"u8);
                writer.WriteObjectValue<InternalStaticChunkingStrategyDetails>(_internalDetails, options);
            }
        }

        StaticFileChunkingStrategy IJsonModel<StaticFileChunkingStrategy>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => (StaticFileChunkingStrategy)JsonModelCreateCore(ref reader, options);

        protected override FileChunkingStrategy JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<StaticFileChunkingStrategy>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(StaticFileChunkingStrategy)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeStaticFileChunkingStrategy(document.RootElement, options);
        }

        internal static StaticFileChunkingStrategy DeserializeStaticFileChunkingStrategy(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            InternalStaticChunkingStrategyDetails internalDetails = default;
            string @type = "static";
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("static"u8))
                {
                    internalDetails = InternalStaticChunkingStrategyDetails.DeserializeInternalStaticChunkingStrategyDetails(prop.Value, options);
                    continue;
                }
                if (prop.NameEquals("type"u8))
                {
                    @type = prop.Value.GetString();
                    continue;
                }
                if (true)
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new StaticFileChunkingStrategy(internalDetails, @type, additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<StaticFileChunkingStrategy>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected override BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<StaticFileChunkingStrategy>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(StaticFileChunkingStrategy)} does not support writing '{options.Format}' format.");
            }
        }

        StaticFileChunkingStrategy IPersistableModel<StaticFileChunkingStrategy>.Create(BinaryData data, ModelReaderWriterOptions options) => (StaticFileChunkingStrategy)PersistableModelCreateCore(data, options);

        protected override FileChunkingStrategy PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<StaticFileChunkingStrategy>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeStaticFileChunkingStrategy(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(StaticFileChunkingStrategy)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<StaticFileChunkingStrategy>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(StaticFileChunkingStrategy staticFileChunkingStrategy)
        {
            if (staticFileChunkingStrategy == null)
            {
                return null;
            }
            return BinaryContent.Create(staticFileChunkingStrategy, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator StaticFileChunkingStrategy(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeStaticFileChunkingStrategy(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
