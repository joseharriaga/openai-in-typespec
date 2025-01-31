#pragma warning disable OPENAI001
using NUnit.Framework;

#region usings
using System;
using System.ClientModel;

using OpenAI.Assistants;
#endregion

namespace OpenAI.Docs.ApiReference;
public partial class DeleteMessageApiReference {

    [Test]
    public void DeleteMessage()
    {
		AssistantClient assistantClient = new (new ApiKeyCredential(Environment.GetEnvironmentVariable("OPENAI_API_KEY")));
		var message = assistantClient.DeleteMessage("thread_abc123", "msg_abc123");
		Console.WriteLine(message.Value);
	}
}
