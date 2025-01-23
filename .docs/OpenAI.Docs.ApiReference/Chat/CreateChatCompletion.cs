using System;
using NUnit.Framework;


//using OpenAI.Chat;

//ChatClient client = new(
//    model: "gpt-4o",
//    Environment.GetEnvironmentVariable("OPENAI_API_KEY")
//);

//ChatCompletion completion = client.CompleteChat(new List<ChatMessage> {
//    new SystemChatMessage("You are a helpful assistant."),
//    new UserChatMessage("Hello!")
//});

//Console.WriteLine($"[ASSISTANT]: {completion}");

using OpenAI.Chat;

namespace OpenAI.Docs.ApiReference;
public partial class CreateChatCompletionApiReference {

    [Test]
    public void CreateChatCompletion()
    {
		ChatClient client = new(
		    model: "gpt-4o",
		    Environment.GetEnvironmentVariable("OPENAI_API_KEY")
		);
		
		ChatCompletion completion = client.CompleteChat(new ChatMessage[] {
		    new SystemChatMessage("Say this is a test.")
		}, new ChatCompletionOptions() 
		{
		    MaxOutputTokenCount = 7,
		    Temperature = 0
		});
		
		Console.WriteLine($"[ASSISTANT]: {completion}");
	}
}
