// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using OpenAI;

namespace OpenAI.Chat
{
    internal partial class InternalCreateChatCompletionStreamResponseChoiceLogprobs : IJsonModel<InternalCreateChatCompletionStreamResponseChoiceLogprobs>
    {
        internal InternalCreateChatCompletionStreamResponseChoiceLogprobs()
        {
        }

        void IJsonModel<InternalCreateChatCompletionStreamResponseChoiceLogprobs>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalCreateChatCompletionStreamResponseChoiceLogprobs>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalCreateChatCompletionStreamResponseChoiceLogprobs)} does not support writing '{format}' format.");
            }
            if (_additionalBinaryDataProperties?.ContainsKey("content") != true)
            {
                if (Content != null && Optional.IsCollectionDefined(Content))
                {
                    writer.WritePropertyName("content"u8);
                    writer.WriteStartArray();
                    foreach (ChatTokenLogProbabilityDetails item in Content)
                    {
                        writer.WriteObjectValue(item, options);
                    }
                    writer.WriteEndArray();
                }
                else
                {
                    writer.WriteNull("content"u8);
                }
            }
            if (_additionalBinaryDataProperties?.ContainsKey("refusal") != true)
            {
                if (Refusal != null && Optional.IsCollectionDefined(Refusal))
                {
                    writer.WritePropertyName("refusal"u8);
                    writer.WriteStartArray();
                    foreach (ChatTokenLogProbabilityDetails item in Refusal)
                    {
                        writer.WriteObjectValue(item, options);
                    }
                    writer.WriteEndArray();
                }
                else
                {
                    writer.WriteNull("refusal"u8);
                }
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

        InternalCreateChatCompletionStreamResponseChoiceLogprobs IJsonModel<InternalCreateChatCompletionStreamResponseChoiceLogprobs>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual InternalCreateChatCompletionStreamResponseChoiceLogprobs JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalCreateChatCompletionStreamResponseChoiceLogprobs>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalCreateChatCompletionStreamResponseChoiceLogprobs)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalCreateChatCompletionStreamResponseChoiceLogprobs(document.RootElement, options);
        }

        internal static InternalCreateChatCompletionStreamResponseChoiceLogprobs DeserializeInternalCreateChatCompletionStreamResponseChoiceLogprobs(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IList<ChatTokenLogProbabilityDetails> content = default;
            IList<ChatTokenLogProbabilityDetails> refusal = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("content"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        content = new ChangeTrackingList<ChatTokenLogProbabilityDetails>();
                        continue;
                    }
                    List<ChatTokenLogProbabilityDetails> array = new List<ChatTokenLogProbabilityDetails>();
                    foreach (var item in prop.Value.EnumerateArray())
                    {
                        array.Add(ChatTokenLogProbabilityDetails.DeserializeChatTokenLogProbabilityDetails(item, options));
                    }
                    content = array;
                    continue;
                }
                if (prop.NameEquals("refusal"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        refusal = new ChangeTrackingList<ChatTokenLogProbabilityDetails>();
                        continue;
                    }
                    List<ChatTokenLogProbabilityDetails> array = new List<ChatTokenLogProbabilityDetails>();
                    foreach (var item in prop.Value.EnumerateArray())
                    {
                        array.Add(ChatTokenLogProbabilityDetails.DeserializeChatTokenLogProbabilityDetails(item, options));
                    }
                    refusal = array;
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new InternalCreateChatCompletionStreamResponseChoiceLogprobs(content, refusal, additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<InternalCreateChatCompletionStreamResponseChoiceLogprobs>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalCreateChatCompletionStreamResponseChoiceLogprobs>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalCreateChatCompletionStreamResponseChoiceLogprobs)} does not support writing '{options.Format}' format.");
            }
        }

        InternalCreateChatCompletionStreamResponseChoiceLogprobs IPersistableModel<InternalCreateChatCompletionStreamResponseChoiceLogprobs>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        protected virtual InternalCreateChatCompletionStreamResponseChoiceLogprobs PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalCreateChatCompletionStreamResponseChoiceLogprobs>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeInternalCreateChatCompletionStreamResponseChoiceLogprobs(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalCreateChatCompletionStreamResponseChoiceLogprobs)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalCreateChatCompletionStreamResponseChoiceLogprobs>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(InternalCreateChatCompletionStreamResponseChoiceLogprobs internalCreateChatCompletionStreamResponseChoiceLogprobs)
        {
            return BinaryContent.Create(internalCreateChatCompletionStreamResponseChoiceLogprobs, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator InternalCreateChatCompletionStreamResponseChoiceLogprobs(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeInternalCreateChatCompletionStreamResponseChoiceLogprobs(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
