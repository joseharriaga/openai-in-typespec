using System;
using NUnit.Framework;


using System.ClientModel.Primitives;
using System.Text.Json;
#pragma warning disable OPENAI001
// DO NOT INCLUDE IN DOCS ABOVE THIS POINT

using OpenAI.FineTuning;

namespace OpenAI.Docs.ApiReference;
public partial class ListFineTunningJobsApiReference {

    [Test]
    public void ListFineTunningJobs()
    {
		FineTuningClient client = new(Environment.GetEnvironmentVariable("OPENAI_API_KEY"));
		
		var result = client.GetJobs(null, null, null);
		
		// DO NOT INCLUDE IN DOCS FROM THIS POINT ONWARDS
		
		//BinaryData output = result.First().GetRawResponse().Content;
		//using JsonDocument outputAsJson = JsonDocument.Parse(output);
		//Console.WriteLine(outputAsJson.RootElement.ToString());
	}
}
