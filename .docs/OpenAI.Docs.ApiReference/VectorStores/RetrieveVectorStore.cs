#pragma warning disable OPENAI001
using NUnit.Framework;

#region usings
using System;
using System.ClientModel;

using OpenAI.VectorStores;
#endregion

namespace OpenAI.Docs.ApiReference;
public partial class RetrieveVectorStoreApiReference {

    [Test]
    public void RetrieveVectorStore()
    {
		VectorStoreClient client = new (new ApiKeyCredential(Environment.GetEnvironmentVariable("OPENAI_API_KEY")));
		var store = client.GetVectorStore("vs_abc123");
		Console.WriteLine(store.Value.Id);
	}
}
