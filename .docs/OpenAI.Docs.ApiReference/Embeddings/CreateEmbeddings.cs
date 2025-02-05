using NUnit.Framework;

#region usings
using System;

using OpenAI.Embeddings;
#endregion

namespace OpenAI.Docs.ApiReference;

public partial class EmbeddingDocs
{
    [Test]
    public void CreateEmbeddings()
    {
        #region logic

        EmbeddingClient client = new(
            model: "text-embedding-3-small",
            apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY")
        );

        OpenAIEmbedding embedding = client.GenerateEmbedding(input: "The quick brown fox jumped over the lazy dog");
        ReadOnlyMemory<float> vector = embedding.ToFloats();

        for (int i = 0; i < vector.Length; i++)
        {
            Console.WriteLine($"  [{i,4}] = {vector.Span[i]}");
        }

        #endregion
    }
}
