namespace OpenAI.Files;

[CodeGenModel("DeleteFileResponse")]
internal partial class InternalDeleteFileResponse { }

[CodeGenModel("DeleteFileResponseObject")]
internal readonly partial struct InternalDeleteFileResponseObject { }

[CodeGenModel("ListFilesResponseObject")]
internal readonly partial struct InternalListFilesResponseObject { }

[CodeGenModel("OpenAIFileObject")]
internal readonly partial struct InternalOpenAIFileObject { }

[CodeGenModel("Upload")]
internal partial class InternalUpload
{
    [CodeGenMember("Bytes")]
    public long TotalSizeInBytes { get; }

    [CodeGenMember("Purpose")]
    public InternalCreateUploadRequestPurpose Purpose { get; }
}

[CodeGenModel("CreateUploadRequestPurpose")]
internal readonly partial struct InternalCreateUploadRequestPurpose { }

[CodeGenModel("UploadObject")]
internal readonly partial struct InternalUploadObject { }

[CodeGenModel("UploadStatus")]
internal readonly partial struct InternalUploadStatus { }

[CodeGenModel("UploadPart")]
internal partial class InternalUploadPart { }

[CodeGenModel("UploadPartObject")]
internal readonly partial struct InternalUploadPartObject { }

[CodeGenModel("CompleteUploadRequest")]
internal partial class InternalCompleteUploadRequest { }

[CodeGenModel("CreateUploadRequest")]
internal partial class InternalCreateUploadRequest { }

[CodeGenModel("AddUploadPartRequest")]
internal partial class InternalAddUploadPartRequest { }

