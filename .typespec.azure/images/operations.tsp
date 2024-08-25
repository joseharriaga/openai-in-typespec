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
  /**
   * Creates an image given a prompt.
   */
  @route("/generations")
  @post
  @operationId("createImage")
  @tag("Images")
  createImage(
    @path deploymentId: string,
    @body image: CreateImageRequest,
    // @query api-version: string;
  ): ImagesResponse | AzureOpenAIDalleErrorResponse;
}
