#pragma warning disable OPENAI001
using NUnit.Framework;

#region usings
using System;
using System.ClientModel;

using OpenAI.VectorStores;
#endregion

namespace OpenAI.Docs.ApiReference;
public partial class CreateVectorStoreFileBatchApiReference {

    [Test]
    public void CreateVectorStoreFileBatch()
    {
		VectorStoreClient client = new (new ApiKeyCredential(Environment.GetEnvironmentVariable("OPENAI_API_KEY")));
		var batch = client.CreateBatchFileJob("vs_abc123", ["file-abc123", "file-abc456"], true);
		Console.WriteLine(batch.Value.BatchId);
	}
}
