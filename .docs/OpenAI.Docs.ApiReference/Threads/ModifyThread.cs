#pragma warning disable OPENAI001
using NUnit.Framework;

#region usings
using System;
using System.ClientModel;
using System.Collections.Generic;

using OpenAI.Assistants;
#endregion

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
