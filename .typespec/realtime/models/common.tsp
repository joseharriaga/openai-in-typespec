using TypeSpec.OpenAPI;

namespace OpenAI.Realtime;

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
