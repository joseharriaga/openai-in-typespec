import "@azure-tools/typespec-client-generator-core";
import "./custom.tsp";
import "./models.tsp";

using Azure.ClientGenerator.Core;
using OpenAI;

@@access(ChatCompletionFunctionChoice, Access.public);
@@usage(ChatCompletionFunctionChoice, Usage.input);

@@access(ChatCompletionRequestMessageContentPart, Access.public);
@@usage(ChatCompletionRequestMessageContentPart, Usage.input | Usage.output);

@@access(ChatCompletionRole, Access.public);
@@usage(ChatCompletionRole, Usage.input | Usage.output);

@@access(CreateChatCompletionFunctionResponse, Access.public);
@@usage(CreateChatCompletionFunctionResponse, Usage.output);

@@access(CreateChatCompletionStreamResponse, Access.public);
@@usage(CreateChatCompletionStreamResponse, Usage.output);

@@access(ChatResponseFormatJsonSchema, Access.public);
@@usage(ChatResponseFormatJsonSchema, Usage.input);

@@access(ClientOnlyChatCompletionToolChoiceOption, Access.public);
@@usage(ClientOnlyChatCompletionToolChoiceOption, Usage.input);

@@access(ClientOnlyChatCompletionToolChoiceOptionPredefined, Access.public);
@@usage(ClientOnlyChatCompletionToolChoiceOptionPredefined, Usage.input);

@@access(ClientOnlyChatCompletionToolChoiceOptionNamed, Access.public);
@@usage(ClientOnlyChatCompletionToolChoiceOptionNamed, Usage.input);

@@clientName(ChatCompletionToolType, "ChatToolKind", "csharp");
@@clientName(ChatCompletionTool.type, "kind", "csharp");
@@clientName(ChatCompletionFunctionTool.type, "kind", "csharp");

@@clientName(ChatCompletionRequestMessageContentPart.type, "kind", "csharp");
@@clientName(ChatCompletionRequestMessageContentPartText.type,
  "kind",
  "csharp"
);
@@clientName(ChatCompletionRequestMessageContentPartImage.type,
  "kind",
  "csharp"
);
@@clientName(ChatCompletionRequestMessageContentPartRefusal.type,
  "kind",
  "csharp"
);

@@clientName(ChatCompletionMessageToolCall.type, "kind", "csharp");
@@clientName(ChatCompletionMessageFunctionToolCall.type, "kind", "csharp");

@@clientName(ChatCompletionMessageToolCall.type, "kind", "csharp");
@@clientName(ChatCompletionMessageFunctionToolCall.type, "kind", "csharp");

@@clientName(ChatCompletionMessageToolCallChunk.type, "kind", "csharp");
@@clientName(ChatCompletionMessageFunctionToolCallChunk.type, "kind", "csharp");
