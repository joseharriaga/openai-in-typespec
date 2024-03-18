﻿using NUnit.Framework;
using OpenAI.Chat;
using System;
using System.ClientModel;
using System.Text.Json;

namespace OpenAI.Samples
{
    public partial class ChatSamples
    {
        [Test]
        [Ignore("Compilation validation only")]
        public void Sample04_Protocol()
        {
            ChatClient client = new("gpt-3.5-turbo", Environment.GetEnvironmentVariable("OpenAIClient_KEY"));

            BinaryData input = BinaryData.FromString("""
                {
                   "model": "gpt-3.5-turbo",
                   "messages": [
                       {
                           "role": "user",
                           "content": "How does AI work? Explain it in simple terms."
                       }
                   ]
                }
                """);

            using BinaryContent content = BinaryContent.Create(input);
            ClientResult result = client.CompleteChat(content);
            BinaryData output = result.GetRawResponse().Content;

            using JsonDocument outputAsJson = JsonDocument.Parse(output.ToString());
            string message = outputAsJson.RootElement
                .GetProperty("choices")[0]
                .GetProperty("message")
                .GetProperty("content")
                .GetString();

            Console.WriteLine($"[ASSISTANT]:");
            Console.WriteLine($"{message}");
        }
    }
}
