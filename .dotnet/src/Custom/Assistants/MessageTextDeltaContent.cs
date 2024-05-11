using System;
using System.Collections.Generic;
using OpenAI.Internal.Models;

namespace OpenAI.Assistants;

[CodeGenModel("MessageDeltaContentTextObject")]
public partial class MessageTextDeltaContent
{
    public string Text => InternalText.Value;
    public IReadOnlyList<MessageDeltaTextContentAnnotation> Annotations => InternalText.Annotations;

    [CodeGenMember("Type")]
    private string InternalType { get; }

    [CodeGenMember("Text")]
    internal InternalMessageDeltaContentTextObjectText InternalText { get; }
}
