using NUnit.Framework;
using System.Text.Json;

#region usings
using System;
using System.ClientModel;

using OpenAI.FineTuning;
#endregion

namespace OpenAI.Docs.ApiReference;

public partial class FineTuningDocs
{
    //[Test]
    public void CreateFineTunningJob()
    {
        #region logic

        FineTuningClient client = new(
            apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY")
        );

        BinaryContent content = BinaryContent.Create(
            BinaryData.FromObjectAsJson(new
            {
                training_file = "file_abc123"
            })
        );

        var result = client.CreateFineTuningJob(content, false);

        #endregion

        BinaryData output = result.GetRawResponse().Content;
        using JsonDocument outputAsJson = JsonDocument.Parse(output);
        Console.WriteLine(outputAsJson.RootElement.ToString());
    }
}
