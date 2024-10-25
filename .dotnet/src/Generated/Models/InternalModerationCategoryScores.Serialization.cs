// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using OpenAI;

namespace OpenAI.Moderations
{
    internal partial class InternalModerationCategoryScores : IJsonModel<InternalModerationCategoryScores>
    {
        internal InternalModerationCategoryScores()
        {
        }

        void IJsonModel<InternalModerationCategoryScores>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalModerationCategoryScores>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalModerationCategoryScores)} does not support writing '{format}' format.");
            }
            if (_additionalBinaryDataProperties?.ContainsKey("hate") != true)
            {
                writer.WritePropertyName("hate"u8);
            }
            writer.WriteNumberValue(Hate);
            if (_additionalBinaryDataProperties?.ContainsKey("hate/threatening") != true)
            {
                writer.WritePropertyName("hate/threatening"u8);
            }
            writer.WriteNumberValue(HateThreatening);
            if (_additionalBinaryDataProperties?.ContainsKey("harassment") != true)
            {
                writer.WritePropertyName("harassment"u8);
            }
            writer.WriteNumberValue(Harassment);
            if (_additionalBinaryDataProperties?.ContainsKey("harassment/threatening") != true)
            {
                writer.WritePropertyName("harassment/threatening"u8);
            }
            writer.WriteNumberValue(HarassmentThreatening);
            if (_additionalBinaryDataProperties?.ContainsKey("self-harm") != true)
            {
                writer.WritePropertyName("self-harm"u8);
            }
            writer.WriteNumberValue(SelfHarm);
            if (_additionalBinaryDataProperties?.ContainsKey("self-harm/intent") != true)
            {
                writer.WritePropertyName("self-harm/intent"u8);
            }
            writer.WriteNumberValue(SelfHarmIntent);
            if (_additionalBinaryDataProperties?.ContainsKey("self-harm/instructions") != true)
            {
                writer.WritePropertyName("self-harm/instructions"u8);
            }
            writer.WriteNumberValue(SelfHarmInstructions);
            if (_additionalBinaryDataProperties?.ContainsKey("sexual") != true)
            {
                writer.WritePropertyName("sexual"u8);
            }
            writer.WriteNumberValue(Sexual);
            if (_additionalBinaryDataProperties?.ContainsKey("sexual/minors") != true)
            {
                writer.WritePropertyName("sexual/minors"u8);
            }
            writer.WriteNumberValue(SexualMinors);
            if (_additionalBinaryDataProperties?.ContainsKey("violence") != true)
            {
                writer.WritePropertyName("violence"u8);
            }
            writer.WriteNumberValue(Violence);
            if (_additionalBinaryDataProperties?.ContainsKey("violence/graphic") != true)
            {
                writer.WritePropertyName("violence/graphic"u8);
            }
            writer.WriteNumberValue(ViolenceGraphic);
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

        InternalModerationCategoryScores IJsonModel<InternalModerationCategoryScores>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual InternalModerationCategoryScores JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalModerationCategoryScores>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalModerationCategoryScores)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalModerationCategoryScores(document.RootElement, options);
        }

        internal static InternalModerationCategoryScores DeserializeInternalModerationCategoryScores(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            float hate = default;
            float hateThreatening = default;
            float harassment = default;
            float harassmentThreatening = default;
            float selfHarm = default;
            float selfHarmIntent = default;
            float selfHarmInstructions = default;
            float sexual = default;
            float sexualMinors = default;
            float violence = default;
            float violenceGraphic = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("hate"u8))
                {
                    hate = prop.Value.GetSingle();
                    continue;
                }
                if (prop.NameEquals("hate/threatening"u8))
                {
                    hateThreatening = prop.Value.GetSingle();
                    continue;
                }
                if (prop.NameEquals("harassment"u8))
                {
                    harassment = prop.Value.GetSingle();
                    continue;
                }
                if (prop.NameEquals("harassment/threatening"u8))
                {
                    harassmentThreatening = prop.Value.GetSingle();
                    continue;
                }
                if (prop.NameEquals("self-harm"u8))
                {
                    selfHarm = prop.Value.GetSingle();
                    continue;
                }
                if (prop.NameEquals("self-harm/intent"u8))
                {
                    selfHarmIntent = prop.Value.GetSingle();
                    continue;
                }
                if (prop.NameEquals("self-harm/instructions"u8))
                {
                    selfHarmInstructions = prop.Value.GetSingle();
                    continue;
                }
                if (prop.NameEquals("sexual"u8))
                {
                    sexual = prop.Value.GetSingle();
                    continue;
                }
                if (prop.NameEquals("sexual/minors"u8))
                {
                    sexualMinors = prop.Value.GetSingle();
                    continue;
                }
                if (prop.NameEquals("violence"u8))
                {
                    violence = prop.Value.GetSingle();
                    continue;
                }
                if (prop.NameEquals("violence/graphic"u8))
                {
                    violenceGraphic = prop.Value.GetSingle();
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new InternalModerationCategoryScores(
                hate,
                hateThreatening,
                harassment,
                harassmentThreatening,
                selfHarm,
                selfHarmIntent,
                selfHarmInstructions,
                sexual,
                sexualMinors,
                violence,
                violenceGraphic,
                additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<InternalModerationCategoryScores>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalModerationCategoryScores>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalModerationCategoryScores)} does not support writing '{options.Format}' format.");
            }
        }

        InternalModerationCategoryScores IPersistableModel<InternalModerationCategoryScores>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        protected virtual InternalModerationCategoryScores PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalModerationCategoryScores>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeInternalModerationCategoryScores(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalModerationCategoryScores)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalModerationCategoryScores>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(InternalModerationCategoryScores internalModerationCategoryScores)
        {
            return BinaryContent.Create(internalModerationCategoryScores, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator InternalModerationCategoryScores(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeInternalModerationCategoryScores(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
