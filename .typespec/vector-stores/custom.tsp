using TypeSpec.OpenAPI;

namespace OpenAI;

union ListVectorStoreFilesFilter {
  string,
  "in_progress",
  "completed",
  "failed",
  "cancelled",
}

@discriminator("type")
model FileChunkingStrategyRequestParam {
  type: string;
}

@discriminator("type")
model FileChunkingStrategyResponseParam {
  type: string;
}

model AutoChunkingStrategyResponseParam
  extends FileChunkingStrategyResponseParam {
  type: "auto";
}
