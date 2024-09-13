namespace OpenAI.Chat;

/// <summary>
/// Represents computed token consumption statistics for a chat completion request.
/// </summary>
[CodeGenModel("CompletionUsage")]
public partial class ChatTokenUsage
{
    // CUSTOM: Renamed.
    /// <summary>
    /// The combined number of output tokens consumed by the model.
    /// </summary>
    /// <remarks>
    /// When using a model that supports <see cref="ReasoningTokens"/> such as <c>o1-mini</c>, this value represents
    /// the sum of those reasoning tokens and conventional, displayed output tokens.
    /// </remarks>
    [CodeGenMember("CompletionTokens")]
    public int OutputTokens { get; }

    // CUSTOM: Renamed.
    /// <summary>
    /// The number of tokens in the request message input, spanning all message content items.
    /// </summary>
    [CodeGenMember("PromptTokens")]
    public int InputTokens { get; }

    /// <summary>
    /// The count of reasoning tokens used. Currently applicable to `o1` series models.
    /// </summary>
    public int ReasoningTokens => _internalCompletionTokenDetails?.ReasoningTokens ?? 0;

    [CodeGenMember("CompletionTokensDetails")]
    private InternalCompletionUsageCompletionTokensDetails _internalCompletionTokenDetails;
}