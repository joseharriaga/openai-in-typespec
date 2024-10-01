using TypeSpec.OpenAPI;

namespace OpenAI.Realtime;

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
