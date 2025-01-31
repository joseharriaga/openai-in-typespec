using NUnit.Framework;
using System.Text.Json;

#region usings
using System;
using System.ClientModel.Primitives;

using OpenAI.FineTuning;
#endregion

using OpenAI.FineTuning;

namespace OpenAI.Docs.ApiReference;
public partial class ListFineTunningEventsApiReference {

    [Test]
    public void ListFineTunningEvents()
    {
		FineTuningClient client = new(Environment.GetEnvironmentVariable("OPENAI_API_KEY"));
        FineTuningJobOperation operation = FineTuningJobOperation.Rehydrate(client, "ftjob-abc123");
		var result = operation.GetJobEvents(null, 2, new RequestOptions() { });
		
		// DO NOT INCLUDE IN DOCS FROM THIS POINT ONWARDS
		
		//BinaryData output = result.GetRawResponse().Content;
		//using JsonDocument outputAsJson = JsonDocument.Parse(output);
		//Console.WriteLine(outputAsJson.RootElement.ToString());
	}
}
