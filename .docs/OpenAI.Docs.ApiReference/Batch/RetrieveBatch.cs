using NUnit.Framework;
using System.Text.Json;

#region usings
using System;

using OpenAI.Batch;
#endregion

namespace OpenAI.Docs.ApiReference;
public partial class RetrieveBatchApiReference {

    [Test]
    public void RetrieveBatch()
    {
		BatchClient client = new(Environment.GetEnvironmentVariable("OPENAI_API_KEY"));
		var result = client.GetBatches(after: null, limit: null, options: null);
		
		// DO NOT INCLUDE IN DOCS FROM THIS POINT ONWARDS
		
		//BinaryData output = result.GetRawResponse().Content;
		//using JsonDocument outputAsJson = JsonDocument.Parse(output);
		//Console.WriteLine(outputAsJson.RootElement.ToString());
	}
}
