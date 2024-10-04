using System.Diagnostics.CodeAnalysis;

namespace OpenAI.RealtimeConversation;

[Experimental("OPENAI002")][CodeGenModel("RealtimeAudioFormat")] public readonly partial struct ConversationAudioFormat { }
[Experimental("OPENAI002")][CodeGenModel("RealtimeAudioInputTranscriptionModel")] public readonly partial struct ConversationTranscriptionModel { }
[Experimental("OPENAI002")][CodeGenModel("RealtimeAudioInputTranscriptionSettings")] public partial class ConversationInputTranscriptionOptions { }
[Experimental("OPENAI002")][CodeGenModel("RealtimeContentPartType")] public readonly partial struct ConversationContentPartKind { }
[Experimental("OPENAI002")][CodeGenModel("RealtimeItemStatus")] public readonly partial struct ConversationItemStatus { }
[Experimental("OPENAI002")][CodeGenModel("RealtimeMessageRole")] public readonly partial struct ConversationMessageRole { }
[Experimental("OPENAI002")][CodeGenModel("RealtimeServerEventResponseAudioDelta")] public partial class ConversationAudioDeltaUpdate{ }
[Experimental("OPENAI002")][CodeGenModel("RealtimeServerEventResponseAudioDone")] public partial class ConversationAudioDoneUpdate{ }
[Experimental("OPENAI002")][CodeGenModel("RealtimeServerEventResponseAudioTranscriptDelta")] public partial class ConversationOutputTranscriptionDeltaUpdate { }
[Experimental("OPENAI002")][CodeGenModel("RealtimeServerEventResponseAudioTranscriptDone")] public partial class ConversationOutputTranscriptionFinishedUpdate { }
[Experimental("OPENAI002")][CodeGenModel("RealtimeServerEventResponseFunctionCallArgumentsDelta")] public partial class ConversationFunctionCallArgumentsDeltaUpdate { }
[Experimental("OPENAI002")][CodeGenModel("RealtimeServerEventResponseFunctionCallArgumentsDone")] public partial class ConversationFunctionCallArgumentsDoneUpdate { }
[Experimental("OPENAI002")][CodeGenModel("RealtimeServerEventInputAudioBufferCleared")] public partial class ConversationInputAudioBufferClearedUpdate { }
[Experimental("OPENAI002")][CodeGenModel("RealtimeServerEventInputAudioBufferCommitted")] public partial class ConversationInputAudioBufferCommittedUpdate { }
[Experimental("OPENAI002")][CodeGenModel("RealtimeServerEventInputAudioBufferSpeechStarted")] public partial class ConversationInputSpeechStartedUpdate { }
[Experimental("OPENAI002")][CodeGenModel("RealtimeServerEventInputAudioBufferSpeechStopped")] public partial class ConversationInputSpeechFinishedUpdate { }
[Experimental("OPENAI002")][CodeGenModel("RealtimeServerEventConversationItemDeleted")] public partial class ConversationItemDeletedUpdate { }
[Experimental("OPENAI002")][CodeGenModel("RealtimeServerEventConversationItemInputAudioTranscriptionCompleted")] public partial class ConversationInputTranscriptionFinishedUpdate { }
[Experimental("OPENAI002")][CodeGenModel("RealtimeServerEventConversationItemTruncated")] public partial class ConversationItemTruncatedUpdate { }
[Experimental("OPENAI002")][CodeGenModel("RealtimeServerEventRateLimitsUpdatedRateLimit")] public partial class ConversationRateLimitDetailsItem { }
[Experimental("OPENAI002")][CodeGenModel("RealtimeServerEventRateLimitsUpdated")] public partial class ConversationRateLimitsUpdatedUpdate{ }
[Experimental("OPENAI002")][CodeGenModel("RealtimeResponseStatus")] public readonly partial struct ConversationStatus { }
[Experimental("OPENAI002")][CodeGenModel("RealtimeServerEventResponseTextDelta")] public partial class ConversationTextDeltaUpdate{ }
[Experimental("OPENAI002")][CodeGenModel("RealtimeServerEventResponseTextDone")] public partial class ConversationTextDoneUpdate{ }
[Experimental("OPENAI002")][CodeGenModel("RealtimeResponseUsage")] public partial class ConversationTokenUsage { }
[Experimental("OPENAI002")][CodeGenModel("RealtimeResponseUsageInputTokenDetails")] public partial class ConversationInputTokenUsageDetails { }
[Experimental("OPENAI002")][CodeGenModel("RealtimeResponseUsageOutputTokenDetails")] public partial class ConversationOutputTokenUsageDetails { }
[Experimental("OPENAI002")][CodeGenModel("RealtimeToolType")] public readonly partial struct ConversationToolKind { }
[Experimental("OPENAI002")][CodeGenModel("RealtimeVoice")] public readonly partial struct ConversationVoice { }
