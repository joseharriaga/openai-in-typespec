using NUnit.Framework;

#region usings
using System;
using System.Collections.Generic;

using OpenAI.Chat;
#endregion

namespace OpenAI.Docs.ApiReference;
public partial class CreateChatCompletion_ImageInputApiReference {

    [Test]
    public void CreateChatCompletion_ImageInput()
    {
        #region code
        ChatClient client = new(
		    model: "gpt-4o",
		    apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY")
		);

		ChatCompletionOptions options = new() 
        { 
            MaxOutputTokenCount = 300 
        };

        List<ChatMessage> messages = 
        [
            new UserChatMessage(
            [
                ChatMessageContentPart.CreateTextPart("What's in this image?"),
                ChatMessageContentPart.CreateImagePart(new Uri("https://upload.wikimedia.org/wikipedia/commons/thumb/d/dd/Gfp-wisconsin-madison-the-nature-boardwalk.jpg/2560px-Gfp-wisconsin-madison-the-nature-boardwalk.jpg"))
            ])
        ];

		ChatCompletion completion = client.CompleteChat(messages, options);
		
		Console.WriteLine($"[ASSISTANT]: {completion}");
        #endregion
    }
}
