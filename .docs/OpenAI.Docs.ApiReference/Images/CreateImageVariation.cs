using NUnit.Framework;

#region usings
using System;

using OpenAI.Images;
#endregion

namespace OpenAI.Docs.ApiReference;

public partial class ImageDocs
{
    [Test]
    public void CreateImageVariation()
    {
        #region logic

        ImageClient client = new(
            model: "dall-e-2",
            apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY")
        );

        GeneratedImage image = client.GenerateImageVariation(imageFilePath: "otter.png");

        Console.WriteLine(image.ImageUri);

        #endregion
    }
}
