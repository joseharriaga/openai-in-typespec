using System;
using NUnit.Framework;


// Assistants is a beta API and subject to change.
// Acknowledge its experimental status by suppressing the matching warning.
#pragma warning disable OPENAI001
using System.ClientModel;
using System.Collections.Generic;
using OpenAI.Assistants;

namespace OpenAI.Docs.ApiReference;
public partial class ModifyMessageApiReference {

    [Test]
    public void ModifyMessage()
    {
		AssistantClient assistantClient = new (new ApiKeyCredential(Environment.GetEnvironmentVariable("OPENAI_API_KEY")));
		
		var message = assistantClient.ModifyMessage("thread_abc123", "msg_abc12",
		    new MessageModificationOptions()
		    {
		        Metadata = new Dictionary<string, string>
		        {
		            { "modified", "true" },
		            { "user", "abc123" }
		        }
		    });
		Console.WriteLine(message.Value.Id);
	}
}
