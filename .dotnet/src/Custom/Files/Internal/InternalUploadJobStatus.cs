namespace OpenAI.Files;

[CodeGenModel("UploadStatus")]
internal enum InternalUploadJobStatus
{
    Pending,
    Completed,
    Cancelled,
    Expired
}
