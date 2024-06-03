﻿using NUnit.Framework;
using OpenAI.Chat;
using System;
using System.ClientModel;

namespace OpenAI.Samples;

public partial class ChatSamples
{
    [Test]
    [Ignore("Compilation validation only")]
    public void Sample02_SimpleChatStreaming()
    {
        ChatClient client = new(
            "gpt-4o",
            // This is the default key used and the line can be omitted
            Environment.GetEnvironmentVariable("OPENAI_API_KEY"));

        CollectionResult<StreamingChatCompletionUpdate> chatUpdates = client.CompleteChatStreaming(
            [
                new UserChatMessage("Say 'this is a test.'"),
            ]);

        foreach (StreamingChatCompletionUpdate chatUpdate in chatUpdates)
        {
            foreach (ChatMessageContentPart contentPart in chatUpdate.ContentUpdate)
            {
                Console.Write(contentPart.Text);
            }
        }
    }
}
