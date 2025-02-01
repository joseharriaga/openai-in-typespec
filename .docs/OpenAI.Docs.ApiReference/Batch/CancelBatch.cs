using NUnit.Framework;
using System.Text.Json;

#region usings
using System;
using System.ClientModel.Primitives;

using OpenAI.Batch;
#endregion

namespace OpenAI.Docs.ApiReference;
public partial class CancelBatchApiReference {

    //[Test]
    public void CancelBatch()
    {
        #region logic
        
        BatchClient client = new(Environment.GetEnvironmentVariable("OPENAI_API_KEY"));
        CollectionResult result = client.GetBatches(after: null, limit: null, options: null);

        #endregion
    }
}
