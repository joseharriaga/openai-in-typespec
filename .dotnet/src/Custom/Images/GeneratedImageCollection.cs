using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace OpenAI.Images;

/// <summary>
/// Represents an image generation response payload that contains information for multiple generated images.
/// </summary>
public class GeneratedImageCollection : ReadOnlyCollection<GeneratedImage>
{
    /// <summary>
    /// The timestamp at which the result images were generated.
    /// </summary>
    public DateTimeOffset CreatedAt { get; }

    internal GeneratedImageCollection(IList<GeneratedImage> list, DateTimeOffset createdAt)
        : base(list)
    {
        CreatedAt = createdAt;
    }

    internal static GeneratedImageCollection Deserialize(BinaryData content)
    {
        using JsonDocument responseDocument = JsonDocument.Parse(content);
        return Deserialize(responseDocument.RootElement);
    }

    internal static GeneratedImageCollection Deserialize(JsonElement element)
    {
        Internal.Models.ImagesResponse response = Internal.Models.ImagesResponse.DeserializeImagesResponse(element);

        List<GeneratedImage> images = [];
        for (int i = 0; i < response.Data.Count; i++)
        {
            images.Add(new GeneratedImage(response, i));
        }

        return new GeneratedImageCollection(images, response.Created);
    }
}