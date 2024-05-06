// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.OpenAI;
using Azure.AI.OpenAI.Embeddings;
using OpenAI.Chat;
using OpenAI.Embeddings;
using System.ClientModel;

namespace Azure.AI.OpenAI.Tests;

public class EmbeddingTests
{
    [Test]
    public void SimpleEmbeddingWithTopLevelClient()
    {
        AzureOpenAIClient client = new();
        EmbeddingClient embeddingClient = client.GetEmbeddingClient("text-embedding-3-small");
        ClientResult<Embedding> embeddingResult = embeddingClient.GenerateEmbedding("sample text to embed");
        Assert.That(embeddingResult?.Value?.Vector.Length, Is.GreaterThan(0));
    }

}