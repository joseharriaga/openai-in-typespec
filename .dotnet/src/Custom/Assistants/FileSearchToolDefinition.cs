using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace OpenAI.Assistants;

[CodeGenModel("AssistantToolsFileSearch")]
[CodeGenSuppress(nameof(FileSearchToolDefinition))]
public partial class FileSearchToolDefinition : ToolDefinition
{
    public int? MaxResults
    {
        get => _fileSearch.InternalMaxNumResults;
        init => _fileSearch.InternalMaxNumResults = value;
    }

    public FileSearchToolDefinition(int? maxResults = null)
        : this("file_search", new ChangeTrackingDictionary<string, BinaryData>(), new InternalAssistantToolsFileSearchFileSearch())
    {
        _fileSearch.InternalMaxNumResults = maxResults;
    }

    [CodeGenMember("FileSearch")]
    private InternalAssistantToolsFileSearchFileSearch _fileSearch;
}
