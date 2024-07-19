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
public partial class UploadJob
{
    [CodeGenMember("Object")]
    internal readonly object _internalObject;
}

[CodeGenModel("UploadPart")]
public partial class UploadJobDataPart
{
    [CodeGenMember("Object")]
    internal readonly object _internalObject;
}
