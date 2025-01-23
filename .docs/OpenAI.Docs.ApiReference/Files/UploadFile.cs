using System;
using NUnit.Framework;


using System.IO;
using OpenAI;
using OpenAI.Files;

namespace OpenAI.Docs.ApiReference;
public partial class UploadFileApiReference {

    [Test]
    public void UploadFile()
    {
		OpenAIClient client = new(Environment.GetEnvironmentVariable("OPENAI_API_KEY"));
		
		var fileName = "monthly_sales.json";
		var filePath = "C:\\Users\\angelpe\\source\\github\\openai-dotnet-samples\\platform.openai.com\\UploadFile\\monthly_sales.json";
		var file = BinaryData.FromBytes(File.ReadAllBytes(filePath));
		
		//OpenAIFile fileInfo = client.GetOpenAIFileClient().UploadFile(
		//    file,
		//    fileName,
		//    FileUploadPurpose.Assistants);
		
		Console.WriteLine(Path.GetFileName(filePath));
		
		OpenAIFile fileInfo = client.GetOpenAIFileClient().UploadFile(
		    filePath,
		    FileUploadPurpose.Assistants);
		
		Console.WriteLine(fileInfo);
	}
}
