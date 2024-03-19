﻿using NUnit.Framework;
using OpenAI.Assistants;
using OpenAI.Audio;
using OpenAI.Chat;
using OpenAI.Embeddings;
using OpenAI.Files;
using OpenAI.Images;
using System.ClientModel;

namespace OpenAI.Samples.Miscellaneous
{
    public partial class ClientSamples
    {
        [Test]
        [Ignore("Compilation validation only")]
        public void CreateAssistantAndFileClients()
        {
            OpenAIClient openAIClient = new("<insert your OpenAI API key here>");
            FileClient fileClient = openAIClient.GetFileClient();
#pragma warning disable OPENAI001
            AssistantClient assistantClient = openAIClient.GetAssistantClient();
#pragma warning restore OPENAI001
        }

        [Test]
        [Ignore("Compilation validation only")]
        public void CreateChatClient()
        {
            ChatClient client = new("gpt-3.5-turbo", "<insert your OpenAI API key here>");
        }

        [Test]
        [Ignore("Compilation validation only")]
        public void CreateEmbeddingClient()
        {
            EmbeddingClient client = new("text-embedding-3-small", new ApiKeyCredential("<insert your OpenAI API key here>"));
        }

        [Test]
        [Ignore("Compilation validation only")]
        public void CreateImageClient()
        {
            ImageClient client = new("dall-e-3", "<insert your OpenAI API key here>");
        }

        [Test]
        [Ignore("Compilation validation only")]
        public void CreateMultipleAudioClients()
        {
            OpenAIClient client = new("<insert your OpenAI API key here>");
            AudioClient ttsClient = client.GetAudioClient("tts-1");
            AudioClient whisperClient = client.GetAudioClient("whisper-1");
        }
    }
}
