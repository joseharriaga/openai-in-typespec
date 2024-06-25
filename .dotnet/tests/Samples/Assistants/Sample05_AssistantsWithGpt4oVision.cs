﻿using NUnit.Framework;
using OpenAI.Assistants;
using OpenAI.Files;
using System;
using System.ClientModel;
using System.Threading.Tasks;

namespace OpenAI.Samples;
public partial class AssistantSamples
{
    [Test]
    [Ignore("Compilation validation only")]
    public void Sample05_AssistantsWithGpt4oVision()
    {
        // Assistants is a beta API and subject to change; acknowledge its experimental status by suppressing the matching warning.
#pragma warning disable OPENAI001
        OpenAIClient openAIClient = new(
            // This is the default key used and the line can be omitted
            Environment.GetEnvironmentVariable("OPENAI_API_KEY"));
        FileClient fileClient = openAIClient.GetFileClient();
        AssistantClient assistantClient = openAIClient.GetAssistantClient();

        OpenAIFileInfo pictureOfAppleFile = fileClient.UploadFile(
            "picture-of-apple.jpg",
            FileUploadPurpose.Vision);
        Uri linkToPictureOfOrange = new("https://platform.openai.com/fictitious-files/picture-of-orange.png");

        Assistant assistant = assistantClient.CreateAssistant(
            "gpt-4o",
            new AssistantCreationOptions()
            {
                Instructions = "When asked a question, attempt to answer very concisely. "
                    + "Prefer one-sentence answers whenever feasible."
            });

        AssistantThread thread = assistantClient.CreateThread(new ThreadCreationOptions()
        {
            InitialMessages =
                {
                    new ThreadInitializationMessage(
                        [
                            "Hello, assistant! Please compare these two images for me:",
                            MessageContent.FromImageFileId(pictureOfAppleFile.Id),
                            MessageContent.FromImageUrl(linkToPictureOfOrange),
                        ]),
                }
        });

        ResultCollection<StreamingUpdate> streamingUpdates = assistantClient.CreateRunStreaming(
            thread,
            assistant,
            new RunCreationOptions()
            {
                AdditionalInstructions = "When possible, try to sneak in puns if you're asked to compare things.",
            });

        foreach (StreamingUpdate streamingUpdate in streamingUpdates)
        {
            if (streamingUpdate.UpdateKind == StreamingUpdateReason.RunCreated)
            {
                Console.WriteLine($"--- Run started! ---");
            }
            if (streamingUpdate is MessageContentUpdate contentUpdate)
            {
                Console.Write(contentUpdate.Text);
            }
        }

        // Delete temporary resources, if desired
        _ = fileClient.DeleteFile(pictureOfAppleFile);
        _ = assistantClient.DeleteThread(thread);
        _ = assistantClient.DeleteAssistant(assistant);
    }
}
