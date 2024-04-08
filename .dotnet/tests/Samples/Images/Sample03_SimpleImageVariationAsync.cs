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
            ImageClient client = new("dall-e-2", Environment.GetEnvironmentVariable("OPENAI_API_KEY"));

            string imagePath = Path.Combine("Assets", "variation_sample_image.png");
            using FileStream inputImage = File.OpenRead(imagePath);

            ImageVariationOptions options = new()
            {
                Size = GeneratedImageSize.W256xH256,
                ResponseFormat = GeneratedImageFormat.Bytes
            };

            GeneratedImageCollection images = await client.GenerateImageVariationsAsync(inputImage, 1, options);
            BinaryData bytes = images[0].ImageBytes;

            using FileStream stream = File.OpenWrite($"{Guid.NewGuid()}.png");
            bytes.ToStream().CopyTo(stream);
        }
    }
}
