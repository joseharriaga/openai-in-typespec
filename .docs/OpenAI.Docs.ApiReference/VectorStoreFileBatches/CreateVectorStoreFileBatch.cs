using System;
using NUnit.Framework;


// Assistants is a beta API and subject to change.
// Acknowledge its experimental status by suppressing the matching warning.
#pragma warning disable OPENAI001
using System.ClientModel;
using OpenAI.VectorStores;

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
