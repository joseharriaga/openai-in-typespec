import "@typespec/http";
import "@typespec/openapi";

import "../common";
import "./models.tsp";

using TypeSpec.Http;
using TypeSpec.OpenAPI;

namespace OpenAI;

@route("/chat")
interface Chat {
  @route("completions")
  @post
  @operationId("createChatCompletion")
  @tag("Chat")
  @summary("Creates a model response for the given chat conversation.")
  createChatCompletion(
    @body requestBody: CreateChatCompletionRequest,
  ): CreateChatCompletionResponse | ErrorResponse;
}
