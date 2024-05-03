using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OpenAI.Images;

/// <summary> The service client for OpenAI image operations. </summary>
[CodeGenClient("Images")]
[CodeGenSuppress("ImageClient", typeof(ClientPipeline), typeof(ApiKeyCredential), typeof(Uri))]
[CodeGenSuppress("CreateImageAsync", typeof(ImageGenerationOptions))]
[CodeGenSuppress("CreateImage", typeof(ImageGenerationOptions))]
[CodeGenSuppress("CreateImageEditAsync", typeof(ImageEditOptions))]
[CodeGenSuppress("CreateImageEdit", typeof(ImageEditOptions))]
[CodeGenSuppress("CreateImageVariationAsync", typeof(ImageVariationOptions))]
[CodeGenSuppress("CreateImageVariation", typeof(ImageVariationOptions))]
public partial class ImageClient
{
    protected readonly string _model;
    protected readonly Uri _endpoint;

    // CUSTOM:
    // - Added `model` parameter.
    // - Added support for retrieving credential and endpoint from environment variables.

    /// <summary>
    /// Initializes a new instance of <see cref="ImageClient"/> that will use an API key when authenticating.
    /// </summary>
    /// <param name="model"> The model name to use for image operations. </param>
    /// <param name="credential"> The API key used to authenticate with the service endpoint. </param>
    /// <param name="options"> Additional options to customize the client. </param>
    /// <exception cref="ArgumentNullException"> The provided <paramref name="credential"/> was null. </exception>
    public ImageClient(string model, ApiKeyCredential credential, OpenAIClientOptions options = default)
        : this(
              OpenAIClient.CreatePipeline(OpenAIClient.GetApiKey(credential, requireExplicitCredential: true), options),
              model,
              OpenAIClient.GetEndpoint(options),
              options)
    { }

    /// <summary>
    /// Initializes a new instance of <see cref="ImageClient"/> that will use an API key from the OPENAI_API_KEY
    /// environment variable when authenticating.
    /// </summary>
    /// <remarks>
    /// To provide an explicit credential instead of using the environment variable, use an alternate constructor like
    /// <see cref="ImageClient(string,ApiKeyCredential,OpenAIClientOptions)"/>.
    /// </remarks>
    /// <param name="model"> The model name to use for image operations. </param>
    /// <param name="options"> Additional options to customize the client. </param>
    /// <exception cref="InvalidOperationException"> The OPENAI_API_KEY environment variable was not found. </exception>
    public ImageClient(string model, OpenAIClientOptions options = default)
        : this(
              OpenAIClient.CreatePipeline(OpenAIClient.GetApiKey(), options),
              model,
              OpenAIClient.GetEndpoint(options),
              options)
    { }

    // CUSTOM:
    // - Added `model` parameter.

    /// <summary> Initializes a new instance of EmbeddingClient. </summary>
    /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
    /// <param name="model"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
    /// <param name="endpoint"> OpenAI Endpoint. </param>
    protected internal ImageClient(ClientPipeline pipeline, string model, Uri endpoint, OpenAIClientOptions options)
    {
        Argument.AssertNotNullOrEmpty(model, nameof(model));

        _pipeline = pipeline;
        _model = model;
        _endpoint = endpoint;
    }

    #region GenerateImages

    /// <summary>
    /// Generates a single image for a provided prompt.
    /// </summary>
    /// <param name="prompt"> The description and instructions for the image. </param>
    /// <param name="options"> Additional options for the image generation request. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="prompt"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="prompt"/> is an empty string, and was expected to be non-empty. </exception>
    public virtual async Task<ClientResult<GeneratedImage>> GenerateImageAsync(string prompt, ImageGenerationOptions options = null)
    {
        Argument.AssertNotNullOrEmpty(prompt, nameof(prompt));

        options ??= new();
        CreateImageGenerationOptions(prompt, null, ref options);

        using BinaryContent content = options.ToBinaryContent();
        ClientResult result = await GenerateImagesAsync(content, (RequestOptions)null).ConfigureAwait(false);
        return ClientResult.FromValue(GeneratedImageCollection.FromResponse(result.GetRawResponse()).FirstOrDefault(), result.GetRawResponse());
    }

    /// <summary>
    /// Generates a single image for a provided prompt.
    /// </summary>
    /// <param name="prompt"> The description and instructions for the image. </param>
    /// <param name="options"> Additional options for the image generation request. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="prompt"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="prompt"/> is an empty string, and was expected to be non-empty. </exception>
    public virtual ClientResult<GeneratedImage> GenerateImage(string prompt, ImageGenerationOptions options = null)
    {
        Argument.AssertNotNullOrEmpty(prompt, nameof(prompt));

        options ??= new();
        CreateImageGenerationOptions(prompt, null, ref options);

        using BinaryContent content = options.ToBinaryContent();
        ClientResult result = GenerateImages(content, (RequestOptions)null);
        return ClientResult.FromValue(GeneratedImageCollection.FromResponse(result.GetRawResponse()).FirstOrDefault(), result.GetRawResponse());
    }

    /// <summary> Creates an image given a prompt. </summary>
    /// <param name="prompt"> TODO </param>
    /// <param name="imageCount"> TODO </param>
    /// <param name="options"> TODO </param>
    /// <exception cref="ArgumentNullException"> <paramref name="prompt"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="prompt"/> is an empty string, and was expected to be non-empty. </exception>
    public virtual async Task<ClientResult<GeneratedImageCollection>> GenerateImagesAsync(string prompt, int? imageCount = null, ImageGenerationOptions options = null)
    {
        Argument.AssertNotNullOrEmpty(prompt, nameof(prompt));

        options ??= new();
        CreateImageGenerationOptions(prompt, imageCount, ref options);

        using BinaryContent content = options.ToBinaryContent();
        ClientResult result = await GenerateImagesAsync(content, (RequestOptions)null).ConfigureAwait(false);
        return ClientResult.FromValue(GeneratedImageCollection.FromResponse(result.GetRawResponse()), result.GetRawResponse());
    }

    /// <summary> Creates an image given a prompt. </summary>
    /// <param name="prompt"> TODO </param>
    /// <param name="imageCount"> TODO </param>
    /// <param name="options"> TODO </param>
    /// <exception cref="ArgumentNullException"> <paramref name="prompt"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="prompt"/> is an empty string, and was expected to be non-empty. </exception>
    public virtual ClientResult<GeneratedImageCollection> GenerateImages(string prompt, int? imageCount = null, ImageGenerationOptions options = null)
    {
        Argument.AssertNotNullOrEmpty(prompt, nameof(prompt));

        options ??= new();
        CreateImageGenerationOptions(prompt, imageCount, ref options);

        using BinaryContent content = options.ToBinaryContent();
        ClientResult result = GenerateImages(content, (RequestOptions)null);
        return ClientResult.FromValue(GeneratedImageCollection.FromResponse(result.GetRawResponse()), result.GetRawResponse());
    }

    #endregion

    #region GenerateImageEdits

    /// <summary> TODO. </summary>
    /// <param name="image"> TODO. </param>
    /// <param name="imageFilename"> TODO. </param>
    /// <param name="prompt"> TODO. </param>
    /// <param name="options"> TODO. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="prompt"/>, <paramref name="image"/> or <paramref name="imageFilename"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="prompt"/> or <paramref name="imageFilename"/> is an empty string, and was expected to be non-empty. </exception>
    public virtual async Task<ClientResult<GeneratedImage>> GenerateImageEditAsync(Stream image, string imageFilename, string prompt, ImageEditOptions options = null)
    {
        Argument.AssertNotNullOrEmpty(prompt, nameof(prompt));
        Argument.AssertNotNull(image, nameof(image));
        Argument.AssertNotNullOrEmpty(imageFilename, nameof(imageFilename));

        options ??= new();
        CreateImageEditOptions(image, imageFilename, prompt, null, null, null, ref options);

        using MultipartFormDataBinaryContent content = options.ToMultipartContent(image, imageFilename, null, null);
        ClientResult result = await GenerateImageEditsAsync(content, content.ContentType).ConfigureAwait(false);
        return ClientResult.FromValue(GeneratedImageCollection.FromResponse(result.GetRawResponse()).FirstOrDefault(), result.GetRawResponse());
    }

    /// <summary> TODO. </summary>
    /// <param name="image"> TODO. </param>
    /// <param name="imageFilename"> TODO. </param>
    /// <param name="prompt"> TODO. </param>
    /// <param name="options"> TODO. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="prompt"/>, <paramref name="image"/> or <paramref name="imageFilename"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="prompt"/> or <paramref name="imageFilename"/> is an empty string, and was expected to be non-empty. </exception>
    public virtual ClientResult<GeneratedImage> GenerateImageEdit(Stream image, string imageFilename, string prompt, ImageEditOptions options = null)
    {
        Argument.AssertNotNullOrEmpty(prompt, nameof(prompt));
        Argument.AssertNotNull(image, nameof(image));
        Argument.AssertNotNullOrEmpty(imageFilename, nameof(imageFilename));

        options ??= new();
        CreateImageEditOptions(image, imageFilename, prompt, null, null, null, ref options);

        using MultipartFormDataBinaryContent content = options.ToMultipartContent(image, imageFilename, null, null);
        ClientResult result = GenerateImageEdits(content, content.ContentType);
        return ClientResult.FromValue(GeneratedImageCollection.FromResponse(result.GetRawResponse()).FirstOrDefault(), result.GetRawResponse());
    }

    /// <summary> TODO. </summary>
    /// <param name="image"> TODO. </param>
    /// <param name="imageFilename"> TODO. </param>
    /// <param name="prompt"> TODO. </param>
    /// <param name="mask"> TODO. </param>
    /// <param name="maskFilename"> TODO. </param>
    /// <param name="options"> TODO. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="prompt"/>, <paramref name="image"/> or <paramref name="imageFilename"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="prompt"/> or <paramref name="imageFilename"/> is an empty string, and was expected to be non-empty. </exception>
    public virtual async Task<ClientResult<GeneratedImage>> GenerateImageEditAsync(Stream image, string imageFilename, string prompt, Stream mask, string maskFilename, ImageEditOptions options = null)
    {
        Argument.AssertNotNullOrEmpty(prompt, nameof(prompt));
        Argument.AssertNotNull(image, nameof(image));
        Argument.AssertNotNullOrEmpty(imageFilename, nameof(imageFilename));

        options ??= new();
        CreateImageEditOptions(image, imageFilename, prompt, mask, maskFilename, null, ref options);

        using MultipartFormDataBinaryContent content = options.ToMultipartContent(image, imageFilename, mask, maskFilename);
        ClientResult result = await GenerateImageEditsAsync(content, content.ContentType).ConfigureAwait(false);
        return ClientResult.FromValue(GeneratedImageCollection.FromResponse(result.GetRawResponse()).FirstOrDefault(), result.GetRawResponse());
    }

    /// <summary> TODO. </summary>
    /// <param name="image"> TODO. </param>
    /// <param name="imageFilename"> TODO. </param>
    /// <param name="prompt"> TODO. </param>
    /// <param name="mask"> TODO. </param>
    /// <param name="maskFilename"> TODO. </param>
    /// <param name="options"> TODO. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="prompt"/>, <paramref name="image"/> or <paramref name="imageFilename"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="prompt"/> or <paramref name="imageFilename"/> is an empty string, and was expected to be non-empty. </exception>
    public virtual ClientResult<GeneratedImage> GenerateImageEdit(Stream image, string imageFilename, string prompt, Stream mask, string maskFilename, ImageEditOptions options = null)
    {
        Argument.AssertNotNullOrEmpty(prompt, nameof(prompt));
        Argument.AssertNotNull(image, nameof(image));
        Argument.AssertNotNullOrEmpty(imageFilename, nameof(imageFilename));

        options ??= new();
        CreateImageEditOptions(image, imageFilename, prompt, mask, maskFilename, null, ref options);

        using MultipartFormDataBinaryContent content = options.ToMultipartContent(image, imageFilename, mask, maskFilename);
        ClientResult result = GenerateImageEdits(content, content.ContentType);
        return ClientResult.FromValue(GeneratedImageCollection.FromResponse(result.GetRawResponse()).FirstOrDefault(), result.GetRawResponse());
    }

    /// <summary> TODO. </summary>
    /// <param name="image"> TODO. </param>
    /// <param name="imageFilename"> TODO. </param>
    /// <param name="prompt"> TODO. </param>
    /// <param name="imageCount"> TODO. </param>
    /// <param name="options"> TODO. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="prompt"/>, <paramref name="image"/> or <paramref name="imageFilename"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="prompt"/> or <paramref name="imageFilename"/> is an empty string, and was expected to be non-empty. </exception>
    public virtual async Task<ClientResult<GeneratedImageCollection>> GenerateImageEditsAsync(Stream image, string imageFilename, string prompt, int? imageCount = null, ImageEditOptions options = null)
    {
        Argument.AssertNotNullOrEmpty(prompt, nameof(prompt));
        Argument.AssertNotNull(image, nameof(image));
        Argument.AssertNotNullOrEmpty(imageFilename, nameof(imageFilename));

        options ??= new();
        CreateImageEditOptions(image, imageFilename, prompt, null, null, imageCount, ref options);

        using MultipartFormDataBinaryContent content = options.ToMultipartContent(image, imageFilename, null, null);
        ClientResult result = await GenerateImageEditsAsync(content, content.ContentType).ConfigureAwait(false);
        return ClientResult.FromValue(GeneratedImageCollection.FromResponse(result.GetRawResponse()), result.GetRawResponse());
    }

    /// <summary> TODO. </summary>
    /// <param name="image"> TODO. </param>
    /// <param name="imageFilename"> TODO. </param>
    /// <param name="prompt"> TODO. </param>
    /// <param name="imageCount"> TODO. </param>
    /// <param name="options"> TODO. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="prompt"/>, <paramref name="image"/> or <paramref name="imageFilename"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="prompt"/> or <paramref name="imageFilename"/> is an empty string, and was expected to be non-empty. </exception>
    public virtual ClientResult<GeneratedImageCollection> GenerateImageEdits(Stream image, string imageFilename, string prompt, int? imageCount = null, ImageEditOptions options = null)
    {
        Argument.AssertNotNullOrEmpty(prompt, nameof(prompt));
        Argument.AssertNotNull(image, nameof(image));
        Argument.AssertNotNullOrEmpty(imageFilename, nameof(imageFilename));

        options ??= new();
        CreateImageEditOptions(image, imageFilename, prompt, null, null, imageCount, ref options);

        using MultipartFormDataBinaryContent content = options.ToMultipartContent(image, imageFilename, null, null);
        ClientResult result = GenerateImageEdits(content, content.ContentType);
        return ClientResult.FromValue(GeneratedImageCollection.FromResponse(result.GetRawResponse()), result.GetRawResponse());
    }

    /// <summary> TODO. </summary>
    /// <param name="image"> TODO. </param>
    /// <param name="imageFilename"> TODO. </param>
    /// <param name="prompt"> TODO. </param>
    /// <param name="mask"> TODO. </param>
    /// <param name="maskFilename"> TODO. </param>
    /// <param name="imageCount"> TODO. </param>
    /// <param name="options"> TODO. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="prompt"/>, <paramref name="image"/> or <paramref name="imageFilename"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="prompt"/> or <paramref name="imageFilename"/> is an empty string, and was expected to be non-empty. </exception>
    public virtual async Task<ClientResult<GeneratedImageCollection>> GenerateImageEditsAsync(Stream image, string imageFilename, string prompt, Stream mask, string maskFilename, int? imageCount = null, ImageEditOptions options = null)
    {
        Argument.AssertNotNullOrEmpty(prompt, nameof(prompt));
        Argument.AssertNotNull(image, nameof(image));
        Argument.AssertNotNullOrEmpty(imageFilename, nameof(imageFilename));

        options ??= new();
        CreateImageEditOptions(image, imageFilename, prompt, mask, maskFilename, imageCount, ref options);

        using MultipartFormDataBinaryContent content = options.ToMultipartContent(image, imageFilename, mask, maskFilename);
        ClientResult result = await GenerateImageEditsAsync(content, content.ContentType).ConfigureAwait(false);
        return ClientResult.FromValue(GeneratedImageCollection.FromResponse(result.GetRawResponse()), result.GetRawResponse());
    }

    /// <summary> TODO. </summary>
    /// <param name="image"> TODO. </param>
    /// <param name="imageFilename"> TODO. </param>
    /// <param name="prompt"> TODO. </param>
    /// <param name="mask"> TODO. </param>
    /// <param name="maskFilename"> TODO. </param>
    /// <param name="imageCount"> TODO. </param>
    /// <param name="options"> TODO. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="prompt"/>, <paramref name="image"/> or <paramref name="imageFilename"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="prompt"/> or <paramref name="imageFilename"/> is an empty string, and was expected to be non-empty. </exception>
    public virtual ClientResult<GeneratedImageCollection> GenerateImageEdits(Stream image, string imageFilename, string prompt, Stream mask, string maskFilename, int? imageCount = null, ImageEditOptions options = null)
    {
        Argument.AssertNotNullOrEmpty(prompt, nameof(prompt));
        Argument.AssertNotNull(image, nameof(image));
        Argument.AssertNotNullOrEmpty(imageFilename, nameof(imageFilename));

        options ??= new();
        CreateImageEditOptions(image, imageFilename, prompt, mask, maskFilename, imageCount, ref options);

        using MultipartFormDataBinaryContent content = options.ToMultipartContent(image, imageFilename, mask, maskFilename);
        ClientResult result = GenerateImageEdits(content, content.ContentType);
        return ClientResult.FromValue(GeneratedImageCollection.FromResponse(result.GetRawResponse()), result.GetRawResponse());
    }

    #endregion

    #region GenerateImageVariations

    /// <summary> TODO. </summary>
    /// <param name="image"> TODO. </param>
    /// <param name="imageFilename"> TODO. </param>
    /// <param name="options"> TODO. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="image"/> or <paramref name="imageFilename"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="imageFilename"/> is an empty string, and was expected to be non-empty. </exception>
    public virtual async Task<ClientResult<GeneratedImage>> GenerateImageVariationAsync(Stream image, string imageFilename, ImageVariationOptions options = null)
    {
        Argument.AssertNotNull(image, nameof(image));
        Argument.AssertNotNullOrEmpty(imageFilename, nameof(imageFilename));

        options ??= new();
        CreateImageVariationOptions(image, imageFilename, null, ref options);

        using MultipartFormDataBinaryContent content = options.ToMultipartContent(image, imageFilename);
        ClientResult result = await GenerateImageVariationsAsync(content, content.ContentType).ConfigureAwait(false);
        return ClientResult.FromValue(GeneratedImageCollection.FromResponse(result.GetRawResponse()).FirstOrDefault(), result.GetRawResponse());
    }

    /// <summary> TODO. </summary>
    /// <param name="image"> TODO. </param>
    /// <param name="imageFilename"> TODO. </param>
    /// <param name="options"> TODO. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="image"/> or <paramref name="imageFilename"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="imageFilename"/> is an empty string, and was expected to be non-empty. </exception>
    public virtual ClientResult<GeneratedImage> GenerateImageVariation(Stream image, string imageFilename, ImageVariationOptions options = null)
    {
        Argument.AssertNotNull(image, nameof(image));
        Argument.AssertNotNullOrEmpty(imageFilename, nameof(imageFilename));

        options ??= new();
        CreateImageVariationOptions(image, imageFilename, null, ref options);

        using MultipartFormDataBinaryContent content = options.ToMultipartContent(image, imageFilename);
        ClientResult result = GenerateImageVariations(content, content.ContentType);
        return ClientResult.FromValue(GeneratedImageCollection.FromResponse(result.GetRawResponse()).FirstOrDefault(), result.GetRawResponse());
    }

    /// <summary> TODO. </summary>
    /// <param name="image"> TODO. </param>
    /// <param name="imageFilename"> TODO. </param>
    /// <param name="imageCount"> TODO. </param>
    /// <param name="options"> TODO. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="image"/> or <paramref name="imageFilename"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="imageFilename"/> is an empty string, and was expected to be non-empty. </exception>
    public virtual async Task<ClientResult<GeneratedImageCollection>> GenerateImageVariationsAsync(Stream image, string imageFilename, int? imageCount = null, ImageVariationOptions options = null)
    {
        Argument.AssertNotNull(image, nameof(image));
        Argument.AssertNotNullOrEmpty(imageFilename, nameof(imageFilename));

        options ??= new();
        CreateImageVariationOptions(image, imageFilename, imageCount, ref options);

        using MultipartFormDataBinaryContent content = options.ToMultipartContent(image, imageFilename);
        ClientResult result = await GenerateImageVariationsAsync(content, content.ContentType).ConfigureAwait(false);
        return ClientResult.FromValue(GeneratedImageCollection.FromResponse(result.GetRawResponse()), result.GetRawResponse());
    }

    /// <summary> TODO. </summary>
    /// <param name="image"> TODO. </param>
    /// <param name="imageFilename"> TODO. </param>
    /// <param name="imageCount"> TODO. </param>
    /// <param name="options"> TODO. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="image"/> or <paramref name="imageFilename"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="imageFilename"/> is an empty string, and was expected to be non-empty. </exception>
    public virtual ClientResult<GeneratedImageCollection> GenerateImageVariations(Stream image, string imageFilename, int? imageCount = null, ImageVariationOptions options = null)
    {
        Argument.AssertNotNull(image, nameof(image));
        Argument.AssertNotNullOrEmpty(imageFilename, nameof(imageFilename));

        options ??= new();
        CreateImageVariationOptions(image, imageFilename, imageCount, ref options);

        using MultipartFormDataBinaryContent content = options.ToMultipartContent(image, imageFilename);
        ClientResult result = GenerateImageVariations(content, content.ContentType);
        return ClientResult.FromValue(GeneratedImageCollection.FromResponse(result.GetRawResponse()), result.GetRawResponse());
    }

    #endregion

    private void CreateImageGenerationOptions(string prompt, int? imageCount, ref ImageGenerationOptions options)
    {
        options.Prompt = prompt;
        options.N = imageCount;
        options.Model = _model;
    }

    private void CreateImageEditOptions(Stream image, string imageFilename, string prompt, Stream mask, string maskFilename, int? imageCount, ref ImageEditOptions options)
    {
        options.Prompt = prompt;
        options.N = imageCount;
        options.Model = _model;
    }

    private void CreateImageVariationOptions(Stream image, string imageFilename, int? imageCount, ref ImageVariationOptions options)
    {
        options.N = imageCount;
        options.Model = _model;
    }
}
