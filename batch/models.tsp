import "../common/models.tsp";

using TypeSpec.Http;
using TypeSpec.OpenAPI;

namespace OpenAI;

/** The request body for an operation that creates a new batch. */
model CreateBatchRequest {
  /**
   * The ID of an uploaded file that contains requests for the new batch.
   * 
   * Input must be formatted as a JSONL file, and must be uploaded with the purpose 'batch'.
   */
  input_file_id: string;

  /**
   * The endpoint to be used for all requests in the batch.
   * 
   * Currently, only '/v1/chat/completions' is supported.
   */
  endpoint: string;

  /**
   * The timeframe within which the batch should be processed.
   * 
   * Currently, only '24h' is supported.
   */
  completion_window: string;

  /**
   * Optional, custom metadata for the batch.
   */
  @extension("x-oaiTypeLabel", "map")
  metadata?: Record<string> | null;
}

/** The response body for batch operation. */
model BatchResponse {
  /**
   * The ID of the batch, as used in other operations.
   */
  id: string;

  /**
   * The object type, which is always 'batch'.
   */
  object: "batch";

  /**
   * The API endpoint used by the batch.
   */
  endpoint: string;

  /**
   * 
   */
  errors: null | {
    /**
     * The object type, which is always 'list'.
     */
    object: "list";

    /**
     * 
     */
    data: {
      /**
       * An error code that identifies the error type.
       */
      code: string;

      /**
       * A human-readable message that provides more details about the error.
       */
      message: string;

      /**
       * The name of the parameter that caused the error, if applicable.
       */
      param: string | null;

      /**
       * The line number of the input file where the error occurred, if applicable.
       */
      line: safeint | null;
    }[];
  };

  /**
   * The ID of the input file used for the batch.
   */
  input_file_id: string;

  /**
   * The timeframe within which the batch should be processed, as measured from its creation time.
   */
  completion_window: string;

  /**
   * The current status of the batch.
   */
  status: string;

  /**
   * The ID of the file that contains the outputs of the requests within the batch that were
   * successfully executed.
   */
  output_file_id: string;

  /**
   * The ID of the file that contains the outputs of the requests within the batch that encountered
   * errors during execution. 
   */
  error_file_id: string;

  /**
   * The timestamp indicating when the batch was created.
   */
  @encode("unixTimestamp", int32)
  created_at: utcDateTime;

  /**
   * The timestamp indicating when the batch started processing.
   */
  @encode("unixTimestamp", int32)
  in_progress_at: utcDateTime | null;

  /**
   * The timestamp indicating when the batch will expire.
   */
  @encode("unixTimestamp", int32)
  expires_at: utcDateTime | null;

  /**
   * The timestamp indicating when the batch started finalization.
   */
  @encode("unixTimestamp", int32)
  finalizing_at: utcDateTime | null;

  /**
   * The timestamp indicating when the batch was successfully completed.
   */
  @encode("unixTimestamp", int32)
  completed_at: utcDateTime | null;

  /**
   * The timestamp indicating when the batch failed.
   */
  @encode("unixTimestamp", int32)
  failed_at: utcDateTime | null;

  /**
   * The timestamp indicating when the batch expired before completing.
   */
  @encode("unixTimestamp", int32)
  expired_at: utcDateTime | null;

  /**
   * The timestamp indicating when the batch began cancellation.
   */
  @encode("unixTimestamp", int32)
  cancelling_at: utcDateTime | null;

  /**
   * The timestamp indicating when the batch completed cancellation.
   */
  @encode("unixTimestamp", int32)
  cancelled_at: utcDateTime | null;

  /**
   * The request counts for different statuses within the batch.
   */
  request_counts: {
    /**
     * The total number of requests in the batch.
     */
    total: safeint;

    /**
     * The number of requests that have completed successfully.
     */
    completed: safeint;

    /**
     * The number of requests that have failed.
     */
    failed: safeint;
  };

  /**
   * Set of 16 key-value pairs that can be attached to an object. This can be useful for storing
   * additional information about the object in a structured format. Keys can be a maximum of 64
   * characters long and values can be a maxium of 512 characters long.
   */
  @extension("x-oaiTypeLabel", "map")
  metadata?: Record<string> | null;
}

/**
 * The per-line object in a batch input file.
 */
model BatchRequestInputLine {
  /**
   * A developer-provided, per-request ID that will be used to match inputs to outputs. Must be
   * unique for each request in a batch.
   */
  custom_id: string;

  /**
   * The HTTP method to be used for the request.
   * 
   * Currently, only 'POST' is supported.
   */
  method: string;

  /**
   * The OpenAI API relative URL to be used for the request.
   * 
   * Currently, only '/v1/chat/completions' is supported.
   */
  url: string;
}

/**
 * The per-line object in a batch output file.
 */
model BatchResponseOutputLine {
  /**
   * The system-provided, unique ID of the single batch output.
   */
  id: string;

  /**
   * A developer-provided, per-request ID used to match inputs to outputs.
   */
  custom_id: string;

  /**
   * The JSON body of the response.
   */
  response: null | Record<unknown>;

  error: null | {
    /**
     * A machine-readable error code.
     */
    code: string;

    /**
     * A human-readable error message.
     */
    message: string;
  }
}
