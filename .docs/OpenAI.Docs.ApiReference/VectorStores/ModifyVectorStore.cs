#pragma warning disable OPENAI001
using NUnit.Framework;

#region usings
using System;
using System.ClientModel;

using OpenAI.VectorStores;
#endregion

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
