using System;

namespace OpenAI.Assistants;

[CodeGenModel("MessageContentImageFileObject")]
public partial class MessageImageFileContentItem
{
    /// <inheritdoc cref="InternalMessageContentItemFileObjectImageFile.FileId"/>
    public string FileId => InternalImageFile.FileId;

    /// <inheritdoc cref="InternalMessageContentItemFileObjectImageFile.InternalDetail"/>
    public MessageImageDetail? Detail => InternalImageFile.InternalDetail?.ToMessageImageDetail();

    /// <summary> Gets or sets the image file. </summary>
    [CodeGenMember("ImageFile")]
    internal InternalMessageContentItemFileObjectImageFile InternalImageFile { get; set; }

    /// <summary> Initializes a new instance of <see cref="MessageImageFileContentItem"/>. </summary>
    public MessageImageFileContentItem(string imageFileId, MessageImageDetail? detail = null)
        : this(new InternalMessageContentItemFileObjectImageFile(imageFileId, detail?.ToSerialString(), null))
    {}

    /// <summary> Initializes a new instance of <see cref="MessageImageFileContentItem"/>. </summary>
    /// <param name="internalImageFile"></param>
    /// <exception cref="ArgumentNullException"> <paramref name="internalImageFile"/> is null. </exception>
    internal MessageImageFileContentItem(InternalMessageContentItemFileObjectImageFile internalImageFile)
    {
        Argument.AssertNotNull(internalImageFile, nameof(internalImageFile));

        Type = "image_file";
        InternalImageFile = internalImageFile;
    }
}
