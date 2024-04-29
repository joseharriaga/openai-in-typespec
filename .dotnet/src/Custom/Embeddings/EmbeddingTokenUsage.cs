namespace OpenAI.Embeddings;

public partial class EmbeddingTokenUsage
{
    private Internal.Models.CreateEmbeddingResponseUsage _internalUsage;

    /// <inheritdoc cref="Internal.Models.EmbeddingUsage.PromptTokens"/>
    public int InputTokens => (int)_internalUsage.PromptTokens;
    /// <inheritdoc cref="Internal.Models.EmbeddingUsage.TotalTokens"/>
    public int TotalTokens => (int)_internalUsage.TotalTokens;

    internal EmbeddingTokenUsage(Internal.Models.CreateEmbeddingResponseUsage internalUsage)
    {
        _internalUsage = internalUsage;
    }
}