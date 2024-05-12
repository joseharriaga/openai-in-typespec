using System;
using OpenAI.Internal.Models;

namespace OpenAI.Assistants;

/// <summary>
/// Represents an item of image URL content within an Assistants API message.
/// </summary>
/// <remarks>
/// Use the <see cref="MessageContent.FromImageUrl(Uri,MessageImageDetail?)"/> method to
/// create an instance of this type.
/// </remarks>
[CodeGenModel("MessageContentImageUrlObject")]
[CodeGenSuppress("MessageImageUrlContent", typeof(InternalMessageContentImageUrlObjectImageUrl))]
public partial class MessageImageUrlContent
{
    [CodeGenMember("Type")]
    private string InternalType { get; } = "image_url";

    /// <inheritdoc cref="InternalMessageContentImageUrlObjectImageUrl.Url"/>
    public Uri Url => InternalImageUrl.Url;

    public MessageImageDetail? Detail => InternalImageUrl.InternalDetail?.ToMessageImageDetail();

    [CodeGenMember("ImageUrl")]
    internal InternalMessageContentImageUrlObjectImageUrl InternalImageUrl { get; }

    /// <summary> Initializes a new instance of <see cref="MessageImageUrlContent"/>. </summary>
    internal MessageImageUrlContent(Uri url, MessageImageDetail? detail = null)
        : this(new InternalMessageContentImageUrlObjectImageUrl(url, detail?.ToSerialString(), null))
        {}

    /// <summary> Initializes a new instance of <see cref="MessageImageUrlContent"/>. </summary>
    /// <param name="imageUrl"></param>
    /// <exception cref="ArgumentNullException"> <paramref name="imageUrl"/> is null. </exception>
    internal MessageImageUrlContent(InternalMessageContentImageUrlObjectImageUrl imageUrl)
    {
        Argument.AssertNotNull(imageUrl, nameof(imageUrl));

        InternalType = "image_url";
        InternalImageUrl = imageUrl;
    }
}
