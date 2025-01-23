using System;
using NUnit.Framework;


// Assistants is a beta API and subject to change.
// Acknowledge its experimental status by suppressing the matching warning.
#pragma warning disable OPENAI001
using System.ClientModel;
using OpenAI.Assistants;

namespace OpenAI.Docs.ApiReference;
public partial class RetrieveRunStepApiReference {

    [Test]
    public void RetrieveRunStep()
    {
		AssistantClient assistantClient = new (new ApiKeyCredential(Environment.GetEnvironmentVariable("OPENAI_API_KEY")));
		
		var runStep = assistantClient.GetRunStep("thread_abc123", "run_abc123", "step_abc123");
		Console.WriteLine(runStep.Value.Id);
	}
}
