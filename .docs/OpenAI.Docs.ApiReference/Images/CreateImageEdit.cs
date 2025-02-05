using NUnit.Framework;

#region usings
using System;

using OpenAI.Images;
#endregion

namespace OpenAI.Docs.ApiReference;

public partial class ImageDocs
{
    [Test]
    public void CreateImageEdit()
    {
        #region logic

        ImageClient client = new(
            model: "dall-e-2",
            apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY")
        );

        GeneratedImage image = client.GenerateImageEdit(
            imageFilePath: "otter.png",
            prompt: "A cute baby sea otter wearing a beret",
            maskFilePath: "mask.png"
        );

        Console.WriteLine(image.ImageUri);

        #endregion
    }
}
