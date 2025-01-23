using System;
using NUnit.Framework;


// Assistants is a beta API and subject to change.
// Acknowledge its experimental status by suppressing the matching warning.
#pragma warning disable OPENAI001
using System.ClientModel;
using OpenAI.VectorStores;

namespace OpenAI.Docs.ApiReference;
public partial class CreateVectorStoreApiReference {

    [Test]
    public void CreateVectorStore()
    {
		//VectorStoreClient client = new (new ApiKeyCredential(Environment.GetEnvironmentVariable("OPENAI_API_KEY")));
		//var store = client.CreateVectorStore(new VectorStoreCreationOptions() { 
		//    Name = "Support FAQ"
		//});
		//Console.WriteLine(store.Value.Id);
		Console.WriteLine("");
	}
}
