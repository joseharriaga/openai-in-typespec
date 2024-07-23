import "@typespec/http";
import "@typespec/openapi";

import "../common";
import "./models.tsp";

using TypeSpec.Http;
using TypeSpec.OpenAPI;

using OpenAI;

namespace AzureOpenAI;

@route("threads/{thread_id}/messages")
interface AzureMessages {
  @post
  @operationId("createMessage")
  @tag("Assistants")
  @summary("Create a message.")
  createMessage(
    /** The ID of the [thread](/docs/api-reference/threads) to create a message for. */
    @path thread_id: string,

    @body requestBody: OpenAI.CreateMessageRequest,
  ): OpenAI.MessageObject | OpenAI.ErrorResponse;
}
