import "@typespec/http";
import "@typespec/openapi";

import "../common";
import "./models.tsp";

using TypeSpec.Http;
using TypeSpec.OpenAPI;

namespace OpenAI;

@route("/fine_tuning")
interface FineTuning {
  @route("jobs")
  @post
  @operationId("createFineTuningJob")
  @tag("Fine-tuning")
  @summary("""
    Creates a fine-tuning job which begins the process of creating a new model from a given dataset.
    
    Response includes details of the enqueued job including job status and the name of the fine-tuned models once complete.
    
    [Learn more about fine-tuning](/docs/guides/fine-tuning)
    """)
  createFineTuningJob(
    @header accept: "application/json",

    @body requestBody: CreateFineTuningJobRequest,
  ): FineTuningJob | ErrorResponse;

  @route("jobs")
  @get
  @operationId("listPaginatedFineTuningJobs")
  @tag("Fine-tuning")
  @summary("List your organization's fine-tuning jobs")
  listPaginatedFineTuningJobs(
    @header accept: "application/json",

    /** Identifier for the last job from the previous pagination request. */
    @query after?: string,

    /** Number of fine-tuning jobs to retrieve. */
    @query limit?: int32 = 20,
  ): ListPaginatedFineTuningJobsResponse | ErrorResponse;

  @route("jobs/{fine_tuning_job_id}")
  @get
  @operationId("retrieveFineTuningJob")
  @tag("Fine-tuning")
  @summary("""
    Get info about a fine-tuning job.
    
    [Learn more about fine-tuning](/docs/guides/fine-tuning)
    """)
  retrieveFineTuningJob(
    @header accept: "application/json",

    /** The ID of the fine-tuning job. */
    @path fine_tuning_job_id: string,
  ): FineTuningJob | ErrorResponse;

  @route("jobs/{fine_tuning_job_id}/cancel")
  @post
  @operationId("cancelFineTuningJob")
  @tag("Fine-tuning")
  @summary("Immediately cancel a fine-tune job.")
  cancelFineTuningJob(
    @header accept: "application/json",

    /** The ID of the fine-tuning job to cancel. */
    @path fine_tuning_job_id: string,
  ): FineTuningJob | ErrorResponse;

  @route("jobs/{fine_tuning_job_id}/checkpoints")
  @get
  @operationId("listFineTuningJobCheckpoints")
  @tag("Fine-tuning")
  @summary("List the checkpoints for a fine-tuning job.")
  listFineTuningJobCheckpoints(
    @header accept: "application/json",

    /** The ID of the fine-tuning job to get checkpoints for. */
    @path fine_tuning_job_id: string,

    /** Identifier for the last checkpoint ID from the previous pagination request. */
    @query after?: string,

    /** Number of checkpoints to retrieve. */
    @query limit?: int32 = 10,
  ): ListFineTuningJobCheckpointsResponse | ErrorResponse;

  @route("jobs/{fine_tuning_job_id}/events")
  @get
  @operationId("listFineTuningEvents")
  @tag("Fine-tuning")
  @summary("Get status updates for a fine-tuning job.")
  listFineTuningEvents(
    @header accept: "application/json",
    
    /** The ID of the fine-tuning job to get events for. */
    @path fine_tuning_job_id: string,

    /** Identifier for the last event from the previous pagination request. */
    @query after?: string,

    /** Number of events to retrieve. */
    @query limit?: int32 = 20,
  ): ListFineTuningJobEventsResponse | ErrorResponse;
}
