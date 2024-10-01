import "@azure-tools/typespec-client-generator-core";
import "./models/requests.tsp";
import "./models/responses.tsp";

using Azure.ClientGenerator.Core;
using OpenAI;

@@clientName(RealtimeRequestCommand.type, "Kind", "csharp");
@@clientName(RealtimeRequestInputAudioBufferAppendCommand.type,
  "Kind",
  "csharp"
);
@@clientName(RealtimeRequestInputAudioBufferClearCommand.type,
  "Kind",
  "csharp"
);
@@clientName(RealtimeRequestInputAudioBufferCommitCommand.type,
  "Kind",
  "csharp"
);
@@clientName(RealtimeRequestItemCreateCommand.type, "Kind", "csharp");
@@clientName(RealtimeRequestItemDeleteCommand.type, "Kind", "csharp");
@@clientName(RealtimeRequestItemTruncateCommand.type, "Kind", "csharp");
@@clientName(RealtimeRequestResponseCancelCommand.type, "Kind", "csharp");
@@clientName(RealtimeRequestResponseCreateCommand.type, "Kind", "csharp");
@@clientName(RealtimeRequestSessionUpdateCommand.type, "Kind", "csharp");

@@clientName(RealtimeResponseAudioDeltaCommand.type, "Kind", "csharp");
@@clientName(RealtimeResponseAudioDeltaCommand.type, "Kind", "csharp");
@@clientName(RealtimeResponseAudioDoneCommand.type, "Kind", "csharp");
@@clientName(RealtimeResponseAudioTranscriptDeltaCommand.type,
  "Kind",
  "csharp"
);
@@clientName(RealtimeResponseAudioTranscriptDeltaCommand.type,
  "Kind",
  "csharp"
);
@@clientName(RealtimeResponseAudioTranscriptDoneCommand.type, "Kind", "csharp");
@@clientName(RealtimeResponseCommand.type, "Kind", "csharp");
@@clientName(RealtimeResponseContentPartAddedCommand.type, "Kind", "csharp");
@@clientName(RealtimeResponseContentPartDoneCommand.type, "Kind", "csharp");
@@clientName(RealtimeResponseCreatedCommand.type, "Kind", "csharp");
@@clientName(RealtimeResponseDoneCommand.type, "Kind", "csharp");
@@clientName(RealtimeResponseErrorCommand.type, "Kind", "csharp");
@@clientName(RealtimeResponseFunctionCallArgumentsDeltaCommand.type,
  "Kind",
  "csharp"
);
@@clientName(RealtimeResponseFunctionCallArgumentsDoneCommand.type,
  "Kind",
  "csharp"
);
@@clientName(RealtimeResponseInputAudioBufferClearedCommand.type,
  "Kind",
  "csharp"
);
@@clientName(RealtimeResponseInputAudioBufferCommittedCommand.type,
  "Kind",
  "csharp"
);
@@clientName(RealtimeResponseInputAudioBufferSpeechStartedCommand.type,
  "Kind",
  "csharp"
);
@@clientName(RealtimeResponseInputAudioBufferSpeechStoppedCommand.type,
  "Kind",
  "csharp"
);
@@clientName(RealtimeResponseItemCreatedCommand.type, "Kind", "csharp");
@@clientName(RealtimeResponseItemDeletedCommand.type, "Kind", "csharp");
@@clientName(RealtimeResponseItemInputAudioTranscriptionCompletedCommand.type,
  "Kind",
  "csharp"
);
@@clientName(RealtimeResponseItemInputAudioTranscriptionFailedCommand.type,
  "Kind",
  "csharp"
);
@@clientName(RealtimeResponseItemTruncatedCommand.type, "Kind", "csharp");
@@clientName(RealtimeResponseOutputItemAddedCommand.type, "Kind", "csharp");
@@clientName(RealtimeResponseOutputItemDoneCommand.type, "Kind", "csharp");
@@clientName(RealtimeResponseRateLimitsUpdatedCommand.type, "Kind", "csharp");
@@clientName(RealtimeResponseSessionCreatedCommand.type, "Kind", "csharp");
@@clientName(RealtimeResponseSessionUpdatedCommand.type, "Kind", "csharp");
@@clientName(RealtimeResponseTextDeltaCommand.type, "Kind", "csharp");
@@clientName(RealtimeResponseTextDoneCommand.type, "Kind", "csharp");

@@clientName(RealtimeTurnDetection.type, "Kind", "csharp");
@@clientName(RealtimeServerVadTurnDetection.type, "Kind", "csharp");
