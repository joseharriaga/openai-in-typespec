using NUnit.Framework;
using OpenAI.Files;
using OpenAI.Tests.Utility;
using System;
using System.IO;
using System.Threading.Tasks;
using static OpenAI.Tests.TestHelpers;

namespace OpenAI.Tests.Files;

[TestFixture(true)]
[TestFixture(false)]
public partial class FileTests : SyncAsyncTestBase
{
    public FileTests(bool isAsync) 
        : base(isAsync)
    {
    }

    [Test]
    public async Task ListFiles()
    {
        FileClient client = GetTestClient();

        OpenAIFileInfoCollection allFiles = IsAsync
            ? await client.GetFilesAsync()
            : client.GetFiles();
        Assert.Greater(allFiles.Count, 0);
        Console.WriteLine($"Total files count: {allFiles.Count}");

        OpenAIFileInfoCollection assistantsFiles = IsAsync
            ? await client.GetFilesAsync(OpenAIFilePurpose.Assistants)
            : client.GetFiles(OpenAIFilePurpose.Assistants);
        Assert.Greater(assistantsFiles.Count, 0);
        Assert.Less(assistantsFiles.Count, allFiles.Count);
        Console.WriteLine($"Assistant files count: {assistantsFiles.Count}");
    }

    [Test]
    public async Task UploadAndDelete()
    {
        FileClient client = GetTestClient();
        using Stream file = BinaryData.FromString("Hello! This is a test text file. Please delete me.").ToStream();
        string filename = "test-file-delete-me.txt";

        OpenAIFileInfo uploadedFile = IsAsync
            ? await client.UploadFileAsync(file, filename, OpenAIFilePurpose.Assistants)
            : client.UploadFile(file, filename, OpenAIFilePurpose.Assistants);
        Assert.NotNull(uploadedFile);
        Assert.AreEqual(filename, uploadedFile.Filename);
        Assert.AreEqual(OpenAIFilePurpose.Assistants, uploadedFile.Purpose);

        OpenAIFileInfo fileInfo = IsAsync
            ? await client.GetFileAsync(uploadedFile.Id)
            : client.GetFile(uploadedFile.Id);
        Assert.AreEqual(uploadedFile.Id, fileInfo.Id);
        Assert.AreEqual(uploadedFile.Filename, fileInfo.Filename);

        bool deleted = IsAsync
            ? await client.DeleteFileAsync(uploadedFile.Id)
            : client.DeleteFile(uploadedFile.Id);
        Assert.IsTrue(deleted);
    }

    [Test]
    public async Task DownloadContent()
    {
        FileClient client = GetTestClient();

        OpenAIFileInfo fileInfo = IsAsync
            ? await client.GetFileAsync("file-S7roYWamZqfMK9D979HU4q6m")
            : client.GetFile("file-S7roYWamZqfMK9D979HU4q6m");
        Assert.NotNull(fileInfo);

        BinaryData downloadedContent = IsAsync
            ? await client.DownloadFileAsync("file-S7roYWamZqfMK9D979HU4q6m")
            : client.DownloadFile("file-S7roYWamZqfMK9D979HU4q6m");
        Assert.That(downloadedContent, Is.Not.Null);
    }

    [Test]
    public void SerializeFileCollection()
    {
        // TODO: Add this test.
    }

    private static FileClient GetTestClient() => GetTestClient<FileClient>(TestScenario.Files);
}