using NUnit.Framework;

#region usings
using System;
using System.ClientModel;

using OpenAI.Files;
#endregion

namespace OpenAI.Docs.ApiReference;

public partial class FileDocs
{
    [Test]
    public void RetrieveFileContent()
    {
        try
        {
            #region logic

            OpenAIFileClient client = new(
                apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY")
            );

            ClientResult<BinaryData> fileContents = client.DownloadFile("file-abc123");

            #endregion
        }
        catch (ClientResultException ex)
        {
            Assert.IsTrue(ex.Message == "HTTP 404 (invalid_request_error: )\r\nParameter: id\r\n\r\nNo such File object: file-abc123");
        }
    }
}
