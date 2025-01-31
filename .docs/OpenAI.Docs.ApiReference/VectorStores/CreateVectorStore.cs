#pragma warning disable OPENAI001
using NUnit.Framework;

#region usings
using System;
using System.ClientModel;

using OpenAI.VectorStores;
#endregion

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
