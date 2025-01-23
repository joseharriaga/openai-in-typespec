using System;
using NUnit.Framework;


// Assistants is a beta API and subject to change.
// Acknowledge its experimental status by suppressing the matching warning.
#pragma warning disable OPENAI001
using System.ClientModel;
using OpenAI.Assistants;

namespace OpenAI.Docs.ApiReference;
public partial class CreateThreadAndRunApiReference {

    [Test]
    public void CreateThreadAndRun()
    {
		AssistantClient assistantClient = new (new ApiKeyCredential(Environment.GetEnvironmentVariable("OPENAI_API_KEY")));
		
		var run = assistantClient.CreateThreadAndRun("asst_abc123", new ThreadCreationOptions() {
		    InitialMessages = {
		        "Explain deep learning to a 5 year old."
		    }
		});
		Console.WriteLine(run.Value.Id);
	}
}
