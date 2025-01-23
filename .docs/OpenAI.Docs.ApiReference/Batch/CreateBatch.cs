using System;
using NUnit.Framework;



using System.Text.Json;

// DO NOT INCLUDE IN DOCS ABOVE THIS POINT

using OpenAI.Batch;
using System.ClientModel;

namespace OpenAI.Docs.ApiReference;
public partial class CreateBatchApiReference {

    [Test]
    public void CreateBatch()
    {
		BatchClient client = new(Environment.GetEnvironmentVariable("OPENAI_API_KEY"));
		
		var content = BinaryContent.Create(
		    BinaryData.FromObjectAsJson(new
		    {
		        input_file_id = "file-abc123",
		        endpoint = "/v1/chat/completions",
		        completion_window = "24h"
		    })
		);
		
		var result = client.CreateBatch(content, false);
		
		// DO NOT INCLUDE IN DOCS FROM THIS POINT ONWARDS
		
		BinaryData output = result.GetRawResponse().Content;
		using JsonDocument outputAsJson = JsonDocument.Parse(output);
		Console.WriteLine(outputAsJson.RootElement.ToString());

	}
}
