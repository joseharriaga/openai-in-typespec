using NUnit.Framework;
using OpenAI.Chat;
using System;
using System.ClientModel;
using System.Threading.Tasks;

namespace OpenAI.Samples
{
    public partial class ChatSamples
    {
        [Test]
        [Ignore("Compilation validation only")]
        public async Task Sample02_SimpleChatStreamingAsync()
        {
            ChatClient client = new("gpt-3.5-turbo", Environment.GetEnvironmentVariable("OPENAI_API_KEY"));

            AsyncResultCollection<StreamingChatCompletionUpdate> chatCompletionUpdates =
                client.CompleteChatStreamingAsync([new UserChatMessage("How does AI work? Explain it in simple terms.")]);

            Console.WriteLine("[ASSISTANT]: ");
            await foreach (StreamingChatCompletionUpdate chatCompletionUpdate in chatCompletionUpdates)
            {
                if (chatCompletionUpdate.ContentUpdate.Count > 0)
                {
                    Console.Write(chatCompletionUpdate.ContentUpdate[0].Text);
                }
            }
        }
    }
}
