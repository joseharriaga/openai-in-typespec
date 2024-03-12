using OpenAI.ClientShared.Internal;

using System.Collections.Generic;

namespace OpenAI.Chat;

/// <summary>
/// Request-level options for chat completion.
/// </summary>
public partial class ChatCompletionOptions
{
    /// <inheritdoc cref="Internal.Models.CreateChatCompletionRequest.FrequencyPenalty" />
    public double? FrequencyPenalty { get; set; }
    /// <inheritdoc cref="Internal.Models.CreateChatCompletionRequest.LogitBias" />
    public IDictionary<long, long> TokenSelectionBiases { get; set; } = new OptionalDictionary<long, long>();
    /// <inheritdoc cref="Internal.Models.CreateChatCompletionRequest.Logprobs" />
    public bool? IncludeLogProbabilities { get; set; }
    /// <inheritdoc cref="Internal.Models.CreateChatCompletionRequest.TopLogprobs" />
    public long? LogProbabilityCount { get; set; }
    /// <inheritdoc cref="Internal.Models.CreateChatCompletionRequest.MaxTokens" />
    public long? MaxTokens { get; set; }
    /// <inheritdoc cref="Internal.Models.CreateChatCompletionRequest.PresencePenalty" />
    public double? PresencePenalty { get; set; }
    /// <inheritdoc cref="Internal.Models.CreateChatCompletionRequest.ResponseFormat" />
    public ChatResponseFormat? ResponseFormat { get; set; }
    /// <inheritdoc cref="Internal.Models.CreateChatCompletionRequest.Seed" />
    public long? Seed { get; set; }
    /// <inheritdoc cref="Internal.Models.CreateChatCompletionRequest.Stop" />
    public IList<string> StopSequences { get; } = new OptionalList<string>();
    /// <inheritdoc cref="Internal.Models.CreateChatCompletionRequest.Temperature" />
    public double? Temperature { get; set; }
    /// <inheritdoc cref="Internal.Models.CreateChatCompletionRequest.TopP" />
    public double? NucleusSamplingFactor { get; set; }
    /// <inheritdoc cref="Internal.Models.CreateChatCompletionRequest.Tools" />
    public IList<ChatToolDefinition> Tools { get; } = new OptionalList<ChatToolDefinition>();
    /// <inheritdoc cref="Internal.Models.CreateChatCompletionRequest.ToolChoice" />
    public ChatToolConstraint ToolConstraint { get; set; }
    /// <inheritdoc cref="Internal.Models.CreateChatCompletionRequest.User" />
    public string User { get; set; }
    /// <inheritdoc cref="Internal.Models.CreateChatCompletionRequest.Functions" />
    public IList<ChatFunctionDefinition> Functions { get; } = new OptionalList<ChatFunctionDefinition>();
    /// <inheritdoc cref="Internal.Models.CreateChatCompletionRequest.FunctionCall" />
    public ChatFunctionConstraint FunctionConstraint { get; set; }
}