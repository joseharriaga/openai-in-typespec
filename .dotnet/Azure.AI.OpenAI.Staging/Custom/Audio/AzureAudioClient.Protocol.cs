// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using OpenAI;
using OpenAI.Audio;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text;

namespace Azure.AI.OpenAI.Staging.Audio;

internal partial class AzureAudioClient : AudioClient
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override ClientResult TranscribeAudio(BinaryContent content, string contentType, RequestOptions options = null)
    {
        using PipelineMessage message = CreateTranscriptionRequestMessage(content, contentType, options);
        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override async Task<ClientResult> TranscribeAudioAsync(BinaryContent content, string contentType, RequestOptions options = null)
    {
        using PipelineMessage message = CreateTranscriptionRequestMessage(content, contentType, options);
        PipelineResponse response = await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false);
        return ClientResult.FromResponse(response);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override ClientResult TranslateAudio(BinaryContent content, string contentType, RequestOptions options = null)
    {
        using PipelineMessage message = CreateTranslationRequestMessage(content, contentType, options);
        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override async Task<ClientResult> TranslateAudioAsync(BinaryContent content, string contentType, RequestOptions options = null)
    {
        using PipelineMessage message = CreateTranslationRequestMessage(content, contentType, options);
        PipelineResponse response = await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false);
        return ClientResult.FromResponse(response);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override ClientResult GenerateSpeechFromText(BinaryContent content, RequestOptions options = null)
    {
        using PipelineMessage message = CreateSpeechGenerationRequestMessage(content, options);
        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override async Task<ClientResult> GenerateSpeechFromTextAsync(BinaryContent content, RequestOptions options = null)
    {
        using PipelineMessage message = CreateSpeechGenerationRequestMessage(content, options);
        PipelineResponse response = await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false);
        return ClientResult.FromResponse(response);
    }

    private PipelineMessage CreateAudioPipelineMessage(
        string operation,
        BinaryContent content,
        string contentTypeHeaderValue,
        string acceptHeaderValue,
        RequestOptions options = null)
    {
        PipelineMessage message = Pipeline.CreateMessage();
        message.ResponseClassifier = AzureOpenAIClient.PipelineMessageClassifier200;
        PipelineRequest request = message.Request;
        request.Method = "POST";
        UriBuilder uriBuilder = new(_endpoint.AbsoluteUri);
        StringBuilder path = new();
        path.Append($"openai/deployments/{_deploymentName}/audio/{operation}");
        uriBuilder.Path += path.ToString();
        uriBuilder.Query += $"?api-version={_apiVersion}";
        request.Uri = uriBuilder.Uri;
        request.Headers.Set("Accept", acceptHeaderValue);
        request.Headers.Set("Content-Type", contentTypeHeaderValue);
        request.Content = content;
        message.Apply(options ?? null);
        return message;
    }

    private PipelineMessage CreateTranscriptionRequestMessage(BinaryContent content, string contentType, RequestOptions options)
        => CreateAudioPipelineMessage("transcriptions", content, contentType, "application/json", options);

    private PipelineMessage CreateTranslationRequestMessage(BinaryContent content, string contentType, RequestOptions options)
        => CreateAudioPipelineMessage("translations", content, contentType, "application/json", options);

    private PipelineMessage CreateSpeechGenerationRequestMessage(BinaryContent content, RequestOptions options)
        => CreateAudioPipelineMessage("speech", content, "application/json", "application/octet-stream", options);
}
