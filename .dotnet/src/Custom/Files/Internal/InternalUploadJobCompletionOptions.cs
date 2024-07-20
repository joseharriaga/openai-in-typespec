using System.Collections.Generic;

namespace OpenAI.Files;

/// <summary>
/// Request-level options for upload job completion.
/// </summary>
[CodeGenModel("CompleteUploadRequest")]
internal partial class InternalUploadJobCompletionOptions
{
    [CodeGenMember("PartIds")]
    internal IList<string> DataPartIds { get; set; }

    /// <summary>
    /// An optional MD5 checksum for the file contents that will be used to verify if the uploaded bytes match.
    /// </summary>
    [CodeGenMember("Md5")]
    public string ContentChecksum { get; set; }
}