using NUnit.Framework;
using OpenAI.Chat;
using System;
using System.Collections.Generic;

namespace OpenAI.Samples
{
    public partial class ChatSamples
    {
        [Test]
        [Ignore("Compilation validation only")]
        public void Sample05_ChatWithVision(Uri imageUri = null)
        {
            ChatClient client = new("gpt-4-vision-preview", Environment.GetEnvironmentVariable("OPENAI_API_KEY"));

            List<ChatMessage> messages = [
                new UserChatMessage(
                    ChatMessageContentPart.CreateTextMessageContentPart("Describe this image for me"),
                    ChatMessageContentPart.CreateImageMessageContentPart(imageUri))
            ];

            ChatCompletion chatCompletion = client.CompleteChat(messages);
        }
    }
}