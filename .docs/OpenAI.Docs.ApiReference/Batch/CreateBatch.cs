using NUnit.Framework;
using System.Text.Json;

#region usings
using System;
using System.ClientModel;

using OpenAI.Batch;
#endregion

namespace OpenAI.Docs.ApiReference;
public partial class CreateBatchApiReference {

    //[Test]
    public void CreateBatch()
    {
        #region logic

        BatchClient client = new(Environment.GetEnvironmentVariable("OPENAI_API_KEY"));
		
		BinaryContent content = BinaryContent.Create(
		    BinaryData.FromObjectAsJson(new
		    {
		        input_file_id = "file-abc123",
		        endpoint = "/v1/chat/completions",
		        completion_window = "24h"
		    })
		);
		
		var result = client.CreateBatch(content, false);
        
		#endregion

        BinaryData output = result.GetRawResponse().Content;
		using JsonDocument outputAsJson = JsonDocument.Parse(output);
		Console.WriteLine(outputAsJson.RootElement.ToString());

	}
}
