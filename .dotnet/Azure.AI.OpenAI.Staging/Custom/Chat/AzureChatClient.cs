// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using OpenAI.Chat;
using System.ClientModel;
using System.ClientModel.Primitives;

namespace Azure.AI.OpenAI.Staging.Chat;

public partial class AzureChatClient : ChatClient
{
    private readonly string _apiVersion;

    public AzureChatClient(
        string deploymentName,
        Uri endpoint = null,
        ApiKeyCredential credential = null,
        AzureOpenAIClientOptions options = null)
            : this(
                  deploymentName,
                  AzureOpenAIClient.CreatePipeline(credential),
                  endpoint ?? AzureOpenAIClient.GetConfiguredEndpoint(options),
                  options)
    {}

    public AzureChatClient(
        string deploymentName,
        Uri endpoint,
        TokenCredential credential,
        AzureOpenAIClientOptions options = null)
            : this(
                  deploymentName,
                  AzureOpenAIClient.CreatePipeline(credential),
                  endpoint ?? AzureOpenAIClient.GetConfiguredEndpoint(options),
                  options)
    {}

    protected internal AzureChatClient(
        string deploymentName,
        ClientPipeline pipeline,
        Uri endpoint,
        AzureOpenAIClientOptions options)
            : base(model: deploymentName, pipeline, endpoint)
    {
        _apiVersion = options?.ApiVersion ?? AzureOpenAIClientOptions.AzureOpenAIServiceApiVersion.Latest;
    }

    protected AzureChatClient()
    { }
}
