using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace OpenAI.Images;

/// <summary>
/// Represents an image generation response payload that contains information for multiple generated images.
/// </summary>
public partial class GeneratedImageCollection : ReadOnlyCollection<GeneratedImage>
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
}