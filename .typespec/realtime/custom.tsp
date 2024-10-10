import "./custom/events.tsp";
import "./custom/items.tsp";
import "./custom/tools.tsp";

using TypeSpec.OpenAPI;

namespace OpenAI;

model RealtimeRequestSession {
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

  // Note: spec errata for 'max_output_tokens'
  max_response_output_tokens?: int32 | "inf";
}

model RealtimeResponse {
  object: "realtime.response";
  id: string;
  status: RealtimeResponseStatus = RealtimeResponseStatus.in_progress;
  status_details: RealtimeResponseStatusDetails | null;
  output: RealtimeResponseItem[];
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

model RealtimeResponseSession {
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
  enabled?: boolean;
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
