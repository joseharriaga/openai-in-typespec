namespace OpenAI.Files;

[CodeGenModel("DeleteFileResponse")]
public partial class DeleteFileResult
{
    // CUSTOM: Made internal.
    /// <summary> The object type, which is always `file`. </summary>
    [CodeGenMember("Object")]
    internal InternalDeleteFileResponseObject Object { get; } = InternalDeleteFileResponseObject.File;
}
