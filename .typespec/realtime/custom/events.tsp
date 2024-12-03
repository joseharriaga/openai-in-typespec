// using TypeSpec.OpenAPI;

namespace OpenAI;

union RealtimeClientEventType {
  string,
  session_update: "session.update",
  input_audio_buffer_append: "input_audio_buffer.append",
  input_audio_buffer_commit: "input_audio_buffer.commit",
  input_audio_buffer_clear: "input_audio_buffer.clear",
  conversation_item_create: "conversation.item.create",
  conversation_item_delete: "conversation.item.delete",
  conversation_item_truncate: "conversation.item.truncate",
  response_create: "response.create",
  response_cancel: "response.cancel",
}

union RealtimeServerEventType {
  string,
  session_created: "session.created",
  session_updated: "session.updated",
  conversation_created: "conversation.created",
  conversation_item_created: "conversation.item.created",
  conversation_item_deleted: "conversation.item.deleted",
  conversation_item_truncated: "conversation.item.truncated",
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
  conversation_item_input_audio_transcription_completed: "conversation.item.input_audio_transcription.completed",
  conversation_item_input_audio_transcription_failed: "conversation.item.input_audio_transcription.failed",
  input_audio_buffer_committed: "input_audio_buffer.committed",
  input_audio_buffer_cleared: "input_audio_buffer.cleared",
  error: "error",
}

@discriminator("type")
model RealtimeClientEvent {
  type: RealtimeClientEventType;
  event_id?: string;
}

@discriminator("type")
model RealtimeServerEvent {
  type: RealtimeServerEventType;
  event_id: string;
}
