using System;
using NUnit.Framework;


using OpenAI.Embeddings;

namespace OpenAI.Docs.ApiReference;
public partial class CreateEmbeddingsApiReference {

    [Test]
    public void CreateEmbeddings()
    {
		EmbeddingClient client = new(
		    model: "text-embedding-3-small", 
		    Environment.GetEnvironmentVariable("OPENAI_API_KEY")
		);
		
		string description = "The quick brown fox jumped over the lazy dog";
		client.GenerateEmbedding(description);
	}
}
