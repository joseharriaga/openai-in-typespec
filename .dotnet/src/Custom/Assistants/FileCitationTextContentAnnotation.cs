using OpenAI.Internal.Models;

namespace OpenAI.Assistants;

[CodeGenModel("MessageContentTextAnnotationsFileCitationObject")]
public partial class FileCitationTextContentAnnotation
{
    /// <inheritdoc cref="InternalMessageContentTextAnnotationsFileCitationObjectFileCitation.FileId"/>
    public string FileId => _internalFileCitation.FileId;

    /// <inheritdoc cref="InternalMessageContentTextAnnotationsFileCitationObjectFileCitation.Quote"/>
    public string Quote => _internalFileCitation.Quote;

    [CodeGenMember("FileCitation")]
    internal InternalMessageContentTextAnnotationsFileCitationObjectFileCitation _internalFileCitation;

    internal FileCitationTextContentAnnotation(string text, InternalMessageContentTextAnnotationsFileCitationObjectFileCitation internalFileCitation, int startIndex, int endIndex)
    {
        Argument.AssertNotNull(text, nameof(text));
        Argument.AssertNotNull(internalFileCitation, nameof(internalFileCitation));

        Type = "file_citation";
        Text = text;
        _internalFileCitation = internalFileCitation;
        StartIndex = startIndex;
        EndIndex = endIndex;
    }
}
