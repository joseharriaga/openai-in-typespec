﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using OpenAI.Batch;

namespace Azure.AI.OpenAI.Batch;

/// <summary>
/// The scenario client used for Files operations with the Azure OpenAI service.
/// </summary>
/// <remarks>
/// To retrieve an instance of this type, use the matching method on <see cref="AzureOpenAIClient"/>.
/// </remarks>
internal partial class AzureBatchClient : BatchClient
{
    private AzureOpenAIPipelineMessageBuilder _messageBuilder;

    internal AzureBatchClient(ClientPipeline pipeline, string deploymentName, Uri endpoint, AzureOpenAIClientOptions options)
        : base(pipeline, new OpenAIClientOptions() { Endpoint = endpoint })
    {
        Argument.AssertNotNull(pipeline, nameof(pipeline));
        Argument.AssertNotNullOrEmpty(deploymentName, nameof(deploymentName));
        Argument.AssertNotNull(endpoint, nameof(endpoint));

        _messageBuilder = new(pipeline, endpoint, options?.Version ?? ServiceVersion.Default, deploymentName);
    }

    protected AzureBatchClient()
    { }
}
