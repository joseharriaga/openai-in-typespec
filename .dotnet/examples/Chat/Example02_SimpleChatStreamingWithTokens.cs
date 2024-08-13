using NUnit.Framework;
using OpenAI.Chat;
using System;
using System.ClientModel;

namespace OpenAI.Examples;

public partial class ChatExamples
{
    [Test]
    public void Example02_SimpleChatStreamingWithTokens()
    {
        ChatClient client = new(model: "gpt-4o-mini", Environment.GetEnvironmentVariable("OPENAI_API_KEY"));

        CollectionResult<StreamingChatCompletionUpdate> updates
            = client.CompleteChatStreaming("Say 'this is a test.'");

        Console.WriteLine($"[ASSISTANT]:");
        foreach (StreamingChatCompletionUpdate update in updates)
        {
            foreach (ChatMessageContentPart updatePart in update.ContentUpdate)
            {
                Console.Write(updatePart);
            }

            // Dotnet library sets 'include_usage' to true by default
            // update.Usage will be null until the end
            if (update.Usage != null)
            {
                //Write a new line to end the chat updates
                Console.WriteLine();
                Console.WriteLine($"usage InputTokens = {update.Usage.InputTokens}");
                Console.WriteLine($"usage OutputTokens = {update.Usage.OutputTokens}");
                Console.WriteLine($"usage TotalTokens = {update.Usage.TotalTokens}");
            }
        }
    }
}
