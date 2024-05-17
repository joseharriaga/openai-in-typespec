namespace OpenAI.Chat;

/// <summary>
/// Represents computed token consumption statistics for a chat completion request.
/// </summary>
public class ChatTokenUsage
{
    /// <inheritdoc cref="Internal.Models.CompletionUsage.PromptTokens"/>
    public int InputTokens { get; }
    /// <inheritdoc cref="Internal.Models.CompletionUsage.CompletionTokens"/>
    public int OutputTokens { get; }
    /// <inheritdoc cref="Internal.Models.CompletionUsage.TotalTokens"/>
    public int TotalTokens { get; }

    internal ChatTokenUsage(OpenAI.LegacyCompletions.CompletionUsage internalUsage)
    {
        InputTokens = internalUsage.PromptTokens;
        OutputTokens = internalUsage.CompletionTokens;
        TotalTokens = internalUsage.TotalTokens;
    }

    internal ChatTokenUsage(int inputTokens, int outputTokens, int totalTokens)
    {
        InputTokens = inputTokens;
        OutputTokens = outputTokens;
        TotalTokens = totalTokens;
    }
}