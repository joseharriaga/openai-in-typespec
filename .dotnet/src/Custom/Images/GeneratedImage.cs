using System;
using System.IO;

namespace OpenAI.Images;

/// <summary>
/// Represents the result data for an image generation request.
/// </summary>
public class GeneratedImage
{
    /// <summary>
    /// The binary image data received from the response, provided when
    /// <see cref="ImageGenerationOptions.ResponseFormat"/> is set to <see cref="ImageResponseFormat.Bytes"/>.
    /// </summary>
    /// <remarks>
    /// This property is mutually exclusive with <see cref="ImageUri"/> and will be <c>null</c> when the other
    /// is present.
    /// </remarks>
    public Stream Image { get; }
    /// <summary>
    /// A temporary internet location for an image, provided by default or when
    /// <see cref="ImageGenerationOptions.ResponseFormat"/> is set to <see cref="ImageResponseFormat.Uri"/>.
    /// </summary>
    /// <remarks>
    /// This property is mutually exclusive with <see cref="Image"/> and will be <c>null</c> when the other
    /// is present.
    /// </remarks>
    public Uri ImageUri { get; }
    /// <summary>
    /// The final, revised prompt that was used to generate the result image, populated if the model performed any
    /// such revisions to the prompt.
    /// </summary>
    /// <remarks>
    /// Revisions are automatically performed to enrich image prompts and improve output quality and consistency.
    /// </remarks>
    public string RevisedPrompt { get; }
    /// <summary>
    /// The timestamp at which the result image was generated.
    /// </summary>
    public DateTimeOffset CreatedAt { get; }

    internal GeneratedImage(Internal.Models.ImagesResponse internalResponse, int internalDataIndex)
    {
        CreatedAt = internalResponse.Created;

        // TODO: Generator will need to update to make file streams Streams instead of BinaryData
        // with this proposal.  This is important if these files are going to be large, since 
        // BinaryData loads the buffers into memory, and this could be problematic for applications.
        Image = internalResponse.Data[(int)internalDataIndex].B64Json.ToStream();
        RevisedPrompt = internalResponse.Data[(int)internalDataIndex].RevisedPrompt;
        ImageUri = internalResponse.Data[(int)internalDataIndex].Url;
    }
}
