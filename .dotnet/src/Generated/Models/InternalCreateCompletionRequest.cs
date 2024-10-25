// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using OpenAI;
using OpenAI.Chat;

namespace OpenAI.LegacyCompletions
{
    internal partial class InternalCreateCompletionRequest
    {
        private protected IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        public InternalCreateCompletionRequest(InternalCreateCompletionRequestModel model, BinaryData prompt)
        {
            Model = model;
            Prompt = prompt;
            LogitBias = new ChangeTrackingDictionary<string, int>();
        }

        internal InternalCreateCompletionRequest(InternalCreateCompletionRequestModel model, BinaryData prompt, int? bestOf, bool? echo, float? frequencyPenalty, IDictionary<string, int> logitBias, int? logprobs, int? maxTokens, int? n, float? presencePenalty, long? seed, BinaryData stop, bool? stream, InternalChatCompletionStreamOptions streamOptions, string suffix, float? temperature, float? topP, string user, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            Model = model;
            Prompt = prompt;
            BestOf = bestOf;
            Echo = echo;
            FrequencyPenalty = frequencyPenalty;
            LogitBias = logitBias;
            Logprobs = logprobs;
            MaxTokens = maxTokens;
            N = n;
            PresencePenalty = presencePenalty;
            Seed = seed;
            Stop = stop;
            Stream = stream;
            StreamOptions = streamOptions;
            Suffix = suffix;
            Temperature = temperature;
            TopP = topP;
            User = user;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        public InternalCreateCompletionRequestModel Model { get; set; }

        public BinaryData Prompt { get; set; }

        public int? BestOf { get; set; }

        public bool? Echo { get; set; }

        public float? FrequencyPenalty { get; set; }

        public IDictionary<string, int> LogitBias { get; set; }

        public int? Logprobs { get; set; }

        public int? MaxTokens { get; set; }

        public int? N { get; set; }

        public float? PresencePenalty { get; set; }

        public long? Seed { get; set; }

        public BinaryData Stop { get; set; }

        public bool? Stream { get; set; }

        public InternalChatCompletionStreamOptions StreamOptions { get; set; }

        public string Suffix { get; set; }

        public float? Temperature { get; set; }

        public float? TopP { get; set; }

        public string User { get; set; }

        internal IDictionary<string, BinaryData> SerializedAdditionalRawData
        {
            get => _additionalBinaryDataProperties;
            set => _additionalBinaryDataProperties = value;
        }
    }
}
