#pragma warning disable OPENAI001
using NUnit.Framework;

#region usings
using System;
using System.ClientModel;

using OpenAI.Assistants;
#endregion

namespace OpenAI.Docs.ApiReference;
public partial class CreateMessageApiReference {

    //[Test]
    public void CreateMessage()
    {
        #region logic

        AssistantClient assistantClient = new (
			apiKey:Environment.GetEnvironmentVariable("OPENAI_API_KEY")
		);
		
		ClientResult<ThreadMessage> message = assistantClient.CreateMessage(
			"thread_abc123", 
			MessageRole.User, 
			[
		        MessageContent.FromText("How does AI work? Explain it in simple terms.")
		    ]
		);

		Console.WriteLine(message.Value.Id);
        
		#endregion
    }
}
