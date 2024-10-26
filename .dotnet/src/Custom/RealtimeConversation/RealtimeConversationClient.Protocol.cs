using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.ClientModel.Primitives.TwoWayClient;
using System.Threading.Tasks;

namespace OpenAI.RealtimeConversation;

public partial class RealtimeConversationClient
{
    // This can take the configuration for the conversation
    // Does this make sense?  It is not part of the HTTP protocol, so maybe we want to keep
    // that as a separate message on the conversation after it is created.
    // Maybe that is only part of the convenience overload.
    public virtual async Task<RealtimeConversation> StartConversationAsync(
        BinaryContent configuration,
        // TODO: Maybe there is a subtype of TwoWayPipelineOptions specific to the
        // conversation?  Maybe it holds the configuration for the conversation, too?
        TwoWayPipelineOptions conversationOptions,
        RequestOptions options)
    {
        // TODO: are inputs needed to create a unique conversation?
        //Argument.AssertNotNullOrEmpty(assistantId, nameof(assistantId));

        using PipelineMessage message = CreateStartConversationRequest(options);


        PipelineResponse response = await _pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false);

        RealtimeConversation result = new RealtimeConversation(response, )

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

    private PipelineMessage CreateStartConversationRequest(RequestOptions options)
    {
        // TODO: Add this
        //_clientWebSocket.Options.SetRequestHeader("openai-beta", $"realtime=v1");

        throw new NotImplementedException();
    }
}