#pragma warning disable OPENAI001
using NUnit.Framework;

#region usings
using System;
using System.ClientModel;

using OpenAI.Assistants;
#endregion

namespace OpenAI.Docs.ApiReference;
public partial class SubmitToolOutputsApiReference {

    [Test]
    public void SubmitToolOutputs()
    {
		AssistantClient assistantClient = new (new ApiKeyCredential(Environment.GetEnvironmentVariable("OPENAI_API_KEY")));
		var streamingUpdates = assistantClient.SubmitToolOutputsToRunStreaming("thread_123", "run_123", [
		    new ToolOutput("call_001", "70 degrees and sunny.")
		]);
		
		foreach (var streamingUpdate in streamingUpdates) {
		    Console.WriteLine(streamingUpdate.UpdateKind);
		}
	}
}
