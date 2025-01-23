using System;
using NUnit.Framework;


// Assistants is a beta API and subject to change.
// Acknowledge its experimental status by suppressing the matching warning.
#pragma warning disable OPENAI001
using System.ClientModel;
using OpenAI.Assistants;

namespace OpenAI.Docs.ApiReference;
public partial class CreateMessageApiReference {

    [Test]
    public void CreateMessage()
    {
		AssistantClient assistantClient = new (new ApiKeyCredential(Environment.GetEnvironmentVariable("OPENAI_API_KEY")));
		
		var message = assistantClient.CreateMessage("thread_abc123", MessageRole.User, [
		        MessageContent.FromText("How does AI work? Explain it in simple terms.")
		    ]);
		Console.WriteLine(message.Value.Id);
	}
}
