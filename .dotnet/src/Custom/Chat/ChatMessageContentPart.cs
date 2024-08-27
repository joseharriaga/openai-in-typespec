using System;
using System.Collections.Generic;

namespace OpenAI.Chat;

/// <summary>
///     A part of the <see cref="ChatMessageContent"/>.
///     <list>
///         <item>
///             Call <see cref="CreateTextPart(string)"/> to create a <see cref="ChatMessageContentPart"/> that
///             encapsulates text.
///         </item>
///         <item>
///             Call <see cref="CreateImagePart(Uri, ChatImageDetailLevel?)"/> or
///             <see cref="CreateImagePart(BinaryData, string, OpenAI.Chat.ChatImageDetailLevel?)"/> to create a
///             <see cref="ChatMessageContentPart"/> that encapsulates an image.
///         </item>
///         <item>
///             Call <see cref="CreateRefusalPart(string)"/> to create a <see cref="ChatMessageContentPart"/> that
///             encapsulates a refusal coming from the model.
///         </item>
///     </list>
/// </summary>
[CodeGenModel("ChatMessageContentPart")]
[CodeGenSuppress("ChatMessageContentPart", typeof(IDictionary<string, BinaryData>))]
public partial class ChatMessageContentPart
{
    internal ChatMessageContentPartKind _kind;
    internal string _text;
    internal InternalChatCompletionRequestMessageContentPartImageImageUrl _imageUrl;
    internal string _refusal;

    // CUSTOM: Made internal.
    internal ChatMessageContentPart()
    {
    }

    // CUSTOM: Added to support deserialization.
    internal ChatMessageContentPart(string kind, string text, InternalChatCompletionRequestMessageContentPartImageImageUrl imageUrl, string refusal, IDictionary<string, BinaryData> serializedAdditionalRawData)
    {
        _kind = new ChatMessageContentPartKind(kind);
        _text = text;
        _imageUrl = imageUrl;
        _refusal = refusal;
        SerializedAdditionalRawData = serializedAdditionalRawData;
    }

    /// <summary> The content part kind. </summary>
    public ChatMessageContentPartKind Kind => _kind;

    /// <summary> The text. </summary>
    /// <remarks> Present when <see cref="Kind"/> is <see cref="ChatMessageContentPartKind.Text"/>. </remarks>
    public string Text => _text;

    /// <summary> The public internet URI where the image is located. </summary>
    /// <remarks> Present when <see cref="Kind"/> is <see cref="ChatMessageContentPartKind.Image"/>. </remarks>
    public Uri ImageUri => _imageUrl?.ImageUri;

    /// <summary> The image bytes. </summary>
    /// <remarks> Present when <see cref="Kind"/> is <see cref="ChatMessageContentPartKind.Image"/>. </remarks>
    public BinaryData ImageBytes => _imageUrl?.ImageBytes;

    /// <summary> The MIME type of the image, e.g., <c>image/png</c>. </summary>
    /// <remarks> Present when <see cref="Kind"/> is <see cref="ChatMessageContentPartKind.Image"/>. </remarks>
    public string ImageBytesMediaType => _imageUrl?.ImageBytesMediaType;

    /// <summary>
    ///     The level of detail with which the model should process the image and generate its textual understanding of
    ///     it. Learn more in the <see href="https://platform.openai.com/docs/guides/vision/low-or-high-fidelity-image-understanding">vision guide</see>.
    /// </summary>
    /// <remarks> Present when <see cref="Kind"/> is <see cref="ChatMessageContentPartKind.Image"/>. </remarks>
    public ChatImageDetailLevel? ImageDetailLevel => _imageUrl?.Detail;

    /// <summary> The refusal message generated by the model. </summary>
    /// <remarks> Present when <see cref="Kind"/> is <see cref="ChatMessageContentPartKind.Refusal"/>. </remarks>
    public string Refusal => _refusal;

    /// <summary> Creates a new <see cref="ChatMessageContentPart"/> that encapsulates text. </summary>
    /// <param name="text"> The text. </param>
    public static ChatMessageContentPart CreateTextPart(string text)
    {
        Argument.AssertNotNull(text, nameof(text));

        return new()
        {
            _kind = ChatMessageContentPartKind.Text,
            _text = text
        };
    }

    /// <summary> Creates a new <see cref="ChatMessageContentPart"/> that encapsulates an image. </summary>
    /// <param name="imageUri"> The public internet URI where the image is located. </param>
    /// <param name="imageDetailLevel">
    ///     The level of detail with which the model should process the image and generate its textual understanding of
    ///     it. Learn more in the <see href="https://platform.openai.com/docs/guides/vision/low-or-high-fidelity-image-understanding">vision guide</see>.
    /// </param>
    public static ChatMessageContentPart CreateImagePart(Uri imageUri, ChatImageDetailLevel? imageDetailLevel = null)
    {
        Argument.AssertNotNull(imageUri, nameof(imageUri));

        return new()
        {
            _kind = ChatMessageContentPartKind.Image,
            _imageUrl = new(imageUri) { Detail = imageDetailLevel }
        };
    }

    /// <summary> Creates a new <see cref="ChatMessageContentPart"/> that encapsulates an image. </summary>
    /// <param name="imageBytes"> The image bytes. </param>
    /// <param name="imageBytesMediaType"> The MIME type of the image, e.g., <c>image/png</c>. </param>
    /// <param name="imageDetailLevel">
    ///     The level of detail with which the model should process the image and generate its textual understanding of
    ///     it. Learn more in the <see href="https://platform.openai.com/docs/guides/vision/low-or-high-fidelity-image-understanding">vision guide</see>.
    /// </param>
    public static ChatMessageContentPart CreateImagePart(BinaryData imageBytes, string imageBytesMediaType, ChatImageDetailLevel? imageDetailLevel = null)
    {
        Argument.AssertNotNull(imageBytes, nameof(imageBytes));
        Argument.AssertNotNull(imageBytesMediaType, nameof(imageBytesMediaType));

        return new()
        {
            _kind = ChatMessageContentPartKind.Image,
            _imageUrl = new(imageBytes, imageBytesMediaType) { Detail = imageDetailLevel }
        };
    }

    /// <summary> Creates a new <see cref="ChatMessageContentPart"/> that encapsulates a refusal coming from the model. </summary>
    /// <param name="refusal"> The refusal message generated by the model. </param>
    public static ChatMessageContentPart CreateRefusalPart(string refusal)
    {
        Argument.AssertNotNull(refusal, nameof(refusal));

        return new()
        {
            _kind = ChatMessageContentPartKind.Refusal,
            _refusal = refusal
        };
    }

    /// <summary>
    ///     Implicitly intantiates a new <see cref="ChatMessageContentPart"/> from a <see cref="string"/>. As such,
    ///     using a <see cref="string"/> in place of a <see cref="ChatMessageContentPart"/> is equivalent to calling the
    ///     <see cref="CreateTextPart(string)"/> method.
    /// </summary>
    /// <param name="text"> The text encapsulated by this <see cref="ChatMessageContentPart"/>. </param>
    public static implicit operator ChatMessageContentPart(string text) => CreateTextPart(text);
}
