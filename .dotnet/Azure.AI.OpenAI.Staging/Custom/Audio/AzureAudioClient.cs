// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using OpenAI.Audio;
using System.ClientModel;
using System.ClientModel.Primitives;

namespace Azure.AI.OpenAI.Staging.Audio;

public partial class AzureAudioClient : AudioClient
{
    private readonly string _apiVersion;

    public AzureAudioClient(
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

    public AzureAudioClient(
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

    protected internal AzureAudioClient(
        string deploymentName,
        ClientPipeline pipeline,
        Uri endpoint,
        AzureOpenAIClientOptions options)
            : base(pipeline, model: deploymentName, credential: null, endpoint)
    {
        _apiVersion = options?.ApiVersion ?? AzureOpenAIClientOptions.AzureOpenAIServiceApiVersion.Latest;
    }

    protected AzureAudioClient()
    { }
}
