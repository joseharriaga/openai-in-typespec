using NUnit.Framework;

#region usings
using System;

using OpenAI.Embeddings;
#endregion

namespace OpenAI.Docs.ApiReference;
public partial class CreateEmbeddingsApiReference {

    [Test]
    public void CreateEmbeddings()
    {
		#region logic

		EmbeddingClient client = new(
		    model: "text-embedding-3-small", 
		    apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY")
		);
		
		string description = "The quick brown fox jumped over the lazy dog";
		client.GenerateEmbedding(description);
		
		#endregion
	}
}
