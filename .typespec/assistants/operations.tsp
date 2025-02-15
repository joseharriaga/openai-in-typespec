import "@typespec/http";
import "@typespec/openapi";

import "../common";
import "./models.tsp";

using TypeSpec.Http;
using TypeSpec.OpenAPI;

namespace OpenAI;

@route("/assistants")
interface Assistants {
  @post
  @operationId("createAssistant")
  @tag("Assistants")
  @summary("Create an assistant with a model and instructions.")
  createAssistant(
    ...AcceptJsonHeader,
    ...AssistantsBetaHeader,
    @body requestBody: CreateAssistantRequest,
  ): AssistantObject | ErrorResponse;

  @get
  @operationId("listAssistants")
  @tag("Assistants")
  @summary("Returns a list of assistants.")
  listAssistants(
    ...AcceptJsonHeader,
    ...AssistantsBetaHeader,
    ...CommonPageQueryParameters,
  ): ListAssistantsResponse | ErrorResponse;

  @route("{assistant_id}")
  @get
  @operationId("getAssistant")
  @tag("Assistants")
  @summary("Retrieves an assistant.")
  getAssistant(
    ...AcceptJsonHeader,
    ...AssistantsBetaHeader,

    /** The ID of the assistant to retrieve. */
    @path assistant_id: string,
  ): AssistantObject | ErrorResponse;

  @route("{assistant_id}")
  @post
  @operationId("modifyAssistant")
  @tag("Assistants")
  @summary("Modifies an assistant.")
  modifyAssistant(
    ...AcceptJsonHeader,
    ...AssistantsBetaHeader,

    /** The ID of the assistant to modify. */
    @path assistant_id: string,

    @body requestBody: ModifyAssistantRequest,
  ): AssistantObject | ErrorResponse;

  @route("{assistant_id}")
  @delete
  @operationId("deleteAssistant")
  @tag("Assistants")
  @summary("Delete an assistant.")
  deleteAssistant(
    ...AcceptJsonHeader,
    ...AssistantsBetaHeader,

    /** The ID of the assistant to delete. */
    @path assistant_id: string,
  ): DeleteAssistantResponse | ErrorResponse;
}
