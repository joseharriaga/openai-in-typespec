import "@typespec/http";
import "@typespec/openapi";

import "../common";
import "./models.request.tsp";
import "./models.response.tsp";

using TypeSpec.Http;
using TypeSpec.OpenAPI;
using OpenAI;

namespace AzureOpenAI;

@route("{deployment_id}/chat")
interface AzureChat {
  @route("completions")
  @post
  @operationId("createChatCompletion")
  @tag("Chat")
  createChatCompletion(
    @path deployment_id: string,
    @body request: AzureCreateChatCompletionRequest,
  ): AzureCreateChatCompletionResponse | AzureOpenAIChatErrorResponse;
}
