using System;
using OpenAI.Internal.Models;

namespace OpenAI.Assistants;

[CodeGenModel("MessageDeltaContentImageFileObject")]
public partial class MessageImageFileDeltaContent
{
    [CodeGenMember("Type")]
    private string InternalType { get; } = "image_file";

    /// <inheritdoc cref="InternalMessageDeltaContentImageFileObjectImageFile.FileId"/>
    public string FileId => InternalImageFile.FileId;

    /// <inheritdoc cref="InternalMessageDeltaContentImageFileObjectImageFile.Detail"/>
    public MessageImageDetail? Detail => InternalImageFile.InternalDetail?.ToMessageImageDetail();

    /// <summary> Gets or sets the image file. </summary>
    [CodeGenMember("ImageFile")]
    internal InternalMessageDeltaContentImageFileObjectImageFile InternalImageFile { get; set; }

    /// <summary> Initializes a new instance of <see cref="MessageImageFileContent"/>. </summary>
    internal MessageImageFileDeltaContent(string imageFileId, MessageImageDetail? detail = null)
        : this(new InternalMessageDeltaContentImageFileObjectImageFile(imageFileId, detail?.ToSerialString(), null))
    {}

    /// <summary> Initializes a new instance of <see cref="MessageImageFileContent"/>. </summary>
    /// <param name="internalImageFile"></param>
    /// <exception cref="ArgumentNullException"> <paramref name="internalImageFile"/> is null. </exception>
    internal MessageImageFileDeltaContent(InternalMessageDeltaContentImageFileObjectImageFile internalImageFile)
    {
        Argument.AssertNotNull(internalImageFile, nameof(internalImageFile));

        InternalType = "image_file";
        InternalImageFile = internalImageFile;
    }
}
