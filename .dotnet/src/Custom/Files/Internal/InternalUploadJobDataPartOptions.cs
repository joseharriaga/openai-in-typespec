using System.Collections.Generic;

namespace OpenAI.Files;

/// <summary>
/// Request-level options for upload job creation.
/// </summary>
[CodeGenModel("AddUploadPartRequest")]
internal partial class InternalUploadJobDataPartOptions
{
    internal MultipartFormDataBinaryContent ToMultipartContent()
    {
        MultipartFormDataBinaryContent content = new();
        content.Add(Data, "data");
        return content;
    }
}