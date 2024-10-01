using System;
using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;

namespace OpenAI.RealtimeConversation;

[Experimental("OPENAI002")]
[CodeGenModel("RealtimeResponseCommand")]
public partial class ConversationUpdate
{
    [CodeGenMember("Type")]
    public ConversationUpdateKind Type { get; set; }

    public BinaryData GetRawContent() => ModelReaderWriter.Write(this);
}