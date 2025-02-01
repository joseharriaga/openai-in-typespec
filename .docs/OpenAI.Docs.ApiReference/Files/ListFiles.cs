using NUnit.Framework;

#region usings
using System;

using OpenAI;
using OpenAI.Files;
#endregion

namespace OpenAI.Docs.ApiReference;
public partial class ListFilesApiReference {

    [Test]
    public void ListFiles()
    {
        #region logic
        
        OpenAIClient client = new(Environment.GetEnvironmentVariable("OPENAI_API_KEY"));

        var files = client.GetOpenAIFileClient().GetFiles();
		foreach (var file in files.Value) 
        {
		    Console.WriteLine($"{file.Filename} ({file.Id})");
		}

        #endregion
    }
}
