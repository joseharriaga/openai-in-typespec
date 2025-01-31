#pragma warning disable OPENAI001
using NUnit.Framework;

#region usings
using System;
using System.ClientModel;

using OpenAI.Assistants;
#endregion

namespace OpenAI.Docs.ApiReference;
public partial class DeleteAssistantApiReference {

    [Test]
    public void DeleteAssistant()
    {
		AssistantClient assistantClient = new (new ApiKeyCredential(Environment.GetEnvironmentVariable("OPENAI_API_KEY")));
		var response = assistantClient.DeleteAssistant("asst_abc123");
		Console.WriteLine(response.Value);
	}
}
