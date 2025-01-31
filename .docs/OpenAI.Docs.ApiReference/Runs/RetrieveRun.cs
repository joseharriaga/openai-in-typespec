#pragma warning disable OPENAI001
using NUnit.Framework;

#region usings
using System;
using System.ClientModel;

using OpenAI.Assistants;
#endregion

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
