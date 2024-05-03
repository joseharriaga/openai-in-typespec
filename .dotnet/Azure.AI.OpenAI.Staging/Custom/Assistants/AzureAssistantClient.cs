// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using OpenAI.Assistants;
using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.OpenAI.Staging.FineTuning;

/// <summary>
/// The scenario client used for assistant operations with the Azure OpenAI service.
/// </summary>
/// <remarks>
/// To retrieve an instance of this type, use the matching method on <see cref="AzureOpenAIClient"/>.
/// </remarks>
[Experimental("OPENAI001")]
internal partial class AzureAssistantClient : AssistantClient
{
    private readonly Uri _endpoint;
    private readonly string _apiVersion;

    protected internal AzureAssistantClient(
        ClientPipeline pipeline,
        Uri endpoint,
        AzureOpenAIClientOptions options)
            : base(pipeline, endpoint, options)
    {
        options ??= new();
        _endpoint = endpoint;
        _apiVersion = options.Version;

        throw new NotImplementedException($"Protocol support not yet implemented");
    }

    protected AzureAssistantClient()
    { }
}
