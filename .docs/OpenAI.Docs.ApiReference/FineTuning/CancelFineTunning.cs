using NUnit.Framework;

#region usings
using System;
using System.ClientModel.Primitives;

using OpenAI.FineTuning;
#endregion

namespace OpenAI.Docs.ApiReference;
public partial class CancelFineTunningApiReference {

    //[Test]
    public void CancelFineTunning()
    {
        #region logic
        FineTuningClient client = new(
            apiKey:Environment.GetEnvironmentVariable("OPENAI_API_KEY")
        );
		FineTuningJobOperation operation = FineTuningJobOperation.Rehydrate(client, "ftjob-abc123");
        operation.Cancel(new RequestOptions() { });
        #endregion
    }
}
