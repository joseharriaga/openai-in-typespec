// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using OpenAI.FineTuning;
using System.ClientModel;
using System.ClientModel.Primitives;

namespace Azure.AI.OpenAI.Staging.FineTuning;

public partial class AzureFineTuningClient : FineTuningClient
{
    private readonly string _apiVersion;

    public AzureFineTuningClient(
        Uri endpoint = null,
        ApiKeyCredential credential = null,
        AzureOpenAIClientOptions options = null)
            : this(
                  AzureOpenAIClient.CreatePipeline(credential),
                  endpoint ?? AzureOpenAIClient.GetConfiguredEndpoint(options),
                  options)
    {}

    public AzureFineTuningClient(
        Uri endpoint,
        TokenCredential credential,
        AzureOpenAIClientOptions options = null)
            : this(
                  AzureOpenAIClient.CreatePipeline(credential),
                  endpoint ?? AzureOpenAIClient.GetConfiguredEndpoint(options),
                  options)
    {}

    protected internal AzureFineTuningClient(
        ClientPipeline pipeline,
        Uri endpoint,
        AzureOpenAIClientOptions options)
            : base(pipeline, credential: null, endpoint)
    {
        _apiVersion = options?.ApiVersion ?? AzureOpenAIClientOptions.AzureOpenAIServiceApiVersion.Latest;
    }

    protected AzureFineTuningClient()
    { }
}
