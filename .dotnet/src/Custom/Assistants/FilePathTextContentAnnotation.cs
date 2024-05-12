using OpenAI.Internal.Models;

namespace OpenAI.Assistants;

[CodeGenModel("MessageContentTextAnnotationsFilePathObject")]
public partial class FilePathTextContentAnnotation
{
    /// <inheritdoc cref="InternalMessageContentTextAnnotationsFilePathObjectFilePath.FileId"/>
    public string FileId => InternalFilePath.FileId;

    [CodeGenMember("FilePath")]
    internal InternalMessageContentTextAnnotationsFilePathObjectFilePath InternalFilePath { get; set; }

    internal FilePathTextContentAnnotation(string text, InternalMessageContentTextAnnotationsFilePathObjectFilePath internalFilePath, int startIndex, int endIndex)
    {
        Argument.AssertNotNull(text, nameof(text));
        Argument.AssertNotNull(internalFilePath, nameof(internalFilePath));

        Type = "file_path";
        Text = text;
        InternalFilePath = internalFilePath;
        StartIndex = startIndex;
        EndIndex = endIndex;
    }
}