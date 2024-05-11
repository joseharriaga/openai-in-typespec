using System;

namespace OpenAI.Assistants;

/// <summary>
/// Represents an item of text content within an Assistants API message.
/// </summary>
/// <remarks>
/// Use the <see cref="MessageContent.FromText(string)"/> method to create an instance of this
/// type.
/// </remarks>
[CodeGenModel("MessageRequestContentTextObject")]
public partial class RequestMessageTextContent
{
    [CodeGenMember("Type")]
    private string InternalType { get; } = "text";

    /// <summary> Initializes a new instance of <see cref="RequestMessageTextContent"/>. </summary>
    /// <param name="text"> Text content to be sent to the model. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="text"/> is null. </exception>
    internal RequestMessageTextContent(string text)
        : this()
    {
        Argument.AssertNotNull(text, nameof(text));

        Text = text;
    }
}
