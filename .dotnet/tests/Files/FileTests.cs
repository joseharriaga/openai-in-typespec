using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;
using OpenAI.Files;
using OpenAI.Tests.Utility;
using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using static OpenAI.Tests.TestHelpers;

namespace OpenAI.Tests.Files;

[TestFixture(true)]
[TestFixture(false)]
[Parallelizable(ParallelScope.Fixtures)]
[Category("Files")]
public partial class FileTests : SyncAsyncTestBase
{
    public FileTests(bool isAsync) : base(isAsync)
    {
    }

    [Test]
    public async Task ListFiles()
    {
        FileClient client = GetTestClient();

        OpenAIFileInfoCollection allFiles = IsAsync
            ? await client.GetFilesAsync()
            : client.GetFiles();
        Assert.That(allFiles.Count, Is.GreaterThan(0));
        Console.WriteLine($"Total files count: {allFiles.Count}");

        OpenAIFileInfoCollection assistantsFiles = IsAsync
            ? await client.GetFilesAsync(OpenAIFilePurpose.Assistants)
            : client.GetFiles(OpenAIFilePurpose.Assistants);
        Assert.That(assistantsFiles.Count, Is.GreaterThan(0).And.LessThan(allFiles.Count));
        Console.WriteLine($"Assistant files count: {assistantsFiles.Count}");
    }

    [Test]
    public async Task UploadAndRetrieve()
    {
        FileClient client = GetTestClient();
        string fileContent = "Hello! This is a test text file. Please delete me.";
        using Stream file = BinaryData.FromString(fileContent).ToStream();
        string filename = "test-file-delete-me.txt";

        // Upload file.
        OpenAIFileInfo uploadedFile = IsAsync
            ? await client.UploadFileAsync(file, filename, FileUploadPurpose.Assistants)
            : client.UploadFile(file, filename, FileUploadPurpose.Assistants);
        Assert.That(uploadedFile, Is.Not.Null);

        try
        {
            Assert.That(uploadedFile.Filename, Is.EqualTo(filename));
            Assert.That(uploadedFile.Purpose, Is.EqualTo(OpenAIFilePurpose.Assistants));

            // Retrieve file.
            OpenAIFileInfo retrievedFile = IsAsync
                ? await client.GetFileAsync(uploadedFile.Id)
                : client.GetFile(uploadedFile.Id);
            Assert.That(retrievedFile.Id, Is.EqualTo(uploadedFile.Id));
            Assert.That(retrievedFile.Filename, Is.EqualTo(uploadedFile.Filename));
        }
        finally
        {
            // Delete file.
            bool deleted = IsAsync
                ? await client.DeleteFileAsync(uploadedFile.Id)
                : client.DeleteFile(uploadedFile.Id);
            Assert.That(deleted, Is.True);
        }
    }

    [Test]
    public async Task UploadAndDownloadContent()
    {
        FileClient client = GetTestClient();
        string imagePath = Path.Combine("Assets", "images_dog_and_cat.png");

        // Upload file.
        OpenAIFileInfo uploadedFile = IsAsync
            ? await client.UploadFileAsync(imagePath, FileUploadPurpose.Vision)
            : client.UploadFile(imagePath, FileUploadPurpose.Vision);
        Assert.That(uploadedFile, Is.Not.Null);

        try
        {
            Assert.That(uploadedFile.Filename, Is.EqualTo(imagePath));
            Assert.That(uploadedFile.Purpose, Is.EqualTo(OpenAIFilePurpose.Vision));

            // Download file content.
            BinaryData downloadedContent = IsAsync
                ? await client.DownloadFileAsync(uploadedFile.Id)
                : client.DownloadFile(uploadedFile.Id);
            Assert.That(downloadedContent, Is.Not.Null);
        }
        finally
        {
            // Delete file.
            bool deleted = IsAsync
                ? await client.DeleteFileAsync(uploadedFile.Id)
                : client.DeleteFile(uploadedFile.Id);
            Assert.That(deleted, Is.True);
        }
    }

    [Test]
    public void SerializeFileCollection()
    {
        // TODO: Add this test.
    }

    [Test]
    public async Task NonAsciiFilename()
    {
        FileClient client = GetTestClient();
        string filename = "你好.txt";
        BinaryData fileContent = BinaryData.FromString("世界您好！这是个测试。");
        OpenAIFileInfo uploadedFile = IsAsync
            ? await client.UploadFileAsync(fileContent, filename, FileUploadPurpose.Assistants)
            : client.UploadFile(fileContent, filename, FileUploadPurpose.Assistants);
        Assert.That(uploadedFile?.Filename, Is.EqualTo(filename));
    }

    [Test]
    public async Task UploadJobWorksProtocol()
    {
        FileClient client = GetTestClient();

        List<byte[]> bytesPerPart =
        [
            "Hello "u8.ToArray(),
            "World "u8.ToArray(),
            "this is a test"u8.ToArray(),
        ];
        int totalSize = bytesPerPart.Sum(part => part.Length);

        List<MemoryStream> parts = bytesPerPart.Select(bytes => new MemoryStream(bytes)).ToList();

        var requestData = BinaryData.FromString($$"""
            {
                "purpose": "assistants",
                "filename": "my-assistants-input.txt",
                "bytes": {{totalSize}},
                "mime_type": "text/plain"
            }
            """);
        using var requestContent = BinaryContent.Create(requestData);

        IncrementalUpload uploadJob = IsAsync
            ? await client.CreateIncrementalUploadAsync(requestContent, new RequestOptions())
            : client.CreateIncrementalUpload(requestContent, new RequestOptions());
        Assert.That(uploadJob, Is.Not.Null);
        PipelineResponse rawResponse = uploadJob.GetRawResponse();
        Assert.That(rawResponse, Is.Not.Null);
        BinaryData rawResponseContent = rawResponse.Content;
        Assert.That(rawResponseContent, Is.Not.Null);

        static string GetIdFromJsonResponse(PipelineResponse response)
        {
            using JsonDocument document = JsonDocument.Parse(response.Content);
            JsonElement idElement = document.RootElement.GetProperty("id"u8);
            return idElement.GetString();
        }

        Assert.That(uploadJob.Id, Is.EqualTo(GetIdFromJsonResponse(rawResponse)));
        Assert.That(uploadJob.CreatedAt, Is.GreaterThan(new DateTimeOffset(2024, 1, 1, 0, 0, 0, TimeSpan.Zero)));
        Assert.That(uploadJob.ExpiresAt, Is.GreaterThan(new DateTimeOffset(2024, 1, 1, 0, 0, 0, TimeSpan.Zero)));
        Assert.That(uploadJob.ExpiresAt, Is.GreaterThan(uploadJob.CreatedAt));

        IncrementalUpload rehydratedJob = IncrementalUpload.FromContinuationToken(client, uploadJob.ContinuationToken);
        Assert.That(rehydratedJob, Is.Not.Null);
        Assert.That(rehydratedJob.Id, Is.EqualTo(uploadJob.Id));
        Assert.That(rehydratedJob.CreatedAt, Is.EqualTo(uploadJob.CreatedAt));
        Assert.That(rehydratedJob.ExpiresAt, Is.EqualTo(uploadJob.ExpiresAt));
        Assert.Throws<InvalidOperationException>(() => rehydratedJob.GetRawResponse());

        static (BinaryContent Content, string ContentType) CreateMultipartFormDataForPart(Stream dataPart)
        {
            const string boundary = "this-is-a-test-boundary-real-values-do-not-matter";
            using StreamReader reader = new(dataPart);
            BinaryData multipartData = BinaryData.FromString($$"""
                --{{boundary}}
                Content-Disposition: form-data; name="data"; filename="data_part"

                {{reader.ReadToEnd()}}
                --{{boundary}}--
                """);
            return (BinaryContent.Create(multipartData), $@"multipart/form-data; boundary=""{boundary}""");
        }

        List<Task<ClientResult>> dataUploadTasks = parts.Select(part => (Task<ClientResult>)null).ToList();

        for (int i = 0; i < parts.Count; i++)
        {
            int index = i;
            IncrementalUpload jobToUse = index % 2 == 0 ? uploadJob : rehydratedJob;
            dataUploadTasks[index] = Task.Run(async () =>
            {
                (BinaryContent content, string contentType) = CreateMultipartFormDataForPart(parts[index]);
                return IsAsync
                    ? await jobToUse.AddDataPartAsync(jobToUse.Id, content, contentType, new RequestOptions())
                    : jobToUse.AddDataPart(jobToUse.Id, content, contentType, new RequestOptions());
            });
        }

        await Task.WhenAll(dataUploadTasks);

        BinaryContent completionRequest = BinaryContent.Create(BinaryData.FromObjectAsJson(new
        {
            part_ids = dataUploadTasks.Select(task => GetIdFromJsonResponse(task.Result.GetRawResponse())),
        }));

        ClientResult completionResult = IsAsync
            ? await uploadJob.CompleteAsync(uploadJob.Id, completionRequest, new RequestOptions())
            : uploadJob.Complete(uploadJob.Id, completionRequest, new RequestOptions());

        using JsonDocument completeJobDocument = JsonDocument.Parse(completionResult.GetRawResponse().Content);
        Assert.That(completeJobDocument.RootElement.TryGetProperty("file", out JsonElement fileProperty)
            && fileProperty.TryGetProperty("id", out JsonElement fileIdProperty)
            && !string.IsNullOrEmpty(fileIdProperty.GetString())
            && fileProperty.TryGetProperty("bytes", out JsonElement sizeProperty)
            && sizeProperty.GetInt64() == totalSize);
    }

    private static FileClient GetTestClient() => GetTestClient<FileClient>(TestScenario.Files);
}