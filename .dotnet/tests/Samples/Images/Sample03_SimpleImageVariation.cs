using NUnit.Framework;
using OpenAI.Images;
using System;
using System.IO;

namespace OpenAI.Samples
{
    public partial class ImageSamples
    {
        [Test]
        [Ignore("Compilation validation only")]
        public void Sample03_SimpleImageVariation()
        {
            ImageClient client = new("dall-e-2", Environment.GetEnvironmentVariable("OPENAI_API_KEY"));

            string imagePath = Path.Combine("Assets", "variation_sample_image.png");
            using FileStream inputImage = File.OpenRead(imagePath);

            ImageVariationOptions options = new()
            {
                Size = GeneratedImageSize.W1024xH1024,
                ResponseFormat = GeneratedImageFormat.Bytes
            };

            GeneratedImageCollection images = client.GenerateImageVariations(inputImage, 1, options);
            BinaryData bytes = images[0].ImageBytes;

            using FileStream stream = File.OpenWrite($"{Guid.NewGuid()}.png");
            bytes.ToStream().CopyTo(stream);
        }
    }
}
