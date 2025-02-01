using NUnit.Framework;

#region usings
using System;

using OpenAI.Images;
#endregion

namespace OpenAI.Docs.ApiReference;
public partial class CreateImageVariationApiReference {

    [Test]
    public void CreateImageVariation()
    {
        #region logic

        ImageClient client = new(
            model: "dall-e-2",
            apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY")
        );

        var image = client.GenerateImageVariation(
		    "otter.png",
		    new ImageVariationOptions () 
            { 
		        Size = GeneratedImageSize.W1024xH1024 
		    }
		);
		
		Console.WriteLine(image.Value.ImageUri);
        
        #endregion
    }
}
