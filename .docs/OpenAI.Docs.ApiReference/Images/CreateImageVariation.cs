using System;
using NUnit.Framework;


using OpenAI;
using OpenAI.Images;

namespace OpenAI.Docs.ApiReference;
public partial class CreateImageVariationApiReference {

    [Test]
    public void CreateImageVariation()
    {
		OpenAIClient client = new(Environment.GetEnvironmentVariable("OPENAI_API_KEY"));
		
		var image = client.GetImageClient("dall-e-2").GenerateImageVariation(
		    "otter.png",
		    new () { 
		        Size = GeneratedImageSize.W1024xH1024 
		    }
		);
		
		Console.WriteLine(image.Value.ImageUri);
	}
}
