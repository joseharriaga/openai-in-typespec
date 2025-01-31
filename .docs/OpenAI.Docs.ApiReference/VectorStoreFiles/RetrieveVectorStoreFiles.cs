#pragma warning disable OPENAI001
using NUnit.Framework;

#region usings
using System;
using System.ClientModel;

using OpenAI.VectorStores;
#endregion

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
