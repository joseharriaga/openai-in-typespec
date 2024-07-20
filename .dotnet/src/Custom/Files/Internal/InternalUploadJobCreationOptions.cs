using System.Collections.Generic;

namespace OpenAI.Files;

/// <summary>
/// Request-level options for upload job creation.
/// </summary>
[CodeGenModel("CreateUploadRequest")]
internal partial class InternalUploadJobCreationOptions
{
    /// <summary>
    /// The total number of bytes that will be uploaded across all data parts.
    /// </summary>
    [CodeGenMember("Bytes")]
    public long TotalUploadSize { get; set; }
}