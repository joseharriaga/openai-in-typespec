import "./common.tsp";
import "./items.tsp";
import "./tools.tsp";
import "./turn_detection.tsp";

using TypeSpec.OpenAPI;

namespace OpenAI.Realtime;

union RealtimeRequestCommandType {
  string,
  session_update: "session.update",
  input_audio_buffer_append: "input_audio_buffer.append",
  input_audio_buffer_commit: "input_audio_buffer.commit",
  input_audio_buffer_clear: "input_audio_buffer.clear",
  item_create: "conversation.item.create",
  item_delete: "conversation.item.delete",
  item_truncate: "conversation.item.truncate",
  response_create: "response.create",
  response_cancel: "response.cancel",
}

/**
 * A base representation for messages sent by the client to the service.
 */
@discriminator("type")
model RealtimeRequestCommand {
  type: RealtimeRequestCommandType;
  event_id?: string;
}

model RealtimeRequestSessionUpdateCommand extends RealtimeRequestCommand {
  type: RealtimeRequestCommandType.session_update;
  session: {
    `model`?: RealtimeRequestModel;
    modalities?: RealtimeModalities;
    voice?: RealtimeVoice = RealtimeVoice.alloy;
    instructions?: string;
    input_audio_format?: RealtimeAudioFormat;
    output_audio_format?: RealtimeAudioFormat;
    input_audio_transcription?: RealtimeAudioInputTranscriptionSettings;
    turn_detection?: RealtimeTurnDetection;
    tools?: RealtimeTool[];
    tool_choice?: RealtimeToolChoice = RealtimeToolChoiceLiteral.auto;
    temperature?: float32;
    max_response_output_tokens?: int32 | "inf";
  };
}

model RealtimeRequestInputAudioBufferAppendCommand
  extends RealtimeRequestCommand {
  type: RealtimeRequestCommandType.input_audio_buffer_append;

  @encode("base64")
  audio: bytes;
}

model RealtimeRequestInputAudioBufferCommitCommand
  extends RealtimeRequestCommand {
  type: RealtimeRequestCommandType.input_audio_buffer_commit;
}

model RealtimeRequestInputAudioBufferClearCommand
  extends RealtimeRequestCommand {
  type: RealtimeRequestCommandType.input_audio_buffer_clear;
}

model RealtimeRequestItemCreateCommand extends RealtimeRequestCommand {
  type: RealtimeRequestCommandType.item_create;
  previous_item_id?: string;
  item: RealtimeRequestItem;
}

model RealtimeRequestItemDeleteCommand extends RealtimeRequestCommand {
  type: RealtimeRequestCommandType.item_delete;
  item_id: string;
}

model RealtimeRequestItemTruncateCommand extends RealtimeRequestCommand {
  type: RealtimeRequestCommandType.item_truncate;
  item_id: string;
  content_index: int32;
  audio_end_ms: int32;
}

/**
 * Trigger model inference to generate a model turn, the response will be streamed back with
 * a series of events, starting with an add_message event and ending with a turn_finished event.
 * If functions are enabled the response may be two, the second being a tool_call.
 *
 * Fields:
 * - conversation_label: References a conversation. If empty or set to a label that does not exist,
 *     Generate will create a new conversation, otherwise it will be based on the context of the
 *     existing conversation.
 * - commit: If true, the generated messages will be appended to the end of the conversation.
 *     Only valid if conversation_label is set.
 * - cancel_previous: If True, the generation will cancel any pending generation for that specific
 *     conversation. If False, the generation will be queued and will be generated after the
 *     previous generation has completed.
 * - append_messages: If set, these messages will be appended to the end of the conversation before
 *     a response is generated. If commit is false, these messages will be discarded. This can only
 *     be done with an existing conversation, and thus will throw an error if conversation_label is
 *     not set or does not exist.
 * - messages: If conversation_label is not set or does not exist, this will be the initial messages
 *     of the conversation, i.e. the context of the generation. If the conversation exists, this will
 *     throw an error.
 */
model RealtimeRequestResponseCreateCommand extends RealtimeRequestCommand {
  type: RealtimeRequestCommandType.response_create;
  response?: {
    commit: boolean = true;
    cancel_previous: boolean = true;
    append_input_items?: RealtimeRequestItem[];
    input_items?: RealtimeRequestItem[];
    instructions?: string;
    modalities?: RealtimeModalities;
    voice?: RealtimeVoice;
    temperature?: float32;
    max_output_tokens?: int32 | "inf" | null;
    tools?: RealtimeTool[];
    tool_choice?: RealtimeToolChoice;
    output_audio_format?: RealtimeAudioFormat;
  };
}

model RealtimeRequestResponseCancelCommand extends RealtimeRequestCommand {
  type: RealtimeRequestCommandType.response_cancel;
}

union RealtimeRequestModel {
  string,
  gpt_4o_realtime: "gpt-4o-realtime",
}
