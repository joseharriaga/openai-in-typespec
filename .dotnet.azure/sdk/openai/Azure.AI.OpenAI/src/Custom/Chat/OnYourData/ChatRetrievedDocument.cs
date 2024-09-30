using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.OpenAI.Chat;

[CodeGenModel("AzureChatMessageContextAllRetrievedDocuments")]
[Experimental("AOAI001")]
public partial class ChatRetrievedDocument
{
    [CodeGenMember("Filepath")]
    /// <summary> The file path for the citation. </summary>
    public string FilePath { get; }

    [CodeGenMember("Url")]
    /// <summary> The location of the citation. </summary>
    public Uri Uri { get; }
}
