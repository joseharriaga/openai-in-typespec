using NUnit.Framework;

#region usings
using System;

using OpenAI.Images;
#endregion

namespace OpenAI.Docs.ApiReference;
public partial class CreateImageApiReference {

    [Test]
    public void CreateImage()
    {
        #region logic

        ImageClient client = new(
            model: "dall-e-3",
            apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY")
		);
		
		var image = client.GenerateImage("A cute little sea otter.");
		Console.WriteLine(image.Value.ImageUri);
        
        #endregion
    }
}
