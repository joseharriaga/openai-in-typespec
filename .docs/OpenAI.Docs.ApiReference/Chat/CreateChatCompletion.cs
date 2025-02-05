using NUnit.Framework;

#region usings
using System;
using System.Collections.Generic;

using OpenAI.Chat;
#endregion

namespace OpenAI.Docs.ApiReference;

public partial class ChatDocs
{
    [Test]
    public void CreateChatCompletion()
    {
        #region

        ChatClient client = new(
            model: "gpt-4o",
            apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY")
        );

        List<ChatMessage> messages =
        [
            new SystemChatMessage("You are a helpful assistant."),
            new UserChatMessage("Hello!")
        ];

        ChatCompletion completion = client.CompleteChat(messages);

        Console.WriteLine(completion.Content[0].Text);

        #endregion
    }
}
