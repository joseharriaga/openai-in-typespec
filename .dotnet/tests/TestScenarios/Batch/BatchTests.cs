using NUnit.Framework;
using OpenAI.Assistants;
using OpenAI.Batch;
using OpenAI.Batch;
using OpenAI.Files;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using static OpenAI.Tests.TestHelpers;

namespace OpenAI.Tests.Batch;

public partial class BatchTests
{
    [Test]
    public async Task ListBatches()
    {
        BatchClient client = GetTestClient();
        ListQueryPage<OpenAI.Batch.Batch> batches = await client.GetBatchesAsync();
        Assert.That(batches?.Count, Is.GreaterThan(0));
        Assert.That(batches[0].CreatedAt, Is.GreaterThan(new DateTimeOffset(2024, 01, 01, 0, 0, 0, TimeSpan.Zero)));
    }

    [Test]
    public async Task CreateGetAndCancelBatch()
    {
        using MemoryStream testFileStream = new();
        using StreamWriter streamWriter = new (testFileStream);
        string input = @"{""custom_id"": ""request-1"", ""method"": ""POST"", ""url"": ""/v1/chat/completions"", ""body"": {""model"": ""gpt-3.5-turbo"", ""messages"": [{""role"": ""system"", ""content"": ""You are a helpful assistant.""}, {""role"": ""user"", ""content"": ""What is 2+2?""}]}}";
        streamWriter.WriteLine(input);
        streamWriter.Flush();
        testFileStream.Position = 0;

        FileClient fileClient = new();
        OpenAIFileInfo inputFile = await fileClient.UploadAsync(testFileStream, "test-batch-file", OpenAIFilePurpose.BatchInput);
        Assert.That(inputFile.Id, Is.Not.Null.Or.Empty);

        BatchClient client = GetTestClient();
        OpenAI.Batch.Batch newBatch = await client.CreateBatchAsync(
            inputFile.Id,
            BatchOperationEndpoint.V1ChatCompletions,
            BatchCompletionTimeframe._24h,
            new Dictionary<string, string>()
            {
                ["test-metadata-key"] = "test metadata value",
            });
        Assert.That(newBatch?.CreatedAt, Is.GreaterThan(new DateTimeOffset(2024, 01, 01, 0, 0, 0, TimeSpan.Zero)));
        Assert.That(newBatch.Status, Is.EqualTo(BatchStatus.Validating));
        Assert.That(newBatch.Metadata["test-metadata-key"], Is.EqualTo("test metadata value"));
        newBatch = await client.GetBatchAsync(newBatch.Id);
        Assert.That(newBatch.Endpoint, Is.EqualTo(BatchOperationEndpoint.V1ChatCompletions));
        newBatch = await client.CancelBatchAsync(newBatch.Id);
        Assert.That(newBatch.Status, Is.EqualTo(BatchStatus.Cancelling));
    }

    private static BatchClient GetTestClient() => GetTestClient<BatchClient>(TestScenario.Batch);
}