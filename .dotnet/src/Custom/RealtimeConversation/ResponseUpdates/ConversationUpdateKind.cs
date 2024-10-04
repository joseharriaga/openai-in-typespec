using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace OpenAI.RealtimeConversation;

[Experimental("OPENAI002")]
[CodeGenModel("RealtimeServerEventType")]
public enum ConversationUpdateKind
{
    Unknown,
    /// <summary>
    /// The <c>session.created</c> response command.
    /// </summary>
    [CodeGenMember("SessionCreated")]
    SessionStarted,
    /// <summary>
    /// The <c>session.updated</c> response command.
    /// </summary>
    [CodeGenMember("SessionUpdated")]
    SessionConfigured,
    [CodeGenMember("ConversationItemCreated")]
    ItemAcknowledged,
    ConversationCreated,
    /// <summary>
    /// The <c>conversation.item.deleted</c> response command.
    /// </summary>
    [CodeGenMember("ConversationItemDeleted")]
    ItemDeleted,
    /// <summary>
    /// The <c>conversation.item.truncated</c> response command.
    /// </summary>
    [CodeGenMember("ConversationItemTruncated")]
    ItemTruncated,
    /// <summary>
    /// The <c>response.created</c> response command.
    /// </summary>
    [CodeGenMember("ResponseCreated")]
    ResponseStarted,
    /// <summary>
    /// The <c>response.done</c> response command.
    /// </summary>
    [CodeGenMember("ResponseDone")]
    ResponseFinished,
    [CodeGenMember("RateLimitsUpdated")]
    RateLimitsUpdated,
    /// <summary>
    /// The <c>response.output_item.added</c> response command.
    /// </summary>
    [CodeGenMember("ResponseOutputItemAdded")]
    ItemStarted,
    /// <summary>
    /// The <c>response.output_item.done</c> response command.
    /// </summary>
    [CodeGenMember("ResponseOutputItemDone")]
    ItemFinished,
    /// <summary>
    /// The <c>response.content_part.added</c> response command.
    /// </summary>
    [CodeGenMember("ResponseContentPartAdded")]
    ContentPartStarted,
    /// <summary>
    /// The <c>response.content_part.done</c> response command.
    /// </summary>
    [CodeGenMember("ResponseContentPartDone")]
    ContentPartFinished,
    [CodeGenMember("ResponseAudioDelta")]
    ResponseAudioDelta,
    [CodeGenMember("ResponseAudioDone")]
    ResponseAudioDone,
    [CodeGenMember("ResponseAudioTranscriptDelta")]
    ResponseAudioTranscriptDelta,
    [CodeGenMember("ResponseAudioTranscriptDone")]
    ResponseAudioTranscriptDone,
    [CodeGenMember("ResponseTextDelta")]
    ResponseTextDelta,
    [CodeGenMember("ResponseTextDone")]
    ResponseTextDone,
    [CodeGenMember("ResponseFunctionCallArgumentsDelta")]
    ResponseFunctionCallArgumentsDelta,
    [CodeGenMember("ResponseFunctionCallArgumentsDone")]
    ResponseFunctionCallArgumentsDone,
    [CodeGenMember("InputAudioBufferSpeechStarted")]
    InputAudioBufferSpeechStarted,
    [CodeGenMember("InputAudioBufferSpeechStopped")]
    InputAudioBufferSpeechStopped,
    [CodeGenMember("ConversationItemInputAudioTranscriptionCompleted")]
    ItemInputAudioTranscriptionCompleted,
    [CodeGenMember("ConversationItemInputAudioTranscriptionFailed")]
    ItemInputAudioTranscriptionFailed,
    [CodeGenMember("InputAudioBufferCommitted")]
    InputAudioBufferCommitted,
    [CodeGenMember("InputAudioBufferCleared")]
    InputAudioBufferCleared,
    [CodeGenMember("Error")]
    Error
}