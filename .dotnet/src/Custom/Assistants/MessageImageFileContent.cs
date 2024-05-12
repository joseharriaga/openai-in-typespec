using System;
using OpenAI.Internal.Models;

namespace OpenAI.Assistants;

/// <summary>
/// Represents an item of image file content within an Assistants API message.
/// </summary>
/// <remarks>
/// Use the <see cref="MessageContent.FromImageFile(string,MessageImageDetail?)"/> method to
/// create an instance of this type.
/// </remarks>
[CodeGenModel("MessageContentImageFileObject")]
[CodeGenSuppress("MessageImageFileContent", typeof(InternalMessageContentItemFileObjectImageFile))]
public partial class MessageImageFileContent
{
    [CodeGenMember("Type")]
    private string _type = "image_file";

    [CodeGenMember("ImageFile")]
    internal InternalMessageContentItemFileObjectImageFile _imageFile;

    /// <inheritdoc cref="InternalMessageContentItemFileObjectImageFile.FileId"/>
    public string FileId => _imageFile.FileId;

    /// <inheritdoc cref="InternalMessageContentItemFileObjectImageFile.Detail"/>
    public MessageImageDetail? Detail => _imageFile.Detail?.ToMessageImageDetail();

    /// <summary> Initializes a new instance of <see cref="MessageImageFileContent"/>. </summary>
    internal MessageImageFileContent(string imageFileId, MessageImageDetail? detail = null)
        : this(new InternalMessageContentItemFileObjectImageFile(imageFileId, detail?.ToSerialString(), null))
    {}

    /// <summary> Initializes a new instance of <see cref="MessageImageFileContent"/>. </summary>
    /// <param name="imageFile"></param>
    /// <exception cref="ArgumentNullException"> <paramref name="imageFile"/> is null. </exception>
    internal MessageImageFileContent(InternalMessageContentItemFileObjectImageFile imageFile)
    {
        Argument.AssertNotNull(imageFile, nameof(imageFile));
        _imageFile = imageFile;
    }
}
