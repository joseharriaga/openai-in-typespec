#pragma warning disable OPENAI001
using NUnit.Framework;

#region usings
using System;
using System.ClientModel;

using OpenAI.VectorStores;
#endregion

namespace OpenAI.Docs.ApiReference;
public partial class CancelVectorStoreFileBatchApiReference {

    //[Test]
    public void CancelVectorStoreFileBatch()
    {
        #region logic

        VectorStoreClient client = new (
			apiKey:Environment.GetEnvironmentVariable("OPENAI_API_KEY")
		);

		ClientResult<VectorStoreBatchFileJob> result = client.CancelBatchFileJob("vs_abc123", "vsfb_abc123");
		Console.WriteLine(result.Value);
        
        #endregion
    }
}
