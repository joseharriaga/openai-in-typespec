using System;
using NUnit.Framework;


using OpenAI;
using OpenAI.Files;

namespace OpenAI.Docs.ApiReference;
public partial class RetrieveFileApiReference {

    [Test]
    public void RetrieveFile()
    {
		OpenAIClient client = new(Environment.GetEnvironmentVariable("OPENAI_API_KEY"));
		
		var file = client.GetOpenAIFileClient().GetFile("file-abc123");
		Console.WriteLine($"{file.Value.Filename} ({file.Value.Id})");
	}
}
