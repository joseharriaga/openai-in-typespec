using System;
using NUnit.Framework;


using OpenAI;

namespace OpenAI.Docs.ApiReference;
public partial class ListFilesApiReference {

    [Test]
    public void ListFiles()
    {
		OpenAIClient client = new(Environment.GetEnvironmentVariable("OPENAI_API_KEY"));
		
		var files = client.GetOpenAIFileClient().GetFiles();
		foreach (var file in files.Value) {
		    Console.WriteLine($"{file.Filename} ({file.Id})");
		}
	}
}
