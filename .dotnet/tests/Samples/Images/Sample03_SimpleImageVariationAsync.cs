using NUnit.Framework;
using OpenAI.Images;
using System;
using System.IO;
using System.Threading.Tasks;

namespace OpenAI.Samples
{
    public partial class ImageSamples
    {
        [Test]
        [Ignore("Compilation validation only")]
        public async Task Sample03_SimpleImageVariationAsync()
        {
            ImageClient client = new("dall-e-2", Environment.GetEnvironmentVariable("OpenAIClient_KEY"));

            string imagePath = Path.Combine("Assets", "variation_sample_image.png");
            using FileStream inputImage = File.OpenRead(imagePath);

            ImageVariationOptions options = new()
            {
                Size = ImageSize.Size1024x1024,
                ResponseFormat = ImageResponseFormat.Bytes
            };

            GeneratedImageCollection imageCollection = await client.GenerateImageVariationsAsync(inputImage, 1, options);
            using Stream outputImage = imageCollection[0].Image;

            using FileStream stream = File.OpenWrite($"{Guid.NewGuid()}.png");
            await outputImage.CopyToAsync(stream);
        }
    }
}
