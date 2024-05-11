using System;
using OpenAI.Internal.Models;

namespace OpenAI.Assistants;

[CodeGenModel("MessageDeltaContentImageUrlObject")]
public partial class MessageImageUrlDeltaContent
{
    [CodeGenMember("Type")]
    private string InternalType { get; } = "image_url";

    /// <inheritdoc cref="InternalMessageContentImageUrlObjectImageUrl.Url"/>
    public Uri Url => InternalImageUrl.Url;

    public MessageImageDetail? Detail => InternalImageUrl.InternalDetail?.ToMessageImageDetail();

    [CodeGenMember("ImageUrl")]
    internal InternalMessageDeltaContentImageUrlObjectImageUrl InternalImageUrl { get; }

    /// <summary> Initializes a new instance of <see cref="MessageImageUrlContent"/>. </summary>
    internal MessageImageUrlDeltaContent(Uri url, MessageImageDetail? detail = null)
        : this(new InternalMessageDeltaContentImageUrlObjectImageUrl(url, detail?.ToSerialString(), null))
        {}

    /// <summary> Initializes a new instance of <see cref="MessageImageUrlContent"/>. </summary>
    /// <param name="imageUrl"></param>
    /// <exception cref="ArgumentNullException"> <paramref name="imageUrl"/> is null. </exception>
    internal MessageImageUrlDeltaContent(InternalMessageDeltaContentImageUrlObjectImageUrl imageUrl)
    {
        Argument.AssertNotNull(imageUrl, nameof(imageUrl));

        InternalType = "image_url";
        InternalImageUrl = imageUrl;
    }
}
