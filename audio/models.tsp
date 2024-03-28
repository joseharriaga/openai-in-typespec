import "../common/models.tsp";

using TypeSpec.Http;
using TypeSpec.OpenAPI;

namespace OpenAI;

model CreateSpeechRequest {
  /** One of the available [TTS models](/docs/models/tts): `tts-1` or `tts-1-hd` */
  @extension("x-oaiTypeLabel", "string")
  `model`: string | TEXT_TO_SPEECH_MODELS;

  /**
   * The text to generate audio for. The maximum length is 4096 characters.
   */
  @maxLength(4096)
  input: string;

  /**
   * The voice to use when generating the audio. Supported voices are `alloy`, `echo`, `fable`,
   * `onyx`, `nova`, and `shimmer`. Previews of the voices are available in the
   * [Text to speech guide](/docs/guides/text-to-speech/voice-options).
   */
  voice: "alloy" | "echo" | "fable" | "onyx" | "nova" | "shimmer";

  /**
   * The format to audio in. Supported formats are `mp3`, `opus`, `aac`, `flac`, `wav`, and `pcm`.
   */
  response_format?: "mp3" | "opus" | "aac" | "flac" | "wav" | "pcm" = "mp3";

  /**
   * The speed of the generated audio. Select a value from `0.25` to `4.0`. `1.0` is the default.
   */
  @minValue(0.25)
  @maxValue(4.0)
  speed?: float64 = 1.0;
}

model CreateTranscriptionRequest {
  /**
   * The audio file object (not file name) to transcribe, in one of these formats: flac, mp3, mp4,
   * mpeg, mpga, m4a, ogg, wav, or webm.
   */
  @encode("binary")
  @extension("x-oaiTypeLabel", "file")
  file: bytes;

  /**
   * ID of the model to use. Only `whisper-1` (which is powered by our open source Whisper V2 model)
   * is currently available.
   */
  @extension("x-oaiTypeLabel", "string")
  `model`: string | SPEECH_TO_TEXT_MODELS;

  /**
   * The language of the input audio. Supplying the input language in
   * [ISO-639-1](https://en.wikipedia.org/wiki/List_of_ISO_639-1_codes) format will improve accuracy
   * and latency.
   */
  language?: string;

  /**
   * An optional text to guide the model's style or continue a previous audio segment. The
   * [prompt](/docs/guides/speech-to-text/prompting) should match the audio language.
   */
  prompt?: string;

  /**
   * The format of the transcript output, in one of these options: json, text, srt, verbose_json, or
   * vtt.
   */
  response_format?: "json" | "text" | "srt" | "verbose_json" | "vtt" = "json";

  // TODO: Min and max values are absent in the OpenAPI spec but mentioned in the description.
  /**
   * The sampling temperature, between 0 and 1. Higher values like 0.8 will make the output more
   * random, while lower values like 0.2 will make it more focused and deterministic. If set to 0,
   * the model will use [log probability](https://en.wikipedia.org/wiki/Log_probability) to
   * automatically increase the temperature until certain thresholds are hit.
   */
  @minValue(0)
  @maxValue(1)
  temperature?: float64 = 0;

  /**
   * The timestamp granularities to populate for this transcription. `response_format` must be set
   * `verbose_json` to use timestamp granularities. Either or both of these options are supported:
   * `word`, or `segment`. Note: There is no additional latency for segment timestamps, but
   * generating word timestamps incurs additional latency.
   */
  timestamp_granularities?: TimestampGranularities[] = [ "segment" ]
}

model CreateTranslationRequest {
  /**
   * The audio file object (not file name) to translate, in one of these formats: flac, mp3, mp4,
   * mpeg, mpga, m4a, ogg, wav, or webm.
   */
  @encode("binary")
  @extension("x-oaiTypeLabel", "file")
  file: bytes;

  /**
   * ID of the model to use. Only `whisper-1` (which is powered by our open source Whisper V2 model)
   * is currently available.
   */
  @extension("x-oaiTypeLabel", "string")
  `model`: string | SPEECH_TO_TEXT_MODELS;

  /**
   * An optional text to guide the model's style or continue a previous audio segment. The
   * [prompt](/docs/guides/speech-to-text/prompting) should match the audio language.
   */
  prompt?: string;

  // TODO: This is defined as a plain string in the OpenAPI spec instead of an enum.
  /**
   * The format of the transcript output, in one of these options: json, text, srt, verbose_json, or
   * vtt.
   */
  response_format?: "json" | "text" | "srt" | "verbose_json" | "vtt" = "json";

  // TODO: Min and max values are absent in the OpenAPI spec but mentioned in the description.
  /**
   * The sampling temperature, between 0 and 1. Higher values like 0.8 will make the output more
   * random, while lower values like 0.2 will make it more focused and deterministic. If set to 0,
   * the model will use [log probability](https://en.wikipedia.org/wiki/Log_probability) to
   * automatically increase the temperature until certain thresholds are hit.
   */
  @minValue(0)
  @maxValue(1)
  temperature?: float64 = 0;
}

/** Represents a transcription response returned by model, based on the provided input. */
model CreateTranscriptionResponseJson {
  /** The transcribed text. */
  text: string;
}

/**
 * Represents a verbose json transcription response returned by model, based on the provided input.
 */
model CreateTranscriptionResponseVerboseJson {
  // TODO: This is not defined in the OpenAPI spec.
  /** The task label. */
  task: "transcribe";

  /** The language of the input audio. */
  language: string;

  /** The duration of the input audio. */
  @encode("seconds", float64)
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

model CreateTranslationResponseVerboseJson {
  // TODO: This is not defined in the OpenAPI spec.
  /** The task label. */
  task: "translate";

  /** The language of the output translation (always `english`). */
  language: string;

  /** The duration of the input audio. */
  @encode("seconds", float64)
  duration: duration;

  /** The translated text. */
  text: string;

  // TODO: The OpenAPI spec reuses the TranscriptionSegment definition here even though this belongs
  // to the translation response.
  /** Segments of the translated text and their corresponding details. */
  segments?: TranscriptionSegment[]; 
}

alias TEXT_TO_SPEECH_MODELS =
  | "tts-1"
  | "tts-1-hd";

alias SPEECH_TO_TEXT_MODELS =
  | "whisper-1";

alias TimestampGranularities =
  | "word"
  | "segment";

model TranscriptionSegment {
  /** Unique identifier of the segment. */
  id: safeint;

  /** Seek offset of the segment. */
  seek: safeint;

  /** Start time of the segment in seconds. */
  @encode("seconds", float64)
  start: duration;

  /** End time of the segment in seconds. */
  @encode("seconds", float64)
  end: duration;

  /** Text content of the segment. */
  text: string;

  /** Array of token IDs for the text content. */
  tokens: TokenArray;

   // TODO: Min and max values are not defined in the OpenAPI spec.
  /** Temperature parameter used for generating the segment. */
  @minValue(0)
  @maxValue(1)
  temperature: float64;

  /**
   * Average logprob of the segment. If the value is lower than -1, consider the logprobs failed.
   */
  avg_logprob: float64;

  /**
   * Compression ratio of the segment. If the value is greater than 2.4, consider the compression
   * failed.
   */
  compression_ratio: float64;

  /**
   * Probability of no speech in the segment. If the value is higher than 1.0 and the `avg_logprob`
   * is below -1, consider this segment silent.
   */
  no_speech_prob: float64;
}

model TranscriptionWord {
  /** The text content of the word. */
  word: string;

  /** Start time of the word in seconds. */
  @encode("seconds", float64)
  start: duration;

  /** End time of the word in seconds. */
  @encode("seconds", float64)
  end: duration;
}