// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;
using System.ClientModel.Primitives.TwoWayClient;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.OpenAI.RealtimeConversation;

[Experimental("OPENAI002")]
internal partial class AzureRealtimeConversationClient : RealtimeConversationClient
{
    // TODO: validate that Azure client can derive from OAI client
    // and modify endpoint and credential as needed.

    public override Task<AssistantConversation> StartConversationAsync(BinaryContent configuration, TwoWayPipelineOptions conversationOptions, RequestOptions requestOptions)
    {
        return base.StartConversationAsync(configuration, conversationOptions, requestOptions);
    }

    ///// <summary>
    ///// <para>[Protocol Method]</para>
    ///// Creates a new realtime conversation operation instance, establishing a connection with the /realtime endpoint.
    ///// </summary>
    ///// <param name="options"></param>
    ///// <returns></returns>
    //[EditorBrowsable(EditorBrowsableState.Never)]
    //public override Task<AssistantConversation> StartConversationAsync(RequestOptions options)
    //{
    //    throw new NotImplementedException();

    //    //AssistantConversation provisionalOperation = _tokenCredential is not null
    //    //    ? new AzureRealtimeConversationSession(this, _endpoint, _tokenCredential, _tokenAuthorizationScopes, _userAgent)
    //    //    : new AzureRealtimeConversationSession(this, _endpoint, _credential, _userAgent);
    //    //try
    //    //{
    //    //    // TODO
    //    //    //await provisionalOperation.ConnectAsync(options).ConfigureAwait(false);
    //    //    AssistantConversation result = provisionalOperation;
    //    //    provisionalOperation = null;
    //    //    return result;
    //    //}
    //    //finally
    //    //{
    //    //    provisionalOperation?.Dispose();
    //    //}
    //}
}
