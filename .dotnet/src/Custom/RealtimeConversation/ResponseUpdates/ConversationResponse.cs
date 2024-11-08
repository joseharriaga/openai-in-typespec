using System;
using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;

namespace OpenAI.RealtimeConversation;

[Experimental("OPENAI002")]
[CodeGenModel("RealtimeResponseCommand")]
public partial class ConversationResponse
{
    [CodeGenMember("Kind")]
    public ConversationResponseKind Kind { get; internal protected set; }

    public BinaryData GetRawContent() => ModelReaderWriter.Write(this);
}