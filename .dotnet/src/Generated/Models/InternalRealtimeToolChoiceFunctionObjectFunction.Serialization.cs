// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.RealtimeConversation
{
    internal partial class InternalRealtimeToolChoiceFunctionObjectFunction : IJsonModel<InternalRealtimeToolChoiceFunctionObjectFunction>
    {
        void IJsonModel<InternalRealtimeToolChoiceFunctionObjectFunction>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalRealtimeToolChoiceFunctionObjectFunction>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalRealtimeToolChoiceFunctionObjectFunction)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            if (SerializedAdditionalRawData?.ContainsKey("name") != true)
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(Name);
            }
            if (SerializedAdditionalRawData != null)
            {
                foreach (var item in SerializedAdditionalRawData)
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
            writer.WriteEndObject();
        }

        InternalRealtimeToolChoiceFunctionObjectFunction IJsonModel<InternalRealtimeToolChoiceFunctionObjectFunction>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalRealtimeToolChoiceFunctionObjectFunction>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalRealtimeToolChoiceFunctionObjectFunction)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalRealtimeToolChoiceFunctionObjectFunction(document.RootElement, options);
        }

        internal static InternalRealtimeToolChoiceFunctionObjectFunction DeserializeInternalRealtimeToolChoiceFunctionObjectFunction(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string name = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (true)
                {
                    rawDataDictionary ??= new Dictionary<string, BinaryData>();
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new InternalRealtimeToolChoiceFunctionObjectFunction(name, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<InternalRealtimeToolChoiceFunctionObjectFunction>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalRealtimeToolChoiceFunctionObjectFunction>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalRealtimeToolChoiceFunctionObjectFunction)} does not support writing '{options.Format}' format.");
            }
        }

        InternalRealtimeToolChoiceFunctionObjectFunction IPersistableModel<InternalRealtimeToolChoiceFunctionObjectFunction>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalRealtimeToolChoiceFunctionObjectFunction>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeInternalRealtimeToolChoiceFunctionObjectFunction(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalRealtimeToolChoiceFunctionObjectFunction)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalRealtimeToolChoiceFunctionObjectFunction>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        internal static InternalRealtimeToolChoiceFunctionObjectFunction FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeInternalRealtimeToolChoiceFunctionObjectFunction(document.RootElement);
        }

        internal virtual BinaryContent ToBinaryContent()
        {
            return BinaryContent.Create(this, ModelSerializationExtensions.WireOptions);
        }
    }
}
