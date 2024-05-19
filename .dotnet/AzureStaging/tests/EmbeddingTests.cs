// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.OpenAI;
using Azure.AI.OpenAI.Embeddings;
using OpenAI.Chat;
using OpenAI.Embeddings;
using System.ClientModel;

namespace Azure.AI.OpenAI.Tests;

public class EmbeddingTests : TestBase<EmbeddingClient>
{
    [Test]
    [Category("Smoke")]
    public void CanCreateClient() => Assert.That(GetTestClient(), Is.InstanceOf<EmbeddingClient>());

    [Test]
    public void SimpleEmbeddingWithTopLevelClient()
    {
        EmbeddingClient embeddingClient = GetTestClient();
        ClientResult<Embedding> embeddingResult = embeddingClient.GenerateEmbedding("sample text to embed");
        Assert.That(embeddingResult?.Value?.Vector.Length, Is.GreaterThan(0));
    }
}