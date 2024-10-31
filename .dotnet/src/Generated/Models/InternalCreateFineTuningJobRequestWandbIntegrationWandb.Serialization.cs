// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using OpenAI;

namespace OpenAI.FineTuning
{
    internal partial class InternalCreateFineTuningJobRequestWandbIntegrationWandb : IJsonModel<InternalCreateFineTuningJobRequestWandbIntegrationWandb>
    {
        internal InternalCreateFineTuningJobRequestWandbIntegrationWandb()
        {
        }

        void IJsonModel<InternalCreateFineTuningJobRequestWandbIntegrationWandb>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalCreateFineTuningJobRequestWandbIntegrationWandb>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalCreateFineTuningJobRequestWandbIntegrationWandb)} does not support writing '{format}' format.");
            }
            if (Optional.IsDefined(Name) && _additionalBinaryDataProperties?.ContainsKey("name") != true)
            {
                if (Name != null)
                {
                    writer.WritePropertyName("name"u8);
                    writer.WriteStringValue(Name);
                }
                else
                {
                    writer.WriteNull("name"u8);
                }
            }
            if (Optional.IsDefined(Entity) && _additionalBinaryDataProperties?.ContainsKey("entity") != true)
            {
                if (Entity != null)
                {
                    writer.WritePropertyName("entity"u8);
                    writer.WriteStringValue(Entity);
                }
                else
                {
                    writer.WriteNull("entity"u8);
                }
            }
            if (Optional.IsCollectionDefined(Tags) && _additionalBinaryDataProperties?.ContainsKey("tags") != true)
            {
                writer.WritePropertyName("tags"u8);
                writer.WriteStartArray();
                foreach (string item in Tags)
                {
                    if (item == null)
                    {
                        writer.WriteNullValue();
                        continue;
                    }
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (_additionalBinaryDataProperties?.ContainsKey("project") != true)
            {
                writer.WritePropertyName("project"u8);
                writer.WriteStringValue(Project);
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

        InternalCreateFineTuningJobRequestWandbIntegrationWandb IJsonModel<InternalCreateFineTuningJobRequestWandbIntegrationWandb>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual InternalCreateFineTuningJobRequestWandbIntegrationWandb JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalCreateFineTuningJobRequestWandbIntegrationWandb>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalCreateFineTuningJobRequestWandbIntegrationWandb)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalCreateFineTuningJobRequestWandbIntegrationWandb(document.RootElement, options);
        }

        internal static InternalCreateFineTuningJobRequestWandbIntegrationWandb DeserializeInternalCreateFineTuningJobRequestWandbIntegrationWandb(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string name = default;
            string entity = default;
            IList<string> tags = default;
            string project = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("name"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        name = null;
                        continue;
                    }
                    name = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("entity"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        entity = null;
                        continue;
                    }
                    entity = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("tags"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<string> array = new List<string>();
                    foreach (var item in prop.Value.EnumerateArray())
                    {
                        if (item.ValueKind == JsonValueKind.Null)
                        {
                            array.Add(null);
                        }
                        else
                        {
                            array.Add(item.GetString());
                        }
                    }
                    tags = array;
                    continue;
                }
                if (prop.NameEquals("project"u8))
                {
                    project = prop.Value.GetString();
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new InternalCreateFineTuningJobRequestWandbIntegrationWandb(name, entity, tags ?? new ChangeTrackingList<string>(), project, additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<InternalCreateFineTuningJobRequestWandbIntegrationWandb>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalCreateFineTuningJobRequestWandbIntegrationWandb>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalCreateFineTuningJobRequestWandbIntegrationWandb)} does not support writing '{options.Format}' format.");
            }
        }

        InternalCreateFineTuningJobRequestWandbIntegrationWandb IPersistableModel<InternalCreateFineTuningJobRequestWandbIntegrationWandb>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        protected virtual InternalCreateFineTuningJobRequestWandbIntegrationWandb PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalCreateFineTuningJobRequestWandbIntegrationWandb>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeInternalCreateFineTuningJobRequestWandbIntegrationWandb(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalCreateFineTuningJobRequestWandbIntegrationWandb)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalCreateFineTuningJobRequestWandbIntegrationWandb>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(InternalCreateFineTuningJobRequestWandbIntegrationWandb internalCreateFineTuningJobRequestWandbIntegrationWandb)
        {
            if (internalCreateFineTuningJobRequestWandbIntegrationWandb == null)
            {
                return null;
            }
            return BinaryContent.Create(internalCreateFineTuningJobRequestWandbIntegrationWandb, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator InternalCreateFineTuningJobRequestWandbIntegrationWandb(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeInternalCreateFineTuningJobRequestWandbIntegrationWandb(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
