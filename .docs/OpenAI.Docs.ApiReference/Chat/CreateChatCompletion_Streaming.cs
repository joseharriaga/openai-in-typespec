using NUnit.Framework;

#region usings
using System;
using System.ClientModel;
using System.Collections.Generic;

using OpenAI.Chat;
using System.Threading.Tasks;
#endregion

namespace OpenAI.Docs.ApiReference;

public partial class ChatDocs
{
    [Test]
    public async Task CreateChatCompletion_Streaming()
    {
        #region logic

        ChatClient client = new(
            model: "gpt-4o",
            apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY")
        );

        List<ChatMessage> messages =
        [
            new SystemChatMessage("You are a helpful assistant."),
            new UserChatMessage("Hello!")
        ];

        AsyncCollectionResult<StreamingChatCompletionUpdate> completionUpdates = client.CompleteChatStreamingAsync(messages);

        await foreach (StreamingChatCompletionUpdate completionUpdate in completionUpdates)
        {
            if (completionUpdate.ContentUpdate.Count > 0)
            {
                Console.Write(completionUpdate.ContentUpdate[0].Text);
            }
        }

        #endregion
    }
}
