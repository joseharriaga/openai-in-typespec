namespace OpenAI.Files;

[CodeGenModel("UploadStatus")]
public enum UploadJobStatus
{
    Pending,
    Completed,
    Cancelled,
    Expired
}
