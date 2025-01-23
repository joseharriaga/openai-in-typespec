using System;
using NUnit.Framework;


// Assistants is a beta API and subject to change.
// Acknowledge its experimental status by suppressing the matching warning.
#pragma warning disable OPENAI001
using System.ClientModel;
using OpenAI.VectorStores;

namespace OpenAI.Docs.ApiReference;
public partial class DeleteVectorStoreApiReference {

    [Test]
    public void DeleteVectorStore()
    {
		VectorStoreClient client = new (new ApiKeyCredential(Environment.GetEnvironmentVariable("OPENAI_API_KEY")));
		var result = client.DeleteVectorStore("vs_abc123");
		Console.WriteLine(result.Value);
	}
}
