using System;
using System.ClientModel;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenAI.Chat;
using OpenAI.Images;
using OpenAI.TestFramework;
using OpenAI.Tests.Utility;

namespace OpenAI.Tests.Images;

[Category("Images")]
public class ImageGenerationTests(bool isAsync) : OpenAiTestBase(isAsync)
{
    [RecordedTest]
    public async Task BasicGenerationWorks()
    {
        ImageClient client = GetTestClient<ImageClient>();

        string prompt = "An isolated stop sign.";

        GeneratedImage image = await client.GenerateImageAsync(prompt);
        Assert.That(image.ImageUri, Is.Not.Null);
        Assert.That(image.ImageBytes, Is.Null);

        Console.WriteLine(image.ImageUri.AbsoluteUri);
        await ValidateGeneratedImageAsync(image.ImageUri, "stop");
    }

    [RecordedTest]
    public async Task GenerationWithOptionsWorks()
    {
        ImageClient client = GetTestClient<ImageClient>();

        string prompt = "An isolated stop sign.";

        ImageGenerationOptions options = new()
        {
            Quality = GeneratedImageQuality.Standard,
            Style = GeneratedImageStyle.Natural,
        };

        GeneratedImage image = await client.GenerateImageAsync(prompt, options);
        Assert.That(image.ImageUri, Is.Not.Null);
    }

    [RecordedTest]
    public async Task GenerationWithBytesResponseWorks()
    {
        ImageClient client = GetTestClient<ImageClient>();

        string prompt = "An isolated stop sign.";

        ImageGenerationOptions options = new()
        {
            ResponseFormat = GeneratedImageFormat.Bytes
        };

        GeneratedImage image = await client.GenerateImageAsync(prompt, options);
        Assert.That(image.ImageUri, Is.Null);
        Assert.That(image.ImageBytes, Is.Not.Null);

        await ValidateGeneratedImageAsync(image.ImageBytes, "stop");
    }

    [RecordedTest]
    public async Task GenerateImageEditWorks()
    {
        ImageClient client = GetTestClient<ImageClient>("dall-e-2");

        string prompt = "A big cat with big, round eyes sitting in an empty room and looking at the camera.";
        string maskImagePath = Path.Combine("Assets", "images_empty_room_with_mask.png");

        GeneratedImage image = await client.GenerateImageEditAsync(maskImagePath, prompt);
        Assert.That(image.ImageUri, Is.Not.Null);
        Assert.That(image.ImageBytes, Is.Null);

        Console.WriteLine(image.ImageUri.AbsoluteUri);

        await ValidateGeneratedImageAsync(image.ImageUri, "cat");
    }

    [RecordedTest]
    public async Task GenerateImageEditWithMaskFileWorks()
    {
        ImageClient client = GetTestClient<ImageClient>("dall-e-2");

        string prompt = "A big cat with big, round eyes sitting in an empty room and looking at the camera.";
        string originalImagePath = Path.Combine("Assets", "images_empty_room.png");
        string maskImagePath = Path.Combine("Assets", "images_empty_room_with_mask.png");

        GeneratedImage image = await client.GenerateImageEditAsync(originalImagePath, prompt, maskImagePath);
        Assert.That(image.ImageUri, Is.Not.Null);
        Assert.That(image.ImageBytes, Is.Null);

        Console.WriteLine(image.ImageUri.AbsoluteUri);

        await ValidateGeneratedImageAsync(image.ImageUri, "cat");
    }

    [RecordedTest]
    public async Task GenerateImageEditWithBytesResponseWorks()
    {
        ImageClient client = GetTestClient<ImageClient>("dall-e-2");

        string prompt = "A big cat with big, round eyes sitting in an empty room and looking at the camera.";
        string maskImagePath = Path.Combine("Assets", "images_empty_room_with_mask.png");

        ImageEditOptions options = new()
        {
            ResponseFormat = GeneratedImageFormat.Bytes
        };

        GeneratedImage image = await client.GenerateImageEditAsync(maskImagePath, prompt, options);
        Assert.That(image.ImageUri, Is.Null);
        Assert.That(image.ImageBytes, Is.Not.Null);

        await ValidateGeneratedImageAsync(image.ImageBytes, "cat", "Note that it likely depicts some sort of animal.");
    }

    [RecordedTest]
    public async Task GenerateImageVariationWorks()
    {
        ImageClient client = GetTestClient<ImageClient>("dall-e-2");
        string imagePath = Path.Combine("Assets", "images_dog_and_cat.png");

        GeneratedImage image = await client.GenerateImageVariationAsync(imagePath);
        Assert.That(image.ImageUri, Is.Not.Null);
        Assert.That(image.ImageBytes, Is.Null);

        Console.WriteLine(image.ImageUri.AbsoluteUri);

        await ValidateGeneratedImageAsync(image.ImageUri, "cat", "Note that it likely depicts some sort of animal.");
    }

    [RecordedTest]
    public async Task GenerateImageVariationWithBytesResponseWorks()
    {
        ImageClient client = GetTestClient<ImageClient>("dall-e-2");
        string imagePath = Path.Combine("Assets", "images_dog_and_cat.png");

        ImageVariationOptions options = new()
        {
            ResponseFormat = GeneratedImageFormat.Bytes
        };

        GeneratedImage image = await client.GenerateImageVariationAsync(imagePath, options);
        Assert.That(image.ImageUri, Is.Null);
        Assert.That(image.ImageBytes, Is.Not.Null);

        await ValidateGeneratedImageAsync(image.ImageBytes, "cat", "Note that it likely depicts some sort of animal.");
    }

    private async Task ValidateGeneratedImageAsync(Uri imageUri, string expectedSubstring, string descriptionHint = null)
    {
        ChatClient chatClient = GetTestClient<ChatClient>("gpt-4o");
        IEnumerable<ChatMessage> messages = [
            new UserChatMessage(
                ChatMessageContentPart.CreateTextMessageContentPart($"Describe this image for me. {descriptionHint}"),
                ChatMessageContentPart.CreateImageMessageContentPart(imageUri)),
        ];
        ChatCompletionOptions chatOptions = new() { MaxTokens = 2048 };
        ClientResult<ChatCompletion> result = await chatClient.CompleteChatAsync(messages, chatOptions);

        Assert.That(result.Value.Content[0].Text.ToLowerInvariant(), Contains.Substring(expectedSubstring));
    }

    private async Task ValidateGeneratedImageAsync(BinaryData imageBytes, string expectedSubstring, string descriptionHint = null)
    {
        ChatClient chatClient = GetTestClient<ChatClient>();
        IEnumerable<ChatMessage> messages = [
            new UserChatMessage(
                ChatMessageContentPart.CreateTextMessageContentPart($"Describe this image for me. {descriptionHint}"),
                ChatMessageContentPart.CreateImageMessageContentPart(imageBytes, "image/png")),
        ];
        ChatCompletionOptions chatOptions = new() { MaxTokens = 2048 };
        ClientResult<ChatCompletion> result = await chatClient.CompleteChatAsync(messages, chatOptions);

        Assert.That(result.Value.Content[0].Text.ToLowerInvariant(), Contains.Substring(expectedSubstring));
    }
}
