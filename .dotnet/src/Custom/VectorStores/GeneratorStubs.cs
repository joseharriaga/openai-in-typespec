namespace OpenAI.VectorStores;

[CodeGenModel("ListVectorStoreFilesFilter")]
public readonly partial struct VectorStoreFileStatusFilter {}

[CodeGenModel("CreateVectorStoreFileRequest")]
internal partial class InternalCreateVectorStoreFileRequest {}

[CodeGenModel("CreateVectorStoreFileBatchRequest")]
internal partial class InternalCreateVectorStoreFileBatchRequest {}

[CodeGenModel("DeleteVectorStoreResponse")]
internal partial class InternalDeleteVectorStoreResponse { }

[CodeGenModel("DeleteVectorStoreResponseObject")]
internal readonly partial struct InternalDeleteVectorStoreResponseObject { }

[CodeGenModel("DeleteVectorStoreFileResponse")]
internal partial class InternalDeleteVectorStoreFileResponse { }

[CodeGenModel("DeleteVectorStoreFileResponseObject")]
internal readonly partial struct InternalDeleteVectorStoreFileResponseObject { }

[CodeGenModel("VectorStoreObjectFileCounts")]
public readonly partial struct VectorStoreFileCounts {}

[CodeGenModel("ListVectorStoresResponse")]
internal partial class InternalListVectorStoresResponse : IInternalListResponse<VectorStore>
{
    private readonly object Object;
}

[CodeGenModel("VectorStoreFileAssociationErrorCode")]
public readonly partial struct VectorStoreFileAssociationErrorCode {}

[CodeGenModel("VectorStoreFileObjectLastError")]
public partial struct VectorStoreFileAssociationError {}

[CodeGenModel("ListVectorStoreFilesResponse")]
internal partial class InternalListVectorStoreFilesResponse : IInternalListResponse<VectorStoreFileAssociation>
{
    private readonly object Object;
}

[CodeGenModel("VectorStoreBatchFileJobStatus")]
public readonly partial struct VectorStoreBatchFileJobStatus {}