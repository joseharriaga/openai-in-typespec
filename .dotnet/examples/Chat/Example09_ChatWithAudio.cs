﻿using NUnit.Framework;
using OpenAI.Chat;
using System;
using System.Collections.Generic;
using System.IO;

namespace OpenAI.Examples;

public partial class ChatExamples
{
    [Test]
    public void Example09_ChatWithAudio()
    {
        // Chat audio input and output is only supported on specific models, beginning with gpt-4o-audio-preview
        ChatClient client = new("gpt-4o-audio-preview", Environment.GetEnvironmentVariable("OPENAI_API_KEY"));

        // Input audio is provided to a request by adding an audio content part to a user message
        string audioFilePath = Path.Combine("Assets", "whats_the_weather_pcm16_24khz_mono.wav");
        byte[] audioFileRawBytes = File.ReadAllBytes(audioFilePath);
        BinaryData audioData = BinaryData.FromBytes(audioFileRawBytes);
        List<ChatMessage> messages =
            [
                new UserChatMessage(ChatMessageContentPart.CreateAudioPart(audioData, ChatInputAudioFormat.Wav)),
            ];

        // Output audio is requested by configuring AudioOptions on ChatCompletionOptions
        ChatCompletionOptions options = new()
        {
            AudioOptions = new(ChatResponseVoice.Alloy, ChatOutputAudioFormat.Mp3),
        };

        ChatCompletion completion = client.CompleteChat(messages, options);

        void PrintAudioContent()
        {
            foreach (ChatMessageContentPart contentPart in completion.Content)
            {
                if (contentPart.AudioCorrelationId is not null)
                {
                    Console.WriteLine($"Response audio transcript: {contentPart.AudioTranscript}");

                    string outputFilePath = $"{contentPart.AudioCorrelationId}.mp3";
                    using (FileStream outputFileStream = File.OpenWrite(outputFilePath))
                    {
                        outputFileStream.Write(contentPart.AudioBytes);
                    }
                    Console.WriteLine($"Response audio written to file: {outputFilePath}");
                    Console.WriteLine($"Valid on followup requests until: {contentPart.AudioExpiresAt}");
                }
            }
        }

        PrintAudioContent();

        // To refer to past audio output, create an assistant message from the earlier ChatCompletion, use the earlier
        // response content part, or use ChatMessageContentPart.CreateAudioPart(string) to manually instantiate a part.

        messages.Add(new AssistantChatMessage(completion));
        messages.Add("Can you say that like a pirate?");

        completion = client.CompleteChat(messages, options);

        PrintAudioContent();
    }
}