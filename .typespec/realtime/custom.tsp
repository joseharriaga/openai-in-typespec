import "./custom/events.tsp";
import "./custom/items.tsp";
import "./custom/tools.tsp";

namespace OpenAI;

model RealtimeRequestSession {
  ...RealtimeSessionBase;
  modalities?: RealtimeModalities;
  instructions?: string;
  voice?: RealtimeVoice;
  input_audio_format?: RealtimeAudioFormat;
  output_audio_format?: RealtimeAudioFormat;
  input_audio_transcription?: RealtimeAudioInputTranscriptionSettings | null;
  turn_detection?: RealtimeTurnDetection | null;
  tools?: RealtimeTool[];
  tool_choice?: RealtimeToolChoice;
  temperature?: float32;
  max_response_output_tokens?: int32 | "inf";
}

model RealtimeResponseSession {
  ...RealtimeSessionBase;
  object: "realtime.session";
  id: string;
  `model`: string;
  modalities: RealtimeModalities;
  instructions: string;
  voice: RealtimeVoice;
  input_audio_format: RealtimeAudioFormat;
  output_audio_format: RealtimeAudioFormat;
  input_audio_transcription: RealtimeAudioInputTranscriptionSettings | null;
  turn_detection: RealtimeTurnDetection;
  tools: RealtimeTool[];
  tool_choice: RealtimeToolChoice;
  temperature: float32;
  max_response_output_tokens: int32 | "inf" | null;
}

model RealtimeResponseOptions {
  ...RealtimeResponseBase;

  /** The modalities for the response. */
  modalities?: RealtimeModalities;

  /** Instructions for the model. */
  instructions?: string;

  @doc("""
    The voice the model uses to respond - one of `alloy`, `echo`, or `shimmer`.
    """)
  voice?: RealtimeVoice;

  /** The format of output audio. */
  output_audio_format?: RealtimeAudioFormat;

  // Tool customization: apply enriched tool definition hierarchy
  /** Tools (functions) available to the model. */
  tools?: RealtimeTool[];

  /** How the model chooses tools. */
  tool_choice?: RealtimeToolChoice;

  /** Sampling temperature. */
  temperature?: float32;

  /** Maximum number of output tokens for a single assistant response, inclusive of tool calls. Provide an integer between 1 and 4096 to limit output tokens, or "inf" for the maximum available tokens for a given model. Defaults to "inf". */
  max_output_tokens?: int32 | "inf";
}

model RealtimeResponse {
  ...RealtimeResponseBase;
  object: "realtime.response";
  id: string;
  status: RealtimeResponseStatus = RealtimeResponseStatus.in_progress;
  status_details: RealtimeResponseStatusDetails | null;
  output: RealtimeConversationResponseItem[];
  usage: {
    total_tokens: int32;
    input_tokens: int32;
    output_tokens: int32;
    input_token_details: {
      cached_tokens: int32;
      text_tokens: int32;
      audio_tokens: int32;
    };
    output_token_details: {
      text_tokens: int32;
      audio_tokens: int32;
    };
  };
}

union RealtimeVoice {
  string,
  alloy: "alloy",
  shimmer: "shimmer",
  echo: "echo",
}

union RealtimeAudioFormat {
  string,
  pcm16: "pcm16",
  g711_ulaw: "g711_ulaw",
  g711_alaw: "g711_alaw",
}

union RealtimeAudioInputTranscriptionModel {
  string,
  whisper_1: "whisper-1",
}

model RealtimeAudioInputTranscriptionSettings {
  `model`?: RealtimeAudioInputTranscriptionModel = RealtimeAudioInputTranscriptionModel.whisper_1;
}

alias RealtimeModalities = ("text" | "audio")[];

union RealtimeTurnDetectionType {
  string,

  /**
   * Indicates that server-side voice activity detection (VAD) should be enabled, allowing the server to determine when
   * add_user_audio commands present ends of speech and should be automatically committed.
   *
   * The API will also detect when the user begins talking, sending a generation_canceled command.
   */
  server_vad: "server_vad",
}

@discriminator("type")
model RealtimeTurnDetection {
  type: RealtimeTurnDetectionType;
}

model RealtimeServerVadTurnDetection extends RealtimeTurnDetection {
  type: RealtimeTurnDetectionType.server_vad;
  threshold?: float32 = 0.5;

  // @encode("milliseconds", int32)
  prefix_padding_ms?: duration; // = 300ms

  // @encode("milliseconds", int32)
  silence_duration_ms?: duration; // = 200,s
}

union RealtimeResponseStatus {
  string,
  in_progress: "in_progress",
  completed: "completed",
  cancelled: "cancelled",
  incomplete: "incomplete",
  failed: "failed",
}

@discriminator("type")
model RealtimeResponseStatusDetails {
  type: RealtimeResponseStatus;
}

model RealtimeServerEventRateLimitsUpdatedRateLimitsItem {
  /** The rate limit property name that this item includes information about. */
  name: string;

  /** The maximum configured limit for this rate limit property. */
  limit: int32;

  /** The remaining quota available against the configured limit for this rate limit property. */
  remaining: int32;

  /** The remaining time, in seconds, until this rate limit property is reset. */
  @encode("seconds", float32)
  reset_seconds: duration;
}
