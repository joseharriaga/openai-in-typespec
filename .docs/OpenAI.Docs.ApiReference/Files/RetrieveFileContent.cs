using System;
using NUnit.Framework;


using OpenAI;

namespace OpenAI.Docs.ApiReference;
public partial class RetrieveFileContentApiReference {

    [Test]
    public void RetrieveFileContent()
    {
		OpenAIClient client = new(Environment.GetEnvironmentVariable("OPENAI_API_KEY"));
		
		var fileContents = client.GetOpenAIFileClient().DownloadFile("file-abc123");
	}
}
