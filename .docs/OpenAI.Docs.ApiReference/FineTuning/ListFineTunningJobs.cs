using NUnit.Framework;
using System.Text.Json;

#region usings
using System;
using System.ClientModel.Primitives;

using OpenAI.FineTuning;
#endregion

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
