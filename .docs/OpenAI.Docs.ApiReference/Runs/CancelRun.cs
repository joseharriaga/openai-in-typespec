#pragma warning disable OPENAI001
using NUnit.Framework;

#region usings
using System;
using System.ClientModel;

using OpenAI.Assistants;
#endregion

namespace OpenAI.Docs.ApiReference;
public partial class CancelRunApiReference {

    [Test]
    public void CancelRun()
    {
		AssistantClient assistantClient = new (new ApiKeyCredential(Environment.GetEnvironmentVariable("OPENAI_API_KEY")));
		
		var result = assistantClient.CancelRun("thread_abc123", "run_abc123");
		Console.WriteLine(result.Value);
	}
}
