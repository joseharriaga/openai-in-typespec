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
    @body requestBody: CreateAssistantRequest,
  ): AssistantObject | ErrorResponse;

  @get
  @operationId("listAssistants")
  @tag("Assistants")
  @summary("Returns a list of assistants.")
  listAssistants(
    /**
     * A limit on the number of objects to be returned. Limit can range between 1 and 100, and the
     * default is 20.
     */
    @query limit?: int32 = 20,

    /**
     * Sort order by the `created_at` timestamp of the objects. `asc` for ascending order and`desc`
     * for descending order.
     */
    @query order?: ListOrder = ListOrder.desc,

    /**
     * A cursor for use in pagination. `after` is an object ID that defines your place in the list.
     * For instance, if you make a list request and receive 100 objects, ending with obj_foo, your
     * subsequent call can include after=obj_foo in order to fetch the next page of the list.
     */
    @query after?: string,

    /**
     * A cursor for use in pagination. `before` is an object ID that defines your place in the list.
     * For instance, if you make a list request and receive 100 objects, ending with obj_foo, your
     * subsequent call can include before=obj_foo in order to fetch the previous page of the list.
     */
    @query before?: string,
  ): ListAssistantsResponse | ErrorResponse;

  @route("{assistant_id}")
  @get
  @operationId("getAssistant")
  @tag("Assistants")
  @summary("Retrieves an assistant.")
  getAssistant(
    /** The ID of the assistant to retrieve. */
    @path assistant_id: string,
  ): AssistantObject | ErrorResponse;

  @route("{assistant_id}")
  @post
  @operationId("modifyAssistant")
  @tag("Assistants")
  @summary("Modifies an assistant.")
  modifyAssistant(
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
    /** The ID of the assistant to delete. */
    @path assistant_id: string,
  ): DeleteAssistantResponse | ErrorResponse;
}
