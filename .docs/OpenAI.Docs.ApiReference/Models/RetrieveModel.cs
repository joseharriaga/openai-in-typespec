using NUnit.Framework;

#region usings
using System;
using System.ClientModel;

using OpenAI.Models;
#endregion

namespace OpenAI.Docs.ApiReference;

public partial class ModelDocs
{
    [Test]
    public void RetrieveModel()
    {
        OpenAIModelClient client = new(
            Environment.GetEnvironmentVariable("OPENAI_API_KEY")
        );

        ClientResult<OpenAIModel> model = client.GetModel("babbage-002");
        Console.WriteLine(model.Value.Id);
    }
}
