using NUnit.Framework;
using OpenAI.Files;
using System;
using System.IO;
using System.Threading.Tasks;
using static OpenAI.Tests.TestHelpers;

namespace OpenAI.Tests.Files;

public partial class FileTests
{
    [Test]
    public async Task ListFiles()
    {
        FileClient client = GetTestClient();

        OpenAIFileInfoCollection allFiles = await client.GetFilesAsync();
        Assert.Greater(allFiles.Count, 0);
        Console.WriteLine($"Total files count: {allFiles.Count}");

        OpenAIFileInfoCollection assistantsFiles = await client.GetFilesAsync(OpenAIFilePurpose.Assistants);
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

        OpenAIFileInfo uploadedFile = await client.UploadAsync(file, filename, OpenAIFilePurpose.Assistants);
        Assert.NotNull(uploadedFile);
        Assert.AreEqual(filename, uploadedFile.Filename);
        Assert.AreEqual(OpenAIFilePurpose.Assistants, uploadedFile.Purpose);

        OpenAIFileInfo fileInfo = await client.GetFileAsync(uploadedFile.Id);
        Assert.AreEqual(uploadedFile.Id, fileInfo.Id);
        Assert.AreEqual(uploadedFile.Filename, fileInfo.Filename);

        DeleteFileResponse deleteResponse = await client.DeleteFileAsync(uploadedFile.Id);
        Assert.AreEqual(uploadedFile.Id, deleteResponse.Id);
        Assert.IsTrue(deleteResponse.Deleted);
    }

    [Test]
    public async Task DownloadContent()
    {
        FileClient client = GetTestClient();

        OpenAIFileInfo fileInfo = await client.GetFileAsync("file-S7roYWamZqfMK9D979HU4q6m");
        Assert.NotNull(fileInfo);

        BinaryData downloadedContent = await client.DownloadFileAsync("file-S7roYWamZqfMK9D979HU4q6m");
        Assert.That(downloadedContent, Is.Not.Null);
    }

    [Test]
    public void SerializeFileCollection()
    {
        // TODO: Add this test.
    }

    private static FileClient GetTestClient() => GetTestClient<FileClient>(TestScenario.Files);
}