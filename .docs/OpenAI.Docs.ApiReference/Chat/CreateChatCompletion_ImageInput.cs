using System;
using NUnit.Framework;


using OpenAI.Chat;

namespace OpenAI.Docs.ApiReference;
public partial class CreateChatCompletion_ImageInputApiReference {

    [Test]
    public void CreateChatCompletion_ImageInput()
    {
		ChatClient client = new(
		    model: "gpt-4o",
		    Environment.GetEnvironmentVariable("OPENAI_API_KEY")
		);
		
		ChatCompletion completion = client.CompleteChat(new ChatMessage[] {
		        new UserChatMessage(new ChatMessageContentPart[] {
		            ChatMessageContentPart.CreateTextPart("What's in this image?"),
		            ChatMessageContentPart.CreateImagePart(
		                new Uri("https://upload.wikimedia.org/wikipedia/commons/thumb/d/dd/Gfp-wisconsin-madison-the-nature-boardwalk.jpg/2560px-Gfp-wisconsin-madison-the-nature-boardwalk.jpg"))
		        })
		    });
		
		Console.WriteLine($"[ASSISTANT]: {completion}");
	}
}
