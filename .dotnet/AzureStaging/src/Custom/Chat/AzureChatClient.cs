// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using OpenAI.Chat;
using System.ClientModel;
using System.ClientModel.Primitives;

namespace Azure.AI.OpenAI.Chat;

/// <summary>
/// The scenario client used for chat completion operations with the Azure OpenAI service.
/// </summary>
/// <remarks>
/// To retrieve an instance of this type, use the matching method on <see cref="AzureOpenAIClient"/>.
/// </remarks>
internal partial class AzureChatClient : ChatClient
{
    private readonly string _deploymentName;
    private readonly Uri _endpoint;
    private readonly string _apiVersion;

    internal AzureChatClient(
        ClientPipeline pipeline,
        string deploymentName,
        Uri endpoint,
        AzureOpenAIClientOptions options)
            : base(pipeline, model: deploymentName, endpoint, options)
    {
        options ??= new();
        _deploymentName = deploymentName;
        _endpoint = endpoint;
        _apiVersion = options.Version;
    }

    protected AzureChatClient()
    { }

    /// <inheritdoc/>
    public override AsyncResultCollection<StreamingChatUpdate> CompleteChatStreamingAsync(IEnumerable<ChatMessage> messages, ChatCompletionOptions options = null)
    {
        options ??= new();
        options.StreamOptions = null;
        return base.CompleteChatStreamingAsync(messages, options);
    }

    /// <inheritdoc/>
    public override ResultCollection<StreamingChatUpdate> CompleteChatStreaming(IEnumerable<ChatMessage> messages, ChatCompletionOptions options = null)
    {
        options ??= new();
        options.StreamOptions = null;
        return base.CompleteChatStreaming(messages, options);
    }
}
