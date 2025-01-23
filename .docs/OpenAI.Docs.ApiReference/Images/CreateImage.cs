using System;
using NUnit.Framework;


using OpenAI;

namespace OpenAI.Docs.ApiReference;
public partial class CreateImageApiReference {

    [Test]
    public void CreateImage()
    {
		OpenAIClient client = new(Environment.GetEnvironmentVariable("OPENAI_API_KEY"));
		
		var image = client.GetImageClient("dall-e-3").GenerateImage("A cute little sea otter.");
		Console.WriteLine(image.Value.ImageUri);
	}
}
