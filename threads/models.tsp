/*
 * This file was automatically generated from an OpenAPI .yaml file.
 * Edits made directly to this file will be lost.
 */

import "../messages";

using TypeSpec.OpenAPI;

namespace OpenAI;

model CreateThreadRequest {
  /** A list of [messages](/docs/api-reference/messages) to start the thread with. */
  messages?: CreateMessageRequest[];

  @doc("""
  A set of resources that are made available to the assistant's tools in this thread. The resources are specific to the type of tool. For example, the `code_interpreter` tool requires a list of file IDs, while the `file_search` tool requires a list of vector store IDs.

""")
  tool_resources?: {
    code_interpreter?: {
      @doc("""
      A list of [file](/docs/api-reference/files) IDs made available to the `code_interpreter` tool. There can be a maximum of 20 files associated with the tool.

""")
      @maxItems(20)
      file_ids?: string[] = [];
    };
    file_search?: {
      /**
       * The [vector store](/docs/api-reference/vector-stores/object) attached to this thread.
       * There can be a maximum of 1 vector store attached to the thread.
       */
      @maxItems(1)
      vector_store_ids?: string[];

      /**
       * A helper to create a [vector store](/docs/api-reference/vector-stores/object) with
       * file_ids and attach it to this thread. There can be a maximum of 1 vector store attached
       * to the thread.
       */
      @maxItems(1)
      vector_stores?: {
        /**
         * A list of [file](/docs/api-reference/files) IDs to add to the vector store. There can be
         * a maximum of 10000 files in a vector store.
         */
        @maxItems(10000)
        file_ids?: string[];

        /**
         * Set of 16 key-value pairs that can be attached to a vector store. This can be useful for
         * storing additional information about the vector store in a structured format. Keys can
         * be a maximum of 64 characters long and values can be a maxium of 512 characters long.
         */
        @extension("x-oaiTypeLabel", "map")
        metadata?: Record<string>;
      }[];
    };
  } | null;

  /**
   * Set of 16 key-value pairs that can be attached to an object. This can be useful for storing
   * additional information about the object in a structured format. Keys can be a maximum of 64
   * characters long and values can be a maxium of 512 characters long.
   */
  @extension("x-oaiTypeLabel", "map")
  metadata?: Record<string> | null;
}

model ModifyThreadRequest {
  @doc("""
  A set of resources that are made available to the assistant's tools in this thread. The resources are specific to the type of tool. For example, the `code_interpreter` tool requires a list of file IDs, while the `file_search` tool requires a list of vector store IDs.

""")
  tool_resources?: {
    code_interpreter?: {
      @doc("""
      A list of [file](/docs/api-reference/files) IDs made available to the `code_interpreter` tool. There can be a maximum of 20 files associated with the tool.

""")
      @maxItems(20)
      file_ids?: string[] = [];
    };
    file_search?: {
      /**
       * The [vector store](/docs/api-reference/vector-stores/object) attached to this thread.
       * There can be a maximum of 1 vector store attached to the thread.
       */
      @maxItems(1)
      vector_store_ids?: string[];
    };
  } | null;

  /**
   * Set of 16 key-value pairs that can be attached to an object. This can be useful for storing
   * additional information about the object in a structured format. Keys can be a maximum of 64
   * characters long and values can be a maxium of 512 characters long.
   */
  @extension("x-oaiTypeLabel", "map")
  metadata?: Record<string> | null;
}

model DeleteThreadResponse {
  id: string;
  deleted: boolean;
  object: "thread.deleted";
}

/** Represents a thread that contains [messages](/docs/api-reference/messages). */
model ThreadObject {
  /** The identifier, which can be referenced in API endpoints. */
  id: string;

  @doc("""
  The object type, which is always `thread`.
""")
  object: "thread";

  /** The Unix timestamp (in seconds) for when the thread was created. */
  @encode("unixTimestamp", int32)
  @extension(
    "x-customTspIngestionRule",
    "_at and created are Unix encoded utcDateTime"
  )
  created_at: utcDateTime;

  @doc("""
  A set of resources that are made available to the assistant's tools in this thread. The resources are specific to the type of tool. For example, the `code_interpreter` tool requires a list of file IDs, while the `file_search` tool requires a list of vector store IDs.

""")
  tool_resources: {
    code_interpreter?: {
      @doc("""
      A list of [file](/docs/api-reference/files) IDs made available to the `code_interpreter` tool. There can be a maximum of 20 files associated with the tool.

""")
      @maxItems(20)
      file_ids?: string[] = [];
    };
    file_search?: {
      /**
       * The [vector store](/docs/api-reference/vector-stores/object) attached to this thread.
       * There can be a maximum of 1 vector store attached to the thread.
       */
      @maxItems(1)
      vector_store_ids?: string[];
    };
  } | null;

  /**
   * Set of 16 key-value pairs that can be attached to an object. This can be useful for storing
   * additional information about the object in a structured format. Keys can be a maximum of 64
   * characters long and values can be a maxium of 512 characters long.
   */
  @extension("x-oaiTypeLabel", "map")
  metadata: Record<string> | null;
}

model ListThreadsResponse {
  object: string;
  data: ThreadObject[];
  first_id: string;
  last_id: string;
  has_more: boolean;
}
