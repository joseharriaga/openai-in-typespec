#pragma warning disable OPENAI001
using NUnit.Framework;

#region usings
using System;
using System.ClientModel.Primitives;

using OpenAI.VectorStores;
#endregion

namespace OpenAI.Docs.ApiReference;

public partial class VectorStoreFileDocs
{
    //[Test]
    public void ListVectorStoreFiles()
    {
        #region logic

        VectorStoreClient client = new(
            apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY")
        );

        CollectionResult files = client.GetFileAssociations("vs_abc123");

        Console.WriteLine(files);

        #endregion
    }
}
