using System;

namespace OpenAI.Assistants;

[CodeGenModel("MessageContent")]
public abstract partial class MessageContent
{
    public static MessageImageFileContent FromImageFile(
        string imageFileId,
        MessageImageDetail? detail = null)
            => new(imageFileId, detail);

    public static MessageImageUrlContent FromImageUrl(Uri imageUri, MessageImageDetail? detail = null)
        => new(imageUri, detail);

    public static RequestMessageTextContent FromText(string text)
        => new(text);

    /// <summary>
    /// The implicit conversion operator that infers an equivalent <see cref="MessageContent"/> 
    /// instance from a plain <see cref="string"/>.
    /// </summary>
    /// <param name="value"> The text for the message content. </param>
    public static implicit operator MessageContent(string value) => FromText(value);

}
