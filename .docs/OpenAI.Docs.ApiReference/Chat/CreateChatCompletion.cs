using NUnit.Framework;

#region usings
using System;
using System.ClientModel;

using OpenAI.Chat;
#endregion

namespace OpenAI.Docs.ApiReference;
public partial class CreateChatCompletionApiReference {

    [Test]
    public void CreateChatCompletion()
    {
        #region

        //using OpenAI.Chat;

        ChatClient client = new(
		    model: "gpt-4o",
		    Environment.GetEnvironmentVariable("OPENAI_API_KEY")
		);

		ChatCompletion completion = client.CompleteChat(
			[
				new SystemChatMessage("You are a helpful assistant."),
				new UserChatMessage("Hello!")
			]
		);
		
		Console.WriteLine($"[ASSISTANT]: {completion}");
        #endregion
    }
}
