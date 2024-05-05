using NUnit.Framework;
using OpenAI.Files;
using System;
using System.ClientModel;
using System.IO;
using static OpenAI.Tests.TestHelpers;

namespace OpenAI.Tests.Files;

public partial class FileClientTests
{
    [Test]
    public void List()
    {
        FileClient client = GetTestClient();

        ClientResult<OpenAIFileInfoCollection> allFiles = client.GetFiles();
        Assert.That(allFiles.Value.Count, Is.GreaterThan(0));
        Console.WriteLine($"Total files count: {allFiles.Value.Count}");

        ClientResult<OpenAIFileInfoCollection> assistantsFiles = client.GetFiles(OpenAIFilePurpose.Assistants);
        Assert.Greater(assistantsFiles.Value.Count, 0);
        Assert.Less(assistantsFiles.Value.Count, allFiles.Value.Count);
        Console.WriteLine($"Assistant files count: {assistantsFiles.Value.Count}");
    }

    [Test]
    public void UploadAndDelete()
    {
        FileClient client = GetTestClient();

        using Stream file = BinaryData.FromString("Hello! This is a test text file. Please delete me.").ToStream();
        string filename = "test-file-delete-me.txt";

        ClientResult<OpenAIFileInfo> uploadedFile = client.Upload(file, filename, OpenAIFilePurpose.Assistants);
        Assert.NotNull(uploadedFile.Value);
        Assert.AreEqual(filename, uploadedFile.Value.Filename);
        Assert.AreEqual(OpenAIFilePurpose.Assistants, uploadedFile.Value.Purpose);

        ClientResult<OpenAIFileInfo> fileInfo = client.GetFile(uploadedFile.Value.Id);
        Assert.AreEqual(uploadedFile.Value.Id, fileInfo.Value.Id);
        Assert.AreEqual(uploadedFile.Value.Filename, fileInfo.Value.Filename);

        ClientResult<DeleteFileResponse> deleteResponse = client.Delete(uploadedFile.Value.Id);
        Assert.AreEqual(uploadedFile.Value.Id, deleteResponse.Value.Id);
        Assert.IsTrue(deleteResponse.Value.Deleted);
    }

    [Test]
    public void Download()
    {
        FileClient client = GetTestClient();

        ClientResult<OpenAIFileInfo> fileInfo = client.GetFile("file-S7roYWamZqfMK9D979HU4q6m");
        Assert.NotNull(fileInfo);

        ClientResult<BinaryData> downloadResult = client.DownloadContent("file-S7roYWamZqfMK9D979HU4q6m");
        Assert.That(downloadResult.Value, Is.Not.Null);
    }

    private static FileClient GetTestClient() => GetTestClient<FileClient>(TestScenario.Files);
}