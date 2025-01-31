using NUnit.Framework;
using System.Text.Json;

#region usings
using System;
using System.ClientModel.Primitives;

using OpenAI.FineTuning;
#endregion

using OpenAI.FineTuning;

namespace OpenAI.Docs.ApiReference;
public partial class CancelFineTunningApiReference {

    [Test]
    public void CancelFineTunning()
    {
		FineTuningClient client = new(Environment.GetEnvironmentVariable("OPENAI_API_KEY"));
		FineTuningJobOperation operation = FineTuningJobOperation.Rehydrate(client, "ftjob-abc123");
        operation.Cancel(new RequestOptions() { });
	}
}
