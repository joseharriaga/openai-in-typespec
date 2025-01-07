using System;
using System.Collections.Generic;

namespace OpenAI.Chat;

/// <summary>
///     A part of the chat message content.
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
    private readonly ChatMessageContentPartKind _kind;
    private readonly string _text;
    private readonly InternalChatCompletionRequestMessageContentPartImageImageUrl _imageUri;
    private readonly InternalChatCompletionRequestMessageContentPartAudioInputAudio _inputAudio;
    private readonly InternalChatCompletionResponseMessageAudio _outputAudio;
    private readonly InternalChatCompletionMessageAudioChunk _responseAudioUpdate;
    private readonly InternalChatCompletionRequestAssistantMessageAudio _audioReference;
    private readonly string _refusal;

    // CUSTOM: Made internal.
    internal ChatMessageContentPart()
    {
    }

    // CUSTOM: Added to support deserialization.
    internal ChatMessageContentPart(
        ChatMessageContentPartKind kind,
        string text = default,
        InternalChatCompletionRequestMessageContentPartImageImageUrl imageUri = default,
        string refusal = default,
        InternalChatCompletionRequestMessageContentPartAudioInputAudio inputAudio = default,
        InternalChatCompletionResponseMessageAudio outputAudio = default,
        InternalChatCompletionMessageAudioChunk responseAudioUpdate = default,
        InternalChatCompletionRequestAssistantMessageAudio audioReference = default,
        IDictionary<string, BinaryData> serializedAdditionalRawData = default)
    {
        _kind = kind;
        _text = text;
        _imageUri = imageUri;
        _refusal = refusal;
        _inputAudio = inputAudio;
        _outputAudio = outputAudio;
        _responseAudioUpdate = responseAudioUpdate;
        _audioReference = audioReference;
        _additionalBinaryDataProperties = serializedAdditionalRawData;
    }

    /// <summary> The kind of content part. </summary>
    public ChatMessageContentPartKind Kind => _kind;

    // CUSTOM: Spread.
    /// <summary> The text. </summary>
    /// <remarks> Present when <see cref="Kind"/> is <see cref="ChatMessageContentPartKind.Text"/>. </remarks>
    public string Text => _text;

    // CUSTOM: Spread.
    /// <summary> The public internet URI where the image is located. </summary>
    /// <remarks> Present when <see cref="Kind"/> is <see cref="ChatMessageContentPartKind.Image"/>. </remarks>
    public Uri ImageUri => _imageUri?.ImageUri;

    // CUSTOM: Spread.
    /// <summary> The image bytes. </summary>
    /// <remarks> Present when <see cref="Kind"/> is <see cref="ChatMessageContentPartKind.Image"/>. </remarks>
    public BinaryData ImageBytes => _imageUri?.ImageBytes;

    // CUSTOM: Spread.
    /// <summary> The MIME type of the image, e.g., <c>image/png</c>. </summary>
    /// <remarks> Present when <see cref="Kind"/> is <see cref="ChatMessageContentPartKind.Image"/>. </remarks>
    public string ImageBytesMediaType => _imageUri?.ImageBytesMediaType;

    /// <summary>
    /// The encoded binary audio payload associated with the content part.
    /// </summary>
    /// <remarks>
    /// Present when <see cref="Kind"/> is <see cref="ChatMessageContentPartKind.Audio"/> and the content part
    /// represents user role audio input or response audio content from the model.
    /// <para>
    /// When streaming, this value represents the latest incremental audio update.
    /// </para>
    /// </remarks>
    public BinaryData AudioBytes => _inputAudio?.Data ?? _outputAudio?.Data ?? _responseAudioUpdate?.Data;

    /// <summary>
    /// The encoding format that the audio data provided in <see cref="AudioBytes"/> should be interpreted with.
    /// </summary>
    /// <remarks>
    /// Present when <see cref="Kind"/> is <see cref="ChatMessageContentPartKind.Audio"/> and the content part
    /// represents user role audio input.
    /// </remarks>
    public ChatInputAudioFormat? AudioInputFormat => _inputAudio?.Format;

    /// <summary>
    /// The unique identifier, as provided with model-generated response audio, that may be supplied as assistant
    /// conversation history.
    /// </summary>
    /// <remarks>
    /// Present when <see cref="Kind"/> is <see cref="ChatMessageContentPartKind.Audio"/> and the content part
    /// represents response audio from the service or assistant role historical audio input.
    /// </remarks>
    public string AudioCorrelationId => _audioReference?.Id ?? _outputAudio?.Id ?? _responseAudioUpdate?.Id;

    /// <summary>
    /// The timestamp after which the audio associated with <see cref="AudioCorrelationId"/> is no longer available.
    /// </summary>
    /// <remarks>
    /// Present when <see cref="Kind"/> is <see cref="ChatMessageContentPartKind.Audio"/> and the content part
    /// represents response audio from the service.
    /// </remarks>
    public DateTimeOffset? AudioExpiresAt => _outputAudio?.ExpiresAt ?? _responseAudioUpdate?.ExpiresAt;

    /// <summary>
    /// The transcript that approximates the content of the audio provided by <see cref="AudioBytes"/>.
    /// </summary>
    /// <remarks>
    /// Present when <see cref="Kind"/> is <see cref="ChatMessageContentPartKind.Audio"/> and the content part
    /// represents response audio from the service.
    /// <para>
    /// When streaming, this value represents the latest transcript update.
    /// </para>
    /// </remarks>
    public string AudioTranscript => _outputAudio?.Transcript ?? _responseAudioUpdate?.Transcript;

    // CUSTOM: Spread.
    /// <summary>
    ///     The level of detail with which the model should process the image and generate its textual understanding of
    ///     it. Learn more in the <see href="https://platform.openai.com/docs/guides/vision/low-or-high-fidelity-image-understanding">vision guide</see>.
    /// </summary>
    /// <remarks> Present when <see cref="Kind"/> is <see cref="ChatMessageContentPartKind.Image"/>. </remarks>
    public ChatImageDetailLevel? ImageDetailLevel => _imageUri?.Detail;

    // CUSTOM: Spread.
    /// <summary> The refusal message generated by the model. </summary>
    /// <remarks> Present when <see cref="Kind"/> is <see cref="ChatMessageContentPartKind.Refusal"/>. </remarks>
    public string Refusal => _refusal;

    /// <summary> Creates a new <see cref="ChatMessageContentPart"/> that encapsulates text. </summary>
    /// <param name="text"> The text. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="text"/> is null. </exception>
    public static ChatMessageContentPart CreateTextPart(string text)
    {
        Argument.AssertNotNull(text, nameof(text));

        return new ChatMessageContentPart(ChatMessageContentPartKind.Text, text: text);
    }

    /// <summary> Creates a new <see cref="ChatMessageContentPart"/> that encapsulates an image. </summary>
    /// <param name="imageUri"> The public internet URI where the image is located. </param>
    /// <param name="imageDetailLevel">
    ///     The level of detail with which the model should process the image and generate its textual understanding of
    ///     it. Learn more in the <see href="https://platform.openai.com/docs/guides/vision/low-or-high-fidelity-image-understanding">vision guide</see>.
    /// </param>
    /// <exception cref="ArgumentNullException"> <paramref name="imageUri"/> is null. </exception>
    public static ChatMessageContentPart CreateImagePart(Uri imageUri, ChatImageDetailLevel? imageDetailLevel = null)
    {
        Argument.AssertNotNull(imageUri, nameof(imageUri));

        return new ChatMessageContentPart(
            kind: ChatMessageContentPartKind.Image,
            imageUri: new(imageUri) { Detail = imageDetailLevel });
    }

    /// <summary> Creates a new <see cref="ChatMessageContentPart"/> that encapsulates an image. </summary>
    /// <param name="imageBytes"> The image bytes. </param>
    /// <param name="imageBytesMediaType"> The MIME type of the image, e.g., <c>image/png</c>. </param>
    /// <param name="imageDetailLevel">
    ///     The level of detail with which the model should process the image and generate its textual understanding of
    ///     it. Learn more in the <see href="https://platform.openai.com/docs/guides/vision/low-or-high-fidelity-image-understanding">vision guide</see>.
    /// </param>
    /// <exception cref="ArgumentNullException"> <paramref name="imageBytes"/> or <paramref name="imageBytesMediaType"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="imageBytesMediaType"/> is an empty string, and was expected to be non-empty. </exception>
    public static ChatMessageContentPart CreateImagePart(BinaryData imageBytes, string imageBytesMediaType, ChatImageDetailLevel? imageDetailLevel = null)
    {
        Argument.AssertNotNull(imageBytes, nameof(imageBytes));
        Argument.AssertNotNullOrEmpty(imageBytesMediaType, nameof(imageBytesMediaType));

        return new ChatMessageContentPart(
            kind: ChatMessageContentPartKind.Image,
            imageUri: new(imageBytes, imageBytesMediaType) { Detail = imageDetailLevel });
    }

    /// <summary> Creates a new <see cref="ChatMessageContentPart"/> that encapsulates a refusal coming from the model. </summary>
    /// <param name="refusal"> The refusal message generated by the model. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="refusal"/> is null. </exception>
    public static ChatMessageContentPart CreateRefusalPart(string refusal)
    {
        Argument.AssertNotNull(refusal, nameof(refusal));

        return new ChatMessageContentPart(
            kind: ChatMessageContentPartKind.Refusal,
            refusal: refusal);
    }

    /// <summary> Creates a new <see cref="ChatMessageContentPart"/> that encapsulates user role input audio in a known format. </summary>
    /// <remarks>
    /// Binary audio content parts may only be used with <see cref="UserChatMessage"/> instances to represent user audio input. When referring to
    /// past audio output from the model, use <see cref="CreateAudioPart(string)"/> instead.
    /// </remarks>
    /// <param name="audioBytes"> The audio data. </param>
    /// <param name="audioFormat"> The format of the audio data. </param>
    public static ChatMessageContentPart CreateAudioPart(BinaryData audioBytes, ChatInputAudioFormat audioFormat)
    {
        Argument.AssertNotNull(audioBytes, nameof(audioBytes));

        return new ChatMessageContentPart(
            kind: ChatMessageContentPartKind.Audio,
            inputAudio: new(audioBytes, audioFormat));
    }

    /// <summary> Creates a new <see cref="ChatMessageContentPart"/> that encapsulates an ID-based reference to earlier response audio provided by the model. </summary>
    /// <remarks>
    /// Reference-based audio content parts are used with <see cref="AssistantChatMessage"/> instances to represent historical audio output from the model. When providing
    /// user audio input, use <see cref="CreateAudioPart(BinaryData, ChatInputAudioFormat)"/> instead.
    /// </remarks>
    /// <param name="audioCorrelationId"> The unique identifier associated with the audio. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="audioCorrelationId"/> is null. </exception>
    public static ChatMessageContentPart CreateAudioPart(string audioCorrelationId)
    {
        Argument.AssertNotNull(audioCorrelationId, nameof(audioCorrelationId));

        return new(
            kind: ChatMessageContentPartKind.Audio,
            audioReference: new InternalChatCompletionRequestAssistantMessageAudio(audioCorrelationId, null));
    }

    /// <summary>
    ///     Implicitly intantiates a new <see cref="ChatMessageContentPart"/> from a <see cref="string"/>. As such,
    ///     using a <see cref="string"/> in place of a <see cref="ChatMessageContentPart"/> is equivalent to calling the
    ///     <see cref="CreateTextPart(string)"/> method.
    /// </summary>
    /// <param name="text"> The text encapsulated by this <see cref="ChatMessageContentPart"/>. </param>
    public static implicit operator ChatMessageContentPart(string text) => CreateTextPart(text);

    /// <summary>
    /// Gets a value indicating whether this content part is contrived, in which case it does not represent a valid
    /// member of a JSON content array within a REST body.
    /// </summary>
    internal bool IsContrived
    {
        get
        {
            // Audio content parts representing ID-based references or response audio are synthesized from dedicated
            // "audio" JSON properties.
            if (_kind == ChatMessageContentPartKind.Audio && _inputAudio is null)
            {
                return true;
            }
            return false;
        }
    }
}
