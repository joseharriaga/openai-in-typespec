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

            string imagePath = Path.Combine("Assets", "edit_sample_image.png");
            using Stream inputImage = File.OpenRead(imagePath);

            string prompt = "An inflatable flamingo float in a pool";

            string maskPath = Path.Combine("Assets", "edit_sample_mask.png");
            using Stream mask = File.OpenRead(maskPath);
            
            ImageEditOptions options = new()
            {
                Mask = mask,
                MaskFileName = "edit_sample_mask.png",
                Size = ImageSize.Size1024x1024,
                ResponseFormat = ImageResponseFormat.Bytes
            };

            GeneratedImageCollection imageCollection = await client.GenerateImageEditsAsync(inputImage, "edit_sample_image.png", prompt, 1, options);
            using Stream editedImage = imageCollection[0].Image;

            using FileStream stream = File.OpenWrite($"{Guid.NewGuid()}.png");
            await editedImage.CopyToAsync(stream);
        }
    }
}
