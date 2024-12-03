// customizations for Java
import "@azure-tools/typespec-client-generator-core";

import "../models.tsp";

using Azure.ClientGenerator.Core;
using OpenAI;

// RealtimeClientEvent subclass renames
@@clientName(RealtimeClientEventSessionUpdate, "SessionUpdateEvent", "java");
@@clientName(RealtimeClientEventInputAudioBufferAppend, "InputAudioBufferAppendEvent", "java");
@@clientName(RealtimeClientEventInputAudioBufferCommit, "InputAudioBufferCommitEvent", "java");
@@clientName(RealtimeClientEventInputAudioBufferClear, "InputAudioBufferClearEvent", "java");
@@clientName(RealtimeClientEventConversationItemCreate, "ConversationItemCreateEvent", "java");
@@clientName(RealtimeClientEventConversationItemTruncate, "ConversationItemTruncateEvent", "java");
@@clientName(RealtimeClientEventConversationItemDelete, "ConversationItemDeleteEvent", "java");
@@clientName(RealtimeClientEventResponseCreate, "ResponseCreateEvent", "java");
@@clientName(RealtimeClientEventResponseCancel, "ResponseCancelEvent", "java");

// RealtimeServerEvent subclass renames
@@clientName(RealtimeServerEventSessionCreated, "SessionCreatedEvent", "java");
@@clientName(RealtimeServerEventSessionUpdated, "SessionUpdatedEvent", "java");
@@clientName(RealtimeServerEventConversationCreated, "ConversationCreatedEvent", "java");
@@clientName(RealtimeServerEventInputAudioBufferCommitted, "InputAudioBufferCommittedEvent", "java");
@@clientName(RealtimeServerEventInputAudioBufferCleared, "InputAudioBufferClearedEvent", "java");
@@clientName(RealtimeServerEventInputAudioBufferSpeechStarted, "InputAudioBufferSpeechStartedEvent", "java");
@@clientName(RealtimeServerEventInputAudioBufferSpeechStopped, "InputAudioBufferSpeechStoppedEvent", "java");
@@clientName(RealtimeServerEventConversationItemCreated, "ConversationItemCreatedEvent", "java");
@@clientName(RealtimeServerEventConversationItemInputAudioTranscriptionCompleted, "ConversationItemInputAudioTranscriptionCompletedEvent", "java");
@@clientName(RealtimeServerEventConversationItemInputAudioTranscriptionFailed, "ConversationItemInputAudioTranscriptionFailedEvent", "java");
@@clientName(RealtimeServerEventConversationItemTruncated, "ConversationItemTruncatedEvent", "java");
@@clientName(RealtimeServerEventConversationItemDeleted, "ConversationItemDeletedEvent", "java");
@@clientName(RealtimeServerEventResponseCreated, "ResponseCreatedEvent", "java");
@@clientName(RealtimeServerEventResponseDone, "ResponseDoneEvent", "java");
@@clientName(RealtimeServerEventResponseOutputItemAdded, "ResponseOutputItemAddedEvent", "java");
@@clientName(RealtimeServerEventResponseOutputItemDone, "ResponseOutputItemDoneEvent", "java");
@@clientName(RealtimeServerEventResponseContentPartAdded, "ResponseContentPartAddedEvent", "java");
@@clientName(RealtimeServerEventResponseContentPartDone, "ResponseContentPartDoneEvent", "java");
@@clientName(RealtimeServerEventResponseTextDelta, "ResponseTextDeltaEvent", "java");
@@clientName(RealtimeServerEventResponseTextDone, "ResponseTextDoneEvent", "java");
@@clientName(RealtimeServerEventResponseAudioTranscriptDelta, "ResponseAudioTranscriptDeltaEvent", "java");
@@clientName(RealtimeServerEventResponseAudioTranscriptDone, "ResponseAudioTranscriptDoneEvent", "java");
@@clientName(RealtimeServerEventResponseAudioDelta, "ResponseAudioDeltaEvent", "java");
@@clientName(RealtimeServerEventResponseAudioDone, "ResponseAudioDoneEvent", "java");
@@clientName(RealtimeServerEventResponseFunctionCallArgumentsDelta, "ResponseFunctionCallArgumentsDeltaEvent", "java");
@@clientName(RealtimeServerEventResponseFunctionCallArgumentsDone, "ResponseFunctionCallArgumentsDoneEvent", "java");
@@clientName(RealtimeServerEventRateLimitsUpdated, "RateLimitsUpdatedEvent", "java");
