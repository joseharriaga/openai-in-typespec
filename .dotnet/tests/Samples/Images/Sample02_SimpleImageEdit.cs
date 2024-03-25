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
        public void Sample02_SimpleImageEdit()
        {
            ImageClient client = new("dall-e-2", Environment.GetEnvironmentVariable("OpenAIClient_KEY"));

            string imagePath = Path.Combine("Assets", "edit_sample_image.png");
            using FileStream inputImage = File.OpenRead(imagePath);

            string prompt = "An inflatable flamingo float in a pool";

            string maskPath = Path.Combine("Assets", "edit_sample_mask.png");
            using Stream mask = File.OpenRead(maskPath);

            ImageEditOptions options = new()
            {
                Mask = mask,
                MaskFileName = "edit_sample_mask.png",
                Size = GeneratedImageSize.W1024xH1024,
                ResponseFormat = ImageResponseFormat.Bytes
            };

            GeneratedImageCollection imageCollection = client.GenerateImageEdits(inputImage, prompt, 1, options);
            using Stream editedImage = imageCollection[0].Image;

            using FileStream stream = File.OpenWrite($"{Guid.NewGuid()}.png");
            editedImage.CopyTo(stream);
        }
    }
}
