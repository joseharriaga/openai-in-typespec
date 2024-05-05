using System;
using System.IO;

namespace OpenAI.Files;

[CodeGenModel("CreateFileRequest")]
[CodeGenSuppress("UploadFileOptions", typeof(Stream), typeof(UploadFileOptionsPurpose))]
public partial class UploadFileOptions
{
    // CUSTOM:
    // - Made internal. This value comes from a parameter on the client method.
    // - Added setter.
    /// <summary> The file object (not file name) to be uploaded. </summary>
    internal Stream File { get; set; }

    // CUSTOM:
    // - Made internal. This value comes from a parameter on the client method.
    // - Added setter.
    /// <summary>
    /// The intended purpose of the uploaded file. Use "fine-tune" for
    /// [Fine-tuning](/docs/api-reference/fine-tuning) and "assistants" for
    /// [Assistants](/docs/api-reference/assistants) and [Messages](/docs/api-reference/messages). This
    /// allows us to validate the format of the uploaded file is correct for fine-tuning.
    /// </summary>
    internal UploadFileOptionsPurpose Purpose { get; set; }

    // CUSTOM: Made public now that there are no required properties.
    /// <summary> Initializes a new instance of <see cref="UploadFileOptions"/> for deserialization. </summary>
    public UploadFileOptions()
    {
    }

    internal MultipartFormDataBinaryContent ToMultipartContent(Stream file, string filename)
    {
        MultipartFormDataBinaryContent content = new();

        content.Add(file, "file", filename);

        content.Add(Purpose.ToString(), "purpose");

        return content;
    }
}
