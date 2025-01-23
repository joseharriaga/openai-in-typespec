using System;
using NUnit.Framework;


// Assistants is a beta API and subject to change.
// Acknowledge its experimental status by suppressing the matching warning.
#pragma warning disable OPENAI001
using System.ClientModel;
using OpenAI.VectorStores;

namespace OpenAI.Docs.ApiReference;
public partial class RetrieveVectorStoreFilesApiReference {

    [Test]
    public void RetrieveVectorStoreFiles()
    {
		VectorStoreClient client = new (new ApiKeyCredential(Environment.GetEnvironmentVariable("OPENAI_API_KEY")));
		var file = client.GetFileAssociation("vs_abc123", "file-abc123");
		Console.WriteLine(file);
	}
}
