import "@typespec/http";
import "@typespec/openapi";

import "../common";
import "./models.tsp";

using TypeSpec.Http;
using TypeSpec.OpenAPI;
using OpenAI;

namespace AzureOpenAI;

@route("/deployments/{deploymentId}/images")
interface AzureImages {
  @route("/generations")
  @post
  @operationId("ImageGenerations_Create")
  @tag("Images")
  createImage(
    @path deploymentId: string,
    @body image: CreateImageRequest,
    // @query api-version: string;
  ): ImagesResponse | AzureOpenAIErrorResponse<AzureOpenAIDalleError>;
}
