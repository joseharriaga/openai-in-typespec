using OpenAI.Internal.Models;
using System.Collections.Generic;

namespace OpenAI.Assistants;

[CodeGenModel("MessageDeltaContentTextObject")]
public partial class MessageTextDeltaContent
{
    [CodeGenMember("Type")]
    private string _type;

    [CodeGenMember("Text")]
    internal InternalMessageDeltaContentTextObjectText _text;

    /// <inheritdoc cref="InternalMessageDeltaContentTextObjectText.Value"/>
    public string Text => _text.Value;
    /// <inheritdoc cref="InternalMessageDeltaContentTextObjectText.Annotations"/>
    public IReadOnlyList<MessageDeltaTextContentAnnotation> Annotations => _text.Annotations;
}
