#pragma warning disable OPENAI001
using NUnit.Framework;

#region usings
using System;
using System.ClientModel;

using OpenAI.VectorStores;
using System.Security.Cryptography;
#endregion

namespace OpenAI.Docs.ApiReference;

public partial class VectorStoreFileBatchDocs
{
    //[Test]
    public void CreateVectorStoreFileBatch()
    {
        #region logic

        VectorStoreClient client = new(
            apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY")
        );

        CreateBatchFileJobOperation batch = client.CreateBatchFileJob(
            "vs_abc123",
            [
                "file-abc123",
                "file-abc456"
            ],
            true
        );

        Console.WriteLine(batch.Value.BatchId);

        #endregion
    }
}
