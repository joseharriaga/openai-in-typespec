namespace OpenAI.VectorStores;

[CodeGenModel("UpdateVectorStoreRequest")]
public partial class VectorStoreModificationOptions {}

[CodeGenModel("ListVectorStoreFilesFilter")]
public readonly partial struct VectorStoreFileStatusFilter {}

[CodeGenModel("CreateVectorStoreFileRequest")]
internal partial class InternalCreateVectorStoreFileRequest {}

[CodeGenModel("CreateVectorStoreFileBatchRequest")]
internal partial class InternalCreateVectorStoreFileBatchRequest {}

[CodeGenModel("DeleteVectorStoreResponse")]
internal partial class InternalDeleteVectorStoreResponse { private readonly object Object; }

[CodeGenModel("VectorStoreObjectFileCounts")]
public readonly partial struct VectorStoreFileCounts {}

[CodeGenModel("ListVectorStoresResponse")]
internal partial class InternalListVectorStoresResponse : IInternalListResponse<VectorStore>
{
    private readonly object Object;
}

[CodeGenModel("VectorStoreFileObjectLastErrorCode")]
public readonly partial struct VectorStoreFileAssociationErrorCode {}

[CodeGenModel("VectorStoreFileObjectLastError")]
public partial struct VectorStoreFileAssociationError {}

[CodeGenModel("ListVectorStoreFilesResponse")]
internal partial class InternalListVectorStoreFilesResponse : IInternalListResponse<VectorStoreFileAssociation>
{
    private readonly object Object;
}