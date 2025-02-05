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
    public void RetrieveFile()
    {
        try
        {
            #region logic

            OpenAIFileClient client = new(
                apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY")
            );

            ClientResult<OpenAIFile> file = client.GetFile("file-abc123");
            Console.WriteLine($"{file.Value.Filename} ({file.Value.Id})");

            #endregion
        }
        catch (ClientResultException ex)
        {
            Assert.IsTrue(ex.Message == "HTTP 404 (invalid_request_error: )\r\nParameter: id\r\n\r\nNo such File object: file-abc123");
        }
    }
}
