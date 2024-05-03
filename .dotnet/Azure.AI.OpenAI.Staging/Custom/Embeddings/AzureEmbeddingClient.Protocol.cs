// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using OpenAI;
using OpenAI.Embeddings;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text;

namespace Azure.AI.OpenAI.Staging.Embeddings;

public partial class AzureEmbeddingClient : EmbeddingClient
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override ClientResult GenerateEmbedding(BinaryContent content, RequestOptions options = null)
    {
        using PipelineMessage message = CreateEmbeddingPipelineMessage(content, options);
        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override async Task<ClientResult> GenerateEmbeddingAsync(BinaryContent content, RequestOptions options = null)
    {
        using PipelineMessage message = CreateEmbeddingPipelineMessage(content, options);
        PipelineResponse response = await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false);
        return ClientResult.FromResponse(response);
    }

    private PipelineMessage CreateEmbeddingPipelineMessage(BinaryContent content, RequestOptions options = null)
    {
        PipelineMessage message = Pipeline.CreateMessage();
        message.ResponseClassifier = AzureOpenAIClient.PipelineMessageClassifier200;
        PipelineRequest request = message.Request;
        request.Method = "POST";
        UriBuilder uriBuilder = new(_endpoint.AbsoluteUri);
        StringBuilder path = new();
        path.Append($"openai/deployments/{_model}/embeddings");
        uriBuilder.Path += path.ToString();
        uriBuilder.Query += $"?api-version={_apiVersion}";
        request.Uri = uriBuilder.Uri;
        request.Headers.Set("Accept", "application/json");
        request.Headers.Set("Content-Type", "application/json");
        request.Content = content;
        message.Apply(options ?? AzureOpenAIClient.DefaultRequestOptions);
        return message;
    }
}
