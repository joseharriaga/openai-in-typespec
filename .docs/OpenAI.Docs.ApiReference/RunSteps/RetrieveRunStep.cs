#pragma warning disable OPENAI001
using NUnit.Framework;

#region usings
using System;
using System.ClientModel;

using OpenAI.Assistants;
#endregion

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
