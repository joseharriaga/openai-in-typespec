using System;

namespace OpenAI.Assistants;

[CodeGenModel("MessageContentImageUrlObject")]
public partial class MessageImageUrlContentItem
{
    /// <inheritdoc cref="InternalMessageContentImageUrlObjectImageUrl.Url"/>
    public Uri Url => InternalImageUrl.Url;

    public MessageImageDetail? Detail => InternalImageUrl.InternalDetail?.ToMessageImageDetail();

    [CodeGenMember("ImageUrl")]
    internal InternalMessageContentImageUrlObjectImageUrl InternalImageUrl { get; }

    /// <summary> Initializes a new instance of <see cref="MessageImageUrlContentItem"/>. </summary>
    public MessageImageUrlContentItem(Uri url, MessageImageDetail? detail = null)
        : this(new InternalMessageContentImageUrlObjectImageUrl(url, detail?.ToSerialString(), null))
        {}

    /// <summary> Initializes a new instance of <see cref="MessageImageUrlContentItem"/>. </summary>
    /// <param name="imageUrl"></param>
    /// <exception cref="ArgumentNullException"> <paramref name="imageUrl"/> is null. </exception>
    internal MessageImageUrlContentItem(InternalMessageContentImageUrlObjectImageUrl imageUrl)
    {
        Argument.AssertNotNull(imageUrl, nameof(imageUrl));

        Type = "image_url";
        InternalImageUrl = imageUrl;
    }
}
