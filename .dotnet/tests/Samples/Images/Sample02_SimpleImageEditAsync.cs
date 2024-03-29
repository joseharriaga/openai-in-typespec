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
        public async Task Sample02_SimpleImageEditAsync()
        {
            ImageClient client = new("dall-e-2", Environment.GetEnvironmentVariable("OpenAIClient_KEY"));

            string imageFileName = "edit_sample_image.png";
            string imagePath = Path.Combine("Assets", imageFileName);
            using Stream inputImage = File.OpenRead(imagePath);

            string prompt = "An inflatable flamingo float in a pool";

            string maskFileName = "edit_sample_mask.png";
            string maskPath = Path.Combine("Assets", maskFileName);
            using Stream mask = File.OpenRead(maskPath);

            ImageEditOptions options = new()
            {
                Mask = mask,
                MaskFileName = maskFileName,
                Size = GeneratedImageSize.W1024xH1024,
                ResponseFormat = GeneratedImageFormat.Bytes
            };

            GeneratedImageCollection images = await client.GenerateImageEditsAsync(inputImage, imageFileName, prompt, 1, options);
            BinaryData bytes = images[0].ImageBytes;

            using FileStream stream = File.OpenWrite($"{Guid.NewGuid()}.png");
            await bytes.ToStream().CopyToAsync(stream);
        }
    }
}
