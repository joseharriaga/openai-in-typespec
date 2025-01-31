#pragma warning disable OPENAI001
using NUnit.Framework;

#region usings
using System;
using System.ClientModel;

using OpenAI.VectorStores;
#endregion

namespace OpenAI.Docs.ApiReference;
public partial class DeleteVectorStoreFileApiReference {

    [Test]
    public void DeleteVectorStoreFile()
    {
		VectorStoreClient client = new (new ApiKeyCredential(Environment.GetEnvironmentVariable("OPENAI_API_KEY")));
		var result = client.RemoveFileFromStore("vs_abc123", "file-abc123");
		Console.WriteLine(result.Value);
	}
}
