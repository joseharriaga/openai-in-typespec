/*
 * This file was automatically generated from an OpenAPI .yaml file.
 * Edits made directly to this file will be lost.
 */

using TypeSpec.OpenAPI;

namespace OpenAI;

model CreateSpeechRequest {
  @doc("""
    One of the available [TTS models](/docs/models/tts): `tts-1` or `tts-1-hd`
    """)
  @extension("x-oaiTypeLabel", "string")
  `model`: string | "tts-1" | "tts-1-hd";

  /** The text to generate audio for. The maximum length is 4096 characters. */
  @maxLength(4096)
  input: string;

  @doc("""
    The voice to use when generating the audio. Supported voices are `alloy`, `echo`, `fable`, `onyx`, `nova`, and `shimmer`. Previews of the voices are available in the [Text to speech guide](/docs/guides/text-to-speech/voice-options).
    """)
  voice: "alloy" | "echo" | "fable" | "onyx" | "nova" | "shimmer";

  @doc("""
    The format to audio in. Supported formats are `mp3`, `opus`, `aac`, `flac`, `wav`, and `pcm`.
    """)
  response_format?: "mp3" | "opus" | "aac" | "flac" | "wav" | "pcm" = "mp3";

  @doc("""
    The speed of the generated audio. Select a value from `0.25` to `4.0`. `1.0` is the default.
    """)
  @minValue(0.25)
  @maxValue(4.0)
  speed?: float32 = 1.0;
}

model CreateTranscriptionRequest {
  // Tool customization: binary payloads are encoded bytes
  /** The audio file object (not file name) to transcribe, in one of these formats: flac, mp3, mp4, mpeg, mpga, m4a, ogg, wav, or webm. */
  @extension("x-oaiTypeLabel", "file")
  @encode("binary")
  file: bytes;

  @doc("""
    ID of the model to use. Only `whisper-1` (which is powered by our open source Whisper V2 model) is currently available.
    """)
  @extension("x-oaiTypeLabel", "string")
  `model`: string | "whisper-1";

  /** The language of the input audio. Supplying the input language in [ISO-639-1](https://en.wikipedia.org/wiki/List_of_ISO_639-1_codes) format will improve accuracy and latency. */
  language?: string;

  /** An optional text to guide the model's style or continue a previous audio segment. The [prompt](/docs/guides/speech-to-text/prompting) should match the audio language. */
  prompt?: string;

  @doc("""
    The format of the transcript output, in one of these options: `json`, `text`, `srt`, `verbose_json`, or `vtt`.
    """)
  response_format?: "json" | "text" | "srt" | "verbose_json" | "vtt" = "json";

  // Tool customization: add missing but documented min/max for temperature
  /** The sampling temperature, between 0 and 1. Higher values like 0.8 will make the output more random, while lower values like 0.2 will make it more focused and deterministic. If set to 0, the model will use [log probability](https://en.wikipedia.org/wiki/Log_probability) to automatically increase the temperature until certain thresholds are hit. */
  @minValue(0)
  @maxValue(1)
  temperature?: float32 = 0;

  @doc("""
    The timestamp granularities to populate for this transcription. `response_format` must be set `verbose_json` to use timestamp granularities. Either or both of these options are supported: `word`, or `segment`. Note: There is no additional latency for segment timestamps, but generating word timestamps incurs additional latency.
    """)
  timestamp_granularities?: ("word" | "segment")[] = #["segment"];
}

model CreateTranslationRequest {
  // Tool customization: binary payloads are encoded bytes
  /** The audio file object (not file name) translate, in one of these formats: flac, mp3, mp4, mpeg, mpga, m4a, ogg, wav, or webm. */
  @extension("x-oaiTypeLabel", "file")
  @encode("binary")
  file: bytes;

  @doc("""
    ID of the model to use. Only `whisper-1` (which is powered by our open source Whisper V2 model) is currently available.
    """)
  @extension("x-oaiTypeLabel", "string")
  `model`: string | "whisper-1";

  /** An optional text to guide the model's style or continue a previous audio segment. The [prompt](/docs/guides/speech-to-text/prompting) should be in English. */
  prompt?: string;

  // Tool customization: add enum types
  @doc("""
    The format of the transcript output, in one of these options: `json`, `text`, `srt`, `verbose_json`, or `vtt`.
    """)
  response_format?: "json" | "text" | "srt" | "verbose_json" | "vtt" = "json";

  // Tool customization: add missing but documented min/max for temperature
  /** The sampling temperature, between 0 and 1. Higher values like 0.8 will make the output more random, while lower values like 0.2 will make it more focused and deterministic. If set to 0, the model will use [log probability](https://en.wikipedia.org/wiki/Log_probability) to automatically increase the temperature until certain thresholds are hit. */
  @minValue(0)
  @maxValue(1)
  temperature?: float32 = 0;
}

/** Represents a transcription response returned by model, based on the provided input. */
model CreateTranscriptionResponseJson {
  /** The transcribed text. */
  text: string;
}

// Tool customization: Add a missing 'task' field, present on the wire but not in the spec
/** Represents a verbose json transcription response returned by model, based on the provided input. */
model CreateTranscriptionResponseVerboseJson {
  /** The task label. */
  task: "transcribe";

  /** The language of the input audio. */
  language: string;

  // Tool customization: timespans are encoded durations
  /** The duration of the input audio. */
  @encode("seconds", float32)
  duration: duration;

  /** The transcribed text. */
  text: string;

  /** Extracted words and their corresponding timestamps. */
  words?: TranscriptionWord[];

  /** Segments of the transcribed text and their corresponding details. */
  segments?: TranscriptionSegment[];
}

model CreateTranslationResponseJson {
  text: string;
}

// Tool customization: Add a missing 'task' field, present on the wire but not in the spec
model CreateTranslationResponseVerboseJson {
  /** The task label. */
  task: "translate";

  @doc("""
    The language of the output translation (always `english`).
    """)
  language: string;

  // Tool customization: timespans are encoded durations
  /** The duration of the input audio. */
  @encode("seconds", float32)
  duration: duration;

  /** The translated text. */
  text: string;

  /** Segments of the translated text and their corresponding details. */
  segments?: TranscriptionSegment[];
}

model TranscriptionSegment {
  /** Unique identifier of the segment. */
  id: int32;

  /** Seek offset of the segment. */
  seek: int32;

  // Tool customization: timespans are encoded durations
  /** Start time of the segment in seconds. */
  @encode("seconds", float32)
  start: duration;

  // Tool customization: timespans are encoded durations
  /** End time of the segment in seconds. */
  @encode("seconds", float32)
  end: duration;

  /** Text content of the segment. */
  text: string;

  /** Array of token IDs for the text content. */
  tokens: int32[];

  /** Temperature parameter used for generating the segment. */
  temperature: float32;

  /** Average logprob of the segment. If the value is lower than -1, consider the logprobs failed. */
  avg_logprob: float32;

  /** Compression ratio of the segment. If the value is greater than 2.4, consider the compression failed. */
  compression_ratio: float32;

  @doc("""
    Probability of no speech in the segment. If the value is higher than 1.0 and the `avg_logprob` is below -1, consider this segment silent.
    """)
  no_speech_prob: float32;
}

model TranscriptionWord {
  /** The text content of the word. */
  word: string;

  // Tool customization: timespans are encoded durations
  /** Start time of the word in seconds. */
  @encode("seconds", float32)
  start: duration;

  // Tool customization: timespans are encoded durations
  /** End time of the word in seconds. */
  @encode("seconds", float32)
  end: duration;
}
