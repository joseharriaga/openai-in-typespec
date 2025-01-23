using System;
using NUnit.Framework;


// Assistants is a beta API and subject to change.
// Acknowledge its experimental status by suppressing the matching warning.
#pragma warning disable OPENAI001
using System.ClientModel;
using OpenAI.Assistants;

namespace OpenAI.Docs.ApiReference;
public partial class RetrieveMessageApiReference {

    [Test]
    public void RetrieveMessage()
    {
		AssistantClient assistantClient = new (new ApiKeyCredential(Environment.GetEnvironmentVariable("OPENAI_API_KEY")));
		var message = assistantClient.GetMessage("thread_abc123", "msg_abc123");
		Console.WriteLine(message.Value.Id);
	}
}
