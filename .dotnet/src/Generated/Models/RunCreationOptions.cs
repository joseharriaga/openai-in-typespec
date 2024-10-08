// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Assistants
{
    public partial class RunCreationOptions
    {
        private protected IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        internal RunCreationOptions(string assistantId, bool? stream, AssistantResponseFormat responseFormat, string modelOverride, string instructionsOverride, string additionalInstructions, IList<MessageCreationOptions> internalMessages, bool? allowParallelToolCalls, IList<ToolDefinition> toolsOverride, IDictionary<string, string> metadata, float? temperature, float? nucleusSamplingFactor, int? maxInputTokenCount, int? maxOutputTokenCount, RunTruncationStrategy truncationStrategy, ToolConstraint toolConstraint, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            AssistantId = assistantId;
            Stream = stream;
            ResponseFormat = responseFormat;
            ModelOverride = modelOverride;
            InstructionsOverride = instructionsOverride;
            AdditionalInstructions = additionalInstructions;
            InternalMessages = internalMessages;
            AllowParallelToolCalls = allowParallelToolCalls;
            ToolsOverride = toolsOverride;
            Metadata = metadata;
            Temperature = temperature;
            NucleusSamplingFactor = nucleusSamplingFactor;
            MaxInputTokenCount = maxInputTokenCount;
            MaxOutputTokenCount = maxOutputTokenCount;
            TruncationStrategy = truncationStrategy;
            ToolConstraint = toolConstraint;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }
    }
}
