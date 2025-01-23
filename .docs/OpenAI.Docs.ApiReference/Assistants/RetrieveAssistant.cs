using System;
using NUnit.Framework;


// Assistants is a beta API and subject to change.
// Acknowledge its experimental status by suppressing the matching warning.
#pragma warning disable OPENAI001
using OpenAI.Assistants;
using System.ClientModel;

namespace OpenAI.Docs.ApiReference;
public partial class RetrieveAssistantApiReference {

    [Test]
    public void RetrieveAssistant()
    {
		AssistantClient assistantClient = new (new ApiKeyCredential(Environment.GetEnvironmentVariable("OPENAI_API_KEY")));
		var response = assistantClient.GetAssistant("asst_abc123");
		Console.WriteLine(response.Value.Id);
	}
}
