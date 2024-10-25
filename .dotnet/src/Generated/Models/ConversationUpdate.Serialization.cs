// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Text.Json;
using OpenAI;

namespace OpenAI.RealtimeConversation
{
    [PersistableModelProxy(typeof(UnknownRealtimeResponseCommand))]
    public abstract partial class ConversationUpdate : IJsonModel<ConversationUpdate>
    {
        internal ConversationUpdate()
        {
        }

        void IJsonModel<ConversationUpdate>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ConversationUpdate>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ConversationUpdate)} does not support writing '{format}' format.");
            }
            if (_additionalBinaryDataProperties?.ContainsKey("event_id") != true)
            {
                if (EventId != null)
                {
                    writer.WritePropertyName("event_id"u8);
                    writer.WriteStringValue(EventId);
                }
                else
                {
                    writer.WriteNull("eventId"u8);
                }
            }
            if (_additionalBinaryDataProperties?.ContainsKey("type") != true)
            {
                writer.WritePropertyName("type"u8);
            }
            writer.WriteStringValue(Kind.ToSerialString());
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

        ConversationUpdate IJsonModel<ConversationUpdate>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual ConversationUpdate JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ConversationUpdate>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ConversationUpdate)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeConversationUpdate(document.RootElement, options);
        }

        internal static ConversationUpdate DeserializeConversationUpdate(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            if (element.TryGetProperty("kind"u8, out JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "session.created":
                        return ConversationSessionStartedUpdate.DeserializeConversationSessionStartedUpdate(element, options);
                    case "session.updated":
                        return ConversationSessionConfiguredUpdate.DeserializeConversationSessionConfiguredUpdate(element, options);
                    case "conversation.item.created":
                        return ConversationItemAcknowledgedUpdate.DeserializeConversationItemAcknowledgedUpdate(element, options);
                    case "conversation.item.deleted":
                        return ConversationItemDeletedUpdate.DeserializeConversationItemDeletedUpdate(element, options);
                    case "conversation.item.truncated":
                        return ConversationItemTruncatedUpdate.DeserializeConversationItemTruncatedUpdate(element, options);
                    case "response.created":
                        return ConversationResponseStartedUpdate.DeserializeConversationResponseStartedUpdate(element, options);
                    case "response.done":
                        return ConversationResponseFinishedUpdate.DeserializeConversationResponseFinishedUpdate(element, options);
                    case "rate_limits.updated":
                        return ConversationRateLimitsUpdatedUpdate.DeserializeConversationRateLimitsUpdatedUpdate(element, options);
                    case "response.output_item.added":
                        return ConversationItemStartedUpdate.DeserializeConversationItemStartedUpdate(element, options);
                    case "response.output_item.done":
                        return ConversationItemFinishedUpdate.DeserializeConversationItemFinishedUpdate(element, options);
                    case "response.content_part.added":
                        return ConversationContentPartStartedUpdate.DeserializeConversationContentPartStartedUpdate(element, options);
                    case "response.content_part.done":
                        return ConversationContentPartFinishedUpdate.DeserializeConversationContentPartFinishedUpdate(element, options);
                    case "response.audio.delta":
                        return ConversationAudioDeltaUpdate.DeserializeConversationAudioDeltaUpdate(element, options);
                    case "response.audio.done":
                        return ConversationAudioDoneUpdate.DeserializeConversationAudioDoneUpdate(element, options);
                    case "response.audio_transcript.delta":
                        return ConversationOutputTranscriptionDeltaUpdate.DeserializeConversationOutputTranscriptionDeltaUpdate(element, options);
                    case "response.audio_transcript.done":
                        return ConversationOutputTranscriptionFinishedUpdate.DeserializeConversationOutputTranscriptionFinishedUpdate(element, options);
                    case "response.text.delta":
                        return ConversationTextDeltaUpdate.DeserializeConversationTextDeltaUpdate(element, options);
                    case "response.text.done":
                        return ConversationTextDoneUpdate.DeserializeConversationTextDoneUpdate(element, options);
                    case "response.function_call_arguments.delta":
                        return ConversationFunctionCallArgumentsDeltaUpdate.DeserializeConversationFunctionCallArgumentsDeltaUpdate(element, options);
                    case "response.function_call_arguments.done":
                        return ConversationFunctionCallArgumentsDoneUpdate.DeserializeConversationFunctionCallArgumentsDoneUpdate(element, options);
                    case "input_audio_buffer.speech_started":
                        return ConversationInputSpeechStartedUpdate.DeserializeConversationInputSpeechStartedUpdate(element, options);
                    case "input_audio_buffer.speech_stopped":
                        return ConversationInputSpeechFinishedUpdate.DeserializeConversationInputSpeechFinishedUpdate(element, options);
                    case "conversation.item.input_audio_transcription.completed":
                        return ConversationInputTranscriptionFinishedUpdate.DeserializeConversationInputTranscriptionFinishedUpdate(element, options);
                    case "conversation.item.input_audio_transcription.failed":
                        return ConversationInputTranscriptionFailedUpdate.DeserializeConversationInputTranscriptionFailedUpdate(element, options);
                    case "input_audio_buffer.committed":
                        return ConversationInputAudioBufferCommittedUpdate.DeserializeConversationInputAudioBufferCommittedUpdate(element, options);
                    case "input_audio_buffer.cleared":
                        return ConversationInputAudioBufferClearedUpdate.DeserializeConversationInputAudioBufferClearedUpdate(element, options);
                    case "error":
                        return ConversationErrorUpdate.DeserializeConversationErrorUpdate(element, options);
                }
            }
            return UnknownRealtimeResponseCommand.DeserializeUnknownRealtimeResponseCommand(element, options);
        }

        BinaryData IPersistableModel<ConversationUpdate>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ConversationUpdate>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(ConversationUpdate)} does not support writing '{options.Format}' format.");
            }
        }

        ConversationUpdate IPersistableModel<ConversationUpdate>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        protected virtual ConversationUpdate PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ConversationUpdate>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeConversationUpdate(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(ConversationUpdate)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<ConversationUpdate>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(ConversationUpdate conversationUpdate)
        {
            return BinaryContent.Create(conversationUpdate, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator ConversationUpdate(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeConversationUpdate(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
