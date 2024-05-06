import "@typespec/http";
import "@typespec/openapi";

import "../common";
import "./models.tsp";

using TypeSpec.Http;
using TypeSpec.OpenAPI;

namespace OpenAI;

@route("/batches")
interface Batches {
  @get
  @operationId("listBatches")
  @tag("Batches")
  @summary("List your organization's batches.")
  listBatches(
    /**
     * A cursor for use in pagination. `after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with obj_foo, your subsequent call can include after=obj_foo in order to fetch the next page of the list.
     */
    @query after?: string;
    /**
     * A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 20.
     */
    @query limit?: int32 = 20;
  ): ListBatchesResponse | ErrorResponse;
}
