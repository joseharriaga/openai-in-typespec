// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using OpenAI.Images;
using System.ClientModel;
using System.ClientModel.Primitives;

namespace Azure.AI.OpenAI.Staging.Images;

public partial class AzureImageClient : ImageClient
{
    private readonly string _apiVersion;

    public AzureImageClient(
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

    public AzureImageClient(
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

    protected internal AzureImageClient(
        string deploymentName,
        ClientPipeline pipeline,
        Uri endpoint,
        AzureOpenAIClientOptions options)
            : base(pipeline, model: deploymentName, credential: null, endpoint)
    {
        _apiVersion = options?.ApiVersion ?? AzureOpenAIClientOptions.AzureOpenAIServiceApiVersion.Latest;
    }

    protected AzureImageClient()
    {}
}
