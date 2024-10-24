// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.RealtimeConversation
{
    public partial class ConversationSessionOptions : IJsonModel<ConversationSessionOptions>
    {
        void IJsonModel<ConversationSessionOptions>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ConversationSessionOptions>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ConversationSessionOptions)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            if (SerializedAdditionalRawData?.ContainsKey("modalities") != true && Optional.IsCollectionDefined(_internalModalities))
            {
                writer.WritePropertyName("modalities"u8);
                writer.WriteStartArray();
                foreach (var item in _internalModalities)
                {
                    writer.WriteStringValue(item.ToString());
                }
                writer.WriteEndArray();
            }
            if (SerializedAdditionalRawData?.ContainsKey("instructions") != true && Optional.IsDefined(Instructions))
            {
                writer.WritePropertyName("instructions"u8);
                writer.WriteStringValue(Instructions);
            }
            if (SerializedAdditionalRawData?.ContainsKey("voice") != true && Optional.IsDefined(Voice))
            {
                writer.WritePropertyName("voice"u8);
                writer.WriteStringValue(Voice.Value.ToString());
            }
            if (SerializedAdditionalRawData?.ContainsKey("input_audio_format") != true && Optional.IsDefined(InputAudioFormat))
            {
                writer.WritePropertyName("input_audio_format"u8);
                writer.WriteStringValue(InputAudioFormat.Value.ToString());
            }
            if (SerializedAdditionalRawData?.ContainsKey("output_audio_format") != true && Optional.IsDefined(OutputAudioFormat))
            {
                writer.WritePropertyName("output_audio_format"u8);
                writer.WriteStringValue(OutputAudioFormat.Value.ToString());
            }
            if (SerializedAdditionalRawData?.ContainsKey("input_audio_transcription") != true && Optional.IsDefined(InputTranscriptionOptions))
            {
                if (InputTranscriptionOptions != null)
                {
                    writer.WritePropertyName("input_audio_transcription"u8);
                    writer.WriteObjectValue<ConversationInputTranscriptionOptions>(InputTranscriptionOptions, options);
                }
                else
                {
                    writer.WriteNull("input_audio_transcription");
                }
            }
            if (SerializedAdditionalRawData?.ContainsKey("turn_detection") != true && Optional.IsDefined(TurnDetectionOptions))
            {
                if (TurnDetectionOptions != null)
                {
                    writer.WritePropertyName("turn_detection"u8);
                    writer.WriteObjectValue<ConversationTurnDetectionOptions>(TurnDetectionOptions, options);
                }
                else
                {
                    writer.WriteNull("turn_detection");
                }
            }
            if (SerializedAdditionalRawData?.ContainsKey("tools") != true && Optional.IsCollectionDefined(Tools))
            {
                writer.WritePropertyName("tools"u8);
                writer.WriteStartArray();
                foreach (var item in Tools)
                {
                    writer.WriteObjectValue(item, options);
                }
                writer.WriteEndArray();
            }
            if (SerializedAdditionalRawData?.ContainsKey("tool_choice") != true && Optional.IsDefined(_internalToolChoice))
            {
                writer.WritePropertyName("tool_choice"u8);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(_internalToolChoice);
#else
                using (JsonDocument document = JsonDocument.Parse(_internalToolChoice))
                {
                    JsonSerializer.Serialize(writer, document.RootElement);
                }
#endif
            }
            if (SerializedAdditionalRawData?.ContainsKey("temperature") != true && Optional.IsDefined(Temperature))
            {
                writer.WritePropertyName("temperature"u8);
                writer.WriteNumberValue(Temperature.Value);
            }
            if (SerializedAdditionalRawData?.ContainsKey("max_response_output_tokens") != true && Optional.IsDefined(_maxResponseOutputTokens))
            {
                writer.WritePropertyName("max_response_output_tokens"u8);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(_maxResponseOutputTokens);
#else
                using (JsonDocument document = JsonDocument.Parse(_maxResponseOutputTokens))
                {
                    JsonSerializer.Serialize(writer, document.RootElement);
                }
#endif
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

        ConversationSessionOptions IJsonModel<ConversationSessionOptions>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ConversationSessionOptions>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ConversationSessionOptions)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeConversationSessionOptions(document.RootElement, options);
        }

        internal static ConversationSessionOptions DeserializeConversationSessionOptions(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IList<InternalRealtimeRequestSessionModality> modalities = default;
            string instructions = default;
            ConversationVoice? voice = default;
            ConversationAudioFormat? inputAudioFormat = default;
            ConversationAudioFormat? outputAudioFormat = default;
            ConversationInputTranscriptionOptions inputAudioTranscription = default;
            ConversationTurnDetectionOptions turnDetection = default;
            IList<ConversationTool> tools = default;
            BinaryData toolChoice = default;
            float? temperature = default;
            BinaryData maxResponseOutputTokens = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("modalities"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<InternalRealtimeRequestSessionModality> array = new List<InternalRealtimeRequestSessionModality>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(new InternalRealtimeRequestSessionModality(item.GetString()));
                    }
                    modalities = array;
                    continue;
                }
                if (property.NameEquals("instructions"u8))
                {
                    instructions = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("voice"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    voice = new ConversationVoice(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("input_audio_format"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    inputAudioFormat = new ConversationAudioFormat(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("output_audio_format"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    outputAudioFormat = new ConversationAudioFormat(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("input_audio_transcription"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        inputAudioTranscription = null;
                        continue;
                    }
                    inputAudioTranscription = ConversationInputTranscriptionOptions.DeserializeConversationInputTranscriptionOptions(property.Value, options);
                    continue;
                }
                if (property.NameEquals("turn_detection"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        turnDetection = null;
                        continue;
                    }
                    turnDetection = ConversationTurnDetectionOptions.DeserializeConversationTurnDetectionOptions(property.Value, options);
                    continue;
                }
                if (property.NameEquals("tools"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<ConversationTool> array = new List<ConversationTool>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(ConversationTool.DeserializeConversationTool(item, options));
                    }
                    tools = array;
                    continue;
                }
                if (property.NameEquals("tool_choice"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    toolChoice = BinaryData.FromString(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("temperature"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    temperature = property.Value.GetSingle();
                    continue;
                }
                if (property.NameEquals("max_response_output_tokens"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    maxResponseOutputTokens = BinaryData.FromString(property.Value.GetRawText());
                    continue;
                }
                if (true)
                {
                    rawDataDictionary ??= new Dictionary<string, BinaryData>();
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new ConversationSessionOptions(
                modalities ?? new ChangeTrackingList<InternalRealtimeRequestSessionModality>(),
                instructions,
                voice,
                inputAudioFormat,
                outputAudioFormat,
                inputAudioTranscription,
                turnDetection,
                tools ?? new ChangeTrackingList<ConversationTool>(),
                toolChoice,
                temperature,
                maxResponseOutputTokens,
                serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<ConversationSessionOptions>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ConversationSessionOptions>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(ConversationSessionOptions)} does not support writing '{options.Format}' format.");
            }
        }

        ConversationSessionOptions IPersistableModel<ConversationSessionOptions>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ConversationSessionOptions>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeConversationSessionOptions(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(ConversationSessionOptions)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<ConversationSessionOptions>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        internal static ConversationSessionOptions FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeConversationSessionOptions(document.RootElement);
        }

        internal virtual BinaryContent ToBinaryContent()
        {
            return BinaryContent.Create(this, ModelSerializationExtensions.WireOptions);
        }
    }
}
