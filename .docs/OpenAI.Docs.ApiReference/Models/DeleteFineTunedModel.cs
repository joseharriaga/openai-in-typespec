using NUnit.Framework;

#region usings
using System;

using OpenAI.Models;
using System.ClientModel;
#endregion

namespace OpenAI.Docs.ApiReference;

public partial class ModelDocs
{
    [Test]
    public void DeleteFineTunedModel()
    {
        try
        {
            #region logic

            OpenAIModelClient client = new(
                Environment.GetEnvironmentVariable("OPENAI_API_KEY")
            );

            ClientResult success = client.DeleteModel("ft:gpt-4o-mini:acemeco:suffix:abc123");
            Console.WriteLine(success);

            #endregion
        }
        catch (ClientResultException ex)
        {
            Assert.IsTrue(ex.Message == "HTTP 404 (invalid_request_error: model_not_found)\r\nParameter: model\r\n\r\nThe model 'ft:gpt-4o-mini:acemeco:suffix:abc123' does not exist");
        }
    }
}
