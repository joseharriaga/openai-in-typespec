#pragma warning disable OPENAI001
using NUnit.Framework;

#region usings
using System;
using System.ClientModel;

using OpenAI.VectorStores;
#endregion

namespace OpenAI.Docs.ApiReference;
public partial class CreateVectorStoreFileApiReference {

    [Test]
    public void CreateVectorStoreFile()
    {
        #region logic

        VectorStoreClient client = new(
            apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY")
        );

        AddFileToVectorStoreOperation file = client.AddFileToVectorStore("vs_abc123", "file-abc123", true);
		
        Console.WriteLine(file.Value.FileId);

        #endregion
    }
}
