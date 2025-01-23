using System;
using NUnit.Framework;


// Assistants is a beta API and subject to change.
// Acknowledge its experimental status by suppressing the matching warning.
#pragma warning disable OPENAI001
using System.ClientModel;
using OpenAI.Assistants;

namespace OpenAI.Docs.ApiReference;
public partial class CreateThreadApiReference {

    [Test]
    public void CreateThread()
    {
		AssistantClient assistantClient = new (new ApiKeyCredential(Environment.GetEnvironmentVariable("OPENAI_API_KEY")));
		
		var thread = assistantClient.CreateThread(new ThreadCreationOptions()
		{
		    InitialMessages = {
		        "Hello, what is AI?",
		        "How does AI work? Explain it in simple terms."
		    }
		});
		Console.WriteLine(thread.Value.Id);
	}
}
