using System;
using System.ClientModel;
using NUnit.Framework;
using OpenAI.Embeddings;
using System.Collections.Generic;
using System.Threading.Tasks;
using static OpenAI.Tests.TestHelpers;

namespace OpenAI.Tests.Embeddings;

public partial class EmbeddingTests
{
    [Test]
    public async Task GenerateSingleEmbedding()
    {
        EmbeddingClient client = new("text-embedding-3-small");

        Embedding embedding = await client.GenerateEmbeddingAsync("hello, world");
        Assert.IsNotNull(embedding);
        Assert.AreEqual(0, embedding.Index);
        Assert.IsNotNull(embedding.Vector);
        Assert.AreEqual(1536, embedding.Vector.Span.Length);
        
        float[] array = embedding.Vector.ToArray();
        Assert.AreEqual(1536, array.Length);
    }

    [Test]
    public async Task GenerateMultipleEmbeddings()
    {
        EmbeddingClient client = new("text-embedding-3-small");

        const int Dimensions = 456;

        List<string> prompts =
        [
            "Hello, world!",
            "This is a test.",
            "Goodbye!"
        ];

        EmbeddingOptions options = new()
        {
            Dimensions = Dimensions,
        };

        EmbeddingCollection embeddings = await client.GenerateEmbeddingsAsync(prompts, options);
        Assert.IsNotNull(embeddings);
        Assert.AreEqual(3, embeddings.Count);
        Assert.AreEqual("text-embedding-3-small", embeddings.Model);
        Assert.Greater(embeddings.Usage.InputTokens, 0);
        Assert.Greater(embeddings.Usage.TotalTokens, 0);

        for (int i = 0; i < embeddings.Count; i++)
        {
            Assert.AreEqual(i, embeddings[i].Index);
            Assert.NotNull(embeddings[i].Vector);
            Assert.AreEqual(Dimensions, embeddings[i].Vector.Span.Length);

            float[] array = embeddings[i].Vector.ToArray();
            Assert.AreEqual(Dimensions, array.Length);
        }
    }

    [Test]
    public void BadOptions()
    {
        EmbeddingClient client = GetTestClient();
        Exception caughtException = null;
        try
        {
            client.GenerateEmbedding("foo", new EmbeddingOptions()
            {
                Dimensions = -42,
            });
        }
        catch (Exception ex)
        {
            caughtException = ex;
        }
        Assert.That(caughtException, Is.InstanceOf<ClientResultException>());
        Assert.That(caughtException.Message, Contains.Substring("dimensions"));
    }

    [Test]
    public void SerializeEmbeddingCollection()
    {
        // TODO: Add this test.
    }

    private static EmbeddingClient GetTestClient() => GetTestClient<EmbeddingClient>(TestScenario.Embeddings);
}
