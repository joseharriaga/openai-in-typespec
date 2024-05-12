using System;
using OpenAI.Internal.Models;

namespace OpenAI.Assistants;

[CodeGenModel("MessageDeltaContentImageFileObject")]
public partial class MessageImageFileDeltaContent
{
    [CodeGenMember("Type")]
    private string _type = "image_file";

    /// <inheritdoc cref="InternalMessageDeltaContentImageFileObjectImageFile.FileId"/>
    public string FileId => _imageFile.FileId;

    /// <inheritdoc cref="InternalMessageDeltaContentImageFileObjectImageFile.Detail"/>
    public MessageImageDetail? Detail => _imageFile.Detail?.ToMessageImageDetail();

    [CodeGenMember("ImageFile")]
    internal InternalMessageDeltaContentImageFileObjectImageFile _imageFile;

    /// <summary> Initializes a new instance of <see cref="MessageImageFileContent"/>. </summary>
    internal MessageImageFileDeltaContent(string imageFileId, MessageImageDetail? detail = null)
        : this(new InternalMessageDeltaContentImageFileObjectImageFile(imageFileId, detail?.ToSerialString(), null))
    {}

    /// <summary> Initializes a new instance of <see cref="MessageImageFileContent"/>. </summary>
    /// <param name="imageFile"></param>
    /// <exception cref="ArgumentNullException"> <paramref name="imageFile"/> is null. </exception>
    internal MessageImageFileDeltaContent(InternalMessageDeltaContentImageFileObjectImageFile imageFile)
    {
        Argument.AssertNotNull(imageFile, nameof(imageFile));
        _imageFile = imageFile;
    }
}
