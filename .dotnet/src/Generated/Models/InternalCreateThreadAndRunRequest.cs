// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using OpenAI;

namespace OpenAI.Assistants
{
    internal partial class InternalCreateThreadAndRunRequest
    {
        private protected IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        public InternalCreateThreadAndRunRequest(string assistantId)
        {
            Argument.AssertNotNull(assistantId, nameof(assistantId));

            AssistantId = assistantId;
            Tools = new ChangeTrackingList<ToolDefinition>();
            Metadata = new ChangeTrackingDictionary<string, string>();
        }

        internal InternalCreateThreadAndRunRequest(string assistantId, ThreadCreationOptions thread, string instructions, IList<ToolDefinition> tools, IDictionary<string, string> metadata, float? temperature, float? topP, bool? stream, int? maxPromptTokens, int? maxCompletionTokens, RunTruncationStrategy truncationStrategy, bool? parallelToolCalls, string model, ToolResources toolResources, AssistantResponseFormat responseFormat, ToolConstraint toolChoice, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            AssistantId = assistantId;
            Thread = thread;
            Instructions = instructions;
            Tools = tools;
            Metadata = metadata;
            Temperature = temperature;
            TopP = topP;
            Stream = stream;
            MaxPromptTokens = maxPromptTokens;
            MaxCompletionTokens = maxCompletionTokens;
            TruncationStrategy = truncationStrategy;
            ParallelToolCalls = parallelToolCalls;
            Model = model;
            ToolResources = toolResources;
            ResponseFormat = responseFormat;
            ToolChoice = toolChoice;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        public string AssistantId { get; set; }

        public ThreadCreationOptions Thread { get; set; }

        public string Instructions { get; set; }

        public IList<ToolDefinition> Tools { get; set; }

        public IDictionary<string, string> Metadata { get; set; }

        public float? Temperature { get; set; }

        public float? TopP { get; set; }

        public bool? Stream { get; set; }

        public int? MaxPromptTokens { get; set; }

        public int? MaxCompletionTokens { get; set; }

        public RunTruncationStrategy TruncationStrategy { get; set; }

        public bool? ParallelToolCalls { get; set; }
    }
}
