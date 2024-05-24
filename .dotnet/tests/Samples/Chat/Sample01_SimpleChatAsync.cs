﻿using NUnit.Framework;
using OpenAI.Chat;
using System;
using System.Threading.Tasks;

namespace OpenAI.Samples;

public partial class ChatSamples
{
    [Test]
    [Ignore("Compilation validation only")]
    public async Task Sample01_SimpleChatAsync()
    {
        ChatClient client = new(
            "gpt-3.5-turbo",
            // This is the default key used and the line can be omitted
            Environment.GetEnvironmentVariable("OPENAI_API_KEY"));

        ChatCompletion chatCompletion = await client.CompleteChatAsync(
            [
                new UserChatMessage("Say 'this is a test.'"),
            ]);
    }
}
