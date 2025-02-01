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

        OpenAIClient client = new(Environment.GetEnvironmentVariable("OPENAI_API_KEY"));
		
		string filePath = "C:\\Users\\angelpe\\source\\github\\openai-dotnet-samples\\platform.openai.com\\UploadFile\\monthly_sales.json";
		BinaryData file = BinaryData.FromBytes(File.ReadAllBytes(filePath));
		
		Console.WriteLine(Path.GetFileName(filePath));
		
		OpenAIFile fileInfo = client.GetOpenAIFileClient().UploadFile(
		    filePath,
		    FileUploadPurpose.Assistants);
		
		Console.WriteLine(fileInfo);
		
		#endregion
	}
}
