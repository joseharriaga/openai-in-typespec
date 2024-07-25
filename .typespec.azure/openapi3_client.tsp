import "./main.tsp";
import "./client.tsp";

import "@typespec/openapi3";

using TypeSpec.OpenAPI;

// the @extension decorator does not accept symbols as arguments, therefore OpenAI.CreateChatCompletionResponse is passed as a string
@@extension(AzureOpenAI.AzureCreateChatCompletionResponse, "x-inherits-from-model", "OpenAI.CreateChatCompletionResponse");

