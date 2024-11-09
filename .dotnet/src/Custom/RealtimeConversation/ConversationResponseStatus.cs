using System;

namespace OpenAI.RealtimeConversation;

public partial class ConversationResponseStatus
{
    public ConversationResponseFinishReason FinishReason => _finishReason ??= GetFinishReason();
    public string ErrorCode => (_internalStatusDetails as InternalRealtimeResponseStatusDetailsFailed)?.Error?.Code;

    internal readonly InternalRealtimeResponseStatusKind _internalStatusKind;
    internal readonly InternalRealtimeResponseStatusDetails _internalStatusDetails;

    private ConversationResponseFinishReason? _finishReason;

    internal ConversationResponseStatus(
        InternalRealtimeResponseStatusKind internalStatusKind,
        InternalRealtimeResponseStatusDetails internalStatusDetails)
    {
        _internalStatusKind = internalStatusKind;
        _internalStatusDetails = internalStatusDetails;
    }

    private ConversationResponseFinishReason GetFinishReason()
    {
        if (_internalStatusKind == InternalRealtimeResponseStatusKind.InProgress)
        {
            return ConversationResponseFinishReason.InProgress;
        }
        if (_internalStatusKind == InternalRealtimeResponseStatusKind.Completed)
        {
            return ConversationResponseFinishReason.Completed;
        }
        if (_internalStatusKind == InternalRealtimeResponseStatusKind.Failed)
        {
            return ConversationResponseFinishReason.Failed;
        }
        if (_internalStatusDetails is InternalRealtimeResponseStatusDetailsCancelled cancelledDetails)
        {
            return new ConversationResponseFinishReason(cancelledDetails.Reason.ToObjectFromJson<string>());
        }
        if (_internalStatusDetails is InternalRealtimeResponseStatusDetailsIncomplete incompleteDetails)
        {
            return new ConversationResponseFinishReason(incompleteDetails.Reason.ToObjectFromJson<string>());
        }
        throw new ArgumentException($"Internal error: unexpected status/status_details combination: {_internalStatusKind}/{_internalStatusDetails}");
    }
}