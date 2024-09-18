using System;
using System.Collections.Generic;

namespace Azure.AI.OpenAI.Chat;

[CodeGenModel("AzureChatMessageContextCitation")]
public partial class ChatCitation
{
    /// <summary> The location of the citation. </summary>
    [CodeGenMember("Url")]
    public Uri Uri { get; }
    /// <summary> The file path for the citation. </summary>
    [CodeGenMember("Filepath")]
    public string FilePath { get; }
}
