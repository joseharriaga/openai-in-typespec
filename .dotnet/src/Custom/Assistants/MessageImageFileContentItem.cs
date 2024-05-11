using System;

namespace OpenAI.Assistants;

[CodeGenModel("MessageContentImageFileObject")]
public partial class MessageImageFileContentItem
{
    public string FileId => InternalImageFile.FileId;

    public MessageImageDetail? Detail => InternalImageFile.Detail;

    [CodeGenMember("ImageFile")]
    internal InternalMessageContentItemFileObjectImageFile InternalImageFile { get; }

    /// <summary> Initializes a new instance of <see cref="MessageImageFileContentItem"/>. </summary>
    public MessageImageFileContentItem(string imageFileId, MessageImageDetail? detail)
        : this(new InternalMessageContentItemFileObjectImageFile(imageFileId, detail))
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
