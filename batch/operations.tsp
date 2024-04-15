import "@typespec/http";
import "@typespec/openapi";

import "../common/errors.tsp";
import "./models.tsp";

using TypeSpec.Http;
using TypeSpec.OpenAPI;

namespace OpenAI;

@route("/batches")
interface Batch {
  @post
  @operationId("createBatch")
  @tag("Batch")
  @summary("Creates and executes a batch from an uploaded file of requests.")
  createBatch(
    /** The request body for the batch operation. */
    @body request: CreateBatchRequest,
  ): BatchResponse | ErrorResponse;

  @route("{batch_id}")
  @get
  @operationId("retrieveBatch")
  @tag("Batch")
  @summary("Retrieves a batch.")
  retrieveBatch(
    /** The ID of the batch to retrieve. */
    @path batch_id: string
  ): BatchResponse | ErrorResponse;

  @route("{batch_id}/cancel")
  @post
  @operationId("cancelBatch")
  @tag("Batch")
  @summary("Cancels an in-progress batch.")
  cancelBatch(
    /** The ID of the batch to cancel. */
    @path batch_id: string
  ): BatchResponse | ErrorResponse;
}