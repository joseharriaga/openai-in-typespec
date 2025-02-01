using NUnit.Framework;
using System.Text.Json;

#region usings
using System;
using System.ClientModel;

using OpenAI.FineTuning;
#endregion

namespace OpenAI.Docs.ApiReference;
public partial class CreateFineTunningJob_ValidationFileApiReference {

    [Test]
    public void CreateFineTunningJob_ValidationFile()
    {
        #region logic

        FineTuningClient client = new(
			apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY")
		);
		
		BinaryContent content = BinaryContent.Create(
		    BinaryData.FromObjectAsJson(new
		    {
		        training_file = "file-abc123",
		        validation_file = "file-def456",
		        model = "gpt-4o-mini"
		    })
		);
		
		FineTuningJobOperation result = client.CreateFineTuningJob(content, false);

        #endregion

        BinaryData output = result.GetRawResponse().Content;
		using JsonDocument outputAsJson = JsonDocument.Parse(output);
		Console.WriteLine(outputAsJson.RootElement.ToString());
	}
}
