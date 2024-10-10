using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace OpenAI.RealtimeConversation;

/// <summary>
/// The update (response command) of type <c>response.created</c>, which is received when a new service response turn
/// has been initiated. A response will snapshot conversation and input audio buffer state for the duration of
/// generation and may be triggered by either configured voice activity detection at end of speech or by a caller-
/// initiated <c>response.create</c>
/// (<see cref="RealtimeConversationSession.StartResponseTurnAsync(System.Threading.CancellationToken)"/>).
/// </summary>
[Experimental("OPENAI002")]
[CodeGenModel("RealtimeServerEventResponseCreated")]
public partial class ConversationResponseStartedUpdate
{
    [CodeGenMember("Response")]
    internal readonly InternalRealtimeResponse _internalResponse;
}
