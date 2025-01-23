using System;
using NUnit.Framework;


using System.ClientModel.Primitives;
using System.Text.Json;

// DO NOT INCLUDE IN DOCS ABOVE THIS POINT

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
