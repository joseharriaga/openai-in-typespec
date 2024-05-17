namespace OpenAI.VectorStores;

/// <summary>
/// A representation of a file storage and indexing container used by the <c>file_search</c> tool for assistants.
/// </summary>
[CodeGenModel("VectorStoreObject")]
public partial class VectorStore
{
    private readonly object Object;

    /// <summary>
    /// Gets the policy that controls when this vector store will be automatically deleted.
    /// </summary>
    [CodeGenMember("ExpiresAfter")]
    public VectorStoreExpirationPolicy ExpirationPolicy { get; }
}