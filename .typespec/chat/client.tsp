import "@azure-tools/typespec-client-generator-core";
import "./custom.tsp";
import "./models.tsp";

using Azure.ClientGenerator.Core;
using OpenAI;

@@access(ChatCompletionFunctionChoice, Access.public);
@@usage(ChatCompletionFunctionChoice, Usage.input);

@@access(ChatCompletionToolChoice, Access.public);
@@usage(ChatCompletionToolChoice, Usage.input);

@@access(ChatMessageContentPart, Access.public);
@@usage(ChatMessageContentPart, Usage.input | Usage.output);

@@access(ChatCompletionRole, Access.public);
@@usage(ChatCompletionRole, Usage.input | Usage.output);

@@access(CreateChatCompletionFunctionResponse, Access.public);
@@usage(CreateChatCompletionFunctionResponse, Usage.output);

@@access(CreateChatCompletionStreamResponse, Access.public);
@@usage(CreateChatCompletionStreamResponse, Usage.output);
