#pragma warning disable OPENAI001
using NUnit.Framework;

#region usings
using System;
using System.ClientModel;

using OpenAI.Assistants;
#endregion

namespace OpenAI.Docs.ApiReference;
public partial class ListRunStepsApiReference {

    [Test]
    public void ListRunSteps()
    {
		AssistantClient assistantClient = new (new ApiKeyCredential(Environment.GetEnvironmentVariable("OPENAI_API_KEY")));
		
		var runSteps = assistantClient.GetRunSteps("thread_abc123", "run_abc123");
		Console.WriteLine(runSteps);
	}
}
