import "@azure-tools/typespec-client-generator-core";
import "./models.tsp";

using Azure.ClientGenerator.Core;
using OpenAI;

@@clientName(RealtimeClientEvent.type, "Kind", "csharp");
@@clientName(RealtimeClientEventSessionUpdate.type, "Kind", "csharp");
@@clientName(RealtimeClientEventInputAudioBufferAppend.type, "Kind", "csharp");
@@clientName(RealtimeClientEventInputAudioBufferCommit.type, "Kind", "csharp");
@@clientName(RealtimeClientEventInputAudioBufferClear.type, "Kind", "csharp");
@@clientName(RealtimeClientEventConversationItemCreate.type, "Kind", "csharp");
@@clientName(RealtimeClientEventConversationItemTruncate.type,
  "Kind",
  "csharp"
);
@@clientName(RealtimeClientEventConversationItemDelete.type, "Kind", "csharp");
@@clientName(RealtimeClientEventResponseCreate.type, "Kind", "csharp");
@@clientName(RealtimeClientEventResponseCancel.type, "Kind", "csharp");
@@clientName(RealtimeServerEvent.type, "Kind", "csharp");
@@clientName(RealtimeServerEventError.type, "Kind", "csharp");
@@clientName(RealtimeServerEventSessionCreated.type, "Kind", "csharp");
@@clientName(RealtimeServerEventSessionUpdated.type, "Kind", "csharp");
@@clientName(RealtimeServerEventConversationCreated.type, "Kind", "csharp");
@@clientName(RealtimeServerEventInputAudioBufferCommitted.type,
  "Kind",
  "csharp"
);
@@clientName(RealtimeServerEventInputAudioBufferCleared.type, "Kind", "csharp");
@@clientName(RealtimeServerEventInputAudioBufferSpeechStarted.type,
  "Kind",
  "csharp"
);
@@clientName(RealtimeServerEventInputAudioBufferSpeechStopped.type,
  "Kind",
  "csharp"
);
@@clientName(RealtimeServerEventConversationItemCreated.type, "Kind", "csharp");
@@clientName(RealtimeServerEventConversationItemInputAudioTranscriptionCompleted.type,
  "Kind",
  "csharp"
);
@@clientName(RealtimeServerEventConversationItemInputAudioTranscriptionFailed.type,
  "Kind",
  "csharp"
);
@@clientName(RealtimeServerEventConversationItemTruncated.type,
  "Kind",
  "csharp"
);
@@clientName(RealtimeServerEventConversationItemDeleted.type, "Kind", "csharp");
@@clientName(RealtimeServerEventResponseCreated.type, "Kind", "csharp");
@@clientName(RealtimeServerEventResponseDone.type, "Kind", "csharp");
@@clientName(RealtimeServerEventResponseOutputItemAdded.type, "Kind", "csharp");
@@clientName(RealtimeServerEventResponseOutputItemDone.type, "Kind", "csharp");
@@clientName(RealtimeServerEventResponseContentPartAdded.type,
  "Kind",
  "csharp"
);
@@clientName(RealtimeServerEventResponseContentPartDone.type, "Kind", "csharp");
@@clientName(RealtimeServerEventResponseTextDelta.type, "Kind", "csharp");
@@clientName(RealtimeServerEventResponseTextDone.type, "Kind", "csharp");
@@clientName(RealtimeServerEventResponseAudioTranscriptDelta.type,
  "Kind",
  "csharp"
);
@@clientName(RealtimeServerEventResponseAudioTranscriptDone.type,
  "Kind",
  "csharp"
);
@@clientName(RealtimeServerEventResponseAudioDelta.type, "Kind", "csharp");
@@clientName(RealtimeServerEventResponseAudioDone.type, "Kind", "csharp");
@@clientName(RealtimeServerEventResponseFunctionCallArgumentsDelta.type,
  "Kind",
  "csharp"
);
@@clientName(RealtimeServerEventResponseFunctionCallArgumentsDone.type,
  "Kind",
  "csharp"
);
@@clientName(RealtimeServerEventRateLimitsUpdated.type, "Kind", "csharp");

@@clientName(RealtimeTurnDetection.type, "Kind", "csharp");
@@clientName(RealtimeServerVadTurnDetection.type, "Kind", "csharp");
