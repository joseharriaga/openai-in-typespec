using System;
using NUnit.Framework;


using System.ClientModel;
using System.Text.Json;

// DO NOT INCLUDE IN DOCS ABOVE THIS POINT
using OpenAI.FineTuning;

namespace OpenAI.Docs.ApiReference;
public partial class CreateFineTunningJob_ValidationFileApiReference {

    [Test]
    public void CreateFineTunningJob_ValidationFile()
    {
		FineTuningClient client = new(Environment.GetEnvironmentVariable("OPENAI_API_KEY"));
		
		var content = BinaryContent.Create(
		    BinaryData.FromObjectAsJson(new
		    {
		        training_file = "file-abc123",
		        validation_file = "file-def456",
		        model = "gpt-4o-mini"
		    })
		);
		
		var result = client.CreateFineTuningJob(content, false);
		
		// DO NOT INCLUDE IN DOCS FROM THIS POINT ONWARDS
		
		BinaryData output = result.GetRawResponse().Content;
		using JsonDocument outputAsJson = JsonDocument.Parse(output);
		Console.WriteLine(outputAsJson.RootElement.ToString());
	}
}
