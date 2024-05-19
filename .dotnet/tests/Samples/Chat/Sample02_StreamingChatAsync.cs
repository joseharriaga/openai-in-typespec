﻿using NUnit.Framework;
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
        public async Task Sample02_StreamingChatAsync()
        {
            ChatClient client = new("gpt-3.5-turbo", Environment.GetEnvironmentVariable("OPENAI_API_KEY"));

            AsyncResultCollection<StreamingChatUpdate> result =
                client.CompleteChatStreamingAsync("How does AI work? Explain it in simple terms.");

            Console.WriteLine("[ASSISTANT]: ");
            await foreach (StreamingChatUpdate chatUpdate in result)
            {
                Console.Write(chatUpdate.ContentUpdate);
            }
        }
    }
}
