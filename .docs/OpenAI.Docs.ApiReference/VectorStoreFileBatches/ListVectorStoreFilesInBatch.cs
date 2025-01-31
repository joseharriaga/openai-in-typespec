#pragma warning disable OPENAI001
using NUnit.Framework;

#region usings
using System;
using System.ClientModel;

using OpenAI.VectorStores;
#endregion

namespace OpenAI.Docs.ApiReference;
public partial class ListVectorStoreFilesInBatchApiReference {

    [Test]
    public void ListVectorStoreFilesInBatch()
    {
		VectorStoreClient client = new(new ApiKeyCredential(Environment.GetEnvironmentVariable("OPENAI_API_KEY")));
		var files = client.GetFileAssociations("vs_abc123");
		Console.WriteLine(files);
	}
}
