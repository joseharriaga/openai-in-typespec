/*
 * This file was automatically generated from an OpenAPI .yaml file.
 * Edits made directly to this file will be lost.
 */

import "./custom.tsp";

namespace OpenAI;

// Tool customization: apply discriminated type base
@doc("""
  Send this event to update the session’s default configuration. The client may send this event at any time to update the session configuration, and any field may be updated at any time, except for "voice". The server will respond with a `session.updated` event that shows the full effective configuration. Only fields that are present are updated, thus the correct way to clear a field like "instructions" is to pass an empty string.
  """)
model RealtimeClientEventSessionUpdate extends RealtimeClientEvent {
  // Tool customization: apply discriminated type base
  /** The event type, must be "session.update". */
  type: RealtimeClientEventType.session_update;

  // Tool customization: apply enriched request-specific model
  session: RealtimeRequestSession;
}

// Tool customization: establish custom, enriched discriminated type hierarchy
/** The item to add to the conversation. */
model RealtimeConversationItemBase {
  /** Customized to enriched RealtimeConversation{Request,Response}Item models */
}

// Tool customization: apply enriched response type
/** The response resource. */
model RealtimeResponseBase {
  /** applied in enriched RealtimeResponse */
}

// Tool customization: apply discriminated type base
/**
 * Send this event to append audio bytes to the input audio buffer. The audio buffer is temporary storage you can write to and later commit. In Server VAD mode, the audio buffer is used to detect speech and the server will decide when to commit. When Server VAD is disabled, you must commit the audio buffer manually.
 * The client may choose how much audio to place in each event up to a maximum of 15 MiB, for example streaming smaller chunks from the client may allow the VAD to be more responsive. Unlike made other client events, the server will not send a confirmation response to this event.
 */
model RealtimeClientEventInputAudioBufferAppend extends RealtimeClientEvent {
  // Tool customization: apply discriminated type base
  /** The event type, must be "input_audio_buffer.append". */
  type: RealtimeClientEventType.input_audio_buffer_append;

  // Tool customization: use encoded type for audio data
  @doc("""
    Base64-encoded audio bytes. This must be in the format specified by the `input_audio_format` field in the session configuration.
    """)
  @encode("base64")
  audio: bytes;
}

// Tool customization: apply discriminated type base
@doc("""
  Send this event to commit the user input audio buffer, which will create a new user message item in the conversation. This event will produce an error if the input audio buffer is empty. When in Server VAD mode, the client does not need to send this event, the server will commit the audio buffer automatically.
  Committing the input audio buffer will trigger input audio transcription (if enabled in session configuration), but it will not create a response from the model. The server will respond with an `input_audio_buffer.committed` event.
  """)
model RealtimeClientEventInputAudioBufferCommit extends RealtimeClientEvent {
  // Tool customization: apply discriminated type base
  /** The event type, must be "input_audio_buffer.commit". */
  type: RealtimeClientEventType.input_audio_buffer_commit;
}

// Tool customization: apply discriminated type base
@doc("""
  Send this event to clear the audio bytes in the buffer. The server will respond with an `input_audio_buffer.cleared` event.
  """)
model RealtimeClientEventInputAudioBufferClear extends RealtimeClientEvent {
  // Tool customization: apply discriminated type base
  /** The event type, must be "input_audio_buffer.clear". */
  type: RealtimeClientEventType.input_audio_buffer_clear;
}

// Tool customization: apply discriminated type base
@doc("""
  Add a new Item to the Conversation's context, including messages, function calls, and function call responses. This event can be used both to populate a "history" of the conversation and to add new items mid-stream, but has the current limitation that it cannot populate assistant audio messages.
  If successful, the server will respond with a `conversation.item.created` event, otherwise an `error` event will be sent.
  """)
model RealtimeClientEventConversationItemCreate extends RealtimeClientEvent {
  // Tool customization: apply discriminated type base
  @doc("""
    The event type, must be `conversation.item.create`.
    """)
  type: RealtimeClientEventType.conversation_item_create;

  /** The ID of the preceding item after which the new item will be inserted. If not set, the new item will be appended to the end of the conversation. If set, it allows an item to be inserted mid-conversation. If the ID cannot be found, an error will be returned and the item will not be added. */
  previous_item_id?: string;

  // Tool customization: apply enriched item definition hierarchy
  item: RealtimeConversationRequestItem;
}

// Tool customization: apply discriminated type base
@doc("""
  Send this event to truncate a previous assistant message’s audio. The server will produce audio faster than realtime, so this event is useful when the user interrupts to truncate audio that has already been sent to the client but not yet played. This will synchronize the server's understanding of the audio with the client's playback.
  Truncating audio will delete the server-side text transcript to ensure there is not text in the context that hasn't been heard by the user.
  If successful, the server will respond with a `conversation.item.truncated` event.
  """)
model RealtimeClientEventConversationItemTruncate extends RealtimeClientEvent {
  // Tool customization: apply discriminated type base
  /** The event type, must be "conversation.item.truncate". */
  type: RealtimeClientEventType.conversation_item_truncate;

  /** The ID of the assistant message item to truncate. Only assistant message items can be truncated. */
  item_id: string;

  /** The index of the content part to truncate. Set this to 0. */
  content_index: int32;

  /** Inclusive duration up to which audio is truncated, in milliseconds. If the audio_end_ms is greater than the actual audio duration, the server will respond with an error. */
  audio_end_ms: int32;
}

// Tool customization: apply discriminated type base
@doc("""
  Send this event when you want to remove any item from the conversation history. The server will respond with a `conversation.item.deleted` event, unless the item does not exist in the conversation history, in which case the server will respond with an error.
  """)
model RealtimeClientEventConversationItemDelete extends RealtimeClientEvent {
  // Tool customization: apply discriminated type base
  /** The event type, must be "conversation.item.delete". */
  type: RealtimeClientEventType.conversation_item_delete;

  /** The ID of the item to delete. */
  item_id: string;
}

// Tool customization: apply discriminated type base
@doc("""
  This event instructs the server to create a Response, which means triggering model inference. When in Server VAD mode, the server will create Responses automatically.
  A Response will include at least one Item, and may have two, in which case the second will be a function call. These Items will be appended to the conversation history.
  The server will respond with a `response.created` event, events for Items and content created, and finally a `response.done` event to indicate the Response is complete.
  The `response.create` event includes inference configuration like `instructions`, and `temperature`. These fields will override the Session's configuration for this Response only.
  """)
model RealtimeClientEventResponseCreate extends RealtimeClientEvent {
  // Tool customization: apply discriminated type base
  @doc("""
    The event type, must be `response.create`.
    """)
  type: RealtimeClientEventType.response_create;

  // Tool customization: apply custom, distinct type for request-side response options
  response: RealtimeResponseOptions;
}

// Tool customization: apply discriminated type base
@doc("""
  Send this event to cancel an in-progress response. The server will respond with a `response.cancelled` event or an error if there is no response to cancel.
  """)
model RealtimeClientEventResponseCancel extends RealtimeClientEvent {
  // Tool customization: apply discriminated type base
  @doc("""
    The event type, must be `response.cancel`.
    """)
  type: RealtimeClientEventType.response_cancel;
}

// Tool customization: apply discriminated type base
/** Returned when an error occurs, which could be a client problem or a server problem. Most errors are recoverable and the session will stay open, we recommend to implementors to monitor and log error messages by default. */
model RealtimeServerEventError extends RealtimeServerEvent {
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
/** Returned when a Session is created. Emitted automatically when a new connection is established as the first server event. This event will contain the default Session configuration. */
model RealtimeServerEventSessionCreated extends RealtimeServerEvent {
  // Tool customization: apply discriminated type
  @doc("""
    The event type, must be `session.created`.
    """)
  type: RealtimeServerEventType.session_created;

  // Tool customization: apply enriched response-specific model
  session: RealtimeResponseSession;
}

// Tool customization: apply discriminated type base
@doc("""
  Returned when a session is updated with a `session.update` event, unless there is an error.
  """)
model RealtimeServerEventSessionUpdated extends RealtimeServerEvent {
  // Tool customization: apply discriminated type
  /** The event type, must be "session.updated". */
  type: RealtimeServerEventType.session_updated;

  // Tool customization: apply enriched response-specific model
  session: RealtimeResponseSession;
}

// Tool customization: establish base for enriched request/response split models
/** Realtime session object configuration. */
model RealtimeSessionBase {}

// Tool customization: apply discriminated type base
/** Returned when a conversation is created. Emitted right after session creation. */
model RealtimeServerEventConversationCreated extends RealtimeServerEvent {
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
@doc("""
  Returned when an input audio buffer is committed, either by the client or automatically in server VAD mode. The `item_id` property is the ID of the user message item that will be created, thus a `conversation.item.created` event will also be sent to the client.
  """)
model RealtimeServerEventInputAudioBufferCommitted extends RealtimeServerEvent {
  // Tool customization: apply discriminated type
  @doc("""
    The event type, must be `input_audio_buffer.committed`.
    """)
  type: RealtimeServerEventType.input_audio_buffer_committed;

  /** The ID of the preceding item after which the new item will be inserted. */
  previous_item_id: string;

  /** The ID of the user message item that will be created. */
  item_id: string;
}

// Tool customization: apply discriminated type base
@doc("""
  Returned when the input audio buffer is cleared by the client with a `input_audio_buffer.clear` event.
  """)
model RealtimeServerEventInputAudioBufferCleared extends RealtimeServerEvent {
  // Tool customization: apply discriminated type
  @doc("""
    The event type, must be `input_audio_buffer.cleared`.
    """)
  type: RealtimeServerEventType.input_audio_buffer_cleared;
}

// Tool customization: apply discriminated type base
@doc("""
  Sent by the server when in `server_vad` mode to indicate that speech has been detected in the audio buffer. This can happen any time audio is added to the buffer (unless speech is already detected). The client may want to use this event to interrupt audio playback or provide visual feedback to the user. The client should expect to receive a `input_audio_buffer.speech_stopped` event when speech stops. The `item_id` property is the ID of the user message item that will be created when speech stops and will also be included in the `input_audio_buffer.speech_stopped` event (unless the client manually commits the audio buffer during VAD activation).
  """)
model RealtimeServerEventInputAudioBufferSpeechStarted
  extends RealtimeServerEvent {
  // Tool customization: apply discriminated type
  @doc("""
    The event type, must be `input_audio_buffer.speech_started`.
    """)
  type: RealtimeServerEventType.input_audio_buffer_speech_started;

  @doc("""
    Milliseconds from the start of all audio written to the buffer during the session when speech was first detected. This will correspond to the beginning of audio sent to the model, and thus includes the `prefix_padding_ms` configured in the Session.
    """)
  audio_start_ms: int32;

  /** The ID of the user message item that will be created when speech stops. */
  item_id: string;
}

// Tool customization: apply discriminated type base
@doc("""
  Returned in `server_vad` mode when the server detects the end of speech in the audio buffer. The server will also send an `conversation.item.created` event with the user message item that is created from the audio buffer.
  """)
model RealtimeServerEventInputAudioBufferSpeechStopped
  extends RealtimeServerEvent {
  // Tool customization: apply discriminated type
  @doc("""
    The event type, must be `input_audio_buffer.speech_stopped`.
    """)
  type: RealtimeServerEventType.input_audio_buffer_speech_stopped;

  @doc("""
    Milliseconds since the session started when speech stopped. This will correspond to the end of audio sent to the model, and thus includes the `min_silence_duration_ms` configured in the Session.
    """)
  audio_end_ms: int32;

  /** The ID of the user message item that will be created. */
  item_id: string;
}

// Tool customization: apply discriminated type base
@doc("""
  Returned when a conversation item is created. There are several scenarios that produce this event:
    - The server is generating a Response, which if successful will produce either one or two Items, which will be of type `message` (role `assistant`) or type `function_call`.
    - The input audio buffer has been committed, either by the client or the server (in `server_vad` mode). The server will take the content of the input audio buffer and add it to a new user message Item.
    - The client has sent a `conversation.item.create` event to add a new Item to the Conversation.
  """)
model RealtimeServerEventConversationItemCreated extends RealtimeServerEvent {
  // Tool customization: apply discriminated type
  @doc("""
    The event type, must be `conversation.item.created`.
    """)
  type: RealtimeServerEventType.conversation_item_created;

  /** The ID of the preceding item in the Conversation context, allows the client to understand the order of the conversation. */
  previous_item_id: string;

  // Tool customization: apply enriched item definition hierarchy
  item: RealtimeConversationResponseItem;
}

// Tool customization: apply discriminated type base
@doc("""
  This event is the output of audio transcription for user audio written to the user audio buffer. Transcription begins when the input audio buffer is committed by the client or server (in `server_vad` mode). Transcription runs asynchronously with Response creation, so this event may come before or after the Response events.
  Realtime API models accept audio natively, and thus input transcription is a separate process run on a separate ASR (Automatic Speech Recognition) model, currently always `whisper-1`. Thus the transcript may diverge somewhat from the model's interpretation, and should be treated as a rough guide.
  """)
model RealtimeServerEventConversationItemInputAudioTranscriptionCompleted
  extends RealtimeServerEvent {
  // Tool customization: apply discriminated type
  @doc("""
    The event type, must be `conversation.item.input_audio_transcription.completed`.
    """)
  type: RealtimeServerEventType.conversation_item_input_audio_transcription_completed;

  /** The ID of the user message item containing the audio. */
  item_id: string;

  /** The index of the content part containing the audio. */
  content_index: int32;

  /** The transcribed text. */
  transcript: string;
}

// Tool customization: apply discriminated type base
@doc("""
  Returned when input audio transcription is configured, and a transcription request for a user message failed. These events are separate from other `error` events so that the client can identify the related Item.
  """)
model RealtimeServerEventConversationItemInputAudioTranscriptionFailed
  extends RealtimeServerEvent {
  // Tool customization: apply discriminated type
  @doc("""
    The event type, must be `conversation.item.input_audio_transcription.failed`.
    """)
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
@doc("""
  Returned when an earlier assistant audio message item is truncated by the client with a `conversation.item.truncate` event. This event is used to synchronize the server's understanding of the audio with the client's playback.
  This action will truncate the audio and remove the server-side text transcript to ensure there is no text in the context that hasn't been heard by the user.
  """)
model RealtimeServerEventConversationItemTruncated extends RealtimeServerEvent {
  // Tool customization: apply discriminated type
  @doc("""
    The event type, must be `conversation.item.truncated`.
    """)
  type: RealtimeServerEventType.conversation_item_truncated;

  /** The ID of the assistant message item that was truncated. */
  item_id: string;

  /** The index of the content part that was truncated. */
  content_index: int32;

  /** The duration up to which the audio was truncated, in milliseconds. */
  audio_end_ms: int32;
}

// Tool customization: apply discriminated type base
@doc("""
  Returned when an item in the conversation is deleted by the client with a `conversation.item.delete` event. This event is used to synchronize the server's understanding of the conversation history with the client's view.
  """)
model RealtimeServerEventConversationItemDeleted extends RealtimeServerEvent {
  // Tool customization: apply discriminated type
  @doc("""
    The event type, must be `conversation.item.deleted`.
    """)
  type: RealtimeServerEventType.conversation_item_deleted;

  /** The ID of the item that was deleted. */
  item_id: string;
}

// Tool customization: apply discriminated type base
@doc("""
  Returned when a new Response is created. The first event of response creation, where the response is in an initial state of `in_progress`.
  """)
model RealtimeServerEventResponseCreated extends RealtimeServerEvent {
  // Tool customization: apply discriminated type
  @doc("""
    The event type, must be `response.created`.
    """)
  type: RealtimeServerEventType.response_created;

  response: RealtimeResponse;
}

// Tool customization: apply discriminated type base
@doc("""
  Returned when a Response is done streaming. Always emitted, no matter the final state. The Response object included in the `response.done` event will include all output Items in the Response but will omit the raw audio data.
  """)
model RealtimeServerEventResponseDone extends RealtimeServerEvent {
  // Tool customization: apply discriminated type
  /** The event type, must be "response.done". */
  type: RealtimeServerEventType.response_done;

  response: RealtimeResponse;
}

// Tool customization: apply discriminated type base
/** Returned when a new Item is created during Response generation. */
model RealtimeServerEventResponseOutputItemAdded extends RealtimeServerEvent {
  // Tool customization: apply discriminated type
  @doc("""
    The event type, must be `response.output_item.added`.
    """)
  type: RealtimeServerEventType.response_output_item_added;

  /** The ID of the Response to which the item belongs. */
  response_id: string;

  /** The index of the output item in the Response. */
  output_index: int32;

  // Tool customization: apply enriched item definition hierarchy
  item: RealtimeConversationResponseItem;
}

// Tool customization: apply discriminated type base
/** Returned when an Item is done streaming. Also emitted when a Response is interrupted, incomplete, or cancelled. */
model RealtimeServerEventResponseOutputItemDone extends RealtimeServerEvent {
  // Tool customization: apply discriminated type
  @doc("""
    The event type, must be `response.output_item.done`.
    """)
  type: RealtimeServerEventType.response_output_item_done;

  /** The ID of the Response to which the item belongs. */
  response_id: string;

  /** The index of the output item in the Response. */
  output_index: int32;

  // Tool customization: apply enriched item definition hierarchy
  item: RealtimeConversationResponseItem;
}

// Tool customization: apply discriminated type base
/** Returned when a new content part is added to an assistant message item during response generation. */
model RealtimeServerEventResponseContentPartAdded extends RealtimeServerEvent {
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
/** Emitted at the beginning of a Response to indicate the updated rate limits. When a Response is created some tokens will be "reserved" for the output tokens, the rate limits shown here reflect that reservation, which is then adjusted accordingly once the Response is completed. */
model RealtimeServerEventRateLimitsUpdated extends RealtimeServerEvent {
  // Tool customization: apply discriminated type
  @doc("""
    The event type, must be `rate_limits.updated`.
    """)
  type: RealtimeServerEventType.rate_limits_updated;

  // Tool customization: use custom type for rate limit items (applying encoded duration)
  /** List of rate limit information. */
  rate_limits: RealtimeServerEventRateLimitsUpdatedRateLimitsItem[];
}
