using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.ClientModel.Primitives.TwoWayClient;
using System.Threading.Tasks;

#nullable enable

namespace OpenAI.RealtimeConversation;

public partial class RealtimeConversationClient
{
    // This can take the configuration for the conversation
    // Does this make sense?  It is not part of the HTTP protocol, so maybe we want to keep
    // that as a separate message on the conversation after it is created.
    // Maybe that is only part of the convenience overload.
    public virtual async Task<AssistantConversation> StartConversationAsync(
        BinaryContent configuration,
        // TODO: Maybe there is a subtype of TwoWayPipelineOptions specific to the
        // conversation?  Maybe it holds the configuration for the conversation, too?
        // What goes on these options and do they need to be different from request options?
        // Is there a story about the convenience overload that meshes well here?
        TwoWayPipelineOptions conversationOptions,
        RequestOptions requestOptions)
    {
        // TODO: are inputs needed to create a unique conversation?
        //Argument.AssertNotNullOrEmpty(assistantId, nameof(assistantId));

        using PipelineMessage message = CreateStartConversationRequest(requestOptions);

        // Note: this does everything Connect does, I believe, so no separate
        // "Connect" call is needed.
        PipelineResponse response = await _pipeline.ProcessMessageAsync(message, requestOptions).ConfigureAwait(false);

        AssistantConversation result = new(response, conversationOptions);

        // TODO: validate that the conversation subclient is returned ready for
        // a caller to send a message with, or start listening for responses on.
        return result;

        //RealtimeConversation provisionalSession = new(this, _endpoint, _credential);
        //try
        //{
        //    await provisionalSession.ConnectAsync(options).ConfigureAwait(false);
        //    RealtimeConversation result = provisionalSession;
        //    provisionalSession = null;
        //    return result;
        //}
        //finally
        //{
        //    provisionalSession?.Dispose();
        //}
    }

    public virtual AssistantConversation StartConversation(
        BinaryContent configuration,
        TwoWayPipelineOptions conversationOptions,
        RequestOptions requestOptions)
    {
        throw new NotImplementedException();
    }

    // HTTP request creation helper -- boilerplate .NET client pattern
    private PipelineMessage CreateStartConversationRequest(RequestOptions options)
    {
        // TODO: Add this
        //_clientWebSocket.Options.SetRequestHeader("openai-beta", $"realtime=v1");
        //_clientWebSocket.Options.AddSubProtocol("realtime");

        throw new NotImplementedException();
    }
}