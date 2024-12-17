// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using OpenAI;

namespace OpenAI.RealtimeConversation
{
    internal partial class InternalRealtimeToolChoiceFunctionObjectFunction : IJsonModel<InternalRealtimeToolChoiceFunctionObjectFunction>
    {
        internal InternalRealtimeToolChoiceFunctionObjectFunction()
        {
        }

        void IJsonModel<InternalRealtimeToolChoiceFunctionObjectFunction>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRealtimeToolChoiceFunctionObjectFunction>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalRealtimeToolChoiceFunctionObjectFunction)} does not support writing '{format}' format.");
            }
            if (_additionalBinaryDataProperties?.ContainsKey("name") != true)
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(Name);
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

        InternalRealtimeToolChoiceFunctionObjectFunction IJsonModel<InternalRealtimeToolChoiceFunctionObjectFunction>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual InternalRealtimeToolChoiceFunctionObjectFunction JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRealtimeToolChoiceFunctionObjectFunction>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalRealtimeToolChoiceFunctionObjectFunction)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalRealtimeToolChoiceFunctionObjectFunction(document.RootElement, options);
        }

        internal static InternalRealtimeToolChoiceFunctionObjectFunction DeserializeInternalRealtimeToolChoiceFunctionObjectFunction(JsonElement element, ModelReaderWriterOptions options)
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
                if (true)
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new InternalRealtimeToolChoiceFunctionObjectFunction(name, additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<InternalRealtimeToolChoiceFunctionObjectFunction>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRealtimeToolChoiceFunctionObjectFunction>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalRealtimeToolChoiceFunctionObjectFunction)} does not support writing '{options.Format}' format.");
            }
        }

        InternalRealtimeToolChoiceFunctionObjectFunction IPersistableModel<InternalRealtimeToolChoiceFunctionObjectFunction>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        protected virtual InternalRealtimeToolChoiceFunctionObjectFunction PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRealtimeToolChoiceFunctionObjectFunction>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeInternalRealtimeToolChoiceFunctionObjectFunction(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalRealtimeToolChoiceFunctionObjectFunction)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalRealtimeToolChoiceFunctionObjectFunction>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(InternalRealtimeToolChoiceFunctionObjectFunction internalRealtimeToolChoiceFunctionObjectFunction)
        {
            if (internalRealtimeToolChoiceFunctionObjectFunction == null)
            {
                return null;
            }
            return BinaryContent.Create(internalRealtimeToolChoiceFunctionObjectFunction, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator InternalRealtimeToolChoiceFunctionObjectFunction(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeInternalRealtimeToolChoiceFunctionObjectFunction(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
