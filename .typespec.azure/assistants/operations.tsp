import "@typespec/http";
import "@typespec/openapi";

import "../common";
import "./models.tsp";

using TypeSpec.Http;
using TypeSpec.OpenAPI;
using OpenAI;

namespace AzureOpenAI;

@route("/assistants")
interface AzureAssistants {
  @post
  @operationId("createAssistant")
  @tag("Assistants")
  @summary("Create an assistant with a model and instructions.")
  createAssistant(
    @body assistant: CreateAssistantRequest,
  ): AssistantObject | ErrorResponse;
}
