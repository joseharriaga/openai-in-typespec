#pragma warning disable OPENAI001
using NUnit.Framework;

#region usings
using System;
using System.ClientModel;

using OpenAI.Assistants;
#endregion

namespace OpenAI.Docs.ApiReference;
public partial class CreateThreadApiReference {

    [Test]
    public void CreateThread()
    {
		AssistantClient assistantClient = new (new ApiKeyCredential(Environment.GetEnvironmentVariable("OPENAI_API_KEY")));
		
		var thread = assistantClient.CreateThread(new ThreadCreationOptions()
		{
		    InitialMessages = {
		        "Hello, what is AI?",
		        "How does AI work? Explain it in simple terms."
		    }
		});
		Console.WriteLine(thread.Value.Id);
	}
}
