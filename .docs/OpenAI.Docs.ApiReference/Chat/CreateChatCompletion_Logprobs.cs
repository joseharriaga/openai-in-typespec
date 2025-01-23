using System;
using NUnit.Framework;


using OpenAI.Chat;

namespace OpenAI.Docs.ApiReference;
public partial class CreateChatCompletion_LogprobsApiReference {

    [Test]
    public void CreateChatCompletion_Logprobs()
    {
		ChatClient client = new(
		    model: "gpt-4o",
		    Environment.GetEnvironmentVariable("OPENAI_API_KEY")
		);
		
		ChatCompletion completion = client.CompleteChat(
		    new ChatMessage[] { new UserChatMessage("Hello!") },
		    new ChatCompletionOptions() { IncludeLogProbabilities = true, TopLogProbabilityCount = 2 }
		);
		
		Console.WriteLine($"[ASSISTANT]: {completion}");
	}
}
