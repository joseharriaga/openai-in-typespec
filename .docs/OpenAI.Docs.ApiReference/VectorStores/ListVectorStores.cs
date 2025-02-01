#pragma warning disable OPENAI001
using NUnit.Framework;

#region usings
using System;
using System.ClientModel;

using OpenAI.VectorStores;
#endregion

namespace OpenAI.Docs.ApiReference;
public partial class ListVectorStoresApiReference {

    //[Test]
    public void ListVectorStores()
    {
        #region logic

        VectorStoreClient client = new(
            apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY")
        );

        CollectionResult<VectorStore> stores = client.GetVectorStores();
		Console.WriteLine(stores);

        #endregion
    }
}
