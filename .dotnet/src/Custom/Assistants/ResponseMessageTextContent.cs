using OpenAI.Internal.Models;
using System.Collections.Generic;

namespace OpenAI.Assistants;

/// <summary>
/// Represents an item of annotated text content within an Assistants API response message.
/// </summary>
[CodeGenModel("MessageContentTextObject")]
public partial class ResponseMessageTextContent
{
    /// <inheritdoc cref="MessageContentTextObjectText.Value"/>
    public string Text => _text.Value;

    public IReadOnlyList<MessageTextContentAnnotation> Annotations => _annotations ??= WrapAnnotations();

    [CodeGenMember("Type")]
    private readonly string _type;

    [CodeGenMember("Text")]
    private readonly MessageContentTextObjectText _text;

    private IReadOnlyList<MessageTextContentAnnotation> _annotations;

    /// <summary> Initializes a new instance of <see cref="ResponseMessageTextContent"/>. </summary>
    /// <param name="internalText"></param>
    /// <exception cref="ArgumentNullException"> <paramref name="internalText"/> is null. </exception>
    internal ResponseMessageTextContent(MessageContentTextObjectText internalText)
    {
        Argument.AssertNotNull(internalText, nameof(internalText));

        _text = internalText;
    }

    public override string ToString() => Text;

    private IReadOnlyList<MessageTextContentAnnotation> WrapAnnotations()
    {
        List<MessageTextContentAnnotation> annotations = [];
        foreach (MessageContentTextObjectAnnotation internalAnnotation in _text?.Annotations ?? [])
        {
            annotations.Add(new(internalAnnotation));
        }
        return annotations;
    }
}
