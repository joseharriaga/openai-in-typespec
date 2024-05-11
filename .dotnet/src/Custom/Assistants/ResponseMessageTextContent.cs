using OpenAI.Internal.Models;
using System.Collections.Generic;

namespace OpenAI.Assistants;

/// <summary>
/// Represents an item of annotated text content within an Assistants API response message.
/// </summary>
[CodeGenModel("MessageContentTextObject")]
public partial class ResponseMessageTextContent
{
    public string Text => InternalText.Value;

    public IList<MessageTextContentAnnotation> Annotations => InternalText.Annotations;

    [CodeGenMember("Type")]
    private string InternalType { get; }

    [CodeGenMember("Text")]
    internal InternalMessageContentTextObjectText InternalText { get; set; }

    /// <summary> Initializes a new instance of <see cref="ResponseMessageTextContent"/>. </summary>
    /// <param name="internalText"></param>
    /// <exception cref="ArgumentNullException"> <paramref name="internalText"/> is null. </exception>
    internal ResponseMessageTextContent(InternalMessageContentTextObjectText internalText)
    {
        Argument.AssertNotNull(internalText, nameof(internalText));

        InternalText = internalText;
    }

    public override string ToString() => Text;
}
