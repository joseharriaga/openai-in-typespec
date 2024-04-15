using NUnit.Framework;
using OpenAI.Batch;
using OpenAI.Files;
using System.IO;
using System.Threading.Tasks;

namespace OpenAI.Tests.Batch;

public partial class BatchClientTests
{
    [Test]
    public async Task BatchCreationWorks()
    {
        FileClient fileClient = new();
        EnsureTestInputFile();

        using FileStream batchInputStream = File.OpenRead(s_inputFilename);
        OpenAIFileInfo uploadedFile
            = await fileClient.UploadFileAsync(batchInputStream, s_inputFilename, OpenAIFilePurpose.BatchInput);

        BatchClient client = new();
        BatchInfo batchInfo = client.CreateBatch(uploadedFile.Id, BatchOperationEndpoint.V1_Chat_Completions, BatchCompletionTimeframe.Within_24H);
        Assert.That(batchInfo, Is.Not.Null);

        BatchInfo retrievedBatchInfo = await client.GetBatchAsync(batchInfo.Id);
        Assert.That(batchInfo.Id, Is.EqualTo(retrievedBatchInfo.Id));
        Assert.That(batchInfo.ExpiresAt.HasValue, Is.False);
        Assert.That(batchInfo.CancellingAt.HasValue, Is.False);
        Assert.That(batchInfo.CancelledAt.HasValue, Is.False);
        Assert.That(batchInfo.Endpoint, Is.EqualTo(BatchOperationEndpoint.V1_Chat_Completions));
        Assert.That(batchInfo.CompletedAt.HasValue, Is.False);
        Assert.That(batchInfo.Errors, Is.Empty);
    }

    private void EnsureTestInputFile()
    {
        using (FileStream batchInputStream = File.Create(s_inputFilename))
        using (StreamWriter batchInputWriter = new(batchInputStream))
        {
            batchInputWriter.WriteLine(s_batchBody1);
        }
    }

    private static string s_inputFilename = "tempBatchInput.jsonl";
    private static string s_batchBody1 = @"{""model"":""gpt-3.5-turbo"",""messages"":[{""role"":""user"",""content"":""hello, world!""}]}";
}