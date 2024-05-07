namespace OpenAI.Chat;

/// <summary>
/// Represents the possibles of underlying data for a chat message's <c>content</c> property.
/// </summary>
public enum ChatMessageContentKind
{
    /// <summary>
    /// Plain text content, represented as a <see cref="string"/>.
    /// </summary>
    /// <remarks>
    /// Content of this type may be retrieved via <see cref="ChatMessageContent.ToText"/>.
    /// </remarks>
    Text,
    /// <summary>
    /// Binary image information from a stream or other caller-accessible source.
    /// </summary>
    /// <remarks>
    /// Content of this type may be retrieved via <see cref="ChatMessageContent.ToBinaryData"/>.
    /// </remarks>
    ImageData,
    /// <summary>
    /// A model-accessible internet location for an image.
    /// </summary>
    /// <remarks>
    /// Content of this type may be retrieved via <see cref="ChatMessageContent.ToUri"/>.
    /// </remarks>
    ImageLocation,
    // Audio,
    // Video,
}