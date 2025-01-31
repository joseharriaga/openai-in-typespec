#pragma warning disable OPENAI001
using NUnit.Framework;

#region usings	
using System;
using System.ClientModel;

using OpenAI.Assistants;
#endregion

namespace OpenAI.Docs.ApiReference;
public partial class CreateRunApiReference {

    [Test]
    public void CreateRun()
    {
		AssistantClient assistantClient = new (new ApiKeyCredential(Environment.GetEnvironmentVariable("OPENAI_API_KEY")));
		
		var run = assistantClient.CreateRun("thread_abc123", "asst_abc123");
		Console.WriteLine(run.Value.Id);
	}
}
