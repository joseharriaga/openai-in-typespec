using System;
using NUnit.Framework;


// Assistants is a beta API and subject to change.
// Acknowledge its experimental status by suppressing the matching warning.
#pragma warning disable OPENAI001
using System.ClientModel;
using OpenAI.VectorStores;

namespace OpenAI.Docs.ApiReference;
public partial class ModifyVectorStoreApiReference {

    [Test]
    public void ModifyVectorStore()
    {
		VectorStoreClient client = new (new ApiKeyCredential(Environment.GetEnvironmentVariable("OPENAI_API_KEY")));
		var store = client.ModifyVectorStore("vs_abc123", new VectorStoreModificationOptions()
		{
		    Name = "Support FAQ"
		});
		Console.WriteLine(store.Value.Id);
	}
}
