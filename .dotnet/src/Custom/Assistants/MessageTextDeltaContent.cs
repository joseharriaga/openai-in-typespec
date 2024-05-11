using System;
using OpenAI.Internal.Models;

namespace OpenAI.Assistants;

[CodeGenModel("MessageDeltaContentTextObject")]
public partial class MessageTextDeltaContent
{
    public string Text => InternalText.Value;
    public object Annotations => InternalText.Annotations;

    [CodeGenMember("Type")]
    private string InternalType { get; }

    [CodeGenMember("Text")]
    internal InternalMessageDeltaContentTextObjectText InternalText { get; }
}
