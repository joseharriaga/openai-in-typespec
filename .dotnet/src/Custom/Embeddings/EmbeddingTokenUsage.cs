namespace OpenAI.Embeddings;

[CodeGenModel("EmbeddingUsage")]
public partial class EmbeddingTokenUsage
{
    // CUSTOM: Renamed.
    /// <summary> The number of tokens used by the input prompts. </summary>
    [CodeGenMember("PromptTokens")]
    public long InputTokens { get; }
}