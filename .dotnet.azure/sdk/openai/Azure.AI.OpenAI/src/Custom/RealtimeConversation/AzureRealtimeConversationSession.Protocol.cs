﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Primitives.TwoWayClient;

namespace Azure.AI.OpenAI.RealtimeConversation;

internal partial class AzureRealtimeConversation : AssistantConversation
{
    public AzureRealtimeConversation(PipelineResponse response, TwoWayPipelineOptions options) : base(response, options)
    {
    }

    //[EditorBrowsable(EditorBrowsableState.Never)]
    //internal override async Task ConnectAsync(RequestOptions options)
    //{
    //    ClientUriBuilder uriBuilder = new();
    //    uriBuilder.Reset(_endpoint);

    //    if (_tokenCredential is not null)
    //    {
    //        AccessToken token = await _tokenCredential.GetTokenAsync(_tokenRequestContext, options?.CancellationToken ?? default).ConfigureAwait(false);
    //        _clientWebSocket.Options.SetRequestHeader("Authorization", $"Bearer {token.Token}");
    //    }
    //    else
    //    {
    //        _keyCredential.Deconstruct(out string dangerousCredential);
    //        _clientWebSocket.Options.SetRequestHeader("api-key", dangerousCredential);
    //        // uriBuilder.AppendQuery("api-key", dangerousCredential, escape: false);
    //    }

    //    Uri endpoint = uriBuilder.ToUri();

    //    try
    //    {
    //        await _clientWebSocket.ConnectAsync(endpoint, options?.CancellationToken ?? default)
    //            .ConfigureAwait(false);
    //    }
    //    catch (WebSocketException)
    //    {
    //        throw;
    //    }
    //}
}
