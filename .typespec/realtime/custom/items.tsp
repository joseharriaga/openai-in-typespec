import "./content_parts.tsp";

using TypeSpec.OpenAPI;

namespace OpenAI;

@discriminator("type")
model RealtimeRequestItem {
  type: RealtimeItemType;
  id?: string;
}

@discriminator("role")
model RealtimeRequestMessageItem extends RealtimeRequestItem {
  type: RealtimeItemType.message;
  role: RealtimeMessageRole;
  status?: RealtimeItemStatus;
}

model RealtimeRequestSystemMessageItem extends RealtimeRequestMessageItem {
  role: RealtimeMessageRole.system;
  content: RealtimeRequestTextContentPart[];
}

model RealtimeRequestUserMessageItem extends RealtimeRequestMessageItem {
  role: RealtimeMessageRole.user;
  content: (RealtimeRequestTextContentPart | RealtimeRequestAudioContentPart)[];
}

model RealtimeRequestAssistantMessageItem extends RealtimeRequestMessageItem {
  role: RealtimeMessageRole.assistant;
  content: RealtimeRequestTextContentPart[];
}

model RealtimeRequestFunctionCallItem extends RealtimeRequestItem {
  type: RealtimeItemType.function_call;
  name: string;
  call_id: string;
  arguments: string;
  status?: RealtimeItemStatus;
}

model RealtimeRequestFunctionCallOutputItem extends RealtimeRequestItem {
  type: RealtimeItemType.function_call_output;
  call_id: string;
  output: string;
}

// TODO: representation of a doubly-discriminated type with an absent second discriminator
//   (first discriminator: type = message; second discriminator: no role present)

model RealtimeRequestMessageReferenceItem { // extends RealtimeRequestItem {
  type: RealtimeItemType.message;
  id: string;
}

@discriminator("type")
model RealtimeResponseItem {
  object: "realtime.item";
  type: RealtimeItemType;
  id: string | null;
}

model RealtimeResponseMessageItem extends RealtimeResponseItem {
  type: RealtimeItemType.message;
  role: RealtimeMessageRole;
  content: RealtimeContentPart[];
  status: RealtimeItemStatus;
}

model RealtimeResponseFunctionCallItem extends RealtimeResponseItem {
  type: RealtimeItemType.function_call;
  name: string;
  call_id: string;
  arguments: string;
  status: RealtimeItemStatus;
}

model RealtimeResponseFunctionCallOutputItem extends RealtimeResponseItem {
  type: RealtimeItemType.function_call_output;
  call_id: string;
  output: string;
}

union RealtimeItemType {
  string,
  message: "message",
  function_call: "function_call",
  function_call_output: "function_call_output",
}

union RealtimeItemStatus {
  string,
  in_progress: "in_progress",
  completed: "completed",
  incomplete: "incomplete",
}

union RealtimeMessageRole {
  string,
  system: "system",
  user: "user",
  assistant: "assistant",
}
