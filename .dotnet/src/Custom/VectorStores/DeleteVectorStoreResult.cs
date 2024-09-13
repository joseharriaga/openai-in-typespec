namespace OpenAI.VectorStores;

[CodeGenModel("DeleteVectorStoreResponse")]
public partial class DeleteVectorStoreResult
{
    // CUSTOM: Made internal.
    /// <summary> The object type, which is always `vector_store.deleted`. </summary>
    internal InternalDeleteVectorStoreResponseObject Object { get; } = InternalDeleteVectorStoreResponseObject.VectorStoreDeleted;
}
