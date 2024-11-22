// customizations for Java
import "@azure-tools/typespec-client-generator-core";

import "../models.tsp";

using Azure.ClientGenerator.Core;
using OpenAI;

// RealtimeClientEvent subclass renames
@@clientName(RealtimeClientEventSessionUpdate, "arg", "java");
@@clientName(RealtimeClientEventInputAudioBufferAppend, "arg", "java");
@@clientName(RealtimeClientEventInputAudioBufferCommit, "arg", "java");
@@clientName(RealtimeClientEventInputAudioBufferClear, "arg", "java");
@@clientName(RealtimeClientEventConversationItemCreate, "arg", "java");
@@clientName(RealtimeClientEventConversationItemTruncate, "arg", "java");
@@clientName(RealtimeClientEventConversationItemDelete, "arg", "java");
@@clientName(RealtimeClientEventResponseCreate, "arg", "java");
@@clientName(RealtimeClientEventResponseCancel, "arg", "java");

// RealtimeServerEvent subclass renames
@@clientName(RealtimeServerEventSessionCreated, "arg", "java");
@@clientName(RealtimeServerEventSessionUpdated, "arg", "java");
@@clientName(RealtimeServerEventConversationCreated, "arg", "java");
@@clientName(RealtimeServerEventInputAudioBufferCommitted, "arg", "java");
@@clientName(RealtimeServerEventInputAudioBufferCleared, "arg", "java");
@@clientName(RealtimeServerEventInputAudioBufferSpeechStarted, "arg", "java");
@@clientName(RealtimeServerEventInputAudioBufferSpeechStopped, "arg", "java");
@@clientName(RealtimeServerEventConversationItemCreated, "arg", "java");
@@clientName(RealtimeServerEventConversationItemInputAudioTranscriptionCompleted, "arg", "java");
@@clientName(RealtimeServerEventConversationItemInputAudioTranscriptionFailed, "arg", "java");
@@clientName(RealtimeServerEventConversationItemTruncated, "arg", "java");
@@clientName(RealtimeServerEventConversationItemDeleted, "arg", "java");
@@clientName(RealtimeServerEventResponseCreated, "arg", "java");
@@clientName(RealtimeServerEventResponseDone, "arg", "java");
@@clientName(RealtimeServerEventResponseOutputItemAdded, "arg", "java");
@@clientName(RealtimeServerEventResponseOutputItemDone, "arg", "java");
@@clientName(RealtimeServerEventResponseContentPartAdded, "arg", "java");
@@clientName(RealtimeServerEventResponseContentPartDone, "arg", "java");
@@clientName(RealtimeServerEventResponseTextDelta, "arg", "java");
@@clientName(RealtimeServerEventResponseTextDone, "arg", "java");
@@clientName(RealtimeServerEventResponseAudioTranscriptDelta, "arg", "java");
@@clientName(RealtimeServerEventResponseAudioTranscriptDone, "arg", "java");
@@clientName(RealtimeServerEventResponseAudioDelta, "arg", "java");
@@clientName(RealtimeServerEventResponseAudioDone, "arg", "java");
@@clientName(RealtimeServerEventResponseFunctionCallArgumentsDelta, "arg", "java");
@@clientName(RealtimeServerEventResponseFunctionCallArgumentsDone, "arg", "java");
@@clientName(RealtimeServerEventRateLimitsUpdated, "arg", "java");
