using System;
using NUnit.Framework;


using System.ClientModel.Primitives;
using System.Text.Json;

// DO NOT INCLUDE IN DOCS ABOVE THIS POINT

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
