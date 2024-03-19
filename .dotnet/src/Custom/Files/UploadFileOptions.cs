using OpenAI.Internal;
using System;

namespace OpenAI.Files;

internal class UploadFileOptions
{
    public static MultipartFormDataBinaryContent ToMultipartContent(BinaryData fileData, string fileName, OpenAIFilePurpose purpose)
    {
        MultipartFormDataBinaryContent content = new();

        content.Add(fileData, "file", fileName);

        string purposeValue = purpose switch
        {
            OpenAIFilePurpose.FineTuning => "fine-tune",
            OpenAIFilePurpose.Assistants => "assistants",
            _ => throw new ArgumentException($"Unsupported purpose for file upload: {purpose}"),
        };

        content.Add(purposeValue, "\"purpose\"");

        return content;
    }
}
