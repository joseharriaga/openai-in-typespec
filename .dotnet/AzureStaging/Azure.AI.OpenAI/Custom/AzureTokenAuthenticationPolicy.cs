// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System.ClientModel.Primitives;

namespace Azure.AI.OpenAI;

internal partial class AzureTokenAuthenticationPolicy : PipelinePolicy
{
    private readonly TokenCredential _credential;
    private AccessToken? _currentToken;

    public AzureTokenAuthenticationPolicy(TokenCredential credential)
    {
        _credential = credential;
    }

    public override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        if (!_currentToken.HasValue || _currentToken.Value.ExpiresOn < DateTimeOffset.UtcNow + TimeSpan.FromSeconds(30))
        {
            _currentToken = _credential.GetToken(DefaultTokenRequestContext, cancellationToken: default);
        }
        message?.Request?.Headers?.Add("Authorization", $"Bearer {_currentToken.Value.Token}");
        ProcessNext(message, pipeline, currentIndex);
    }

    public override async ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        if (!_currentToken.HasValue || _currentToken.Value.ExpiresOn < DateTimeOffset.UtcNow + TimeSpan.FromSeconds(30))
        {
            _currentToken = await _credential.GetTokenAsync(DefaultTokenRequestContext, cancellationToken: default);
        }
        message?.Request?.Headers?.Add("Authorization", $"Bearer {_currentToken.Value.Token}");
        await ProcessNextAsync(message, pipeline, currentIndex);
    }

    private static readonly TokenRequestContext DefaultTokenRequestContext = new(["https://cognitiveservices.azure.com/.default"]);
}