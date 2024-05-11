using System;

namespace OpenAI.Assistants;

/// <summary>
/// Represents an item of image file content within an Assistants API message.
/// </summary>
/// <remarks>
/// Use the <see cref="MessageContent.FromImageFile(string,MessageImageDetail?)"/> method to
/// create an instance of this type.
/// </remarks>
[CodeGenModel("MessageContentImageFileObject")]
public partial class MessageImageFileContent
{
    [CodeGenMember("Type")]
    private string InternalType { get; } = "image_file";

    /// <inheritdoc cref="InternalMessageContentItemFileObjectImageFile.FileId"/>
    public string FileId => InternalImageFile.FileId;

    /// <inheritdoc cref="InternalMessageContentItemFileObjectImageFile.InternalDetail"/>
    public MessageImageDetail? Detail => InternalImageFile.InternalDetail?.ToMessageImageDetail();

    /// <summary> Gets or sets the image file. </summary>
    [CodeGenMember("ImageFile")]
    internal InternalMessageContentItemFileObjectImageFile InternalImageFile { get; set; }

    /// <summary> Initializes a new instance of <see cref="MessageImageFileContent"/>. </summary>
    internal MessageImageFileContent(string imageFileId, MessageImageDetail? detail = null)
        : this(new InternalMessageContentItemFileObjectImageFile(imageFileId, detail?.ToSerialString(), null))
    {}

    /// <summary> Initializes a new instance of <see cref="MessageImageFileContent"/>. </summary>
    /// <param name="internalImageFile"></param>
    /// <exception cref="ArgumentNullException"> <paramref name="internalImageFile"/> is null. </exception>
    internal MessageImageFileContent(InternalMessageContentItemFileObjectImageFile internalImageFile)
    {
        Argument.AssertNotNull(internalImageFile, nameof(internalImageFile));

        InternalType = "image_file";
        InternalImageFile = internalImageFile;
    }
}
