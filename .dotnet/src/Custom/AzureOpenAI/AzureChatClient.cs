// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using OpenAI.Chat;
using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading;

namespace Azure.AI.OpenAI.Chat;

/// <summary>
/// The scenario client used for chat completion operations with the Azure OpenAI service.
/// </summary>
/// <remarks>
/// To retrieve an instance of this type, use the matching method on <see cref="AzureOpenAIClient"/>.
/// </remarks>
public partial class AzureChatClient : ChatClient
{
    private readonly string _deploymentName;
    private readonly Uri _endpoint;
    private readonly string _apiVersion;

    public AzureChatClient(
        string deploymentName,
        AzureOpenAIClientOptions options = null)
        : this(
            AzureOpenAIClient.CreatePipeline(
                AzureOpenAIClient.GetApiKey(),
                options),
            AzureOpenAIClient.GetEndpoint(),
            deploymentName,
            AzureOpenAIClient.GetApiVersion(),
            options)
    {}

    public AzureChatClient(
        Uri resourceEndpoint,
        string deploymentName,
        string apiVersion,
        ApiKeyCredential credential,
        AzureOpenAIClientOptions options = null)
        : this(
            AzureOpenAIClient.CreatePipeline(credential, options),
            resourceEndpoint,
            deploymentName,
            apiVersion,
            options)
        {}

    internal AzureChatClient(
        ClientPipeline pipeline,
        Uri endpoint,
        string deploymentName,
        string apiVersion,
        AzureOpenAIClientOptions options)
            : base(pipeline, model: deploymentName, endpoint, null)
    {
        options ??= new();
        _deploymentName = deploymentName;
        _endpoint = endpoint;
        _apiVersion = apiVersion;
    }

    protected AzureChatClient()
    { }

    /// <inheritdoc/>
    public override AsyncResultCollection<StreamingChatCompletionUpdate> CompleteChatStreamingAsync(IEnumerable<ChatMessage> messages, ChatCompletionOptions options = null, CancellationToken cancellationToken = default)
    {
        options ??= new();
        options.StreamOptions = null;
        return base.CompleteChatStreamingAsync(messages, options, cancellationToken);
    }

    /// <inheritdoc/>
    public override ResultCollection<StreamingChatCompletionUpdate> CompleteChatStreaming(IEnumerable<ChatMessage> messages, ChatCompletionOptions options = null, CancellationToken cancellationToken = default)
    {
        options ??= new();
        options.StreamOptions = null;
        return base.CompleteChatStreaming(messages, options, cancellationToken);
    }
}
