using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;
using OpenAI.Chat;
using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using static OpenAI.Tests.TestHelpers;

namespace OpenAI.Tests.Chat;

public partial class ChatClientTests
{
    [Test]
    public void HelloWorldChat()
    {
        ChatClient client = GetTestClient<ChatClient>(TestScenario.Chat); // new("gpt-3.5-turbo");
        Assert.That(client, Is.InstanceOf<ChatClient>());
        ClientResult<ChatCompletion> result = client.CompleteChat([new UserChatMessage("Hello, world!")]);
        Assert.That(result, Is.InstanceOf<ClientResult<ChatCompletion>>());
        Assert.That(result.Value.Content[0].Kind, Is.EqualTo(ChatMessageContentPartKind.Text));
        Assert.That(result.Value.Content[0].Text.Length, Is.GreaterThan(0));
    }

    [Test]
    public void HelloWorldWithTopLevelClient()
    {
        OpenAIClient client = new(credential: new(Environment.GetEnvironmentVariable("OPENAI_API_KEY")));
        ChatClient chatClient = client.GetChatClient("gpt-3.5-turbo");
        ClientResult<ChatCompletion> result = chatClient.CompleteChat([new UserChatMessage("Hello, world!")]);
        Assert.That(result, Is.InstanceOf<ClientResult<ChatCompletion>>());
        Assert.That(result.Value.Content.ToString().Length, Is.GreaterThan(0));
    }
    [Test]
    public void MultiMessageChat()
    {
        ChatClient client = new("gpt-3.5-turbo");
        ClientResult<ChatCompletion> result = client.CompleteChat(
        [
            new SystemChatMessage("You are a helpful assistant. You always talk like a pirate."),
            new UserChatMessage("Hello, assistant! Can you help me train my parrot?"),
        ]);
        Assert.That(new string[] { "aye", "arr", "hearty" }.Any(pirateWord => result.Value.Content.ToString().ToLowerInvariant().Contains(pirateWord)));
    }

    // TODO
    //[Test]
    //public async Task StreamingChat()
    //{
    //    ChatClient client = GetTestClient();

    //    TimeSpan? firstTokenReceiptTime = null;
    //    TimeSpan? latestTokenReceiptTime = null;
    //    Stopwatch stopwatch = Stopwatch.StartNew();

    //    StreamingClientResult<StreamingChatUpdate> streamingResult
    //        = client.CompleteChatStreaming("What are the best pizza toppings? Give me a breakdown on the reasons.");
    //    Assert.That(streamingResult, Is.InstanceOf<StreamingClientResult<StreamingChatUpdate>>());
    //    int updateCount = 0;
    //    ChatTokenUsage usage = null;

    //    await foreach (StreamingChatUpdate chatUpdate in streamingResult)
    //    {
    //        firstTokenReceiptTime ??= stopwatch.Elapsed;
    //        latestTokenReceiptTime = stopwatch.Elapsed;
    //        usage ??= chatUpdate.TokenUsage;
    //        updateCount++;
    //    }
    //    Assert.That(updateCount, Is.GreaterThan(1));
    //    Assert.That(latestTokenReceiptTime - firstTokenReceiptTime > TimeSpan.FromMilliseconds(500));
    //    Assert.That(usage, Is.Not.Null);
    //    Assert.That(usage?.InputTokens, Is.GreaterThan(0));
    //    Assert.That(usage?.OutputTokens, Is.GreaterThan(0));
    //    Assert.That(usage.InputTokens + usage.OutputTokens, Is.EqualTo(usage.TotalTokens));
    //}

    [Test]
    public void TwoTurnChat()
    {
        ChatClient client = GetTestClient();

        List<ChatMessage> messages =
        [
            new UserChatMessage("What are ten of the most common colors, including the brightest and darkest?"),
        ];
        ClientResult<ChatCompletion> firstResult = client.CompleteChat(messages);
        Assert.That(firstResult?.Value, Is.Not.Null);
        Assert.That(firstResult.Value.Content.ToString().ToLowerInvariant(), Contains.Substring("white"));
        Assert.That(firstResult.Value.Content.ToString().ToLowerInvariant(), Contains.Substring("black"));
        messages.Add(new AssistantChatMessage(firstResult.Value));
        messages.Add(new UserChatMessage("Which of those are considered brightest, aligning with hexadecimal rgb notation?"));
        ClientResult<ChatCompletion> secondResult = client.CompleteChat(messages);
        Assert.That(secondResult?.Value, Is.Not.Null);
        Assert.That(secondResult.Value.Content.ToString().ToLowerInvariant(), Contains.Substring("white"));
        Assert.That(secondResult.Value.Content.ToString().ToLowerInvariant(), Does.Not.Contains("black"));
    }

    [Test]
    public void AuthFailure()
    {
        ChatClient client = new("gpt-3.5-turbo", new ApiKeyCredential("not-a-real-key"));
        Exception caughtException = null;
        try
        {
            _ = client.CompleteChat([new UserChatMessage("Uh oh, this isn't going to work with that key")]);
        }
        catch (Exception ex)
        {
            caughtException = ex;
        }
        var clientResultException = caughtException as ClientResultException;
        Assert.That(clientResultException, Is.Not.Null);
        Assert.That(clientResultException.Status, Is.EqualTo((int)HttpStatusCode.Unauthorized));
    }

    [Test]
    [TestCase(true)]
    [TestCase(false)]
    public void SerializeChatToolChoiceAsString(bool fromRawJson)
    {
        ChatToolChoice choice;

        if (fromRawJson)
        {
            BinaryData data = BinaryData.FromString($"\"auto\"");

            // We deserialize the raw JSON. Later, we serialize it back and confirm nothing was lost in the process.
            choice = ModelReaderWriter.Read<ChatToolChoice>(data);
        }
        else
        {
            // We construct a new instance. Later, we serialize it and confirm it was constructed correctly.
            choice = ChatToolChoice.Auto;
        }

        BinaryData serializedChoice = ModelReaderWriter.Write(choice);
        using JsonDocument choiceAsJson = JsonDocument.Parse(serializedChoice);
        Assert.IsNotNull(choiceAsJson.RootElement);
        Assert.AreEqual(JsonValueKind.String, choiceAsJson.RootElement.ValueKind);
        Assert.AreEqual("auto", choiceAsJson.RootElement.ToString());
    }

    [Test]
    [TestCase(true)]
    [TestCase(false)]
    public void SerializeChatToolChoiceAsObject(bool fromRawJson)
    {
        const string functionName = "my_function_name";
        ChatToolChoice choice;

        if (fromRawJson)
        {
            BinaryData data = BinaryData.FromString($$"""
            {
                "type": "function",
                "function": {
                    "name": "{{functionName}}"
                },
                "additional_property": true
            }
            """);

            // We deserialize the raw JSON. Later, we serialize it back and confirm nothing was lost in the process.
            choice = ModelReaderWriter.Read<ChatToolChoice>(data);
        }
        else
        {
            // We construct a new instance. Later, we serialize it and confirm it was constructed correctly.
            choice = new ChatToolChoice(ChatTool.CreateFunctionTool(functionName));
        }

        BinaryData serializedChoice = ModelReaderWriter.Write(choice);
        using JsonDocument choiceAsJson = JsonDocument.Parse(serializedChoice);
        Assert.IsNotNull(choiceAsJson.RootElement);
        Assert.AreEqual(JsonValueKind.Object, choiceAsJson.RootElement.ValueKind);

        Assert.IsTrue(choiceAsJson.RootElement.TryGetProperty("type", out JsonElement typeProperty));
        Assert.IsNotNull(typeProperty);
        Assert.AreEqual(JsonValueKind.String, typeProperty.ValueKind);
        Assert.AreEqual("function", typeProperty.ToString());

        Assert.IsTrue(choiceAsJson.RootElement.TryGetProperty("function", out JsonElement functionProperty));
        Assert.IsNotNull(functionProperty);
        Assert.AreEqual(JsonValueKind.Object, functionProperty.ValueKind);

        Assert.IsTrue(functionProperty.TryGetProperty("name", out JsonElement functionNameProperty));
        Assert.IsNotNull(functionNameProperty);
        Assert.AreEqual(JsonValueKind.String, functionNameProperty.ValueKind);
        Assert.AreEqual(functionName, functionNameProperty.ToString());

        if (fromRawJson)
        {
            // Confirm that we also have the additional data.
            Assert.IsTrue(choiceAsJson.RootElement.TryGetProperty("additional_property", out JsonElement additionalPropertyProperty));
            Assert.IsNotNull(additionalPropertyProperty);
            Assert.AreEqual(JsonValueKind.True, additionalPropertyProperty.ValueKind);
        }
    }

    [Test]
    [TestCase(true)]
    [TestCase(false)]
    public void SerializeChatFunctionChoiceAsString(bool fromRawJson)
    {
        ChatFunctionChoice choice;

        if (fromRawJson)
        {
            BinaryData data = BinaryData.FromString($"\"auto\"");

            // We deserialize the raw JSON. Later, we serialize it back and confirm nothing was lost in the process.
            choice = ModelReaderWriter.Read<ChatFunctionChoice>(data);
        }
        else
        {
            // We construct a new instance. Later, we serialize it and confirm it was constructed correctly.
            choice = ChatFunctionChoice.Auto;
        }

        BinaryData serializedChoice = ModelReaderWriter.Write(choice);
        using JsonDocument choiceAsJson = JsonDocument.Parse(serializedChoice);
        Assert.IsNotNull(choiceAsJson.RootElement);
        Assert.AreEqual(JsonValueKind.String, choiceAsJson.RootElement.ValueKind);
        Assert.AreEqual("auto", choiceAsJson.RootElement.ToString());
    }

    [Test]
    [TestCase(true)]
    [TestCase(false)]
    public void SerializeChatFunctionChoiceAsObject(bool fromRawJson)
    {
        const string functionName = "my_function_name";
        ChatFunctionChoice choice;

        if (fromRawJson)
        {
            BinaryData data = BinaryData.FromString($$"""
            {
                "name": "{{functionName}}",
                "additional_property": true
            }
            """);

            // We deserialize the raw JSON. Later, we serialize it back and confirm nothing was lost in the process.
            choice = ModelReaderWriter.Read<ChatFunctionChoice>(data);
        }
        else
        {
            // We construct a new instance. Later, we serialize it and confirm it was constructed correctly.
            choice = new ChatFunctionChoice(new ChatFunction(functionName));
        }

        BinaryData serializedChoice = ModelReaderWriter.Write(choice);
        using JsonDocument choiceAsJson = JsonDocument.Parse(serializedChoice);
        Assert.IsNotNull(choiceAsJson.RootElement);
        Assert.AreEqual(JsonValueKind.Object, choiceAsJson.RootElement.ValueKind);

        Assert.IsTrue(choiceAsJson.RootElement.TryGetProperty("name", out JsonElement nameProperty));
        Assert.IsNotNull(nameProperty);
        Assert.AreEqual(JsonValueKind.String, nameProperty.ValueKind);
        Assert.AreEqual(functionName, nameProperty.ToString());

        if (fromRawJson)
        {
            // Confirm that we also have the additional data.
            Assert.IsTrue(choiceAsJson.RootElement.TryGetProperty("additional_property", out JsonElement additionalPropertyProperty));
            Assert.IsNotNull(additionalPropertyProperty);
            Assert.AreEqual(JsonValueKind.True, additionalPropertyProperty.ValueKind);
        }
    }

    [Test]
    [TestCase(true)]
    [TestCase(false)]
    public void SerializeChatMessageContentPartAsText(bool fromRawJson)
    {
        const string text = "Hello, world!";
        ChatMessageContentPart part;

        if (fromRawJson)
        {
            BinaryData data = BinaryData.FromString($$"""
                {
                    "type": "text",
                    "text": "{{text}}",
                    "additional_property": true
                }
                """);

            // We deserialize the raw JSON. Later, we serialize it back and confirm nothing was lost in the process.
            part = ModelReaderWriter.Read<ChatMessageContentPart>(data);
        }
        else
        {
            // We construct a new instance. Later, we serialize it and confirm it was constructed correctly.
            part = ChatMessageContentPart.CreateTextMessageContentPart(text);
        }

        BinaryData serializedPart = ModelReaderWriter.Write(part);
        using JsonDocument partAsJson = JsonDocument.Parse(serializedPart);
        Assert.IsNotNull(partAsJson.RootElement);
        Assert.AreEqual(JsonValueKind.Object, partAsJson.RootElement.ValueKind);

        Assert.IsTrue(partAsJson.RootElement.TryGetProperty("type", out JsonElement typeProperty));
        Assert.IsNotNull(typeProperty);
        Assert.AreEqual(JsonValueKind.String, typeProperty.ValueKind);
        Assert.AreEqual("text", typeProperty.ToString());

        Assert.IsTrue(partAsJson.RootElement.TryGetProperty("text", out JsonElement textProperty));
        Assert.IsNotNull(textProperty);
        Assert.AreEqual(JsonValueKind.String, textProperty.ValueKind);
        Assert.AreEqual(text, textProperty.ToString());

        if (fromRawJson)
        {
            // Confirm that we also have the additional data.
            Assert.IsTrue(partAsJson.RootElement.TryGetProperty("additional_property", out JsonElement additionalPropertyProperty));
            Assert.IsNotNull(additionalPropertyProperty);
            Assert.AreEqual(JsonValueKind.True, additionalPropertyProperty.ValueKind);
        }
    }

    [Test]
    [TestCase(true)]
    [TestCase(false)]
    public void SerializeChatMessageContentPartAsImageUri(bool fromRawJson)
    {
        const string uri = "https://avatars.githubusercontent.com/u/14957082";
        ChatMessageContentPart part;

        if (fromRawJson)
        {
            BinaryData data = BinaryData.FromString($$"""
                {
                    "type": "image_url",
                    "image_url": {
                        "url": "{{uri}}",
                        "detail": "high"
                    },
                    "additional_property": true
                }
                """);

            // We deserialize the raw JSON. Later, we serialize it back and confirm nothing was lost in the process.
            part = ModelReaderWriter.Read<ChatMessageContentPart>(data);
        }
        else
        {
            // We construct a new instance. Later, we serialize it and confirm it was constructed correctly.
            part = ChatMessageContentPart.CreateImageMessageContentPart(new Uri(uri), ImageChatMessageContentPartDetail.High);
        }

        BinaryData serializedPart = ModelReaderWriter.Write(part);
        using JsonDocument partAsJson = JsonDocument.Parse(serializedPart);
        Assert.IsNotNull(partAsJson.RootElement);
        Assert.AreEqual(JsonValueKind.Object, partAsJson.RootElement.ValueKind);

        Assert.IsTrue(partAsJson.RootElement.TryGetProperty("type", out JsonElement typeProperty));
        Assert.IsNotNull(typeProperty);
        Assert.AreEqual(JsonValueKind.String, typeProperty.ValueKind);
        Assert.AreEqual("image_url", typeProperty.ToString());

        Assert.IsTrue(partAsJson.RootElement.TryGetProperty("image_url", out JsonElement imageUrlProperty));
        Assert.IsNotNull(imageUrlProperty);
        Assert.AreEqual(JsonValueKind.Object, imageUrlProperty.ValueKind);

        Assert.IsTrue(imageUrlProperty.TryGetProperty("url", out JsonElement imageUrlUrlProperty));
        Assert.IsNotNull(imageUrlUrlProperty);
        Assert.AreEqual(JsonValueKind.String, imageUrlUrlProperty.ValueKind);
        Assert.AreEqual(uri, imageUrlUrlProperty.ToString());

        Assert.IsTrue(imageUrlProperty.TryGetProperty("detail", out JsonElement imageUrlDetailProperty));
        Assert.IsNotNull(imageUrlDetailProperty);
        Assert.AreEqual(JsonValueKind.String, imageUrlDetailProperty.ValueKind);
        Assert.AreEqual("high", imageUrlDetailProperty.ToString());

        if (fromRawJson)
        {
            // Confirm that we also have the additional data.
            Assert.IsTrue(partAsJson.RootElement.TryGetProperty("additional_property", out JsonElement additionalPropertyProperty));
            Assert.IsNotNull(additionalPropertyProperty);
            Assert.AreEqual(JsonValueKind.True, additionalPropertyProperty.ValueKind);
        }
    }

    [Test]
    [TestCase(true)]
    [TestCase(false)]
    public void SerializeChatMessageContentPartAsImageBytes(bool fromRawJson)
    {
        string imageMediaType = "image/png";
        string imageFilename = "variation_sample_image.png";
        string imagePath = Path.Combine("Assets", imageFilename);
        using Stream image = File.OpenRead(imagePath);

        BinaryData imageData = BinaryData.FromStream(image);
        string base64EncodedData = Convert.ToBase64String(imageData.ToArray());
        string dataUri = $"data:{imageMediaType};base64,{base64EncodedData}";

        ChatMessageContentPart part;

        if (fromRawJson)
        {
            BinaryData data = BinaryData.FromString($$"""
                {
                    "type": "image_url",
                    "image_url": {
                        "url": "{{dataUri}}",
                        "detail": "auto"
                    },
                    "additional_property": true
                }
                """);

            // We deserialize the raw JSON. Later, we serialize it back and confirm nothing was lost in the process.
            part = ModelReaderWriter.Read<ChatMessageContentPart>(data);

            // Confirm that we parsed the data URI correctly.
            Assert.AreEqual(imageMediaType, part.ImageBytesMediaType);
            Assert.AreEqual(imageData.ToArray(), part.ImageBytes.ToArray());
        }
        else
        {
            // We construct a new instance. Later, we serialize it and confirm it was constructed correctly.
            part = ChatMessageContentPart.CreateImageMessageContentPart(imageData, imageMediaType, ImageChatMessageContentPartDetail.Auto);
        }

        BinaryData serializedPart = ModelReaderWriter.Write(part);
        using JsonDocument partAsJson = JsonDocument.Parse(serializedPart);
        Assert.IsNotNull(partAsJson.RootElement);
        Assert.AreEqual(JsonValueKind.Object, partAsJson.RootElement.ValueKind);

        Assert.IsTrue(partAsJson.RootElement.TryGetProperty("type", out JsonElement typeProperty));
        Assert.IsNotNull(typeProperty);
        Assert.AreEqual(JsonValueKind.String, typeProperty.ValueKind);
        Assert.AreEqual("image_url", typeProperty.ToString());

        Assert.IsTrue(partAsJson.RootElement.TryGetProperty("image_url", out JsonElement imageUrlProperty));
        Assert.IsNotNull(imageUrlProperty);
        Assert.AreEqual(JsonValueKind.Object, imageUrlProperty.ValueKind);

        Assert.IsTrue(imageUrlProperty.TryGetProperty("url", out JsonElement imageUrlUrlProperty));
        Assert.IsNotNull(imageUrlUrlProperty);
        Assert.AreEqual(JsonValueKind.String, imageUrlUrlProperty.ValueKind);
        Assert.AreEqual(dataUri, imageUrlUrlProperty.ToString());

        Assert.IsTrue(imageUrlProperty.TryGetProperty("detail", out JsonElement imageUrlDetailProperty));
        Assert.IsNotNull(imageUrlDetailProperty);
        Assert.AreEqual(JsonValueKind.String, imageUrlDetailProperty.ValueKind);
        Assert.AreEqual("auto", imageUrlDetailProperty.ToString());

        if (fromRawJson)
        {
            // Confirm that we also have the additional data.
            Assert.IsTrue(partAsJson.RootElement.TryGetProperty("additional_property", out JsonElement additionalPropertyProperty));
            Assert.IsNotNull(additionalPropertyProperty);
            Assert.AreEqual(JsonValueKind.True, additionalPropertyProperty.ValueKind);
        }
    }

    private static ChatClient GetTestClient(string overrideModel = null) => GetTestClient<ChatClient>(TestScenario.Chat, overrideModel);
}
