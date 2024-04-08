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

        content.Add(purpose.ToString(), "\"purpose\"");

        return content;
    }
}
