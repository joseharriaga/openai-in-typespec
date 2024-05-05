﻿using OpenAI.Assistants;
using OpenAI.Audio;
using OpenAI.Chat;
using OpenAI.Embeddings;
using OpenAI.Files;
using OpenAI.Images;
using System;
using System.ClientModel.Primitives;
using System.IO;

namespace OpenAI.Tests;

internal static class TestHelpers
{
    public enum TestScenario
    {
        Assistants,
        TextToSpeech,
        Chat,
        VisionChat,
        Files,
        Embeddings,
        FineTuning,
        Images,
        Transcription,
        Models,
        LegacyCompletions,
        Moderations,
    }

    public static T GetTestClient<T>(TestScenario scenario, string overrideModel = null)
    {
        OpenAIClientOptions options = new();
        options.AddPolicy(GetDumpPolicy(), PipelinePosition.PerTry);
        object clientObject = scenario switch
        {
            TestScenario.Chat => new ChatClient(overrideModel ?? "gpt-3.5-turbo", options),
            TestScenario.VisionChat => new ChatClient(overrideModel ?? "gpt-4-vision-preview", options),
            TestScenario.Embeddings => new EmbeddingClient(overrideModel ?? "text-embedding-3-small", options),
#pragma warning disable OPENAI001
            TestScenario.Assistants => new AssistantClient(options),
#pragma warning restore OPENAI001
            TestScenario.Images => new ImageClient(overrideModel ?? "dall-e-3", options),
            TestScenario.Files => new FileClient(options),
            TestScenario.Transcription => new AudioClient(overrideModel ?? "whisper-1", options),
            _ => throw new NotImplementedException(),
        };
        return (T)clientObject;
    }

    private static PipelinePolicy GetDumpPolicy()
    {
        return new TestPipelinePolicy((message) =>
        {
            if (message.Request?.Uri != null)
            {
                Console.WriteLine($"--- Request URI: ---");
                Console.WriteLine(message.Request.Uri.AbsoluteUri);
            }
            if (message.Request?.Content != null)
            {
                Console.WriteLine($"--- Begin request content ---");
                using MemoryStream stream = new();
                message.Request.Content.WriteTo(stream, default);
                stream.Position = 0;
                using StreamReader reader = new(stream);
                Console.WriteLine(reader.ReadToEnd());
                Console.WriteLine("--- End of request content ---");
            }
            if (message.Response != null)
            {
                Console.WriteLine("--- Begin response content ---");
                Console.WriteLine(message.Response.Content?.ToString());
                Console.WriteLine("--- End of response content ---");
            }
        });
    }
}