using OpenAI.Internal;
using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace OpenAI.Images;

/// <summary> The service client for OpenAI image operations. </summary>
public partial class ImageClient
{
    private readonly OpenAIClientConnector _clientConnector;
    private Internal.Images Shim => _clientConnector.InternalClient.GetImagesClient();

    /// <summary>
    /// Initializes a new instance of <see cref="ImageClient"/>, used for image operation requests. 
    /// </summary>
    /// <remarks>
    /// <para>
    ///     If an endpoint is not provided, the client will use the <c>OPENAI_ENDPOINT</c> environment variable if it
    ///     defined and otherwise use the default OpenAI v1 endpoint.
    /// </para>
    /// <para>
    ///    If an authentication credential is not defined, the client use the <c>OPENAI_API_KEY</c> environment variable
    ///    if it is defined.
    /// </para>
    /// </remarks>
    /// <param name="model">The model name for image operations that the client should use.</param>
    /// <param name="credential">The API key used to authenticate with the service endpoint.</param>
    /// <param name="options">Additional options to customize the client.</param>
    public ImageClient(string model, ApiKeyCredential credential = default, OpenAIClientOptions options = null)
    {
        _clientConnector = new(model, credential, options);
    }

    /// <summary>
    /// Generates a single image for a provided prompt.
    /// </summary>
    /// <param name="prompt"> The description and instructions for the image. </param>
    /// <param name="options"> Additional options for the image generation request. </param>
    /// <returns> A result for a single image generation. </returns>
    public virtual ClientResult<GeneratedImage> GenerateImage(
        string prompt,
        ImageGenerationOptions options = null)
    {
        ClientResult<GeneratedImageCollection> multiResult = GenerateImages(prompt, imageCount: null, options);
        return ClientResult.FromValue(multiResult.Value[0], multiResult.GetRawResponse());
    }

    /// <summary>
    /// Generates a single image for a provided prompt.
    /// </summary>
    /// <param name="prompt"> The description and instructions for the image. </param>
    /// <param name="options"> Additional options for the image generation request. </param>
    /// <returns> A result for a single image generation. </returns>
    public virtual async Task<ClientResult<GeneratedImage>> GenerateImageAsync(
        string prompt,
        ImageGenerationOptions options = null)
    {
        ClientResult<GeneratedImageCollection> multiResult = await GenerateImagesAsync(prompt, imageCount: null, options).ConfigureAwait(false);
        return ClientResult.FromValue(multiResult.Value[0], multiResult.GetRawResponse());
    }

    /// <summary>
    /// Generates a collection of image alternatives for a provided prompt.
    /// </summary>
    /// <param name="prompt"> The description and instructions for the image. </param>
    /// <param name="imageCount">
    ///     The number of alternative images to generate for the prompt.
    /// </param>
    /// <param name="options"> Additional options for the image generation request. </param>
    /// <returns> A result for a single image generation. </returns>
    public virtual ClientResult<GeneratedImageCollection> GenerateImages(
        string prompt,
        int? imageCount = null,
        ImageGenerationOptions options = null)
    {
        Internal.Models.CreateImageRequest request = CreateInternalImageRequest(prompt, imageCount, options);
        ClientResult response = Shim.CreateImage(BinaryContent.Create(request));
        GeneratedImageCollection resultValue = GeneratedImageCollection.Deserialize(response.GetRawResponse().Content);
        return ClientResult.FromValue(resultValue, response.GetRawResponse());
    }

    /// <summary>
    /// Generates a collection of image alternatives for a provided prompt.
    /// </summary>
    /// <param name="prompt"> The description and instructions for the image. </param>
    /// <param name="imageCount">
    ///     The number of alternative images to generate for the prompt.
    /// </param>
    /// <param name="options"> Additional options for the image generation request. </param>
    /// <returns> A result for a single image generation. </returns>
    public virtual async Task<ClientResult<GeneratedImageCollection>> GenerateImagesAsync(
        string prompt,
        int? imageCount = null,
        ImageGenerationOptions options = null)
    {
        Internal.Models.CreateImageRequest request = CreateInternalImageRequest(prompt, imageCount, options);
        ClientResult response = await Shim.CreateImageAsync(BinaryContent.Create(request));
        GeneratedImageCollection resultValue = GeneratedImageCollection.Deserialize(response.GetRawResponse().Content);
        return ClientResult.FromValue(resultValue, response.GetRawResponse());
    }

    public virtual ClientResult<GeneratedImageCollection> GenerateImageEdits(
        FileStream image,
        string prompt,
        int? imageCount = null,
        ImageEditOptions options = null)
     => GenerateImageEdits(image, Path.GetFileName(image.Name), prompt, imageCount, options);

    public virtual ClientResult<GeneratedImageCollection> GenerateImageEdits(
        Stream image,
        string fileName,
        string prompt,
        int? imageCount = null,
        ImageEditOptions options = null)
    {
        Argument.AssertNotNull(image, nameof(image));
        Argument.AssertNotNull(fileName, nameof(fileName));
        Argument.AssertNotNull(prompt, nameof(prompt));

        if (options?.Mask is not null)
        {
            Argument.AssertNotNull(options.MaskFileName, nameof(options.MaskFileName));
        }

        options ??= new();

        using MultipartFormDataBinaryContent content = options.ToMultipartContent(image, fileName, prompt, _clientConnector.Model, imageCount);

        ClientResult result = GenerateImageEdits(content, content.ContentType);

        PipelineResponse response = result.GetRawResponse();

        GeneratedImageCollection value = GeneratedImageCollection.Deserialize(response.Content!);

        return ClientResult.FromValue(value, response);
    }

    public virtual async Task<ClientResult<GeneratedImageCollection>> GenerateImageEditsAsync(
        FileStream image,
        string prompt,
        int? imageCount = null,
        ImageEditOptions options = null)
        => await GenerateImageEditsAsync(image, Path.GetFileName(image.Name), prompt, imageCount, options).ConfigureAwait(false);

    public virtual async Task<ClientResult<GeneratedImageCollection>> GenerateImageEditsAsync(
        Stream image,
        string fileName,
        string prompt,
        int? imageCount = null,
        ImageEditOptions options = null)
    {
        Argument.AssertNotNull(image, nameof(image));
        Argument.AssertNotNull(fileName, nameof(fileName));
        Argument.AssertNotNull(prompt, nameof(prompt));

        if (options?.Mask is not null)
        {
            Argument.AssertNotNull(options.MaskFileName, nameof(options.MaskFileName));
        }

        options ??= new();

        using MultipartFormDataBinaryContent content = options.ToMultipartContent(image, fileName, prompt, _clientConnector.Model, imageCount);

        ClientResult result = await GenerateImageEditsAsync(content, content.ContentType).ConfigureAwait(false);

        PipelineResponse response = result.GetRawResponse();

        GeneratedImageCollection value = GeneratedImageCollection.Deserialize(response.Content!);

        return ClientResult.FromValue(value, response);
    }

    public virtual ClientResult<GeneratedImageCollection> GenerateImageVariations(
        FileStream image,
        int? imageCount = null,
        ImageVariationOptions options = null)
        => GenerateImageVariations(image, Path.GetFileName(image.Name), imageCount, options);

    public virtual ClientResult<GeneratedImageCollection> GenerateImageVariations(
        Stream image,
        string fileName,
        int? imageCount = null,
        ImageVariationOptions options = null)
    {
        Argument.AssertNotNull(image, nameof(image));
        Argument.AssertNotNull(fileName, nameof(fileName));

        options ??= new();

        using MultipartFormDataBinaryContent content = options.ToMultipartContent(image, fileName, _clientConnector.Model, imageCount);

        ClientResult result = GenerateImageVariations(content, content.ContentType);

        PipelineResponse response = result.GetRawResponse();

        GeneratedImageCollection value = GeneratedImageCollection.Deserialize(response.Content!);

        return ClientResult.FromValue(value, response);
    }


    public virtual async Task<ClientResult<GeneratedImageCollection>> GenerateImageVariationsAsync(
        FileStream image,
        int? imageCount = null,
        ImageVariationOptions options = null)
        => await GenerateImageVariationsAsync(image, Path.GetFileName(image.Name), imageCount, options).ConfigureAwait(false);

    public virtual async Task<ClientResult<GeneratedImageCollection>> GenerateImageVariationsAsync(
        Stream image,
        string fileName,
        int? imageCount = null,
        ImageVariationOptions options = null)
    {
        Argument.AssertNotNull(image, nameof(image));
        Argument.AssertNotNull(fileName, nameof(fileName));

        options ??= new();

        using MultipartFormDataBinaryContent content = options.ToMultipartContent(image, fileName, _clientConnector.Model, imageCount);

        ClientResult result = await GenerateImageVariationsAsync(content, content.ContentType).ConfigureAwait(false);

        PipelineResponse response = result.GetRawResponse();

        GeneratedImageCollection value = GeneratedImageCollection.Deserialize(response.Content!);

        return ClientResult.FromValue(value, response);
    }

    private Internal.Models.CreateImageRequest CreateInternalImageRequest(
        string prompt,
        int? imageCount = null,
        ImageGenerationOptions options = null)
    {
        options ??= new();
        Internal.Models.CreateImageRequestQuality? internalQuality = null;
        if (options.Quality != null)
        {
            internalQuality = options.Quality switch
            {
                GeneratedImageQuality.Standard => Internal.Models.CreateImageRequestQuality.Standard,
                GeneratedImageQuality.High => Internal.Models.CreateImageRequestQuality.Hd,
                _ => throw new ArgumentException(nameof(options.Quality)),
            };
        }

        Internal.Models.CreateImageRequestResponseFormat? internalFormat = null;
        if (options.ResponseFormat != null)
        {
            internalFormat = options.ResponseFormat switch
            {
                GeneratedImageFormat.Bytes => Internal.Models.CreateImageRequestResponseFormat.B64Json,
                GeneratedImageFormat.Uri => Internal.Models.CreateImageRequestResponseFormat.Url,
                _ => throw new ArgumentException(nameof(options.ResponseFormat)),
            };
        }

        Internal.Models.CreateImageRequestSize? internalSize = null;
        if (options.Size is not null)
        {
            internalSize = options.Size.ToString();
        }

        Internal.Models.CreateImageRequestStyle? internalStyle = null;
        if (options.Style != null)
        {
            internalStyle = options.Style switch
            {
                GeneratedImageStyle.Vivid => Internal.Models.CreateImageRequestStyle.Vivid,
                GeneratedImageStyle.Natural => Internal.Models.CreateImageRequestStyle.Natural,
                _ => throw new ArgumentException(nameof(options.Style)),
            };
        }

        return new Internal.Models.CreateImageRequest(
            prompt,
            _clientConnector.Model,
            imageCount,
            quality: internalQuality,
            responseFormat: internalFormat,
            size: internalSize,
            style: internalStyle,
            options.User,
            serializedAdditionalRawData: null);
    }

    private PipelineMessage CreateCreateImageEditsRequest(BinaryContent content, string contentType, RequestOptions options)
    {
        PipelineMessage message = Shim.Pipeline.CreateMessage();
        message.ResponseClassifier = ResponseErrorClassifier200;

        PipelineRequest request = message.Request;
        request.Method = "POST";

        UriBuilder uriBuilder = new(_clientConnector.Endpoint.AbsoluteUri);

        StringBuilder path = new();
        path.Append("/images/edits");
        uriBuilder.Path += path.ToString();

        request.Uri = uriBuilder.Uri;

        request.Headers.Set("Content-Type", contentType);

        request.Content = content;

        message.Apply(options);

        return message;
    }

    private PipelineMessage CreateImageVariationsRequest(BinaryContent content, string contentType, RequestOptions options)
    {
        PipelineMessage message = Shim.Pipeline.CreateMessage();
        message.ResponseClassifier = ResponseErrorClassifier200;

        PipelineRequest request = message.Request;
        request.Method = "POST";

        UriBuilder uriBuilder = new(_clientConnector.Endpoint.AbsoluteUri);

        StringBuilder path = new();
        path.Append("/images/variations");
        uriBuilder.Path += path.ToString();

        request.Uri = uriBuilder.Uri;

        request.Headers.Set("Content-Type", contentType);

        request.Content = content;

        message.Apply(options);

        return message;
    }

    private static PipelineMessageClassifier _responseErrorClassifier200;
    private static PipelineMessageClassifier ResponseErrorClassifier200 => _responseErrorClassifier200 ??= PipelineMessageClassifier.Create(stackalloc ushort[] { 200 });
}
