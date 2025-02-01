using NUnit.Framework;

#region usings
using System;
using System.IO;

using OpenAI;
using OpenAI.Files;
#endregion

namespace OpenAI.Docs.ApiReference;
public partial class UploadFileApiReference {

    [Test]
    public void UploadFile()
    {
        #region logic

        OpenAIFileClient client = new(
            apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY")
        );
	
		OpenAIFile fileInfo = client.UploadFile("monthly_sales.json", FileUploadPurpose.Assistants);
		
		Console.WriteLine(fileInfo);
		
		#endregion
	}
}
