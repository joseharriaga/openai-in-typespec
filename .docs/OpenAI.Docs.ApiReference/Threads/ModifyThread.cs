using System;
using NUnit.Framework;


// Assistants is a beta API and subject to change.
// Acknowledge its experimental status by suppressing the matching warning.
#pragma warning disable OPENAI001
using System.ClientModel;
using OpenAI.Assistants;
using System.Collections.Generic;

namespace OpenAI.Docs.ApiReference;
public partial class ModifyThreadApiReference {

    [Test]
    public void ModifyThread()
    {
		AssistantClient assistantClient = new (new ApiKeyCredential(Environment.GetEnvironmentVariable("OPENAI_API_KEY")));
		
		var thread = assistantClient.ModifyThread("thread_abc123", new ThreadModificationOptions() 
		{
		    Metadata = new Dictionary<string, string>
		    {
		        { "modified", "true" },
		        { "user", "abc123" }
		    }
		});
		Console.WriteLine(thread.Value.Id);
	}
}
