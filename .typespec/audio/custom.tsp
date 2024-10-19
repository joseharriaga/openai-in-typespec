import "./models.tsp";

using TypeSpec.OpenAPI;

namespace OpenAI;

enum TranscriptionAudioResponseFormat {
  ...AudioResponseFormat,
}

enum TranslationAudioResponseFormat {
  ...AudioResponseFormat,
}
