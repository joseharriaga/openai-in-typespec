using System;
using NUnit.Framework;


// Assistants is a beta API and subject to change.
// Acknowledge its experimental status by suppressing the matching warning.
#pragma warning disable OPENAI001
using System.ClientModel;
using OpenAI.Assistants;

namespace OpenAI.Docs.ApiReference;
public partial class RetrieveRunApiReference {

    [Test]
    public void RetrieveRun()
    {
		AssistantClient assistantClient = new (new ApiKeyCredential(Environment.GetEnvironmentVariable("OPENAI_API_KEY")));
		
		var run = assistantClient.GetRun("thread_abc123", "run_abc123");
		Console.WriteLine(run.Value.Id);
	}
}
