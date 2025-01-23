using System;
using NUnit.Framework;


using OpenAI.Chat;

namespace OpenAI.Docs.ApiReference;
public partial class CreateChatCompletion_StreamingApiReference {

    [Test]
    public async void CreateChatCompletion_Streaming()
    {
		ChatClient client = new(
		    model: "gpt-4o",
		    Environment.GetEnvironmentVariable("OPENAI_API_KEY")
		);
		
		var updates = client.CompleteChatStreamingAsync(new ChatMessage[] {
		        new SystemChatMessage("You are a helpful assistant."),
		        new UserChatMessage("Hello!")
		    });
		
		Console.WriteLine($"[ASSISTANT]:");
		await foreach (StreamingChatCompletionUpdate update in updates) {
		    foreach (ChatMessageContentPart updatePart in update.ContentUpdate) {
		        Console.Write(updatePart.Text);
		    }
		}
	}
}
