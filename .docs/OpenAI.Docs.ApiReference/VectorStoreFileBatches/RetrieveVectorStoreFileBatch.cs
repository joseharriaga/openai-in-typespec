using System;
using NUnit.Framework;


// Assistants is a beta API and subject to change.
// Acknowledge its experimental status by suppressing the matching warning.
#pragma warning disable OPENAI001
using System.ClientModel;
using OpenAI.VectorStores;

namespace OpenAI.Docs.ApiReference;
public partial class RetrieveVectorStoreFileBatchApiReference {

    [Test]
    public void RetrieveVectorStoreFileBatch()
    {
		VectorStoreClient client = new (new ApiKeyCredential(Environment.GetEnvironmentVariable("OPENAI_API_KEY")));
		var batch = client.GetBatchFileJob("vs_abc123", "vsfb_abc123");
		Console.WriteLine(batch.Value.BatchId);
	}
}
