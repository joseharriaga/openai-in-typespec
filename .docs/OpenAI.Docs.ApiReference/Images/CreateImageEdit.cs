using NUnit.Framework;

#region usings
using System;

using OpenAI;
#endregion

namespace OpenAI.Docs.ApiReference;
public partial class CreateImageEditApiReference {

    [Test]
    public void CreateImageEdit()
    {
		OpenAIClient client = new(Environment.GetEnvironmentVariable("OPENAI_API_KEY"));
		
		var image = client.GetImageClient("dall-e-2").GenerateImageEdit(
		    "otter.png", 
		    "A cute baby sea otter wearing a beret",
		    "mask.png"
		);
		
		Console.WriteLine(image.Value.ImageUri);
	}
}
