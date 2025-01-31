#pragma warning disable OPENAI001
using NUnit.Framework;

#region usings
using System;
using System.ClientModel;

using OpenAI.VectorStores;
#endregion

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
