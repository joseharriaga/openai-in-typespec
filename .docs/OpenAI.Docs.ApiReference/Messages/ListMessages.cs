#pragma warning disable OPENAI001
using NUnit.Framework;

#region usings
using System;
using System.ClientModel;

using OpenAI.Assistants;
#endregion

namespace OpenAI.Docs.ApiReference;
public partial class ListMessagesApiReference {

    [Test]
    public void ListMessages()
    {
		AssistantClient assistantClient = new (new ApiKeyCredential(Environment.GetEnvironmentVariable("OPENAI_API_KEY")));
		
		var messages = assistantClient.GetMessages("thread_abc123");
		Console.WriteLine(messages);
	}
}
