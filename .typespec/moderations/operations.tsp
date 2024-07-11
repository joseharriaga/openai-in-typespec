import "@typespec/http";
import "@typespec/openapi";

import "../common";
import "./models.tsp";

using TypeSpec.Http;
using TypeSpec.OpenAPI;

namespace OpenAI;

@route("/moderations")
interface Moderations {
  @post
  @operationId("createModeration")
  @tag("Moderations")
  @summary("Classifies if text is potentially harmful.")
  createModeration(
    @body requestBody: CreateModerationRequest,
  ): CreateModerationResponse | ErrorResponse;
}
