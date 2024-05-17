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
internal partial class InternalRequestMessageTextContent
{
    [CodeGenMember("Type")]
    private string InternalType { get; } = "text";

    [CodeGenMember("Text")]
    internal string InternalText { get; }
}
