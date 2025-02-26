﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if !AZURE_OPENAI_GA

using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.OpenAI.FineTuning;

/// <summary>
/// The scenario client used for fine-tuning operations with the Azure OpenAI service.
/// </summary>
/// <remarks>
/// To retrieve an instance of this type, use the matching method on <see cref="AzureOpenAIClient"/>.
/// </remarks>
[Experimental("OPENAI001")]
internal partial class AzureFineTuningClient : FineTuningClient
{
    private readonly Uri _endpoint;
    private readonly string _apiVersion;

    [Experimental("OPENAI001")]
    internal AzureFineTuningClient(ClientPipeline pipeline, Uri endpoint)
        : base(pipeline, new OpenAIClientOptions() { Endpoint = endpoint })
    {
        Argument.AssertNotNull(pipeline, nameof(pipeline));
        Argument.AssertNotNull(endpoint, nameof(endpoint));
        AzureOpenAIClientOptions options = new();

        _endpoint = endpoint;
        _apiVersion = options.GetRawServiceApiValueForClient(this);
    }

    [Experimental("OPENAI001")]
    protected AzureFineTuningClient()
    { }

    [Experimental("OPENAI001")]
    internal override FineTuningJob CreateJobFromResponse(PipelineResponse response)
    {
        return new AzureFineTuningJob(Pipeline, _endpoint, response);
    }
}

#endif