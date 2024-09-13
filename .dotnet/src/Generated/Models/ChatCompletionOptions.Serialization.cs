// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Chat
{
    public partial class ChatCompletionOptions : IJsonModel<ChatCompletionOptions>
    {
        void IJsonModel<ChatCompletionOptions>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ChatCompletionOptions>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ChatCompletionOptions)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            if (SerializedAdditionalRawData?.ContainsKey("messages") != true)
            {
                writer.WritePropertyName("messages"u8);
                SerializeMessagesValue(writer, options);
            }
            if (SerializedAdditionalRawData?.ContainsKey("model") != true)
            {
                writer.WritePropertyName("model"u8);
                writer.WriteStringValue(Model.ToString());
            }
            if (SerializedAdditionalRawData?.ContainsKey("frequency_penalty") != true && Optional.IsDefined(FrequencyPenalty))
            {
                if (FrequencyPenalty != null)
                {
                    writer.WritePropertyName("frequency_penalty"u8);
                    writer.WriteNumberValue(FrequencyPenalty.Value);
                }
                else
                {
                    writer.WriteNull("frequency_penalty");
                }
            }
            if (SerializedAdditionalRawData?.ContainsKey("logit_bias") != true && Optional.IsCollectionDefined(LogitBiases))
            {
                if (LogitBiases != null)
                {
                    writer.WritePropertyName("logit_bias"u8);
                    SerializeLogitBiasesValue(writer, options);
                }
                else
                {
                    writer.WriteNull("logit_bias");
                }
            }
            if (SerializedAdditionalRawData?.ContainsKey("logprobs") != true && Optional.IsDefined(IncludeLogProbabilities))
            {
                if (IncludeLogProbabilities != null)
                {
                    writer.WritePropertyName("logprobs"u8);
                    writer.WriteBooleanValue(IncludeLogProbabilities.Value);
                }
                else
                {
                    writer.WriteNull("logprobs");
                }
            }
            if (SerializedAdditionalRawData?.ContainsKey("top_logprobs") != true && Optional.IsDefined(TopLogProbabilityCount))
            {
                if (TopLogProbabilityCount != null)
                {
                    writer.WritePropertyName("top_logprobs"u8);
                    writer.WriteNumberValue(TopLogProbabilityCount.Value);
                }
                else
                {
                    writer.WriteNull("top_logprobs");
                }
            }
            if (SerializedAdditionalRawData?.ContainsKey("max_tokens") != true && Optional.IsDefined(_deprecatedMaxTokens))
            {
                if (_deprecatedMaxTokens != null)
                {
                    writer.WritePropertyName("max_tokens"u8);
                    writer.WriteNumberValue(_deprecatedMaxTokens.Value);
                }
                else
                {
                    writer.WriteNull("max_tokens");
                }
            }
            if (SerializedAdditionalRawData?.ContainsKey("max_completion_tokens") != true && Optional.IsDefined(_maxCompletionTokens))
            {
                if (_maxCompletionTokens != null)
                {
                    writer.WritePropertyName("max_completion_tokens"u8);
                    writer.WriteNumberValue(_maxCompletionTokens.Value);
                }
                else
                {
                    writer.WriteNull("max_completion_tokens");
                }
            }
            if (SerializedAdditionalRawData?.ContainsKey("n") != true && Optional.IsDefined(N))
            {
                if (N != null)
                {
                    writer.WritePropertyName("n"u8);
                    writer.WriteNumberValue(N.Value);
                }
                else
                {
                    writer.WriteNull("n");
                }
            }
            if (SerializedAdditionalRawData?.ContainsKey("presence_penalty") != true && Optional.IsDefined(PresencePenalty))
            {
                if (PresencePenalty != null)
                {
                    writer.WritePropertyName("presence_penalty"u8);
                    writer.WriteNumberValue(PresencePenalty.Value);
                }
                else
                {
                    writer.WriteNull("presence_penalty");
                }
            }
            if (SerializedAdditionalRawData?.ContainsKey("response_format") != true && Optional.IsDefined(ResponseFormat))
            {
                writer.WritePropertyName("response_format"u8);
                writer.WriteObjectValue(ResponseFormat, options);
            }
            if (SerializedAdditionalRawData?.ContainsKey("seed") != true && Optional.IsDefined(Seed))
            {
                if (Seed != null)
                {
                    writer.WritePropertyName("seed"u8);
                    writer.WriteNumberValue(Seed.Value);
                }
                else
                {
                    writer.WriteNull("seed");
                }
            }
            if (SerializedAdditionalRawData?.ContainsKey("service_tier") != true && Optional.IsDefined(_serviceTier))
            {
                if (_serviceTier != null)
                {
                    writer.WritePropertyName("service_tier"u8);
                    writer.WriteStringValue(_serviceTier.Value.ToString());
                }
                else
                {
                    writer.WriteNull("service_tier");
                }
            }
            if (SerializedAdditionalRawData?.ContainsKey("stop") != true && Optional.IsCollectionDefined(StopSequences))
            {
                if (StopSequences != null)
                {
                    writer.WritePropertyName("stop"u8);
                    SerializeStopSequencesValue(writer, options);
                }
                else
                {
                    writer.WriteNull("stop");
                }
            }
            if (SerializedAdditionalRawData?.ContainsKey("stream") != true && Optional.IsDefined(Stream))
            {
                if (Stream != null)
                {
                    writer.WritePropertyName("stream"u8);
                    writer.WriteBooleanValue(Stream.Value);
                }
                else
                {
                    writer.WriteNull("stream");
                }
            }
            if (SerializedAdditionalRawData?.ContainsKey("stream_options") != true && Optional.IsDefined(StreamOptions))
            {
                if (StreamOptions != null)
                {
                    writer.WritePropertyName("stream_options"u8);
                    writer.WriteObjectValue<InternalChatCompletionStreamOptions>(StreamOptions, options);
                }
                else
                {
                    writer.WriteNull("stream_options");
                }
            }
            if (SerializedAdditionalRawData?.ContainsKey("temperature") != true && Optional.IsDefined(Temperature))
            {
                if (Temperature != null)
                {
                    writer.WritePropertyName("temperature"u8);
                    writer.WriteNumberValue(Temperature.Value);
                }
                else
                {
                    writer.WriteNull("temperature");
                }
            }
            if (SerializedAdditionalRawData?.ContainsKey("top_p") != true && Optional.IsDefined(TopP))
            {
                if (TopP != null)
                {
                    writer.WritePropertyName("top_p"u8);
                    writer.WriteNumberValue(TopP.Value);
                }
                else
                {
                    writer.WriteNull("top_p");
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
            if (SerializedAdditionalRawData?.ContainsKey("tool_choice") != true && Optional.IsDefined(ToolChoice))
            {
                writer.WritePropertyName("tool_choice"u8);
                writer.WriteObjectValue<ChatToolChoice>(ToolChoice, options);
            }
            if (SerializedAdditionalRawData?.ContainsKey("parallel_tool_calls") != true && Optional.IsDefined(ParallelToolCallsEnabled))
            {
                writer.WritePropertyName("parallel_tool_calls"u8);
                writer.WriteBooleanValue(ParallelToolCallsEnabled.Value);
            }
            if (SerializedAdditionalRawData?.ContainsKey("user") != true && Optional.IsDefined(EndUserId))
            {
                writer.WritePropertyName("user"u8);
                writer.WriteStringValue(EndUserId);
            }
            if (SerializedAdditionalRawData?.ContainsKey("function_call") != true && Optional.IsDefined(FunctionChoice))
            {
                writer.WritePropertyName("function_call"u8);
                writer.WriteObjectValue<ChatFunctionChoice>(FunctionChoice, options);
            }
            if (SerializedAdditionalRawData?.ContainsKey("functions") != true && Optional.IsCollectionDefined(Functions))
            {
                writer.WritePropertyName("functions"u8);
                writer.WriteStartArray();
                foreach (var item in Functions)
                {
                    writer.WriteObjectValue(item, options);
                }
                writer.WriteEndArray();
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

        ChatCompletionOptions IJsonModel<ChatCompletionOptions>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ChatCompletionOptions>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ChatCompletionOptions)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeChatCompletionOptions(document.RootElement, options);
        }

        internal static ChatCompletionOptions DeserializeChatCompletionOptions(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IList<ChatMessage> messages = default;
            InternalCreateChatCompletionRequestModel model = default;
            float? frequencyPenalty = default;
            IDictionary<int, int> logitBias = default;
            bool? logprobs = default;
            int? topLogprobs = default;
            int? maxTokens = default;
            int? maxCompletionTokens = default;
            int? n = default;
            float? presencePenalty = default;
            ChatResponseFormat responseFormat = default;
            long? seed = default;
            InternalCreateChatCompletionRequestServiceTier? serviceTier = default;
            IList<string> stop = default;
            bool? stream = default;
            InternalChatCompletionStreamOptions streamOptions = default;
            float? temperature = default;
            float? topP = default;
            IList<ChatTool> tools = default;
            ChatToolChoice toolChoice = default;
            bool? parallelToolCalls = default;
            string user = default;
            ChatFunctionChoice functionCall = default;
            IList<ChatFunction> functions = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("messages"u8))
                {
                    List<ChatMessage> array = new List<ChatMessage>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(ChatMessage.DeserializeChatMessage(item, options));
                    }
                    messages = array;
                    continue;
                }
                if (property.NameEquals("model"u8))
                {
                    model = new InternalCreateChatCompletionRequestModel(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("frequency_penalty"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        frequencyPenalty = null;
                        continue;
                    }
                    frequencyPenalty = property.Value.GetSingle();
                    continue;
                }
                if (property.NameEquals("logit_bias"u8))
                {
                    DeserializeLogitBiasesValue(property, ref logitBias);
                    continue;
                }
                if (property.NameEquals("logprobs"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        logprobs = null;
                        continue;
                    }
                    logprobs = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("top_logprobs"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        topLogprobs = null;
                        continue;
                    }
                    topLogprobs = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("max_tokens"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        maxTokens = null;
                        continue;
                    }
                    maxTokens = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("max_completion_tokens"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        maxCompletionTokens = null;
                        continue;
                    }
                    maxCompletionTokens = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("n"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        n = null;
                        continue;
                    }
                    n = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("presence_penalty"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        presencePenalty = null;
                        continue;
                    }
                    presencePenalty = property.Value.GetSingle();
                    continue;
                }
                if (property.NameEquals("response_format"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    responseFormat = ChatResponseFormat.DeserializeChatResponseFormat(property.Value, options);
                    continue;
                }
                if (property.NameEquals("seed"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        seed = null;
                        continue;
                    }
                    seed = property.Value.GetInt64();
                    continue;
                }
                if (property.NameEquals("service_tier"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        serviceTier = null;
                        continue;
                    }
                    serviceTier = new InternalCreateChatCompletionRequestServiceTier(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("stop"u8))
                {
                    DeserializeStopSequencesValue(property, ref stop);
                    continue;
                }
                if (property.NameEquals("stream"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        stream = null;
                        continue;
                    }
                    stream = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("stream_options"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        streamOptions = null;
                        continue;
                    }
                    streamOptions = InternalChatCompletionStreamOptions.DeserializeInternalChatCompletionStreamOptions(property.Value, options);
                    continue;
                }
                if (property.NameEquals("temperature"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        temperature = null;
                        continue;
                    }
                    temperature = property.Value.GetSingle();
                    continue;
                }
                if (property.NameEquals("top_p"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        topP = null;
                        continue;
                    }
                    topP = property.Value.GetSingle();
                    continue;
                }
                if (property.NameEquals("tools"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<ChatTool> array = new List<ChatTool>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(ChatTool.DeserializeChatTool(item, options));
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
                    toolChoice = ChatToolChoice.DeserializeChatToolChoice(property.Value, options);
                    continue;
                }
                if (property.NameEquals("parallel_tool_calls"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    parallelToolCalls = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("user"u8))
                {
                    user = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("function_call"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    functionCall = ChatFunctionChoice.DeserializeChatFunctionChoice(property.Value, options);
                    continue;
                }
                if (property.NameEquals("functions"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<ChatFunction> array = new List<ChatFunction>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(ChatFunction.DeserializeChatFunction(item, options));
                    }
                    functions = array;
                    continue;
                }
                if (true)
                {
                    rawDataDictionary ??= new Dictionary<string, BinaryData>();
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new ChatCompletionOptions(
                messages,
                model,
                frequencyPenalty,
                logitBias ?? new ChangeTrackingDictionary<int, int>(),
                logprobs,
                topLogprobs,
                maxTokens,
                maxCompletionTokens,
                n,
                presencePenalty,
                responseFormat,
                seed,
                serviceTier,
                stop ?? new ChangeTrackingList<string>(),
                stream,
                streamOptions,
                temperature,
                topP,
                tools ?? new ChangeTrackingList<ChatTool>(),
                toolChoice,
                parallelToolCalls,
                user,
                functionCall,
                functions ?? new ChangeTrackingList<ChatFunction>(),
                serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<ChatCompletionOptions>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ChatCompletionOptions>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(ChatCompletionOptions)} does not support writing '{options.Format}' format.");
            }
        }

        ChatCompletionOptions IPersistableModel<ChatCompletionOptions>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ChatCompletionOptions>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeChatCompletionOptions(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(ChatCompletionOptions)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<ChatCompletionOptions>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        internal static ChatCompletionOptions FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeChatCompletionOptions(document.RootElement);
        }

        internal virtual BinaryContent ToBinaryContent()
        {
            return BinaryContent.Create(this, ModelSerializationExtensions.WireOptions);
        }
    }
}
