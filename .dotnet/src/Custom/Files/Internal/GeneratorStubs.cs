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
internal partial class InternalUploadJob
{
    [CodeGenMember("Object")]
    internal readonly object _internalObject;
}

[CodeGenModel("CreateUploadRequestPurpose")]
internal readonly partial struct InternalUploadJobCreationPurpose { }

[CodeGenModel("UploadPart")]
internal partial class InternalUploadJobDataPart
{
    [CodeGenMember("Object")]
    internal readonly object _internalObject;
}
