/*
 * This file was automatically generated from an OpenAPI .yaml file.
 * Edits made directly to this file will be lost.
 */

using TypeSpec.OpenAPI;

namespace OpenAI;

model CreateFileRequest {
  // Tool customization: binary payloads are encoded bytes
  /** The File object (not file name) to be uploaded. */
  @encode("binary")
  file: bytes;

  /**
   * The intended purpose of the uploaded file.
   *
   * Use "assistants" for [Assistants](/docs/api-reference/assistants) and [Message](/docs/api-reference/messages) files, "vision" for Assistants image file inputs, "batch" for [Batch API](/docs/guides/batch), and "fine-tune" for [Fine-tuning](/docs/api-reference/fine-tuning).
   */
  purpose: "assistants" | "batch" | "fine-tune" | "vision";
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

@doc("""
The `File` object represents a document that has been uploaded to OpenAI.
""")
model OpenAIFile {
  /** The file identifier, which can be referenced in the API endpoints. */
  id: string;

  // Tool customization: file response values can have null byte counts
  /** The size of the file, in bytes. */
  bytes: int32 | null;

  // Tool customization: 'created' and fields ending in '_at' are Unix encoded utcDateTime
  /** The Unix timestamp (in seconds) for when the file was created. */
  @encode("unixTimestamp", int32)
  created_at: utcDateTime;

  /** The name of the file. */
  filename: string;

  @doc("""
  The object type, which is always `file`.
  """)
  object: "file";

  @doc("""
  The intended purpose of the file. Supported values are `assistants`, `assistants_output`, `batch`, `batch_output`, `fine-tune`, `fine-tune-results` and `vision`.
  """)
  purpose:
    | "assistants"
    | "assistants_output"
    | "batch"
    | "batch_output"
    | "fine-tune"
    | "fine-tune-results"
    | "vision";

  #deprecated "This field is marked as deprecated."
  @doc("""
  Deprecated. The current status of the file, which can be either `uploaded`, `processed`, or `error`.
  """)
  status: "uploaded" | "processed" | "error";

  #deprecated "This field is marked as deprecated."
  @doc("""
  Deprecated. For details on why a fine-tuning training file failed validation, see the `error` field on `fine_tuning.job`.
  """)
  status_details?: string;
}
