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
            ChatClient client = new(
                "gpt-4o",
                // This is the default key used and the line can be omitted
                Environment.GetEnvironmentVariable("OPENAI_API_KEY"));

            AsyncResultValueCollection<StreamingChatCompletionUpdate> asyncChatUpdates
                = client.CompleteChatStreamingAsync(
                    [
                        new UserChatMessage("Say 'this is a test.'"),
                    ]);

            await foreach (StreamingChatCompletionUpdate chatUpdate in asyncChatUpdates)
            {
                foreach (ChatMessageContentPart contentPart in chatUpdate.ContentUpdate)
                {
                    Console.Write(contentPart.Text);
                }
            }
        }
    }
}
