import "./common.tsp";
import "./content_parts.tsp";
import "./items.tsp";
import "./tools.tsp";
import "./turn_detection.tsp";

using TypeSpec.OpenAPI;

namespace OpenAI;

union RealtimeResponseCommandType {
  string,
  session_created: "session.created",
  session_updated: "session.updated",
  item_created: "conversation.item.created",
  item_deleted: "conversation.item.deleted",
  item_truncated: "conversation.item.truncated",
  response_created: "response.created",
  response_done: "response.done",
  rate_limits_updated: "rate_limits.updated",
  response_output_item_added: "response.output_item.added",
  response_output_item_done: "response.output_item.done",
  response_content_part_added: "response.content_part.added",
  response_content_part_done: "response.content_part.done",
  response_audio_delta: "response.audio.delta",
  response_audio_done: "response.audio.done",
  response_audio_transcript_delta: "response.audio_transcript.delta",
  response_audio_transcript_done: "response.audio_transcript.done",
  response_text_delta: "response.text.delta",
  response_text_done: "response.text.done",
  response_function_call_arguments_delta: "response.function_call_arguments.delta",
  response_function_call_arguments_done: "response.function_call_arguments.done",
  input_audio_buffer_speech_started: "input_audio_buffer.speech_started",
  input_audio_buffer_speech_stopped: "input_audio_buffer.speech_stopped",
  item_input_audio_transcription_completed: "conversation.item.input_audio_transcription.completed",
  item_input_audio_transcription_failed: "conversation.item.input_audio_transcription.failed",
  input_audio_buffer_committed: "input_audio_buffer.committed",
  input_audio_buffer_cleared: "input_audio_buffer.cleared",
  error: "error",
}

/**
 * Base representation of a WebSocket message received from the service.
 */
@discriminator("type")
model RealtimeResponseCommand {
  type: RealtimeResponseCommandType;
  event_id: string | null;
}

model RealtimeResponseSessionCreatedCommand extends RealtimeResponseCommand {
  type: RealtimeResponseCommandType.session_created;
  session: RealtimeResponseSession;
}

model RealtimeResponseSessionUpdatedCommand extends RealtimeResponseCommand {
  type: RealtimeResponseCommandType.session_updated;
  session: RealtimeResponseSession;
}

model RealtimeResponseItemCreatedCommand extends RealtimeResponseCommand {
  type: RealtimeResponseCommandType.item_created;
  item: RealtimeResponseItem;
}

model RealtimeResponseItemDeletedCommand extends RealtimeResponseCommand {
  type: RealtimeResponseCommandType.item_deleted;
  item_id: string;
}

model RealtimeResponseItemTruncatedCommand extends RealtimeResponseCommand {
  type: RealtimeResponseCommandType.item_truncated;
  item_id: string;
  audio_end_ms: int32;
  index: int32 = 0;
}

model RealtimeResponseCreatedCommand extends RealtimeResponseCommand {
  type: RealtimeResponseCommandType.response_created;
  response: RealtimeResponse;
}

model RealtimeResponseDoneCommand extends RealtimeResponseCommand {
  type: RealtimeResponseCommandType.response_done;
  response: RealtimeResponse;
}

model RealtimeResponseRateLimitsUpdatedCommand extends RealtimeResponseCommand {
  type: RealtimeResponseCommandType.rate_limits_updated;
  rate_limits: RealtimeResponseRateLimitDetailsItem[];
}

model RealtimeResponseOutputItemAddedCommand extends RealtimeResponseCommand {
  type: RealtimeResponseCommandType.response_output_item_added;
  response_id: string;
  output_index: int32;
  item: RealtimeResponseItem;
}

model RealtimeResponseOutputItemDoneCommand extends RealtimeResponseCommand {
  type: RealtimeResponseCommandType.response_output_item_done;
  response_id: string;
  output_index: int32;
  item: RealtimeResponseItem;
}

model RealtimeResponseContentPartAddedCommand extends RealtimeResponseCommand {
  type: RealtimeResponseCommandType.response_content_part_added;
  ...RealtimeResponseCommonContentPartFields;
  part: RealtimeContentPart;
}

model RealtimeResponseContentPartDoneCommand extends RealtimeResponseCommand {
  type: RealtimeResponseCommandType.response_content_part_done;
  ...RealtimeResponseCommonContentPartFields;
  part: RealtimeContentPart;
}

model RealtimeResponseAudioDeltaCommand extends RealtimeResponseCommand {
  type: RealtimeResponseCommandType.response_audio_delta;
  ...RealtimeResponseCommonContentPartFields;

  @encode("base64")
  delta: bytes;
}

model RealtimeResponseAudioDoneCommand extends RealtimeResponseCommand {
  type: RealtimeResponseCommandType.response_audio_done;
  ...RealtimeResponseCommonContentPartFields;
}

model RealtimeResponseAudioTranscriptDeltaCommand
  extends RealtimeResponseCommand {
  type: RealtimeResponseCommandType.response_audio_transcript_delta;
  ...RealtimeResponseCommonContentPartFields;
  delta: string;
}

model RealtimeResponseAudioTranscriptDoneCommand
  extends RealtimeResponseCommand {
  type: RealtimeResponseCommandType.response_audio_transcript_done;
  ...RealtimeResponseCommonContentPartFields;
}

model RealtimeResponseTextDeltaCommand extends RealtimeResponseCommand {
  type: RealtimeResponseCommandType.response_text_delta;
  ...RealtimeResponseCommonContentPartFields;
  delta: string;
}

model RealtimeResponseTextDoneCommand extends RealtimeResponseCommand {
  type: RealtimeResponseCommandType.response_text_done;
  ...RealtimeResponseCommonContentPartFields;
  value: string;
}

model RealtimeResponseFunctionCallArgumentsDeltaCommand
  extends RealtimeResponseCommand {
  type: RealtimeResponseCommandType.response_function_call_arguments_delta;
  response_id: string;
  item_id: string;
  output_index: int32;
  call_id: string;
  delta: string;
}

model RealtimeResponseFunctionCallArgumentsDoneCommand
  extends RealtimeResponseCommand {
  type: RealtimeResponseCommandType.response_function_call_arguments_done;
  response_id: string;
  item_id: string;
  output_index: int32;
  call_id: string;
  name: string;
  arguments: string;
}

model RealtimeResponseInputAudioBufferSpeechStartedCommand
  extends RealtimeResponseCommand {
  type: RealtimeResponseCommandType.input_audio_buffer_speech_started;
  audio_start_ms: int32;
  item_id: string;
}

model RealtimeResponseInputAudioBufferSpeechStoppedCommand
  extends RealtimeResponseCommand {
  type: RealtimeResponseCommandType.input_audio_buffer_speech_stopped;
  audio_end_ms: int32;
  item_id: string;
}

model RealtimeResponseItemInputAudioTranscriptionCompletedCommand
  extends RealtimeResponseCommand {
  type: RealtimeResponseCommandType.item_input_audio_transcription_completed;
  item_id: string;
  content_index: int32;
  transcript: string;
}

model RealtimeResponseItemInputAudioTranscriptionFailedCommand
  extends RealtimeResponseCommand {
  type: RealtimeResponseCommandType.item_input_audio_transcription_failed;
  item_id: string;
  content_index: int32;
  error: RealtimeResponseApiError;
}

model RealtimeResponseInputAudioBufferCommittedCommand
  extends RealtimeResponseCommand {
  type: RealtimeResponseCommandType.input_audio_buffer_committed;
  item_id: string;
  previous_item_id?: string;
}

model RealtimeResponseInputAudioBufferClearedCommand
  extends RealtimeResponseCommand {
  type: RealtimeResponseCommandType.input_audio_buffer_cleared;
}

/**
 * A command that describes an error encountered during a realtime operation.
 */
model RealtimeResponseErrorCommand extends RealtimeResponseCommand {
  type: RealtimeResponseCommandType.error;
  error: RealtimeResponseError;
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
  max_response_output_tokens: int32 | null;
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

model RealtimeResponseCancelledStatusDetails
  extends RealtimeResponseStatusDetails {
  type: RealtimeResponseStatus.cancelled;
  reason: "turn_detected" | "client_cancelled";
}

model RealtimeResponseIncompleteStatusDetails
  extends RealtimeResponseStatusDetails {
  type: RealtimeResponseStatus.incomplete;
  reason: "max_output_tokens" | "content_filter";
}

model RealtimeResponseFailedStatusDetails
  extends RealtimeResponseStatusDetails {
  type: RealtimeResponseStatus.failed;
  error: unknown;
}

model RealtimeResponseRateLimitDetailsItem {
  name: string;
  limit: int32;
  remaining: int32;
  reset_seconds: float32;
}

model RealtimeResponseError {
  type: string;
  code?: string;
  message: string;
  param?: string;
  event_id?: string;
}

model RealtimeResponseApiError {
  type: string;
  code?: string;
  message: string;
  param?: string;
}

alias RealtimeResponseCommonContentPartFields = {
  response_id: string;
  item_id: string;
  output_index: int32;
  content_index: int32;
};
