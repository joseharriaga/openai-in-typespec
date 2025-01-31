#pragma warning disable OPENAI001
using NUnit.Framework;

#region usings
using System;
using System.ClientModel;

using OpenAI.Assistants;
#endregion

namespace OpenAI.Docs.ApiReference;
public partial class DeleteThreadApiReference {

    [Test]
    public void DeleteThread()
    {
		AssistantClient assistantClient = new (new ApiKeyCredential(Environment.GetEnvironmentVariable("OPENAI_API_KEY")));
		
		var thread = assistantClient.DeleteThread("thread_abc123");
		Console.WriteLine(thread.Value);
	}
}
