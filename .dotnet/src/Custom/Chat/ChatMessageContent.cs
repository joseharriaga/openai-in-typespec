using System;
using System.IO;

namespace OpenAI.Chat;

/// <summary>
/// Represents the common base type for a piece of message content used for chat completions.
/// </summary>
public partial class ChatMessageContent
{
    /// <summary>
    /// The type of message content data, e.g. text or image, that this <see cref="ChatMessageContent"/> instance
    /// represents.
    /// </summary>
    public ChatMessageContentKind ContentKind { get; }

    private object _contentValue;
    private string _contentMediaType;

    internal ChatMessageContent(object value, ChatMessageContentKind kind, string contentMediaType = null)
    {
        _contentValue = value;
        ContentKind = kind;
        _contentMediaType = contentMediaType;
    }

    /// <summary>
    /// Creates a new instance of <see cref="ChatMessageContent"/> that encapsulates text content.
    /// </summary>
    /// <param name="text"> The content for the new instance. </param>
    /// <returns> A new instance of <see cref="ChatMessageContent"/>. </returns>
    public static ChatMessageContent FromText(string text) => new(text, ChatMessageContentKind.Text);

    /// <summary>
    /// Creates a new instance of <see cref="ChatMessageContent"/> that encapsulates image content obtained from
    /// an internet location that will be accessible to the model when evaluating a message with this content.
    /// </summary>
    /// <remarks>
    /// Do not use this method for binary image data. Instead, use one of the suitable overloads:
    /// <list type="bullet">
    /// <item> <see cref="FromImage(Stream, string)"/></item>
    /// <item> <see cref="FromImage(BinaryData, string)"/></item>
    /// </list>
    /// </remarks>
    /// <param name="imageUri">
    ///     An internet location pointing to an image. This must be accessible to the model.
    /// </param>
    /// <returns> A new instance of <see cref="ChatMessageContent"/>. </returns>
    public static ChatMessageContent FromImage(Uri imageUri) => new(imageUri, ChatMessageContentKind.ImageLocation);

    /// <summary>
    /// Creates a new instance of <see cref="ChatMessageContent"/> that encapsulates image content in an accessible
    /// binary stream.
    /// </summary>
    /// <remarks>
    /// Together with the corresponding MIME type like<c> image/png</c> that describes the image data format, this will
    /// be automatically encoded as a base64-encoded <c>data:</c> URI upon request.
    /// </remarks>
    /// <param name="imageStream"> The readable stream containing the image data to use as content. </param>
    /// <param name="mediaType">
    /// The MIME descriptor, like <c>image/png</c>, corresponding to the image data format of the provided data. 
    /// </param>
    /// <returns> A new instance of <see cref="ChatMessageContent"/>. </returns>
    public static ChatMessageContent FromImage(Stream imageStream, string mediaType)
        => FromImage(BinaryData.FromStream(imageStream), mediaType);

    /// <summary>
    /// Creates a new instance of <see cref="ChatMessageContent"/> that encapsulates binary image content.
    /// </summary>
    /// <remarks>
    /// Together with the corresponding MIME type like<c> image/png</c> that describes the image data format, this will
    /// be automatically encoded as a base64-encoded <c>data:</c> URI upon request.
    /// </remarks>
    /// <param name="imageBytes"> The image data to use as content. </param>
    /// <param name="mediaType">
    /// The MIME descriptor, like <c>image/png</c>, corresponding to the image data format of the provided data. 
    /// </param>
    /// <returns> A new instance of <see cref="ChatMessageContent"/>. </returns>
    public static ChatMessageContent FromImage(BinaryData imageBytes, string mediaType)
        => new(imageBytes, ChatMessageContentKind.ImageData, mediaType);

    /// <summary>
    /// Provides the <see cref="string"/> representation of this content.
    /// </summary>
    /// <remarks>
    /// This method will throw if this content instance's <see cref="ChatMessageContentKind"/> does not support this
    /// representation.
    /// </remarks>
    /// <returns> The textual representation of the content item. </returns>
    /// <exception cref="InvalidOperationException"> The content does not support a Uri representation. </exception>
    public string ToText()
        => ContentKind switch
        {
            ChatMessageContentKind.Text => _contentValue?.ToString(),
            _ => throw new InvalidOperationException(
                $"{nameof(ToText)} conversion not supported for content kind: {ContentKind}"),
        };

    /// <summary>
    /// Provides the <see cref="Uri"/> representation of this content.
    /// </summary>
    /// <remarks>
    /// This method will throw if this content instance's <see cref="ChatMessageContentKind"/> does not support this
    /// representation.
    /// </remarks>
    /// <returns> The binary representation of the content item. </returns>
    /// <exception cref="InvalidOperationException"> The content does not support a Uri representation. </exception>
    public Uri ToUri()
        => ContentKind switch
        {
            ChatMessageContentKind.ImageLocation => _contentValue switch
            {
                Uri imageUri => imageUri,
                _ => throw new InvalidOperationException(
                    $"Cannot convert underlying image data type '{_contentValue?.GetType()}' to a {nameof(Uri)}"),
            },
            _ => throw new InvalidOperationException(
                $"{nameof(ToText)} conversion not supported for content kind: {ContentKind}"),
        };

    /// <summary>
    /// Provides the <see cref="BinaryData"/> representation of this content.
    /// </summary>
    /// <remarks>
    /// This method will throw if this content instance's <see cref="ChatMessageContentKind"/> does not support this
    /// representation.
    /// </remarks>
    /// <returns> The BinaryData for the content item. </returns>
    /// <exception cref="InvalidOperationException"> The content does not support a BinaryData representation. </exception>
    public BinaryData ToBinaryData()
        => ContentKind switch
        {
            ChatMessageContentKind.ImageData => _contentValue switch
            {
                BinaryData binaryData => binaryData,
                _ => throw new InvalidOperationException(
                    $"Cannot convert underlying image data type '{_contentValue?.GetType()}' to  {nameof(BinaryData)}"),
            },
            _ => throw new InvalidOperationException(
                $"{nameof(ToBinaryData)} conversion not supported for content kind: {ContentKind}"),
        };

    /// <summary>
    /// The implicit conversion operator that infers an equivalent <see cref="ChatMessageContent"/> instance from
    /// a plain <see cref="string"/>.
    /// </summary>
    /// <param name="value"> The text for the message content. </param>
    public static implicit operator ChatMessageContent(string value) => FromText(value);

    /// <summary>
    /// An explicit operator allowing a content item to be treated as a string.
    /// </summary>
    /// <param name="content"></param>
    public static explicit operator string(ChatMessageContent content) => content.ToText();

    /// <summary>
    /// An explicit operator allowing a content item to be treated as a URI.
    /// </summary>
    /// <param name="content"></param>
    public static explicit operator Uri(ChatMessageContent content) => content.ToUri();

    /// <summary>
    /// An explicit operator allowing a content item to be treated as a BinaryData instance.
    /// </summary>
    public static explicit operator BinaryData(ChatMessageContent content) => content.ToBinaryData();

    /// <inheritdoc/>
    public override string ToString()
    {
        if (ContentKind == ChatMessageContentKind.Text)
        {
            return ToText();
        }
        return base.ToString();
    }

    internal string ToBase64DataString()
    {
        BinaryData imageData = _contentValue as BinaryData;
        string base64ImageData = Convert.ToBase64String(imageData.ToArray());
        return $"data:{_contentMediaType};base64,{base64ImageData}";
    }
}
