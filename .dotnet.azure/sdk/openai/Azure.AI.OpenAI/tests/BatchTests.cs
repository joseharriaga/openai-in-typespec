// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Azure.AI.OpenAI.Files;
using Azure.AI.OpenAI.Tests.Models;
using Azure.AI.OpenAI.Tests.Utils;
using Azure.AI.OpenAI.Tests.Utils.Config;
using OpenAI.Batch;
using OpenAI.Chat;
using OpenAI.Embeddings;
using OpenAI.Files;
using OpenAI.TestFramework;
using OpenAI.TestFramework.Mocks;
using OpenAI.TestFramework.Utils;

namespace Azure.AI.OpenAI.Tests;

#pragma warning disable CS0618

public class BatchTests : AoaiTestBase<BatchClient>
{
    public BatchTests(bool isAsync) : base(isAsync)
    { }

    [Test]
    [Category("Smoke")]
    public void CanCreateClient() => Assert.That(GetTestClient(), Is.InstanceOf<BatchClient>());

    [RecordedTest]
    public async Task CanUploadFileForBatch()
    {
        BatchClient batchClient = GetTestClient();
        OpenAIFileClient fileClient = GetTestClientFrom<OpenAIFileClient>(batchClient);

        OpenAIFile newFile = await fileClient.UploadFileAsync(
            BinaryData.FromString("this isn't valid input for batch"),
            "intentionally-bad-batch-input.jsonl",
            FileUploadPurpose.Batch);
        Validate(newFile);

        AzureOpenAIFileStatus azureStatus = newFile.Status.ToAzureOpenAIFileStatus();
        Assert.That(azureStatus, Is.EqualTo(AzureOpenAIFileStatus.Pending));

        for (int i = 0; i < 10; i++)
        {
            if (azureStatus == AzureOpenAIFileStatus.Pending)
            {
                await Task.Delay(TimeSpan.FromSeconds(5));
                newFile = await fileClient.GetFileAsync(newFile.Id);
                azureStatus = newFile.Status.ToAzureOpenAIFileStatus();
            }
            else
            {
                break;
            }
        }

        Assert.That(azureStatus, Is.EqualTo(AzureOpenAIFileStatus.Error));
        Assert.That(newFile.StatusDetails, Does.Contain("valid json"));
    }

    [RecordedTest]
    public async Task SimpleBatchCompletionsTest()
    {
        BatchClient batchClient = GetTestClient();
        await using BatchOperations ops = new(this, batchClient);

        // Create the batch operations to send and upload them
        ops.ChatClient.CompleteChat([new SystemChatMessage("You are a saccharine AI"), new UserChatMessage("Tell me about yourself")]);
        ops.ChatClient.CompleteChat([new UserChatMessage("Give me a large random number")]);
        Assert.That(ops.Operations, Has.Count.EqualTo(2));
        string inputFileId = await ops.UploadBatchFileAsync();

        // Create the batch operation
        using var requestContent = new BatchOptions()
        {
            InputFileId = inputFileId,
            Endpoint = ops.Operations.Select(o => o.Url).Distinct().First(),
            Metadata =
            {
                [ "description" ] = "Azure OpenAI .Net SDK integration test framework " + nameof(SimpleBatchCompletionsTest),
            }
        }.ToBinaryContent();

        TimeSpan pollingInterval = Recording!.Mode == RecordedTestMode.Playback ? TimeSpan.FromMilliseconds(1) : TimeSpan.FromSeconds(15);
        CreateBatchOperation operation = await batchClient.CreateBatchAsync(requestContent, waitUntilCompleted: false);
        await operation.WaitForCompletionAsync(pollingInterval);

        ClientResult response = operation.GetBatch(null);
        BatchObject batchObj = ExtractAndValidateBatchObj(response);

        Assert.That(batchObj.OutputFileID, Is.Not.Null.Or.Empty);
        BinaryData outputData = await ops.DownloadAndValidateResultAsync(batchObj.OutputFileID!);

        List<string> customIdsFromRequest = ops.Operations.Select(operation => operation.CustomId).ToList();
        List<ChatCompletion> batchCompletions = GetVerifiedBatchOutputsOf<ChatCompletion>(
            outputData,
            customIdsFromRequest);

        foreach (ChatCompletion batchCompletion in batchCompletions)
        {
            Assert.That(batchCompletion, Is.Not.Null);
            Assert.That(batchCompletion.Role, Is.EqualTo(ChatMessageRole.Assistant));
            Assert.That(batchCompletion.Content, Has.Count.EqualTo(1));
            Assert.That(batchCompletion.Content[0].Kind, Is.EqualTo(ChatMessageContentPartKind.Text));
            Assert.That(batchCompletion.Content[0].Text, Is.Not.Null.Or.Empty);
        }
    }

    #region helper methods

    private BinaryData ValidateHasRawJsonResponse(ClientResult result)
    {
        Assert.That(result, Is.Not.Null);
        PipelineResponse response = result.GetRawResponse();
        Assert.That(response, Is.Not.Null);
        Assert.That(response.Status, Is.GreaterThanOrEqualTo(200).And.LessThan(300));
        Assert.That(response.Headers.GetFirstOrDefault("Content-Type"), Does.StartWith("application/json"));

        return response.Content;
    }

    private void ValidateBatchResult(BatchObject batchObj)
    {
        Assert.That(batchObj, Is.Not.Null);
        Assert.That(batchObj.Id, Is.Not.Null.Or.Empty);
        Assert.That(batchObj.Status, Is.Not.Null);
        Assert.That(batchObj.Status, Is.AnyOf("validating", "in_progress", "finalizing", "completed"));
    }

    private BatchObject ExtractAndValidateBatchObj(ClientResult result)
    {
        var binaryData = ValidateHasRawJsonResponse(result);
        var batchObj = BatchObject.From(binaryData);
        ValidateBatchResult(batchObj);
        return batchObj;
    }

    #endregion

    #region helper classes

    private class BatchOperations : IAsyncDisposable
    {
        private MockHttpMessageHandler _handler;
        private List<BatchOperation> _operations;
        private string? _uploadId;
        private OpenAIFileClient _fileClient;

        public BatchOperations(AoaiTestBase<BatchClient> testBase, BatchClient batchClient)
        {
            _handler = new(MockHttpMessageHandler.ReturnEmptyJson);
            _handler.OnRequest += HandleRequest;
            _operations = new();

            BatchFileName = "batch-" + Guid.NewGuid().ToString("D") + ".jsonl";

            _fileClient = testBase.GetTestClientFrom<OpenAIFileClient>(batchClient);

            // Generate the fake pipeline to capture requests and save them to a file later
            AzureOpenAIClient fakeTopLevel = new AzureOpenAIClient(
                new Uri("https://not.a.real.endpoint.fake"),
                new ApiKeyCredential("not.a.real.key"),
                new() { Transport = _handler.Transport });

            ChatClient = fakeTopLevel.GetChatClient(testBase.TestConfig.GetConfig<BatchClient>().DeploymentOrThrow("batch chat client"));
            EmbeddingClient = fakeTopLevel.GetEmbeddingClient(testBase.TestConfig.GetConfig<BatchClient>().DeploymentOrThrow("batch embedding client"));
        }

        public string BatchFileName { get; }
        public IReadOnlyList<BatchOperation> Operations => _operations;
        public ChatClient ChatClient { get; }
        public EmbeddingClient EmbeddingClient { get; }

        public async Task<string> UploadBatchFileAsync()
        {
            if (Operations.Count == 0)
            {
                throw new InvalidOperationException();
            }

            using MemoryStream stream = new MemoryStream();
            using StreamWriter writer = new(stream);
            foreach (BatchOperation operation in _operations)
            {
                await writer.WriteLineAsync(JsonSerializer.Serialize(operation, JsonOptions.OpenAIJsonOptions));
            }
            writer.Flush();
            stream.Seek(0, SeekOrigin.Begin);
            var data = BinaryData.FromStream(stream);

            using var content = BinaryContent.Create(data);

            OpenAIFile file = await _fileClient.UploadFileAsync(data, BatchFileName, FileUploadPurpose.Batch);
            _uploadId = file.Id;
            Assert.That(_uploadId, Is.Not.Null.Or.Empty);

#pragma warning disable CS0618
            while (file.Status != FileStatus.Processed)
            {
                await Task.Delay(TimeSpan.FromSeconds(5));
                file = await _fileClient.GetFileAsync(file.Id);
            }

            return _uploadId;
        }

        public async Task<BinaryData> DownloadAndValidateResultAsync(string outputId)
        {
            ClientResult<BinaryData> response = await _fileClient.DownloadFileAsync(outputId);
            Assert.That(response, Is.Not.Null);
            Assert.That(response.Value, Is.Not.Null);
            return response.Value;
        }

        public async ValueTask DisposeAsync()
        {
            // clean up any files
            if (_uploadId != null)
            {
                await _fileClient.DeleteFileAsync(_uploadId);
            }

            _handler.OnRequest -= HandleRequest;
            _handler.Dispose();
            _operations.Clear();
        }

        private void HandleRequest(object? sender, CapturedRequest request)
        {
            JsonElement? element = null;
            if (request.Content != null)
            {
                using var json = JsonDocument.Parse(request.Content.ToMemory());
                element = json.RootElement.Clone();
            }

            BatchOperation operation = new()
            {
                Method = request.Method,
                Body = element,
                Url = request.Uri?.AbsolutePath?.Contains("/chat/completions") == true
                    ? "/chat/completions"
                    : throw new ArgumentOutOfRangeException(),
            };

            _operations.Add(operation);
        }

        public class BatchOperation
        {
            public string CustomId { get; } = Guid.NewGuid().ToString();
            public HttpMethod Method { get; init; } = HttpMethod.Get;
            public string Url { get; init; } = string.Empty;
            public JsonElement? Body { get; init; }
        }
    }

    #endregion

    private List<T> GetVerifiedBatchOutputsOf<T>(
        BinaryData downloadBytes,
        IList<string> expectedCustomIds)
            where T : IJsonModel<T>
    {
        using Stream outputStream = downloadBytes.ToStream();
        using StreamReader outputReader = new(outputStream);

        List<T> deserializedBodyOutputs = [];

        for (string? line = outputReader.ReadLine(); !string.IsNullOrEmpty(line); line = outputReader.ReadLine())
        {
            string? customId = null;
            bool foundNullError = false;
            string? requestId = null;
            int? statusCode = null;
            T? deserializedResponseBody = default;

            using JsonDocument resultDocument = JsonDocument.Parse(line);
            foreach (JsonProperty documentProperty in resultDocument.RootElement.EnumerateObject())
            {
                if (documentProperty.NameEquals("custom_id"u8))
                {
                    customId = documentProperty.Value.GetString();
                }
                if (documentProperty.NameEquals("error"u8))
                {
                    Assert.IsTrue(documentProperty.Value.ValueKind == JsonValueKind.Null);
                    foundNullError = true;
                }
                if (documentProperty.NameEquals("response"u8))
                {
                    foreach (JsonProperty responseProperty in documentProperty.Value.EnumerateObject())
                    {
                        if (responseProperty.NameEquals("request_id"u8))
                        {
                            requestId = responseProperty.Value.GetString();
                        }
                        if (responseProperty.NameEquals("status_code"u8))
                        {
                            statusCode = responseProperty.Value.GetInt32();
                        }
                        if (responseProperty.NameEquals("body"u8))
                        {
                            BinaryData responseBodyBytes = BinaryData.FromObjectAsJson(responseProperty.Value);
                            deserializedResponseBody = ModelReaderWriter.Read<T>(responseBodyBytes);
                        }
                    }
                }
            }
            Assert.That(customId, Is.Not.Null.And.Not.Empty);
            // Assert.That(expectedCustomIds.Any(expectedId => expectedId == customId));
            Assert.True(foundNullError);
            Assert.That(requestId, Is.Not.Null.And.Not.Empty);
            Assert.That(statusCode, Is.EqualTo(200));
            Assert.That(deserializedResponseBody, Is.Not.Null);
            deserializedBodyOutputs.Add(deserializedResponseBody!);
        }
        Assert.That(deserializedBodyOutputs, Has.Count.EqualTo(expectedCustomIds.Count));
        return deserializedBodyOutputs;
    }
}
