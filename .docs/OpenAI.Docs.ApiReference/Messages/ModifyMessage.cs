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
        #region logic

        AssistantClient assistantClient = new(
			apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY")
		);

        MessageModificationOptions options = new ()
        {
            Metadata = new Dictionary<string, string>
                {
                    {
                        "modified",
                        "true"
                    },
                    {
                        "user",
                        "abc123"
                    }
                }
        };

        ClientResult<ThreadMessage> message = assistantClient.ModifyMessage(
			"thread_abc123", 
			"msg_abc12",
		    options
		);

		Console.WriteLine(message.Value.Id);

		#endregion
	}
}
