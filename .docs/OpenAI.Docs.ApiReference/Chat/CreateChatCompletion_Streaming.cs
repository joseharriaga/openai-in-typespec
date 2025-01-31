using NUnit.Framework;

#region usings
using System;
using System.ClientModel;

using OpenAI.Chat;
#endregion

namespace OpenAI.Docs.ApiReference;
public partial class CreateChatCompletion_StreamingApiReference {

    [Test]
    public async void CreateChatCompletion_Streaming()
    {
		ChatClient client = new(
		    model: "gpt-4o",
		    Environment.GetEnvironmentVariable("OPENAI_API_KEY")
		);
		
		AsyncCollectionResult<StreamingChatCompletionUpdate> updates = 
			client.CompleteChatStreamingAsync(new ChatMessage[] {
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
