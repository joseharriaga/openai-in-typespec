using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;

namespace OpenAI.Images;

[CodeGenSuppress("CreateImageAsync", typeof(BinaryContent), typeof(RequestOptions))]
[CodeGenSuppress("CreateImage", typeof(BinaryContent), typeof(RequestOptions))]
[CodeGenSuppress("CreateImageEditAsync", typeof(BinaryContent), typeof(RequestOptions))]
[CodeGenSuppress("CreateImageEdit", typeof(BinaryContent), typeof(RequestOptions))]
[CodeGenSuppress("CreateImageVariationAsync", typeof(BinaryContent), typeof(RequestOptions))]
[CodeGenSuppress("CreateImageVariation", typeof(BinaryContent), typeof(RequestOptions))]
public partial class ImageClient
{
    // CUSTOM:
    // - Renamed.
    // - Edited the cref in the doc comment to point to the correct convenience overload after it was also renamed.
    // - Added the EditorBrowsable attribute to hide protocol methods from IntelliSense when a convenience overload is available.
    /// <summary>
    /// [Protocol Method] Creates an image given a prompt
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Please try the simpler <see cref="GenerateImagesAsync(string, int?, ImageGenerationOptions)"/> convenience overload with strongly typed models first.
    /// </description>
    /// </item>
    /// </list>
    /// </summary>
    /// <param name="content"> The content to send as the body of the request. </param>
    /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual async Task<ClientResult> GenerateImagesAsync(BinaryContent content, RequestOptions options = null)
    {
        Argument.AssertNotNull(content, nameof(content));

        using PipelineMessage message = CreateCreateImageRequest(content, options);
        return ClientResult.FromResponse(await _pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    // CUSTOM:
    // - Renamed.
    // - Edited the cref in the doc comment to point to the correct convenience overload after it was also renamed.
    // - Added the EditorBrowsable attribute to hide protocol methods from IntelliSense when a convenience overload is available.
    /// <summary>
    /// [Protocol Method] Creates an image given a prompt
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Please try the simpler <see cref="GenerateImagesAsync(string, int?, ImageGenerationOptions)"/> convenience overload with strongly typed models first.
    /// </description>
    /// </item>
    /// </list>
    /// </summary>
    /// <param name="content"> The content to send as the body of the request. </param>
    /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual ClientResult GenerateImages(BinaryContent content, RequestOptions options = null)
    {
        Argument.AssertNotNull(content, nameof(content));

        using PipelineMessage message = CreateCreateImageRequest(content, options);
        return ClientResult.FromResponse(_pipeline.ProcessMessage(message, options));
    }

    // CUSTOM:
    // - Renamed.
    // - Edited the cref in the doc comment to point to the correct convenience overload after it was also renamed.
    // - Added the EditorBrowsable attribute to hide protocol methods from IntelliSense when a convenience overload is available.
    // - Parametrized the Content-Type header.
    /// <summary>
    /// [Protocol Method] Creates an edited or extended image given an original image and a prompt.
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Please try the simpler <see cref="GenerateImageEditsAsync(Stream, string, int?, ImageEditOptions)"/> convenience overload with strongly typed models first.
    /// </description>
    /// </item>
    /// </list>
    /// </summary>
    /// <param name="content"> The content to send as the body of the request. </param>
    /// <param name="contentType"> The content type of the request. </param>
    /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="contentType"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual async Task<ClientResult> GenerateImageEditsAsync(BinaryContent content, string contentType, RequestOptions options = null)
    {
        Argument.AssertNotNull(content, nameof(content));
        Argument.AssertNotNullOrEmpty(contentType, nameof(contentType));

        using PipelineMessage message = CreateCreateImageEditRequest(content, contentType, options);
        return ClientResult.FromResponse(await _pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    // CUSTOM:
    // - Renamed.
    // - Edited the cref in the doc comment to point to the correct convenience overload after it was also renamed.
    // - Added the EditorBrowsable attribute to hide protocol methods from IntelliSense when a convenience overload is available.
    // - Parametrized the Content-Type header.
    /// <summary>
    /// [Protocol Method] Creates an edited or extended image given an original image and a prompt.
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Please try the simpler <see cref="GenerateImageEditsAsync(Stream, string, int?, ImageEditOptions)"/> convenience overload with strongly typed models first.
    /// </description>
    /// </item>
    /// </list>
    /// </summary>
    /// <param name="content"> The content to send as the body of the request. </param>
    /// <param name="contentType"> The content type of the request. </param>
    /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="contentType"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual ClientResult GenerateImageEdits(BinaryContent content, string contentType, RequestOptions options = null)
    {
        Argument.AssertNotNull(content, nameof(content));
        Argument.AssertNotNullOrEmpty(contentType, nameof(contentType));

        using PipelineMessage message = CreateCreateImageEditRequest(content, contentType, options);
        return ClientResult.FromResponse(_pipeline.ProcessMessage(message, options));
    }

    // CUSTOM:
    // - Renamed.
    // - Edited the cref in the doc comment to point to the correct convenience overload after it was also renamed.
    // - Added the EditorBrowsable attribute to hide protocol methods from IntelliSense when a convenience overload is available.
    // - Parametrized the Content-Type header.
    /// <summary>
    /// [Protocol Method] Creates an edited or extended image given an original image and a prompt.
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Please try the simpler <see cref="GenerateImageVariationsAsync(Stream, string, int?, ImageVariationOptions)"/> convenience overload with strongly typed models first.
    /// </description>
    /// </item>
    /// </list>
    /// </summary>
    /// <param name="content"> The content to send as the body of the request. </param>
    /// <param name="contentType"> The content type of the request. </param>
    /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="contentType"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual async Task<ClientResult> GenerateImageVariationsAsync(BinaryContent content, string contentType, RequestOptions options = null)
    {
        Argument.AssertNotNull(content, nameof(content));
        Argument.AssertNotNullOrEmpty(contentType, nameof(contentType));

        using PipelineMessage message = CreateCreateImageVariationRequest(content, contentType, options);
        return ClientResult.FromResponse(await _pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    // CUSTOM:
    // - Renamed.
    // - Edited the cref in the doc comment to point to the correct convenience overload after it was also renamed.
    // - Added the EditorBrowsable attribute to hide protocol methods from IntelliSense when a convenience overload is available.
    // - Parametrized the Content-Type header.
    /// <summary>
    /// [Protocol Method] Creates an edited or extended image given an original image and a prompt.
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Please try the simpler <see cref="GenerateImageVariations(Stream, string, int?, ImageVariationOptions)"/> convenience overload with strongly typed models first.
    /// </description>
    /// </item>
    /// </list>
    /// </summary>
    /// <param name="content"> The content to send as the body of the request. </param>
    /// <param name="contentType"> The content type of the request. </param>
    /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="contentType"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual ClientResult GenerateImageVariations(BinaryContent content, string contentType, RequestOptions options = null)
    {
        Argument.AssertNotNull(content, nameof(content));
        Argument.AssertNotNullOrEmpty(contentType, nameof(contentType));

        using PipelineMessage message = CreateCreateImageVariationRequest(content, contentType, options);
        return ClientResult.FromResponse(_pipeline.ProcessMessage(message, options));
    }
}
