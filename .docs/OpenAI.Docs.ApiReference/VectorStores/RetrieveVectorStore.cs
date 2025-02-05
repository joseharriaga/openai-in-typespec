#pragma warning disable OPENAI001
using NUnit.Framework;

#region usings
using System;
using System.ClientModel;

using OpenAI.VectorStores;
#endregion

namespace OpenAI.Docs.ApiReference;

public partial class VectorStoreDocs
{
    //[Test]
    public void RetrieveVectorStore()
    {
        #region logic

        VectorStoreClient client = new(
            apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY")
        );

        ClientResult<VectorStore> store = client.GetVectorStore("vs_abc123");

        Console.WriteLine(store.Value.Id);

        #endregion
    }
}
