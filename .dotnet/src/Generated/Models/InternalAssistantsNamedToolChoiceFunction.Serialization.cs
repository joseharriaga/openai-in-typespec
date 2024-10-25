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
    internal partial class InternalAssistantsNamedToolChoiceFunction : IJsonModel<InternalAssistantsNamedToolChoiceFunction>
    {
        internal InternalAssistantsNamedToolChoiceFunction()
        {
        }

        void IJsonModel<InternalAssistantsNamedToolChoiceFunction>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalAssistantsNamedToolChoiceFunction>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalAssistantsNamedToolChoiceFunction)} does not support writing '{format}' format.");
            }
            if (_additionalBinaryDataProperties?.ContainsKey("name") != true)
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(Name);
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

        InternalAssistantsNamedToolChoiceFunction IJsonModel<InternalAssistantsNamedToolChoiceFunction>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual InternalAssistantsNamedToolChoiceFunction JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalAssistantsNamedToolChoiceFunction>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalAssistantsNamedToolChoiceFunction)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalAssistantsNamedToolChoiceFunction(document.RootElement, options);
        }

        internal static InternalAssistantsNamedToolChoiceFunction DeserializeInternalAssistantsNamedToolChoiceFunction(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string name = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("name"u8))
                {
                    name = prop.Value.GetString();
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new InternalAssistantsNamedToolChoiceFunction(name, additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<InternalAssistantsNamedToolChoiceFunction>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalAssistantsNamedToolChoiceFunction>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalAssistantsNamedToolChoiceFunction)} does not support writing '{options.Format}' format.");
            }
        }

        InternalAssistantsNamedToolChoiceFunction IPersistableModel<InternalAssistantsNamedToolChoiceFunction>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        protected virtual InternalAssistantsNamedToolChoiceFunction PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalAssistantsNamedToolChoiceFunction>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeInternalAssistantsNamedToolChoiceFunction(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalAssistantsNamedToolChoiceFunction)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalAssistantsNamedToolChoiceFunction>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(InternalAssistantsNamedToolChoiceFunction internalAssistantsNamedToolChoiceFunction)
        {
            return BinaryContent.Create(internalAssistantsNamedToolChoiceFunction, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator InternalAssistantsNamedToolChoiceFunction(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeInternalAssistantsNamedToolChoiceFunction(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
