// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;

namespace Azure.AI.OpenAI.Assistants;

/// <summary>
/// The scenario client used for assistant operations with the Azure OpenAI service.
/// </summary>
/// <remarks>
/// To retrieve an instance of this type, use the matching method on <see cref="AzureOpenAIClient"/>.
/// </remarks>
internal partial class AzureAssistantClient : AssistantClient
{
    private readonly Uri _endpoint;
    private readonly ServiceVersion _apiVersion;
    private readonly AzureOpenAIPipelineMessageBuilder _messageBuilder;

    internal AzureAssistantClient(ClientPipeline pipeline, Uri endpoint, AzureOpenAIClientOptions options)
        : base(pipeline, new OpenAIClientOptions() { Endpoint = endpoint })
    {
        Argument.AssertNotNull(pipeline, nameof(pipeline));
        Argument.AssertNotNull(endpoint, nameof(endpoint));

        _endpoint = endpoint;
        _apiVersion = options?.Version ?? ServiceVersion.Default;
        _messageBuilder = new(pipeline, _endpoint, _apiVersion);
    }

    protected AzureAssistantClient()
    { }
}
