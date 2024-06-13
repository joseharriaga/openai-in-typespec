using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Assistants;

/// <summary>
/// Represents a streaming update to <see cref="ThreadMessage"/> content as part of the Assistants API.
/// </summary>
/// <remarks>
/// Distinct <see cref="MessageContentUpdate"/> instances will be generated for each <see cref="MessageContent"/> part
/// and each content subcomponent, such as <see cref="TextAnnotationUpdate"/> instances, even if this information
/// arrived in the same response chunk.
/// </remarks>
public partial class MessageContentUpdate : StreamingUpdate
{
    /// <inheritdoc cref="MessageDeltaObject.Id"/>
    public string MessageId => _delta.Id;

    /// <inheritdoc cref="MessageDeltaContentImageFileObject.Index"/>
    public int MessageIndex => _textContent?.Index
        ?? _imageFileContent?.Index
        ?? _imageUrlContent?.Index
        ?? TextAnnotation?.ContentIndex
        ?? 0;

    /// <inheritdoc cref="MessageDeltaObjectDelta.Role"/>
    public MessageRole? Role => _delta.Delta?.Role;

    /// <inheritdoc cref="MessageDeltaContentImageFileObjectImageFile.FileId"/>
    public string ImageFileId => _imageFileContent?.ImageFile?.FileId;

    /// <inheritdoc cref="MessageImageDetail"/>
    public MessageImageDetail? ImageDetail => _imageFileContent?.ImageFile?.Detail?.ToMessageImageDetail()
        ?? _imageUrlContent?.ImageUrl?.Detail?.ToMessageImageDetail();

    /// <inheritdoc cref="MessageDeltaContentTextObjectText.Value"/>
    public string Text => _textContent?.Text?.Value;

    /// <summary>
    /// An update to an annotation associated with a specific content item in the message's content items collection.
    /// </summary>
    public TextAnnotationUpdate TextAnnotation { get; }

    private readonly MessageDeltaContentImageFileObject _imageFileContent;
    private readonly MessageDeltaContentTextObject _textContent;
    private readonly MessageDeltaContentImageUrlObject _imageUrlContent;
    private readonly InternalMessageDeltaObject _delta;

    internal MessageContentUpdate(InternalMessageDeltaObject delta, MessageDeltaContent content, TextAnnotationUpdate annotation = null)
        : base(StreamingUpdateReason.MessageUpdated)
    {
        _delta = delta;
        _textContent = content as MessageDeltaContentTextObject;
        _imageFileContent = content as MessageDeltaContentImageFileObject;
        _imageUrlContent = content as MessageDeltaContentImageUrlObject;
        TextAnnotation = annotation;
    }

    internal static IEnumerable<MessageContentUpdate> DeserializeMessageContentUpdates(
        JsonElement element,
        StreamingUpdateReason _,
        ModelReaderWriterOptions options = null)
    {
        InternalMessageDeltaObject deltaObject = InternalMessageDeltaObject.DeserializeInternalMessageDeltaObject(element, options);
        List<MessageContentUpdate> updates = [];
        foreach (MessageDeltaContent deltaContent in deltaObject.Delta.Content ?? [])
        {
            List<MessageContentUpdate> updatesForContentItem = [];
            if (deltaContent is MessageDeltaContentTextObject textContent)
            {
                foreach (MessageDeltaTextContentAnnotation internalAnnotation in textContent.Text.Annotations)
                {
                    TextAnnotationUpdate annotation = new(internalAnnotation);
                    updatesForContentItem.Add(new(deltaObject, deltaContent, annotation));
                }
            }
            if (updatesForContentItem.Count == 0)
            {
                updatesForContentItem.Add(new(deltaObject, deltaContent));
            }
            updates.AddRange(updatesForContentItem);
        }
        return updates;
    }
}

