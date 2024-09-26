// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenAI.Chat
{
    public partial class ChatCompletionOptions
    {
        internal IDictionary<string, BinaryData> SerializedAdditionalRawData { get; set; }

        internal ChatCompletionOptions(IList<ChatMessage> messages, InternalCreateChatCompletionRequestModel model, float? frequencyPenalty, IDictionary<int, int> logitBiases, bool? includeLogProbabilities, int? topLogProbabilityCount, int? deprecatedMaxTokens, int? maxOutputTokenCount, int? n, float? presencePenalty, ChatResponseFormat responseFormat, long? seed, InternalCreateChatCompletionRequestServiceTier? serviceTier, IList<string> stopSequences, bool? stream, InternalChatCompletionStreamOptions streamOptions, float? temperature, float? topP, IList<ChatTool> tools, ChatToolChoice toolChoice, bool? parallelToolCallsEnabled, string endUserId, ChatFunctionChoice functionChoice, IList<ChatFunction> functions, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Messages = messages;
            Model = model;
            FrequencyPenalty = frequencyPenalty;
            LogitBiases = logitBiases;
            IncludeLogProbabilities = includeLogProbabilities;
            TopLogProbabilityCount = topLogProbabilityCount;
            _deprecatedMaxTokens = deprecatedMaxTokens;
            MaxOutputTokenCount = maxOutputTokenCount;
            N = n;
            PresencePenalty = presencePenalty;
            ResponseFormat = responseFormat;
            Seed = seed;
            _serviceTier = serviceTier;
            StopSequences = stopSequences;
            Stream = stream;
            StreamOptions = streamOptions;
            Temperature = temperature;
            TopP = topP;
            Tools = tools;
            ToolChoice = toolChoice;
            ParallelToolCallsEnabled = parallelToolCallsEnabled;
            EndUserId = endUserId;
            FunctionChoice = functionChoice;
            Functions = functions;
            SerializedAdditionalRawData = serializedAdditionalRawData;
        }
        public float? FrequencyPenalty { get; set; }
        public float? PresencePenalty { get; set; }
        public ChatResponseFormat ResponseFormat { get; set; }
        public float? Temperature { get; set; }
        public float? TopP { get; set; }
    }
}
