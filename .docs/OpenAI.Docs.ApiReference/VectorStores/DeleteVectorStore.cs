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
    public void DeleteVectorStore()
    {
        #region logic

        VectorStoreClient client = new(
            apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY")
        );

        ClientResult<VectorStoreDeletionResult> result = client.DeleteVectorStore("vs_abc123");
        Console.WriteLine(result.Value);

        #endregion
    }
}
