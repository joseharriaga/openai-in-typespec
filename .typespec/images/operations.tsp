import "@typespec/http";
import "@typespec/openapi";

import "../common/models.tsp";
import "./models.tsp";

using TypeSpec.Http;
using TypeSpec.OpenAPI;

namespace OpenAI;

@route("/images")
interface Images {
  @route("generations")
  @post
  @operationId("createImage")
  @tag("Images")
  @summary("Creates an image given a prompt")
  createImage(
    @body requestBody: CreateImageRequest,
  ): ImagesResponse | ErrorResponse;

  @route("edits")
  @post
  @operationId("createImageEdit")
  @tag("Images")
  @summary("Creates an edited or extended image given an original image and a prompt.")
  createImageEdit(
    @header contentType: "multipart/form-data",
    @body requestBody: CreateImageEditRequest,
  ): ImagesResponse | ErrorResponse;

  @route("variations")
  @post
  @operationId("createImageVariation")
  @tag("Images")
  @summary("Creates an edited or extended image given an original image and a prompt.")
  createImageVariation(
    @header contentType: "multipart/form-data",
    @body requestBody: CreateImageVariationRequest,
  ): ImagesResponse | ErrorResponse;
}
