using NUnit.Framework;
using OpenAI.Batch;
using OpenAI.Files;
using System;
using System.ClientModel;
using System.IO;
using System.Threading.Tasks;
using static OpenAI.Tests.TestHelpers;

namespace OpenAI.Tests.Batch;

public partial class BatchTests
{
    [Test]
    public async Task ListBatchesProtocol()
    {
        BatchClient client = GetTestClient();
        ClientResult result = await client.GetBatchesAsync(after: null, limit: null, options: null);
        //var dynamicResult = result.GetRawResponse().Content.ToDynamicFromJson();
        //Assert.That(dynamicResult.data.Count, Is.GreaterThan(0));
        //Assert.That(dynamicResult.data[0].createdAt, Is.GreaterThan(new DateTimeOffset(2024, 01, 01, 0, 0, 0, TimeSpan.Zero)));
    }

    [Test]
    public async Task CreateGetAndCancelBatchProtocol()
    {
        using MemoryStream testFileStream = new();
        using StreamWriter streamWriter = new (testFileStream);
        string input = @"{""custom_id"": ""request-1"", ""method"": ""POST"", ""url"": ""/v1/chat/completions"", ""body"": {""model"": ""gpt-3.5-turbo"", ""messages"": [{""role"": ""system"", ""content"": ""You are a helpful assistant.""}, {""role"": ""user"", ""content"": ""What is 2+2?""}]}}";
        streamWriter.WriteLine(input);
        streamWriter.Flush();
        testFileStream.Position = 0;

        FileClient fileClient = new();
        OpenAIFileInfo inputFile = await fileClient.UploadFileAsync(testFileStream, "test-batch-file", FileUploadPurpose.Batch);
        Assert.That(inputFile.Id, Is.Not.Null.Or.Empty);

        BatchClient client = GetTestClient();
        ClientResult batchResult = await client.CreateBatchAsync(
            BinaryContent.Create(BinaryData.FromObjectAsJson(new
            {
                input_file_id = inputFile.Id,
                endpoint = "/v1/chat/completions",
                completion_window = "24h",
                metadata = new
                {
                    testMetadataKey = "test metadata value",
                },
            })));
        //var newBatchDynamic = batchResult.GetRawResponse().Content.ToDynamicFromJson();

        //Assert.That(newBatchDynamic?.createdAt, Is.GreaterThan(new DateTimeOffset(2024, 01, 01, 0, 0, 0, TimeSpan.Zero)));
        //Assert.That(newBatchDynamic.status, Is.EqualTo("validating"));
        //Assert.That(newBatchDynamic.metadata["testMetadataKey"], Is.EqualTo("test metadata value"));
        //batchResult = await client.GetBatchAsync(newBatchDynamic.id, options: null);
        //newBatchDynamic = batchResult.GetRawResponse().Content.ToObjectFromJson<dynamic>();
        //Assert.That(newBatchDynamic.endpoint, Is.EqualTo("/v1/chat/completions"));
        //batchResult = await client.CancelBatchAsync(newBatchDynamic.id, options: null);
        //newBatchDynamic = batchResult.GetRawResponse().Content.ToObjectFromJson<dynamic>();
        //Assert.That(newBatchDynamic.status, Is.EqualTo("cancelling"));
    }

    private static BatchClient GetTestClient() => GetTestClient<BatchClient>(TestScenario.Batch);
}