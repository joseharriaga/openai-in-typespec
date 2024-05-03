// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using OpenAI;
using OpenAI.Images;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text;

namespace Azure.AI.OpenAI.Staging.Images;

public partial class AzureImageClient : ImageClient
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override ClientResult GenerateImages(BinaryContent content, RequestOptions options = null)
    {
        using PipelineMessage message = CreateGenerateImagesRequestMessage(content, options);
        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override async Task<ClientResult> GenerateImagesAsync(BinaryContent content, RequestOptions options = null)
    {
        using PipelineMessage message = CreateGenerateImagesRequestMessage(content, options);
        PipelineResponse response = await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false);
        return ClientResult.FromResponse(response);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override ClientResult GenerateImageEdits(BinaryContent content, string contentType, RequestOptions options = null)
    {
        using PipelineMessage message = CreateGenerateImageEditsRequestMessage(content, contentType, options);
        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override async Task<ClientResult> GenerateImageEditsAsync(BinaryContent content, string contentType, RequestOptions options = null)
    {
        using PipelineMessage message = CreateGenerateImageEditsRequestMessage(content, contentType, options);
        PipelineResponse response = await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false);
        return ClientResult.FromResponse(response);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override ClientResult GenerateImageVariations(BinaryContent content, string contentType, RequestOptions options = null)
    {
        using PipelineMessage message = CreateGenerateImageVariationsRequestMessage(content, contentType, options);
        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override async Task<ClientResult> GenerateImageVariationsAsync(BinaryContent content, string contentType, RequestOptions options = null)
    {
        using PipelineMessage message = CreateGenerateImageVariationsRequestMessage(content, contentType, options);
        PipelineResponse response = await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false);
        return ClientResult.FromResponse(response);
    }

    private PipelineMessage CreateImagesRequestMessage(
        BinaryContent content,
        string operation,
        string contentType,
        RequestOptions options = null)
    {
        PipelineMessage message = Pipeline.CreateMessage();
        message.ResponseClassifier = AzureOpenAIClient.PipelineMessageClassifier200;
        PipelineRequest request = message.Request;
        request.Method = "POST";
        UriBuilder uriBuilder = new(_endpoint.AbsoluteUri);
        StringBuilder path = new();
        path.Append($"openai/deployments/{_model}/images/{operation}");
        uriBuilder.Path += path.ToString();
        uriBuilder.Query += $"?api-version={_apiVersion}";
        request.Uri = uriBuilder.Uri;
        request.Headers.Set("Accept", "application/json");
        request.Headers.Set("Content-Type", contentType);
        request.Content = content;
        message.Apply(options ?? AzureOpenAIClient.DefaultRequestOptions);
        return message;
    }

    private PipelineMessage CreateGenerateImagesRequestMessage(BinaryContent content, RequestOptions options = null)
        => CreateImagesRequestMessage(content, "generations", "application/json", options);

    private PipelineMessage CreateGenerateImageEditsRequestMessage(BinaryContent content, string contentType, RequestOptions options = null)
        => CreateImagesRequestMessage(content, "edits", contentType, options);

    private PipelineMessage CreateGenerateImageVariationsRequestMessage(BinaryContent content, string contentType, RequestOptions options = null)
        => CreateImagesRequestMessage(content, "variations", contentType, options);
}
