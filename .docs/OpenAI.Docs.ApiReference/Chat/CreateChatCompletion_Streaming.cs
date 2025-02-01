using NUnit.Framework;

#region usings
using System;
using System.ClientModel;

using OpenAI.Chat;
using System.Threading.Tasks;
#endregion

namespace OpenAI.Docs.ApiReference;
public partial class CreateChatCompletion_StreamingApiReference {

    [Test]
    public async Task CreateChatCompletion_Streaming()
    {
        #region logic

        ChatClient client = new(
		    model: "gpt-4o",
		    apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY")
		);
		
		AsyncCollectionResult<StreamingChatCompletionUpdate> updates = 
			client.CompleteChatStreamingAsync(
				[
					new SystemChatMessage("You are a helpful assistant."),
					new UserChatMessage("Hello!")
				]
			);
		
		Console.WriteLine($"[ASSISTANT]:");
		await foreach (StreamingChatCompletionUpdate update in updates) 
		{
		    foreach (ChatMessageContentPart updatePart in update.ContentUpdate) 
			{
		        Console.Write(updatePart.Text);
		    }
		}

        #endregion
    }
}
