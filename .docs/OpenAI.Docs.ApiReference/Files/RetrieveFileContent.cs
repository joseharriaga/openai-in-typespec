using NUnit.Framework;

#region usings
using System;

using OpenAI;
using OpenAI.Files;
#endregion

namespace OpenAI.Docs.ApiReference;
public partial class RetrieveFileContentApiReference {

    [Test]
    public void RetrieveFileContent()
    {
        #region logic
        OpenAIClient client = new(Environment.GetEnvironmentVariable("OPENAI_API_KEY"));
		var fileContents = client.GetOpenAIFileClient().DownloadFile("file-abc123");
        #endregion
    }
}
