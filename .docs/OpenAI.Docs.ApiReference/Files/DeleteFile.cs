using NUnit.Framework;

#region usings
using System;

using OpenAI;
using OpenAI.Files;
#endregion

namespace OpenAI.Docs.ApiReference;
public partial class DeleteFileApiReference {

    [Test]
    public void DeleteFile()
    {
		OpenAIClient client = new(Environment.GetEnvironmentVariable("OPENAI_API_KEY"));
		
		var fileContents = client.GetOpenAIFileClient().DeleteFile("file-abc123");
	}
}
