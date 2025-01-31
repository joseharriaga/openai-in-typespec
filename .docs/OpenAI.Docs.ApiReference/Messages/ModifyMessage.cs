#pragma warning disable OPENAI001
using NUnit.Framework;

#region usings
using System;
using System.ClientModel;
using System.Collections.Generic;

using OpenAI.Assistants;
#endregion

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
