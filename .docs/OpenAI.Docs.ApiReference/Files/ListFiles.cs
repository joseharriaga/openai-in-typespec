using NUnit.Framework;

#region usings
using System;
using System.ClientModel;

using OpenAI.Files;
#endregion

namespace OpenAI.Docs.ApiReference;
public partial class ListFilesApiReference {

    [Test]
    public void ListFiles()
    {
        #region logic

        OpenAIFileClient client = new(
            apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY")
        );

        ClientResult<OpenAIFileCollection> files = client.GetFiles();
		foreach (var file in files.Value) 
        {
		    Console.WriteLine($"{file.Filename} ({file.Id})");
		}

        #endregion
    }
}
