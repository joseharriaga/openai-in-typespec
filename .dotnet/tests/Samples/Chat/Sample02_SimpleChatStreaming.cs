using NUnit.Framework;
using OpenAI.Chat;
using System;
using System.ClientModel;

namespace OpenAI.Samples
{
    public partial class ChatSamples
    {
        [Test]
        [Ignore("Compilation validation only")]
        public void Sample02_SimpleChatStreaming()
        {
            ChatClient client = new("gpt-3.5-turbo", Environment.GetEnvironmentVariable("OPENAI_API_KEY"));

            ResultCollection<StreamingChatCompletionUpdate> chatCompletionUpdates =
                client.CompleteChatStreaming([new UserChatMessage("How does AI work? Explain it in simple terms.")]);

            Console.WriteLine("[ASSISTANT]: ");
            foreach (StreamingChatCompletionUpdate chatCompletionUpdate in chatCompletionUpdates)
            {
                if (chatCompletionUpdate.ContentUpdate.Count > 0)
                {
                    Console.Write(chatCompletionUpdate.ContentUpdate[0].Text);
                }
            }
        }
    }
}
