using NUnit.Framework;
using System.Text.Json;

#region usings
using System;

using OpenAI.Batch;
using System.ClientModel.Primitives;
using OpenAI.VectorStores;
#endregion

namespace OpenAI.Docs.ApiReference;

public partial class BatchDocs
{
    //[Test]
    public void RetrieveBatch()
    {
        #region logic

        BatchClient client = new(Environment.GetEnvironmentVariable("OPENAI_API_KEY"));
        CollectionResult result = client.GetBatches(after: null, limit: null, options: null);

        #endregion
    }
}
