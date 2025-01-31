using NUnit.Framework;
using System.Text.Json;

#region usings
using System;
using System.ClientModel.Primitives;

using OpenAI.FineTuning;
#endregion

using OpenAI.FineTuning;

namespace OpenAI.Docs.ApiReference;
public partial class RetrieveFineTunningJobApiReference {

    [Test]
    public void RetrieveFineTunningJob()
    {
		FineTuningClient client = new(Environment.GetEnvironmentVariable("OPENAI_API_KEY"));
		var result = client.GetJob("ftjob-abc123", new RequestOptions() { });
		
		// DO NOT INCLUDE IN DOCS FROM THIS POINT ONWARDS
		
		BinaryData output = result.GetRawResponse().Content;
		using JsonDocument outputAsJson = JsonDocument.Parse(output);
		Console.WriteLine(outputAsJson.RootElement.ToString());
	}
}
