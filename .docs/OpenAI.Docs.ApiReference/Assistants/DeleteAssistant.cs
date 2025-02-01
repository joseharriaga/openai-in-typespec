#pragma warning disable OPENAI001
using NUnit.Framework;

#region usings
using System;

using OpenAI.Assistants;
#endregion

namespace OpenAI.Docs.ApiReference;
public partial class DeleteAssistantApiReference {

    [Test]
    public void DeleteAssistant()
    {
        #region logic
        AssistantClient client = new(
            apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY")
        );

        var response = client.DeleteAssistant("asst_abc123");
		Console.WriteLine(response.Value);
        #endregion
    }
}
