using NUnit.Framework;

#region usings
using System;

using OpenAI;
using OpenAI.Files;
#endregion

namespace OpenAI.Docs.ApiReference;
public partial class RetrieveFileApiReference {

    [Test]
    public void RetrieveFile()
    {
        #region logic
        
        OpenAIClient client = new(Environment.GetEnvironmentVariable("OPENAI_API_KEY"));
		
		var file = client.GetOpenAIFileClient().GetFile("file-abc123");
		Console.WriteLine($"{file.Value.Filename} ({file.Value.Id})");
        
        #endregion
    }
}
