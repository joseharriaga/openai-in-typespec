using NUnit.Framework;

#region usings
using System;

using OpenAI.Chat;
#endregion

namespace OpenAI.Docs.ApiReference;
public partial class CreateChatCompletionApiReference {

    [Test]
    public void CreateChatCompletion()
    {
        #region

        ChatClient client = new(
		    model: "gpt-4o",
		    apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY")
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
