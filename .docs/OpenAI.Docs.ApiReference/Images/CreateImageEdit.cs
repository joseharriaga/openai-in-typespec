using NUnit.Framework;

#region usings
using System;

using OpenAI.Images;
#endregion

namespace OpenAI.Docs.ApiReference;
public partial class CreateImageEditApiReference {

    [Test]
    public void CreateImageEdit()
    {
        #region logic

        ImageClient client = new(
            model: "dall-e-2",
            apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY")
        );

        var image = client.GenerateImageEdit(
		    "otter.png", 
		    "A cute baby sea otter wearing a beret",
		    "mask.png"
		);
		
		Console.WriteLine(image.Value.ImageUri);

        #endregion
    }
}
