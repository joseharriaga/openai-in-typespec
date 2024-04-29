/*
 * This file was automatically generated from an OpenAPI .yaml file.
 * Edits made directly to this file will be lost.
 */

using TypeSpec.OpenAPI;

namespace OpenAI;

model CreateFileRequest {
  /** The File object (not file name) to be uploaded. */
  file: string;

  /**
   * The intended purpose of the uploaded file.
   *
   * Use "fine-tune" for [Fine-tuning](/docs/api-reference/fine-tuning) and "assistants" for
   * [Assistants](/docs/api-reference/assistants) and [Messages](/docs/api-reference/messages).
   * This allows us to validate the format of the uploaded file is correct for fine-tuning.
   */
  purpose: "fine-tune" | "assistants";
}

model ListFilesResponse {
  data: OpenAIFile[];
  object: "list";
}

model DeleteFileResponse {
  id: string;
  object: "file";
  deleted: boolean;
}

/** The `File` object represents a document that has been uploaded to OpenAI. */
model OpenAIFile {
  /** The file identifier, which can be referenced in the API endpoints. */
  id: string;

  /** The size of the file, in bytes. */
  @extension(
    "x-customTspIngestionRule",
    "file response values can have null byte counts"
  )
  bytes: int32 | null;

  /** The Unix timestamp (in seconds) for when the file was created. */
  @encode("unixTimestamp", int32)
  @extension(
    "x-customTspIngestionRule",
    "_at and created are Unix encoded utcDateTime"
  )
  created_at: utcDateTime;

  /** The name of the file. */
  filename: string;

  /** The object type, which is always `file`. */
  object: "file";

  /**
   * The intended purpose of the file. Supported values are `fine-tune`, `fine-tune-results`,
   * `assistants`, and `assistants_output`.
   */
  purpose:
    | "fine-tune"
    | "fine-tune-results"
    | "assistants"
    | "assistants_output";

  /**
   * Deprecated. The current status of the file, which can be either `uploaded`, `processed`, or
   * `error`.
   */
  status: "uploaded" | "processed" | "error";

  /**
   * Deprecated. For details on why a fine-tuning training file failed validation, see the `error`
   * field on `fine_tuning.job`.
   */
  status_details?: string;
}
