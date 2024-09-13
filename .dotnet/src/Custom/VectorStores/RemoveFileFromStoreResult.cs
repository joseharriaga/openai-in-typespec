namespace OpenAI.VectorStores;

[CodeGenModel("DeleteVectorStoreFileResponse")]
public partial class RemoveFileFromStoreResult
{
    [CodeGenMember("Deleted")]
    public bool Removed { get; }

    // CUSTOM: Made internal.
    /// <summary> The object type, which is always `vector_store.file.deleted`. </summary>
    [CodeGenMember("Object")]
    internal InternalDeleteVectorStoreFileResponseObject Object { get; } = InternalDeleteVectorStoreFileResponseObject.VectorStoreFileDeleted;
}
