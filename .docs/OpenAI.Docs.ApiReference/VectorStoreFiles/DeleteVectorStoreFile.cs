#pragma warning disable OPENAI001
using NUnit.Framework;

#region usings
using System;
using System.ClientModel;

using OpenAI.VectorStores;
#endregion

namespace OpenAI.Docs.ApiReference;

public partial class VectorStoreFileDocs
{
    //[Test]
    public void DeleteVectorStoreFile()
    {
        #region logic

        VectorStoreClient client = new(
            apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY")
        );

        ClientResult<FileFromStoreRemovalResult> result = client.RemoveFileFromStore("vs_abc123", "file-abc123");

        Console.WriteLine(result.Value);

        #endregion
    }
}
