using NUnit.Framework;

#region usings
using System;

using OpenAI.Images;
#endregion

namespace OpenAI.Docs.ApiReference;

public partial class ImageDocs
{
    [Test]
    public void CreateImage()
    {
        #region logic

        ImageClient client = new(
            model: "dall-e-3",
            apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY")
        );

        GeneratedImage image = client.GenerateImage(prompt: "A cute baby sea otter.");

        Console.WriteLine(image.ImageUri);

        #endregion
    }
}
