using System;
using NUnit.Framework;


// Assistants is a beta API and subject to change.
// Acknowledge its experimental status by suppressing the matching warning.
#pragma warning disable OPENAI001
using System.ClientModel;
using OpenAI.Assistants;

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
