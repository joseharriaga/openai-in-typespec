using OpenAI.Internal;
using System;
using System.IO;

namespace OpenAI.Files;

internal class UploadFileOptions
{
    internal static MultipartFormDataBinaryContent ToMultipartContent(Stream file, string fileName, OpenAIFilePurpose purpose)
    {
        MultipartFormDataBinaryContent content = new();

        content.Add(file, "file", fileName);

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
