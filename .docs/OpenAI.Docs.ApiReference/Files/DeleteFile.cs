using NUnit.Framework;

#region usings
using System;
using System.ClientModel;

using OpenAI.Files;
#endregion

namespace OpenAI.Docs.ApiReference;
public partial class DeleteFileApiReference {

    [Test]
    public void DeleteFile()
    {
        #region logic

        OpenAIFileClient client = new(Environment.GetEnvironmentVariable("OPENAI_API_KEY"));
		ClientResult fileContents = client.DeleteFile("file-abc123");

        #endregion
    }
}
