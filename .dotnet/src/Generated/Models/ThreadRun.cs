// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenAI.Assistants
{
    public partial class ThreadRun
    {
        internal IDictionary<string, BinaryData> SerializedAdditionalRawData { get; set; }

        internal ThreadRun(string id, InternalRunObjectObject @object, DateTimeOffset createdAt, string threadId, string assistantId, RunStatus status, InternalRunRequiredAction internalRequiredAction, RunError lastError, DateTimeOffset? expiresAt, DateTimeOffset? startedAt, DateTimeOffset? cancelledAt, DateTimeOffset? failedAt, DateTimeOffset? completedAt, RunIncompleteDetails incompleteDetails, string model, string instructions, IReadOnlyList<ToolDefinition> tools, IReadOnlyDictionary<string, string> metadata, RunTokenUsage usage, float? temperature, float? nucleusSamplingFactor, int? maxPromptTokens, int? maxCompletionTokens, RunTruncationStrategy truncationStrategy, ToolConstraint toolConstraint, bool? allowParallelToolCalls, AssistantResponseFormat responseFormat, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Id = id;
            Object = @object;
            CreatedAt = createdAt;
            ThreadId = threadId;
            AssistantId = assistantId;
            Status = status;
            _internalRequiredAction = internalRequiredAction;
            LastError = lastError;
            ExpiresAt = expiresAt;
            StartedAt = startedAt;
            CancelledAt = cancelledAt;
            FailedAt = failedAt;
            CompletedAt = completedAt;
            IncompleteDetails = incompleteDetails;
            Model = model;
            Instructions = instructions;
            Tools = tools;
            Metadata = metadata;
            Usage = usage;
            Temperature = temperature;
            NucleusSamplingFactor = nucleusSamplingFactor;
            MaxPromptTokens = maxPromptTokens;
            MaxCompletionTokens = maxCompletionTokens;
            TruncationStrategy = truncationStrategy;
            ToolConstraint = toolConstraint;
            AllowParallelToolCalls = allowParallelToolCalls;
            ResponseFormat = responseFormat;
            SerializedAdditionalRawData = serializedAdditionalRawData;
        }

        internal ThreadRun()
        {
        }

        public string Id { get; }

        public DateTimeOffset CreatedAt { get; }
        public string ThreadId { get; }
        public string AssistantId { get; }
        public RunStatus Status { get; }
        public RunError LastError { get; }
        public DateTimeOffset? ExpiresAt { get; }
        public DateTimeOffset? StartedAt { get; }
        public DateTimeOffset? CancelledAt { get; }
        public DateTimeOffset? FailedAt { get; }
        public DateTimeOffset? CompletedAt { get; }
        public RunIncompleteDetails IncompleteDetails { get; }
        public string Model { get; }
        public string Instructions { get; }
        public IReadOnlyList<ToolDefinition> Tools { get; }
        public IReadOnlyDictionary<string, string> Metadata { get; }
        public RunTokenUsage Usage { get; }
        public float? Temperature { get; }
        public int? MaxPromptTokens { get; }
        public int? MaxCompletionTokens { get; }
        public RunTruncationStrategy TruncationStrategy { get; }
    }
}
