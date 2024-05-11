using System;

namespace OpenAI.Assistants;

[CodeGenModel("RequestMessageContentItem")]
public abstract partial class RequestMessageContentItem
{
    // public static MessageImageFileContentItem FromImageFile(
    //     string imageFileId,
    //     MessageImageDetail? detail = null)
    // {
    //     return new MessageImageFileContentItem(imageFileId, detail);
    // }

    // public static MessageImageUrlContentItem FromImageUrl(
    //     Uri imageUri,
    //     MessageImageDetail? detail = null)
    // {
    //     return new MessageImageUrlContentItem(imageUri, detail);
    // }

    public static MessageTextContentItem FromText(string text)
    {
        return new MessageTextContentItem(text);
    }
}
