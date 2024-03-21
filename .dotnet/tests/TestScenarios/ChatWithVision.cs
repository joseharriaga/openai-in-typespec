using NUnit.Framework;
using OpenAI.Chat;
using System;
using System.ClientModel;
using System.IO;
using System.Net.Mime;
using static OpenAI.Tests.TestHelpers;

namespace OpenAI.Tests.Chat;

public partial class ChatWithVision
{
    [Test]
    public void DescribeAnImage()
    {
        string stopSignPath = Path.Combine("Assets", "stop_sign.png");
        using Stream stopSignStream = File.OpenRead(stopSignPath);

        ChatClient client = GetTestClient<ChatClient>(TestScenario.VisionChat);

        ClientResult<ChatCompletion> result = client.CompleteChat(
            [
                new ChatRequestUserMessage(
                    "Describe this image for me",
                    ChatMessageContent.FromImage(stopSignStream, "image/png")),
            ], new ChatCompletionOptions()
            {
                MaxTokens = 2048,
            });
        Console.WriteLine(result.Value.Content);
        Assert.That(result.Value.Content.ToString().ToLowerInvariant(), Contains.Substring("stop"));
    }
}
