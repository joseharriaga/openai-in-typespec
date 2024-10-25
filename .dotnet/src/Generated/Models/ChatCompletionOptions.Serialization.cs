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
    public partial class ChatCompletionOptions : IJsonModel<ChatCompletionOptions>
    {
        void IJsonModel<ChatCompletionOptions>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ChatCompletionOptions>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ChatCompletionOptions)} does not support writing '{format}' format.");
            }
            if (Optional.IsDefined(FrequencyPenalty) && _additionalBinaryDataProperties?.ContainsKey("frequency_penalty") != true)
            {
                if (FrequencyPenalty != null)
                {
                    writer.WritePropertyName("frequency_penalty"u8);
                    writer.WriteNumberValue(FrequencyPenalty.Value);
                }
                else
                {
                    writer.WriteNull("frequencyPenalty"u8);
                }
            }
            if (Optional.IsDefined(PresencePenalty) && _additionalBinaryDataProperties?.ContainsKey("presence_penalty") != true)
            {
                if (PresencePenalty != null)
                {
                    writer.WritePropertyName("presence_penalty"u8);
                    writer.WriteNumberValue(PresencePenalty.Value);
                }
                else
                {
                    writer.WriteNull("presencePenalty"u8);
                }
            }
            if (Optional.IsDefined(ResponseFormat) && _additionalBinaryDataProperties?.ContainsKey("response_format") != true)
            {
                writer.WritePropertyName("response_format"u8);
                writer.WriteObjectValue(ResponseFormat, options);
            }
            if (Optional.IsDefined(Temperature) && _additionalBinaryDataProperties?.ContainsKey("temperature") != true)
            {
                if (Temperature != null)
                {
                    writer.WritePropertyName("temperature"u8);
                    writer.WriteNumberValue(Temperature.Value);
                }
                else
                {
                    writer.WriteNull("temperature"u8);
                }
            }
            if (Optional.IsDefined(TopP) && _additionalBinaryDataProperties?.ContainsKey("top_p") != true)
            {
                if (TopP != null)
                {
                    writer.WritePropertyName("top_p"u8);
                    writer.WriteNumberValue(TopP.Value);
                }
                else
                {
                    writer.WriteNull("topP"u8);
                }
            }
            if (Optional.IsCollectionDefined(Tools) && _additionalBinaryDataProperties?.ContainsKey("tools") != true)
            {
                writer.WritePropertyName("tools"u8);
                writer.WriteStartArray();
                foreach (ChatTool item in Tools)
                {
                    writer.WriteObjectValue(item, options);
                }
                writer.WriteEndArray();
            }
            if (_additionalBinaryDataProperties?.ContainsKey("messages") != true)
            {
                writer.WritePropertyName("messages"u8);
            }
            this.SerializeMessagesValue(writer, options);
            if (_additionalBinaryDataProperties?.ContainsKey("model") != true)
            {
                writer.WritePropertyName("model"u8);
            }
            writer.WriteStringValue(Model.ToString());
            if (Optional.IsDefined(N) && _additionalBinaryDataProperties?.ContainsKey("n") != true)
            {
                if (N != null)
                {
                    writer.WritePropertyName("n"u8);
                    writer.WriteNumberValue(N.Value);
                }
                else
                {
                    writer.WriteNull("n"u8);
                }
            }
            if (Optional.IsDefined(Stream) && _additionalBinaryDataProperties?.ContainsKey("stream") != true)
            {
                if (Stream != null)
                {
                    writer.WritePropertyName("stream"u8);
                    writer.WriteBooleanValue(Stream.Value);
                }
                else
                {
                    writer.WriteNull("stream"u8);
                }
            }
            if (Optional.IsDefined(StreamOptions) && _additionalBinaryDataProperties?.ContainsKey("stream_options") != true)
            {
                if (StreamOptions != null)
                {
                    writer.WritePropertyName("stream_options"u8);
                    writer.WriteObjectValue<InternalChatCompletionStreamOptions>(StreamOptions, options);
                }
                else
                {
                    writer.WriteNull("streamOptions"u8);
                }
            }
            if (Optional.IsDefined(IncludeLogProbabilities) && _additionalBinaryDataProperties?.ContainsKey("logprobs") != true)
            {
                if (IncludeLogProbabilities != null)
                {
                    writer.WritePropertyName("logprobs"u8);
                    writer.WriteBooleanValue(IncludeLogProbabilities.Value);
                }
                else
                {
                    writer.WriteNull("logprobs"u8);
                }
            }
            if (Optional.IsDefined(TopLogProbabilityCount) && _additionalBinaryDataProperties?.ContainsKey("top_logprobs") != true)
            {
                if (TopLogProbabilityCount != null)
                {
                    writer.WritePropertyName("top_logprobs"u8);
                    writer.WriteNumberValue(TopLogProbabilityCount.Value);
                }
                else
                {
                    writer.WriteNull("topLogprobs"u8);
                }
            }
            if (Optional.IsCollectionDefined(StopSequences) && _additionalBinaryDataProperties?.ContainsKey("stop") != true)
            {
                if (StopSequences != null)
                {
                    writer.WritePropertyName("stop"u8);
                    this.SerializeStopSequencesValue(writer, options);
                }
                else
                {
                    writer.WriteNull("stop"u8);
                }
            }
            if (Optional.IsCollectionDefined(LogitBiases) && _additionalBinaryDataProperties?.ContainsKey("logit_bias") != true)
            {
                if (LogitBiases != null)
                {
                    writer.WritePropertyName("logit_bias"u8);
                    this.SerializeLogitBiasesValue(writer, options);
                }
                else
                {
                    writer.WriteNull("logitBias"u8);
                }
            }
            if (Optional.IsDefined(ToolChoice) && _additionalBinaryDataProperties?.ContainsKey("tool_choice") != true)
            {
                writer.WritePropertyName("tool_choice"u8);
                writer.WriteObjectValue<ChatToolChoice>(ToolChoice, options);
            }
            if (Optional.IsDefined(FunctionChoice) && _additionalBinaryDataProperties?.ContainsKey("function_call") != true)
            {
                writer.WritePropertyName("function_call"u8);
                writer.WriteObjectValue<ChatFunctionChoice>(FunctionChoice, options);
            }
            if (Optional.IsDefined(AllowParallelToolCalls) && _additionalBinaryDataProperties?.ContainsKey("parallel_tool_calls") != true)
            {
                writer.WritePropertyName("parallel_tool_calls"u8);
                writer.WriteBooleanValue(AllowParallelToolCalls.Value);
            }
            if (Optional.IsDefined(EndUserId) && _additionalBinaryDataProperties?.ContainsKey("user") != true)
            {
                writer.WritePropertyName("user"u8);
                writer.WriteStringValue(EndUserId);
            }
            if (Optional.IsDefined(Seed) && _additionalBinaryDataProperties?.ContainsKey("seed") != true)
            {
                if (Seed != null)
                {
                    writer.WritePropertyName("seed"u8);
                    writer.WriteNumberValue(Seed.Value);
                }
                else
                {
                    writer.WriteNull("seed"u8);
                }
            }
            if (Optional.IsDefined(_deprecatedMaxTokens) && _additionalBinaryDataProperties?.ContainsKey("max_tokens") != true)
            {
                if (_deprecatedMaxTokens != null)
                {
                    writer.WritePropertyName("max_tokens"u8);
                    writer.WriteNumberValue(_deprecatedMaxTokens.Value);
                }
                else
                {
                    writer.WriteNull("maxTokens"u8);
                }
            }
            if (Optional.IsDefined(MaxOutputTokenCount) && _additionalBinaryDataProperties?.ContainsKey("max_completion_tokens") != true)
            {
                if (MaxOutputTokenCount != null)
                {
                    writer.WritePropertyName("max_completion_tokens"u8);
                    writer.WriteNumberValue(MaxOutputTokenCount.Value);
                }
                else
                {
                    writer.WriteNull("maxCompletionTokens"u8);
                }
            }
            if (Optional.IsCollectionDefined(Functions) && _additionalBinaryDataProperties?.ContainsKey("functions") != true)
            {
                writer.WritePropertyName("functions"u8);
                writer.WriteStartArray();
                foreach (ChatFunction item in Functions)
                {
                    writer.WriteObjectValue(item, options);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(_serviceTier) && _additionalBinaryDataProperties?.ContainsKey("service_tier") != true)
            {
                if (_serviceTier != null)
                {
                    writer.WritePropertyName("service_tier"u8);
                    writer.WriteStringValue(_serviceTier.Value.ToString());
                }
                else
                {
                    writer.WriteNull("serviceTier"u8);
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

        ChatCompletionOptions IJsonModel<ChatCompletionOptions>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual ChatCompletionOptions JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ChatCompletionOptions>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ChatCompletionOptions)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeChatCompletionOptions(document.RootElement, options);
        }

        internal static ChatCompletionOptions DeserializeChatCompletionOptions(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            float? frequencyPenalty = default;
            float? presencePenalty = default;
            ChatResponseFormat responseFormat = default;
            float? temperature = default;
            float? topP = default;
            IList<ChatTool> tools = default;
            IList<ChatMessage> messages = default;
            InternalCreateChatCompletionRequestModel model = default;
            int? n = default;
            bool? stream = default;
            InternalChatCompletionStreamOptions streamOptions = default;
            bool? includeLogProbabilities = default;
            int? topLogProbabilityCount = default;
            IList<string> stopSequences = default;
            IDictionary<int, int> logitBiases = default;
            ChatToolChoice toolChoice = default;
            ChatFunctionChoice functionChoice = default;
            bool? allowParallelToolCalls = default;
            string endUserId = default;
            long? seed = default;
            int? deprecatedMaxTokens = default;
            int? maxOutputTokenCount = default;
            IList<ChatFunction> functions = default;
            InternalCreateChatCompletionRequestServiceTier? serviceTier = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("frequency_penalty"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        frequencyPenalty = null;
                        continue;
                    }
                    frequencyPenalty = prop.Value.GetSingle();
                    continue;
                }
                if (prop.NameEquals("presence_penalty"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        presencePenalty = null;
                        continue;
                    }
                    presencePenalty = prop.Value.GetSingle();
                    continue;
                }
                if (prop.NameEquals("response_format"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    responseFormat = ChatResponseFormat.DeserializeChatResponseFormat(prop.Value, options);
                    continue;
                }
                if (prop.NameEquals("temperature"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        temperature = null;
                        continue;
                    }
                    temperature = prop.Value.GetSingle();
                    continue;
                }
                if (prop.NameEquals("top_p"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        topP = null;
                        continue;
                    }
                    topP = prop.Value.GetSingle();
                    continue;
                }
                if (prop.NameEquals("tools"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<ChatTool> array = new List<ChatTool>();
                    foreach (var item in prop.Value.EnumerateArray())
                    {
                        array.Add(ChatTool.DeserializeChatTool(item, options));
                    }
                    tools = array;
                    continue;
                }
                if (prop.NameEquals("messages"u8))
                {
                    List<ChatMessage> array = new List<ChatMessage>();
                    foreach (var item in prop.Value.EnumerateArray())
                    {
                        array.Add(ChatMessage.DeserializeChatMessage(item, options));
                    }
                    messages = array;
                    continue;
                }
                if (prop.NameEquals("model"u8))
                {
                    model = new InternalCreateChatCompletionRequestModel(prop.Value.GetString());
                    continue;
                }
                if (prop.NameEquals("n"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        n = null;
                        continue;
                    }
                    n = prop.Value.GetInt32();
                    continue;
                }
                if (prop.NameEquals("stream"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        stream = null;
                        continue;
                    }
                    stream = prop.Value.GetBoolean();
                    continue;
                }
                if (prop.NameEquals("stream_options"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        streamOptions = null;
                        continue;
                    }
                    streamOptions = InternalChatCompletionStreamOptions.DeserializeInternalChatCompletionStreamOptions(prop.Value, options);
                    continue;
                }
                if (prop.NameEquals("logprobs"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        includeLogProbabilities = null;
                        continue;
                    }
                    includeLogProbabilities = prop.Value.GetBoolean();
                    continue;
                }
                if (prop.NameEquals("top_logprobs"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        topLogProbabilityCount = null;
                        continue;
                    }
                    topLogProbabilityCount = prop.Value.GetInt32();
                    continue;
                }
                if (prop.NameEquals("stop"u8))
                {
                    DeserializeStopSequencesValue(prop, ref stopSequences);
                    continue;
                }
                if (prop.NameEquals("logit_bias"u8))
                {
                    DeserializeLogitBiasesValue(prop, ref logitBiases);
                    continue;
                }
                if (prop.NameEquals("tool_choice"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    toolChoice = ChatToolChoice.DeserializeChatToolChoice(prop.Value, options);
                    continue;
                }
                if (prop.NameEquals("function_call"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    functionChoice = ChatFunctionChoice.DeserializeChatFunctionChoice(prop.Value, options);
                    continue;
                }
                if (prop.NameEquals("parallel_tool_calls"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    allowParallelToolCalls = prop.Value.GetBoolean();
                    continue;
                }
                if (prop.NameEquals("user"u8))
                {
                    endUserId = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("seed"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        seed = null;
                        continue;
                    }
                    seed = prop.Value.GetInt64();
                    continue;
                }
                if (prop.NameEquals("max_tokens"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        deprecatedMaxTokens = null;
                        continue;
                    }
                    deprecatedMaxTokens = prop.Value.GetInt32();
                    continue;
                }
                if (prop.NameEquals("max_completion_tokens"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        maxOutputTokenCount = null;
                        continue;
                    }
                    maxOutputTokenCount = prop.Value.GetInt32();
                    continue;
                }
                if (prop.NameEquals("functions"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<ChatFunction> array = new List<ChatFunction>();
                    foreach (var item in prop.Value.EnumerateArray())
                    {
                        array.Add(ChatFunction.DeserializeChatFunction(item, options));
                    }
                    functions = array;
                    continue;
                }
                if (prop.NameEquals("service_tier"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        serviceTier = null;
                        continue;
                    }
                    serviceTier = new InternalCreateChatCompletionRequestServiceTier(prop.Value.GetString());
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new ChatCompletionOptions(
                frequencyPenalty,
                presencePenalty,
                responseFormat,
                temperature,
                topP,
                tools ?? new ChangeTrackingList<ChatTool>(),
                messages,
                model,
                n,
                stream,
                streamOptions,
                includeLogProbabilities,
                topLogProbabilityCount,
                stopSequences ?? new ChangeTrackingList<string>(),
                logitBiases ?? new ChangeTrackingDictionary<int, int>(),
                toolChoice,
                functionChoice,
                allowParallelToolCalls,
                endUserId,
                seed,
                deprecatedMaxTokens,
                maxOutputTokenCount,
                functions ?? new ChangeTrackingList<ChatFunction>(),
                serviceTier,
                additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<ChatCompletionOptions>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ChatCompletionOptions>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(ChatCompletionOptions)} does not support writing '{options.Format}' format.");
            }
        }

        ChatCompletionOptions IPersistableModel<ChatCompletionOptions>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        protected virtual ChatCompletionOptions PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ChatCompletionOptions>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeChatCompletionOptions(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(ChatCompletionOptions)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<ChatCompletionOptions>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(ChatCompletionOptions chatCompletionOptions)
        {
            return BinaryContent.Create(chatCompletionOptions, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator ChatCompletionOptions(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeChatCompletionOptions(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
