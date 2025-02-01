#pragma warning disable OPENAI001
using NUnit.Framework;

#region usings
using System;
using System.ClientModel;

using OpenAI.Assistants;
#endregion

namespace OpenAI.Docs.ApiReference;
public partial class RetrieveAssistantApiReference {

    [Test]
    public void RetrieveAssistant()
    {
        #region logic
        AssistantClient client = new(
            apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY")
        );

        ClientResult<Assistant> response = client.GetAssistant("asst_abc123");
		Console.WriteLine(response.Value.Id);
        #endregion
    }
}
