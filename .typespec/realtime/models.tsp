/*
 * This file was automatically generated from an OpenAPI .yaml file.
 * Edits made directly to this file will be lost.
 */

import "./custom.tsp";

using TypeSpec.OpenAPI;

namespace OpenAI;

// Tool customization: apply discriminated type base
/** Send this event to update the session’s default configuration. */
model RealtimeClientEventSessionUpdate extends RealtimeClientEvent {
  /** Optional client-generated ID used to identify this event. */
  event_id?: string;

  // Tool customization: apply discriminated type base
  /** The event type, must be "session.update". */
  type: RealtimeClientEventType.session_update;

  // Tool customization: apply shared session type
  /** Session configuration to update. */
  session: RealtimeRequestSession;
}

// Tool customization: apply discriminated type base
/** Send this event to append audio bytes to the input audio buffer. */
model RealtimeClientEventInputAudioBufferAppend extends RealtimeClientEvent {
  /** Optional client-generated ID used to identify this event. */
  event_id?: string;

  // Tool customization: apply discriminated type base
  /** The event type, must be "input_audio_buffer.append". */
  type: RealtimeClientEventType.input_audio_buffer_append;

  // Tool customization: use encoded type for audio data
  /** Base64-encoded audio bytes. */
  @encode("base64")
  audio: bytes;
}

// Tool customization: apply discriminated type base
/** Send this event to commit audio bytes to a user message. */
model RealtimeClientEventInputAudioBufferCommit extends RealtimeClientEvent {
  /** Optional client-generated ID used to identify this event. */
  event_id?: string;

  // Tool customization: apply discriminated type base
  /** The event type, must be "input_audio_buffer.commit". */
  type: RealtimeClientEventType.input_audio_buffer_commit;
}

// Tool customization: apply discriminated type base
/** Send this event to clear the audio bytes in the buffer. */
model RealtimeClientEventInputAudioBufferClear extends RealtimeClientEvent {
  /** Optional client-generated ID used to identify this event. */
  event_id?: string;

  // Tool customization: apply discriminated type base
  /** The event type, must be "input_audio_buffer.clear". */
  type: RealtimeClientEventType.input_audio_buffer_clear;
}

// Tool customization: apply discriminated type base
/** Send this event when adding an item to the conversation. */
model RealtimeClientEventConversationItemCreate extends RealtimeClientEvent {
  /** Optional client-generated ID used to identify this event. */
  event_id?: string;

  // Tool customization: apply discriminated type base
  /** The event type, must be "conversation.item.create". */
  type: RealtimeClientEventType.conversation_item_create;

  /** The ID of the preceding item after which the new item will be inserted. */
  previous_item_id?: string;

  // Tool customization: apply enriched item definition hierarchy
  /** The item to add to the conversation. */
  item: RealtimeRequestItem;
}

// Tool customization: apply discriminated type base
/** Send this event when you want to truncate a previous assistant message’s audio. */
model RealtimeClientEventConversationItemTruncate extends RealtimeClientEvent {
  /** Optional client-generated ID used to identify this event. */
  event_id?: string;

  // Tool customization: apply discriminated type base
  /** The event type, must be "conversation.item.truncate". */
  type: RealtimeClientEventType.conversation_item_truncate;

  /** The ID of the assistant message item to truncate. */
  item_id: string;

  /** The index of the content part to truncate. */
  content_index: int32;

  /** Inclusive duration up to which audio is truncated, in milliseconds. */
  audio_end_ms: int32;
}

// Tool customization: apply discriminated type base
/** Send this event when you want to remove any item from the conversation history. */
model RealtimeClientEventConversationItemDelete extends RealtimeClientEvent {
  /** Optional client-generated ID used to identify this event. */
  event_id?: string;

  // Tool customization: apply discriminated type base
  /** The event type, must be "conversation.item.delete". */
  type: RealtimeClientEventType.conversation_item_delete;

  /** The ID of the item to delete. */
  item_id: string;
}

// Tool customization: apply discriminated type base
/** Send this event to trigger a response generation. */
model RealtimeClientEventResponseCreate extends RealtimeClientEvent {
  /** Optional client-generated ID used to identify this event. */
  event_id?: string;

  // Tool customization: apply discriminated type base
  /** The event type, must be "response.create". */
  type: RealtimeClientEventType.response_create;

  /** Configuration for the response. */
  response: {
    /** The modalities for the response. */
    modalities?: string[];

    /** Instructions for the model. */
    instructions?: string;

    /** The voice the model uses to respond. */
    voice?: string;

    /** The format of output audio. */
    output_audio_format?: string;

    // Tool customization: apply enriched tool definition hierarchy
    /** Tools (functions) available to the model. */
    tools?: RealtimeTool[];

    /** How the model chooses tools. */
    tool_choice?: string;

    /** Sampling temperature. */
    temperature?: float32;

    /** Maximum number of output tokens for a single assistant response, inclusive of tool calls. Provide an integer between 1 and 4096 to limit output tokens, or "inf" for the maximum available tokens for a given model. Defaults to "inf". */
    max_output_tokens?: int32 | "inf";
  };
}

// Tool customization: apply discriminated type base
/** Send this event to cancel an in-progress response. */
model RealtimeClientEventResponseCancel extends RealtimeClientEvent {
  /** Optional client-generated ID used to identify this event. */
  event_id?: string;

  // Tool customization: apply discriminated type base
  /** The event type, must be "response.cancel". */
  type: RealtimeClientEventType.response_cancel;
}

// Tool customization: apply discriminated type base
/** Returned when an error occurs. */
model RealtimeServerEventError extends RealtimeServerEvent {
  /** The unique ID of the server event. */
  event_id: string;

  // Tool customization: apply discriminated type
  /** The event type, must be "error". */
  type: RealtimeServerEventType.error;

  /** Details of the error. */
  error: {
    /** The type of error (e.g., "invalid_request_error", "server_error"). */
    type?: string;

    /** Error code, if any. */
    code?: string;

    /** A human-readable error message. */
    message?: string;

    /** Parameter related to the error, if any. */
    param?: string;

    /** The event_id of the client event that caused the error, if applicable. */
    event_id?: string;
  };
}

// Tool customization: apply discriminated type base
/** Returned when a session is created. Emitted automatically when a new connection is established. */
model RealtimeServerEventSessionCreated extends RealtimeServerEvent {
  /** The unique ID of the server event. */
  event_id: string;

  // Tool customization: apply discriminated type
  /** The event type, must be "session.created". */
  type: RealtimeServerEventType.session_created;

  // Tool customization: apply shared session type
  /** The session resource. */
  session: RealtimeResponseSession;
}

// Tool customization: apply discriminated type base
/** Returned when a session is updated. */
model RealtimeServerEventSessionUpdated extends RealtimeServerEvent {
  /** The unique ID of the server event. */
  event_id: string;

  // Tool customization: apply discriminated type
  /** The event type, must be "session.updated". */
  type: RealtimeServerEventType.session_updated;

  // Tool customization: apply shared session type
  /** The updated session resource. */
  session: RealtimeResponseSession;
}

// Tool customization: apply discriminated type base
/** Returned when a conversation is created. Emitted right after session creation. */
model RealtimeServerEventConversationCreated extends RealtimeServerEvent {
  /** The unique ID of the server event. */
  event_id: string;

  // Tool customization: apply discriminated type
  /** The event type, must be "conversation.created". */
  type: RealtimeServerEventType.conversation_created;

  /** The conversation resource. */
  conversation: {
    /** The unique ID of the conversation. */
    id?: string;

    /** The object type, must be "realtime.conversation". */
    object?: string;
  };
}

// Tool customization: apply discriminated type base
/** Returned when an input audio buffer is committed, either by the client or automatically in server VAD mode. */
model RealtimeServerEventInputAudioBufferCommitted extends RealtimeServerEvent {
  /** The unique ID of the server event. */
  event_id: string;

  // Tool customization: apply discriminated type
  /** The event type, must be "input_audio_buffer.committed". */
  type: RealtimeServerEventType.input_audio_buffer_committed;

  /** The ID of the preceding item after which the new item will be inserted. */
  previous_item_id: string;

  /** The ID of the user message item that will be created. */
  item_id: string;
}

// Tool customization: apply discriminated type base
/** Returned when the input audio buffer is cleared by the client. */
model RealtimeServerEventInputAudioBufferCleared extends RealtimeServerEvent {
  /** The unique ID of the server event. */
  event_id: string;

  // Tool customization: apply discriminated type
  /** The event type, must be "input_audio_buffer.cleared". */
  type: RealtimeServerEventType.input_audio_buffer_cleared;
}

// Tool customization: apply discriminated type base
/** Returned in server turn detection mode when speech is detected. */
model RealtimeServerEventInputAudioBufferSpeechStarted
  extends RealtimeServerEvent {
  /** The unique ID of the server event. */
  event_id: string;

  // Tool customization: apply discriminated type
  /** The event type, must be "input_audio_buffer.speech_started". */
  type: RealtimeServerEventType.input_audio_buffer_speech_started;

  /** Milliseconds since the session started when speech was detected. */
  audio_start_ms: int32;

  /** The ID of the user message item that will be created when speech stops. */
  item_id: string;
}

// Tool customization: apply discriminated type base
/** Returned in server turn detection mode when speech stops. */
model RealtimeServerEventInputAudioBufferSpeechStopped
  extends RealtimeServerEvent {
  /** The unique ID of the server event. */
  event_id: string;

  // Tool customization: apply discriminated type
  /** The event type, must be "input_audio_buffer.speech_stopped". */
  type: RealtimeServerEventType.input_audio_buffer_speech_stopped;

  /** Milliseconds since the session started when speech stopped. */
  audio_end_ms: int32;

  /** The ID of the user message item that will be created. */
  item_id: string;
}

// Tool customization: apply discriminated type base
/** Returned when a conversation item is created. */
model RealtimeServerEventConversationItemCreated extends RealtimeServerEvent {
  /** The unique ID of the server event. */
  event_id: string;

  // Tool customization: apply discriminated type
  /** The event type, must be "conversation.item.created". */
  type: RealtimeServerEventType.conversation_item_created;

  /** The ID of the preceding item. */
  previous_item_id: string;

  // Tool customization: apply enriched item definition hierarchy
  /** The item that was created. */
  item: RealtimeResponseItem;
}

// Tool customization: apply discriminated type base
/** Returned when input audio transcription is enabled and a transcription succeeds. */
model RealtimeServerEventConversationItemInputAudioTranscriptionCompleted
  extends RealtimeServerEvent {
  /** The unique ID of the server event. */
  event_id: string;

  // Tool customization: apply discriminated type
  /** The event type, must be "conversation.item.input_audio_transcription.completed". */
  type: RealtimeServerEventType.conversation_item_input_audio_transcription_completed;

  /** The ID of the user message item. */
  item_id: string;

  /** The index of the content part containing the audio. */
  content_index: int32;

  /** The transcribed text. */
  transcript: string;
}

// Tool customization: apply discriminated type base
/** Returned when input audio transcription is configured, and a transcription request for a user message failed. */
model RealtimeServerEventConversationItemInputAudioTranscriptionFailed
  extends RealtimeServerEvent {
  /** The unique ID of the server event. */
  event_id: string;

  // Tool customization: apply discriminated type
  /** The event type, must be "conversation.item.input_audio_transcription.failed". */
  type: RealtimeServerEventType.conversation_item_input_audio_transcription_failed;

  /** The ID of the user message item. */
  item_id: string;

  /** The index of the content part containing the audio. */
  content_index: int32;

  /** Details of the transcription error. */
  error: {
    /** The type of error. */
    type?: string;

    /** Error code, if any. */
    code?: string;

    /** A human-readable error message. */
    message?: string;

    /** Parameter related to the error, if any. */
    param?: string;
  };
}

// Tool customization: apply discriminated type base
/** Returned when an earlier assistant audio message item is truncated by the client. */
model RealtimeServerEventConversationItemTruncated extends RealtimeServerEvent {
  /** The unique ID of the server event. */
  event_id: string;

  // Tool customization: apply discriminated type
  /** The event type, must be "conversation.item.truncated". */
  type: RealtimeServerEventType.conversation_item_truncated;

  /** The ID of the assistant message item that was truncated. */
  item_id: string;

  /** The index of the content part that was truncated. */
  content_index: int32;

  /** The duration up to which the audio was truncated, in milliseconds. */
  audio_end_ms: int32;
}

// Tool customization: apply discriminated type base
/** Returned when an item in the conversation is deleted. */
model RealtimeServerEventConversationItemDeleted extends RealtimeServerEvent {
  /** The unique ID of the server event. */
  event_id: string;

  // Tool customization: apply discriminated type
  /** The event type, must be "conversation.item.deleted". */
  type: RealtimeServerEventType.conversation_item_deleted;

  /** The ID of the item that was deleted. */
  item_id: string;
}

// Tool customization: apply discriminated type base
/** Returned when a new Response is created. The first event of response creation, where the response is in an initial state of "in_progress". */
model RealtimeServerEventResponseCreated extends RealtimeServerEvent {
  /** The unique ID of the server event. */
  event_id: string;

  // Tool customization: apply discriminated type
  /** The event type, must be "response.created". */
  type: RealtimeServerEventType.response_created;

  // Tool customization: apply shared response type
  /** The response resource. */
  response: RealtimeResponse;
}

// Tool customization: apply discriminated type base
/** Returned when a Response is done streaming. Always emitted, no matter the final state. */
model RealtimeServerEventResponseDone extends RealtimeServerEvent {
  /** The unique ID of the server event. */
  event_id: string;

  // Tool customization: apply discriminated type
  /** The event type, must be "response.done". */
  type: RealtimeServerEventType.response_done;

  // Tool customization: apply shared response type
  /** The response resource. */
  response: RealtimeResponse;
}

// Tool customization: apply discriminated type base
/** Returned when a new Item is created during response generation. */
model RealtimeServerEventResponseOutputItemAdded extends RealtimeServerEvent {
  /** The unique ID of the server event. */
  event_id: string;

  // Tool customization: apply discriminated type
  /** The event type, must be "response.output_item.added". */
  type: RealtimeServerEventType.response_output_item_added;

  /** The ID of the response to which the item belongs. */
  response_id: string;

  /** The index of the output item in the response. */
  output_index: int32;

  // Tool customization: apply enriched item definition hierarchy
  /** The item that was added. */
  item: RealtimeResponseItem;
}

// Tool customization: apply discriminated type base
/** Returned when an Item is done streaming. Also emitted when a Response is interrupted, incomplete, or cancelled. */
model RealtimeServerEventResponseOutputItemDone extends RealtimeServerEvent {
  /** The unique ID of the server event. */
  event_id: string;

  // Tool customization: apply discriminated type
  /** The event type, must be "response.output_item.done". */
  type: RealtimeServerEventType.response_output_item_done;

  /** The ID of the response to which the item belongs. */
  response_id: string;

  /** The index of the output item in the response. */
  output_index: int32;

  // Tool customization: apply enriched item definition hierarchy
  /** The completed item. */
  item: RealtimeResponseItem;
}

// Tool customization: apply discriminated type base
/** Returned when a new content part is added to an assistant message item during response generation. */
model RealtimeServerEventResponseContentPartAdded extends RealtimeServerEvent {
  /** The unique ID of the server event. */
  event_id: string;

  // Tool customization: apply discriminated type
  /** The event type, must be "response.content_part.added". */
  type: RealtimeServerEventType.response_content_part_added;

  /** The ID of the response. */
  response_id: string;

  /** The ID of the item to which the content part was added. */
  item_id: string;

  /** The index of the output item in the response. */
  output_index: int32;

  /** The index of the content part in the item's content array. */
  content_index: int32;

  // Tool customization: apply detailed content part type
  /** The content part that was added. */
  part: RealtimeContentPart;
}

// Tool customization: apply discriminated type base
/** Returned when a content part is done streaming in an assistant message item. Also emitted when a Response is interrupted, incomplete, or cancelled. */
model RealtimeServerEventResponseContentPartDone extends RealtimeServerEvent {
  /** The unique ID of the server event. */
  event_id: string;

  // Tool customization: apply discriminated type
  /** The event type, must be "response.content_part.done". */
  type: RealtimeServerEventType.response_content_part_done;

  /** The ID of the response. */
  response_id: string;

  /** The ID of the item. */
  item_id: string;

  /** The index of the output item in the response. */
  output_index: int32;

  /** The index of the content part in the item's content array. */
  content_index: int32;

  // Tool customization: apply detailed content part type
  /** The content part that is done. */
  part: RealtimeContentPart;
}

// Tool customization: apply discriminated type base
/** Returned when the text value of a "text" content part is updated. */
model RealtimeServerEventResponseTextDelta extends RealtimeServerEvent {
  /** The unique ID of the server event. */
  event_id: string;

  // Tool customization: apply discriminated type
  /** The event type, must be "response.text.delta". */
  type: RealtimeServerEventType.response_text_delta;

  /** The ID of the response. */
  response_id: string;

  /** The ID of the item. */
  item_id: string;

  /** The index of the output item in the response. */
  output_index: int32;

  /** The index of the content part in the item's content array. */
  content_index: int32;

  /** The text delta. */
  delta: string;
}

// Tool customization: apply discriminated type base
/** Returned when the text value of a "text" content part is done streaming. Also emitted when a Response is interrupted, incomplete, or cancelled. */
model RealtimeServerEventResponseTextDone extends RealtimeServerEvent {
  /** The unique ID of the server event. */
  event_id: string;

  // Tool customization: apply discriminated type
  /** The event type, must be "response.text.done". */
  type: RealtimeServerEventType.response_text_done;

  /** The ID of the response. */
  response_id: string;

  /** The ID of the item. */
  item_id: string;

  /** The index of the output item in the response. */
  output_index: int32;

  /** The index of the content part in the item's content array. */
  content_index: int32;

  /** The final text content. */
  text: string;
}

// Tool customization: apply discriminated type base
/** Returned when the model-generated transcription of audio output is updated. */
model RealtimeServerEventResponseAudioTranscriptDelta
  extends RealtimeServerEvent {
  /** The unique ID of the server event. */
  event_id: string;

  // Tool customization: apply discriminated type
  /** The event type, must be "response.audio_transcript.delta". */
  type: RealtimeServerEventType.response_audio_transcript_delta;

  /** The ID of the response. */
  response_id: string;

  /** The ID of the item. */
  item_id: string;

  /** The index of the output item in the response. */
  output_index: int32;

  /** The index of the content part in the item's content array. */
  content_index: int32;

  /** The transcript delta. */
  delta: string;
}

// Tool customization: apply discriminated type base
/** Returned when the model-generated transcription of audio output is done streaming. Also emitted when a Response is interrupted, incomplete, or cancelled. */
model RealtimeServerEventResponseAudioTranscriptDone
  extends RealtimeServerEvent {
  /** The unique ID of the server event. */
  event_id: string;

  // Tool customization: apply discriminated type
  /** The event type, must be "response.audio_transcript.done". */
  type: RealtimeServerEventType.response_audio_transcript_done;

  /** The ID of the response. */
  response_id: string;

  /** The ID of the item. */
  item_id: string;

  /** The index of the output item in the response. */
  output_index: int32;

  /** The index of the content part in the item's content array. */
  content_index: int32;

  /** The final transcript of the audio. */
  transcript: string;
}

// Tool customization: apply discriminated type base
/** Returned when the model-generated audio is updated. */
model RealtimeServerEventResponseAudioDelta extends RealtimeServerEvent {
  /** The unique ID of the server event. */
  event_id: string;

  // Tool customization: apply discriminated type
  /** The event type, must be "response.audio.delta". */
  type: RealtimeServerEventType.response_audio_delta;

  /** The ID of the response. */
  response_id: string;

  /** The ID of the item. */
  item_id: string;

  /** The index of the output item in the response. */
  output_index: int32;

  /** The index of the content part in the item's content array. */
  content_index: int32;

  // Tool customization: use encoded type for audio data
  /** Base64-encoded audio data delta. */
  @encode("base64")
  delta: bytes;
}

// Tool customization: apply discriminated type base
/** Returned when the model-generated audio is done. Also emitted when a Response is interrupted, incomplete, or cancelled. */
model RealtimeServerEventResponseAudioDone extends RealtimeServerEvent {
  /** The unique ID of the server event. */
  event_id: string;

  // Tool customization: apply discriminated type
  /** The event type, must be "response.audio.done". */
  type: RealtimeServerEventType.response_audio_done;

  /** The ID of the response. */
  response_id: string;

  /** The ID of the item. */
  item_id: string;

  /** The index of the output item in the response. */
  output_index: int32;

  /** The index of the content part in the item's content array. */
  content_index: int32;
}

// Tool customization: apply discriminated type base
/** Returned when the model-generated function call arguments are updated. */
model RealtimeServerEventResponseFunctionCallArgumentsDelta
  extends RealtimeServerEvent {
  /** The unique ID of the server event. */
  event_id: string;

  // Tool customization: apply discriminated type
  /** The event type, must be "response.function_call_arguments.delta". */
  type: RealtimeServerEventType.response_function_call_arguments_delta;

  /** The ID of the response. */
  response_id: string;

  /** The ID of the function call item. */
  item_id: string;

  /** The index of the output item in the response. */
  output_index: int32;

  /** The ID of the function call. */
  call_id: string;

  /** The arguments delta as a JSON string. */
  delta: string;
}

// Tool customization: apply discriminated type base
/** Returned when the model-generated function call arguments are done streaming. Also emitted when a Response is interrupted, incomplete, or cancelled. */
model RealtimeServerEventResponseFunctionCallArgumentsDone
  extends RealtimeServerEvent {
  /** The unique ID of the server event. */
  event_id: string;

  // Tool customization: apply discriminated type
  /** The event type, must be "response.function_call_arguments.done". */
  type: RealtimeServerEventType.response_function_call_arguments_done;

  /** The ID of the response. */
  response_id: string;

  /** The ID of the function call item. */
  item_id: string;

  /** The index of the output item in the response. */
  output_index: int32;

  /** The ID of the function call. */
  call_id: string;

  /** The final arguments as a JSON string. */
  arguments: string;
}

// Tool customization: apply discriminated type base
/** Emitted after every "response.done" event to indicate the updated rate limits. */
model RealtimeServerEventRateLimitsUpdated extends RealtimeServerEvent {
  /** The unique ID of the server event. */
  event_id: string;

  // Tool customization: apply discriminated type
  /** The event type, must be "rate_limits.updated". */
  type: RealtimeServerEventType.rate_limits_updated;

  // Tool customization: use custom type for rate limit items (applying encoded duration)
  /** List of rate limit information. */
  rate_limits: RealtimeServerEventRateLimitsUpdatedRateLimitsItem[];
}
