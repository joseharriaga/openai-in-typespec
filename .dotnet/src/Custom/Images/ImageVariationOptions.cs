using OpenAI.Internal;
using System;
using System.ClientModel.Primitives;
using System.IO;

namespace OpenAI.Images;

/// <summary>
/// Represents additional options available to control the behavior of an image generation operation.
/// </summary>
public partial class ImageVariationOptions
{
    /// <inheritdoc cref="Internal.Models.CreateImageEditRequest.Size"/>
    public GeneratedImageSize? Size { get; init; }

    /// <inheritdoc cref="Internal.Models.CreateImageEditRequest.ResponseFormat"/>
    public ImageResponseFormat? ResponseFormat { get; init; }

    /// <inheritdoc cref="Internal.Models.CreateImageEditRequest.User"/>
    public string User { get; init; }

    internal MultipartFormDataBinaryContent ToMultipartContent(Stream image, string fileName,  string model, int? imageCount)
    {
        MultipartFormDataBinaryContent content = new();

        content.Add(image, "image", fileName);
        content.Add(model, "model");

        if (imageCount is not null)
        {
            content.Add(imageCount.Value, "n");
        }

        if (ResponseFormat is not null)
        {
            string format = ResponseFormat switch
            {
                ImageResponseFormat.Uri => "url",
                ImageResponseFormat.Bytes => "b64_json",
                _ => throw new ArgumentException(nameof(ResponseFormat)),
            };

            content.Add(format, "response_format");
        }

        if (Size is not null)
        {
            string imageSize = ModelReaderWriter.Write(Size).ToString();
            content.Add(imageSize, "size");
        }

        if (User is not null)
        {
            content.Add(User, "user");
        }

        return content;
    }
}