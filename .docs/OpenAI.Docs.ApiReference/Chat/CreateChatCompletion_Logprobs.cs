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
    public void CreateChatCompletion_Logprobs()
    {
        #region logic

        ChatClient client = new(
            model: "gpt-4o",
            apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY")
        );

        List<ChatMessage> messages =
        [
            new UserChatMessage("Hello!")
        ];

        ChatCompletionOptions options = new()
        {
            IncludeLogProbabilities = true,
            TopLogProbabilityCount = 2
        };

        ChatCompletion completion = client.CompleteChat(messages, options);

        Console.WriteLine(completion.Content[0].Text);

        #endregion

        Assert.That(completion, Is.Not.Null);
        Assert.That(completion.ContentTokenLogProbabilities, Has.Count.GreaterThan(0));
        Assert.That(completion.ContentTokenLogProbabilities[0].TopLogProbabilities, Has.Count.EqualTo(2));
    }
}
