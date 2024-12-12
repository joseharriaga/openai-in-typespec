/*
 * This file was automatically generated from an OpenAPI .yaml file.
 * Edits made directly to this file will be lost.
 */

import "../chat";

using TypeSpec.OpenAPI;

namespace OpenAI;

/** The aggregated costs details of the specific time bucket. */
model CostsResult {
  object: "organization.costs.result";

  /** The monetary value in its associated currency. */
  amount?: {
    /** The numeric value of the cost. */
    value?: float32;

    /** Lowercase ISO-4217 currency e.g. "usd" */
    currency?: string;
  };

  @doc("""
    When `group_by=line_item`, this field provides the line item of the grouped costs result.
    """)
  line_item?: string | null;

  @doc("""
    When `group_by=project_id`, this field provides the project ID of the grouped costs result.
    """)
  project_id?: string | null;
}

/**
 * Static predicted output content, such as the content of a text file that is
 * being regenerated.
 */
model PredictionContent {
  @doc("""
    The type of the predicted content you want to provide. This type is
    currently always `content`.
    """)
  type: "content";

  /**
   * The content that should be matched when generating a model response.
   * If generated tokens would match this content, the entire model response
   * can be returned much more quickly.
   */
  @extension("x-oaiExpandable", true)
  content: string | ChatCompletionRequestMessageContentPartText[];
}

/** Represents a project rate limit config. */
model ProjectRateLimit {
  @doc("""
    The object type, which is always `project.rate_limit`
    """)
  object: "project.rate_limit";

  /** The identifier, which can be referenced in API endpoints. */
  id: string;

  /** The model this rate limit applies to. */
  `model`: string;

  /** The maximum requests per minute. */
  max_requests_per_1_minute: int32;

  /** The maximum tokens per minute. */
  max_tokens_per_1_minute: int32;

  /** The maximum images per minute. Only present for relevant models. */
  max_images_per_1_minute?: int32;

  /** The maximum audio megabytes per minute. Only present for relevant models. */
  max_audio_megabytes_per_1_minute?: int32;

  /** The maximum requests per day. Only present for relevant models. */
  max_requests_per_1_day?: int32;

  /** The maximum batch input tokens per day. Only present for relevant models. */
  batch_1_day_max_input_tokens?: int32;
}

model ProjectRateLimitListResponse {
  object: "list";
  data: ProjectRateLimit[];
  first_id: string;
  last_id: string;
  has_more: boolean;
}

model ProjectRateLimitUpdateRequest {
  /** The maximum requests per minute. */
  max_requests_per_1_minute?: int32;

  /** The maximum tokens per minute. */
  max_tokens_per_1_minute?: int32;

  /** The maximum images per minute. Only relevant for certain models. */
  max_images_per_1_minute?: int32;

  /** The maximum audio megabytes per minute. Only relevant for certain models. */
  max_audio_megabytes_per_1_minute?: int32;

  /** The maximum requests per day. Only relevant for certain models. */
  max_requests_per_1_day?: int32;

  /** The maximum batch input tokens per day. Only relevant for certain models. */
  batch_1_day_max_input_tokens?: int32;
}

/** The aggregated audio speeches usage details of the specific time bucket. */
model UsageAudioSpeechesResult {
  object: "organization.usage.audio_speeches.result";

  /** The number of characters processed. */
  characters: int32;

  /** The count of requests made to the model. */
  num_model_requests: int32;

  @doc("""
    When `group_by=project_id`, this field provides the project ID of the grouped usage result.
    """)
  project_id?: string | null;

  @doc("""
    When `group_by=user_id`, this field provides the user ID of the grouped usage result.
    """)
  user_id?: string | null;

  @doc("""
    When `group_by=api_key_id`, this field provides the API key ID of the grouped usage result.
    """)
  api_key_id?: string | null;

  @doc("""
    When `group_by=model`, this field provides the model name of the grouped usage result.
    """)
  `model`?: string | null;
}

/** The aggregated audio transcriptions usage details of the specific time bucket. */
model UsageAudioTranscriptionsResult {
  object: "organization.usage.audio_transcriptions.result";

  /** The number of seconds processed. */
  seconds: int32;

  /** The count of requests made to the model. */
  num_model_requests: int32;

  @doc("""
    When `group_by=project_id`, this field provides the project ID of the grouped usage result.
    """)
  project_id?: string | null;

  @doc("""
    When `group_by=user_id`, this field provides the user ID of the grouped usage result.
    """)
  user_id?: string | null;

  @doc("""
    When `group_by=api_key_id`, this field provides the API key ID of the grouped usage result.
    """)
  api_key_id?: string | null;

  @doc("""
    When `group_by=model`, this field provides the model name of the grouped usage result.
    """)
  `model`?: string | null;
}

/** The aggregated code interpreter sessions usage details of the specific time bucket. */
model UsageCodeInterpreterSessionsResult {
  object: "organization.usage.code_interpreter_sessions.result";

  /** The number of code interpreter sessions. */
  sessions: int32;

  @doc("""
    When `group_by=project_id`, this field provides the project ID of the grouped usage result.
    """)
  project_id?: string | null;
}

/** The aggregated completions usage details of the specific time bucket. */
model UsageCompletionsResult {
  object: "organization.usage.completions.result";

  /** The aggregated number of input tokens used. For customers subscribe to scale tier, this includes scale tier tokens. */
  input_tokens: int32;

  /** The aggregated number of input tokens that has been cached from previous requests. For customers subscribe to scale tier, this includes scale tier tokens. */
  input_cached_tokens?: int32;

  /** The aggregated number of output tokens used. For customers subscribe to scale tier, this includes scale tier tokens. */
  output_tokens: int32;

  /** The count of requests made to the model. */
  num_model_requests: int32;

  @doc("""
    When `group_by=project_id`, this field provides the project ID of the grouped usage result.
    """)
  project_id?: string | null;

  @doc("""
    When `group_by=user_id`, this field provides the user ID of the grouped usage result.
    """)
  user_id?: string | null;

  @doc("""
    When `group_by=api_key_id`, this field provides the API key ID of the grouped usage result.
    """)
  api_key_id?: string | null;

  @doc("""
    When `group_by=model`, this field provides the model name of the grouped usage result.
    """)
  `model`?: string | null;

  @doc("""
    When `group_by=batch`, this field tells whether the grouped usage result is batch or not.
    """)
  batch?: boolean | null;
}

/** The aggregated embeddings usage details of the specific time bucket. */
model UsageEmbeddingsResult {
  object: "organization.usage.embeddings.result";

  /** The aggregated number of input tokens used. */
  input_tokens: int32;

  /** The count of requests made to the model. */
  num_model_requests: int32;

  @doc("""
    When `group_by=project_id`, this field provides the project ID of the grouped usage result.
    """)
  project_id?: string | null;

  @doc("""
    When `group_by=user_id`, this field provides the user ID of the grouped usage result.
    """)
  user_id?: string | null;

  @doc("""
    When `group_by=api_key_id`, this field provides the API key ID of the grouped usage result.
    """)
  api_key_id?: string | null;

  @doc("""
    When `group_by=model`, this field provides the model name of the grouped usage result.
    """)
  `model`?: string | null;
}

/** The aggregated images usage details of the specific time bucket. */
model UsageImagesResult {
  object: "organization.usage.images.result";

  /** The number of images processed. */
  images: int32;

  /** The count of requests made to the model. */
  num_model_requests: int32;

  @doc("""
    When `group_by=source`, this field provides the source of the grouped usage result, possible values are `image.generation`, `image.edit`, `image.variation`.
    """)
  source?: string | null;

  @doc("""
    When `group_by=size`, this field provides the image size of the grouped usage result.
    """)
  size?: string | null;

  @doc("""
    When `group_by=project_id`, this field provides the project ID of the grouped usage result.
    """)
  project_id?: string | null;

  @doc("""
    When `group_by=user_id`, this field provides the user ID of the grouped usage result.
    """)
  user_id?: string | null;

  @doc("""
    When `group_by=api_key_id`, this field provides the API key ID of the grouped usage result.
    """)
  api_key_id?: string | null;

  @doc("""
    When `group_by=model`, this field provides the model name of the grouped usage result.
    """)
  `model`?: string | null;
}

/** The aggregated moderations usage details of the specific time bucket. */
model UsageModerationsResult {
  object: "organization.usage.moderations.result";

  /** The aggregated number of input tokens used. */
  input_tokens: int32;

  /** The count of requests made to the model. */
  num_model_requests: int32;

  @doc("""
    When `group_by=project_id`, this field provides the project ID of the grouped usage result.
    """)
  project_id?: string | null;

  @doc("""
    When `group_by=user_id`, this field provides the user ID of the grouped usage result.
    """)
  user_id?: string | null;

  @doc("""
    When `group_by=api_key_id`, this field provides the API key ID of the grouped usage result.
    """)
  api_key_id?: string | null;

  @doc("""
    When `group_by=model`, this field provides the model name of the grouped usage result.
    """)
  `model`?: string | null;
}

model UsageResponse {
  object: "page";
  data: UsageTimeBucket[];
  has_more: boolean;
  next_page: string;
}

model UsageTimeBucket {
  object: "bucket";
  start_time: int32;
  end_time: int32;
  result: (
    | UsageCompletionsResult
    | UsageEmbeddingsResult
    | UsageModerationsResult
    | UsageImagesResult
    | UsageAudioSpeechesResult
    | UsageAudioTranscriptionsResult
    | UsageVectorStoresResult
    | UsageCodeInterpreterSessionsResult
    | CostsResult)[];
}

/** The aggregated vector stores usage details of the specific time bucket. */
model UsageVectorStoresResult {
  object: "organization.usage.vector_stores.result";

  /** The vector stores usage in bytes. */
  usage_bytes: int32;

  @doc("""
    When `group_by=project_id`, this field provides the project ID of the grouped usage result.
    """)
  project_id?: string | null;
}
