#pragma warning disable OPENAI001
using NUnit.Framework;

#region usings
using System;
using System.ClientModel;

using OpenAI.VectorStores;
#endregion

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
