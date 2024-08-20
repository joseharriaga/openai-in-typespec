// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using OpenAI.Files;
using System.ClientModel;

namespace Azure.AI.OpenAI.Tests;

public class FileTests : TestBase<FileClient>
{
    [Test]
    [Category("Smoke")]
    public void CanCreateClient() => Assert.That(GetTestClient(), Is.InstanceOf<FileClient>());

    [Test]
    public void CanUploadAndDeleteFiles()
    {
        FileClient client = GetTestClient();
        OpenAIFileInfo file = client.UploadFile(
            BinaryData.FromString("hello, world!"),
            "test_file_delete_me.txt",
            FileUploadPurpose.Assistants);
        Validate(file);
        bool deleted = client.DeleteFile(file.Id);
        Assert.IsTrue(deleted);
    }
}