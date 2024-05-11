using OpenAI.Internal.Models;

namespace OpenAI.Assistants;

[CodeGenModel("CreateAssistantRequestToolResources")]
public partial class ToolResourceDefinitions { }

[CodeGenModel("CreateAssistantRequestToolResourcesCodeInterpreter")]
public partial class CodeInterpreterToolResourceDefinitions { }

[CodeGenModel("CreateAssistantRequestToolResourcesFileSearch")]
public partial class FileSearchToolResourceDefinitions { }

[CodeGenModel("AssistantObjectToolResourcesCodeInterpreter")]
public partial class AssistantCodeInterpreterToolResources { }

[CodeGenModel("AssistantObjectToolResources")]
public partial class AssistantToolResources { }

[CodeGenModel("AssistantObjectToolResourcesFileSearch")]
public partial class AssistantFileSearchToolResources { }

[CodeGenModel("ThreadMessageStatus")]
public readonly partial struct MessageStatus { }

[CodeGenModel("MessageObjectIncompleteDetails")]
public partial class MessageFailureDetails { }

[CodeGenModel("MessageFailureDetailsReason")]
public readonly partial struct MessageFailureReason { }

[CodeGenModel("RunCompletionUsage")]
public partial class RunTokenUsage { }

[CodeGenModel("ThreadRunStatus")]
public readonly partial struct RunStatus { }

[CodeGenModel("MessageTextContentAnnotation")]
public partial class MessageTextContentAnnotation { }

[CodeGenModel("MessageDeltaTextContentAnnotation")]
public partial class MessageDeltaTextContentAnnotation { }

[CodeGenModel("MessageContentTextAnnotationsFileCitationObject")]
public partial class FileCitationTextContentAnnotation
{
    [CodeGenMember("FileCitation")]
    internal InternalMessageContentTextAnnotationsFileCitationObjectFileCitation InternalFileCitation { get; set; }

    internal FileCitationTextContentAnnotation(string text, InternalMessageContentTextAnnotationsFileCitationObjectFileCitation internalFileCitation, int startIndex, int endIndex)
    {
        Argument.AssertNotNull(text, nameof(text));
        Argument.AssertNotNull(internalFileCitation, nameof(internalFileCitation));

        Type = "file_citation";
        Text = text;
        InternalFileCitation = internalFileCitation;
        StartIndex = startIndex;
        EndIndex = endIndex;
    }
}

[CodeGenModel("MessageDeltaContentTextAnnotationsFileCitationObject")]
public partial class FileCitationTextDeltaContentAnnotation
{
    [CodeGenMember("FileCitation")]
    internal InternalMessageDeltaContentTextAnnotationsFileCitationObjectFileCitation InternalFileCitation { get; set; }
}

[CodeGenModel("MessageContentTextAnnotationsFilePathObject")]
public partial class FilePathTextContentAnnotation
{
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

[CodeGenModel("MessageDeltaContentTextAnnotationsFilePathObject")]
public partial class FilePathTextDeltaContentAnnotation
{
    [CodeGenMember("FilePath")]
    internal InternalMessageDeltaContentTextAnnotationsFilePathObjectFilePath InternalFilePath { get; set; }
}


