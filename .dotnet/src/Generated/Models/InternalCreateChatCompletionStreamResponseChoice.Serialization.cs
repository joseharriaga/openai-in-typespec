// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Text.Json;
using OpenAI;

namespace OpenAI.Chat
{
    internal partial class InternalCreateChatCompletionStreamResponseChoice : IJsonModel<InternalCreateChatCompletionStreamResponseChoice>
    {
        internal InternalCreateChatCompletionStreamResponseChoice()
        {
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalCreateChatCompletionStreamResponseChoice>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalCreateChatCompletionStreamResponseChoice)} does not support writing '{format}' format.");
            }
            if (_additionalBinaryDataProperties?.ContainsKey("delta") != true)
            {
                writer.WritePropertyName("delta"u8);
                writer.WriteObjectValue(Delta, options);
            }
            if (Optional.IsDefined(Logprobs) && _additionalBinaryDataProperties?.ContainsKey("logprobs") != true)
            {
                if (Logprobs != null)
                {
                    writer.WritePropertyName("logprobs"u8);
                    writer.WriteObjectValue(Logprobs, options);
                }
                else
                {
                    writer.WriteNull("logprobs"u8);
                }
            }
            if (_additionalBinaryDataProperties?.ContainsKey("index") != true)
            {
                writer.WritePropertyName("index"u8);
                writer.WriteNumberValue(Index);
            }
            if (_additionalBinaryDataProperties?.ContainsKey("finish_reason") != true)
            {
                if (FinishReason != null)
                {
                    writer.WritePropertyName("finish_reason"u8);
                    writer.WriteStringValue(FinishReason.Value.ToSerialString());
                }
                else
                {
                    writer.WriteNull("finishReason"u8);
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

        InternalCreateChatCompletionStreamResponseChoice IJsonModel<InternalCreateChatCompletionStreamResponseChoice>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual InternalCreateChatCompletionStreamResponseChoice JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalCreateChatCompletionStreamResponseChoice>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalCreateChatCompletionStreamResponseChoice)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return InternalCreateChatCompletionStreamResponseChoice.DeserializeInternalCreateChatCompletionStreamResponseChoice(document.RootElement, options);
        }

        BinaryData IPersistableModel<InternalCreateChatCompletionStreamResponseChoice>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalCreateChatCompletionStreamResponseChoice>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalCreateChatCompletionStreamResponseChoice)} does not support writing '{options.Format}' format.");
            }
        }

        InternalCreateChatCompletionStreamResponseChoice IPersistableModel<InternalCreateChatCompletionStreamResponseChoice>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        protected virtual InternalCreateChatCompletionStreamResponseChoice PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalCreateChatCompletionStreamResponseChoice>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return InternalCreateChatCompletionStreamResponseChoice.DeserializeInternalCreateChatCompletionStreamResponseChoice(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalCreateChatCompletionStreamResponseChoice)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalCreateChatCompletionStreamResponseChoice>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(InternalCreateChatCompletionStreamResponseChoice internalCreateChatCompletionStreamResponseChoice)
        {
            return BinaryContent.Create(internalCreateChatCompletionStreamResponseChoice, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator InternalCreateChatCompletionStreamResponseChoice(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return InternalCreateChatCompletionStreamResponseChoice.DeserializeInternalCreateChatCompletionStreamResponseChoice(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
