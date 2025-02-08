import "@typespec/http";
import "@typespec/openapi";

import "../common";
import "./custom.tsp";
import "./models.tsp";

using TypeSpec.Http;
using TypeSpec.OpenAPI;

namespace OpenAI;

@route("/vector_stores")
interface VectorStores {
  @get
  @operationId("listVectorStores")
  @tag("Vector Stores")
  @summary("Returns a list of vector-stores.")
  listVectorStores(
    ...AcceptJsonHeader,
    ...AssistantsBetaHeader,
    ...CommonPageQueryParameters,
  ): ListVectorStoresResponse | ErrorResponse;

  @post
  @operationId("createVectorStore")
  @tag("Vector Stores")
  @summary("Creates a vector store.")
  createVectorStore(
    ...AcceptJsonHeader,
    ...AssistantsBetaHeader,
    @body requestBody: CreateVectorStoreRequest,
  ): VectorStoreObject | ErrorResponse;

  @route("{vector_store_id}")
  @get
  @operationId("getVectorStore")
  @tag("Vector Stores")
  @summary("Retrieves a vector store.")
  getVectorStore(
    ...AcceptJsonHeader,
    ...AssistantsBetaHeader,

    /** The ID of the vector store to retrieve. */
    @path vector_store_id: string,
  ): VectorStoreObject | ErrorResponse;

  @route("{vector_store_id}")
  @post
  @operationId("modifyVectorStore")
  @tag("Vector Stores")
  @summary("Modifies a vector store.")
  modifyVectorStore(
    ...AcceptJsonHeader,
    ...AssistantsBetaHeader,

    /** The ID of the vector store to modify. */
    @path vector_store_id: string,

    @body requestBody: UpdateVectorStoreRequest,
  ): VectorStoreObject | ErrorResponse;

  @route("{vector_store_id}")
  @delete
  @operationId("deleteVectorStore")
  @tag("Vector Stores")
  @summary("Delete a vector store.")
  deleteVectorStore(
    ...AcceptJsonHeader,
    ...AssistantsBetaHeader,

    /** The ID of the vector store to delete. */
    @path vector_store_id: string,
  ): DeleteVectorStoreResponse | ErrorResponse;

  @route("{vector_store_id}/files")
  @get
  @operationId("listVectorStoreFiles")
  @tag("Vector Stores")
  @summary("Returns a list of vector store files.")
  listVectorStoreFiles(
    ...AcceptJsonHeader,
    ...AssistantsBetaHeader,

    /** The ID of the vector store that the files belong to. */
    @path vector_store_id: string,

    ...VectorStoreFilesPageQueryParameters,
  ): ListVectorStoreFilesResponse | ErrorResponse;

  @route("{vector_store_id}/files")
  @post
  @operationId("createVectorStoreFile")
  @tag("Vector Stores")
  @summary("Create a vector store file by attaching a [File](/docs/api-reference/files) to a [vector store](/docs/api-reference/vector-stores/object).")
  createVectorStoreFile(
    ...AcceptJsonHeader,
    ...AssistantsBetaHeader,

    /** The ID of the vector store for which to create a File. */
    @path vector_store_id: string,

    @body requestBody: CreateVectorStoreFileRequest,
  ): VectorStoreFileObject | ErrorResponse;

  @route("{vector_store_id}/files/{file_id}")
  @get
  @operationId("getVectorStoreFile")
  @tag("Vector Stores")
  @summary("Retrieves a vector store file.")
  getVectorStoreFile(
    ...AcceptJsonHeader,
    ...AssistantsBetaHeader,

    /** The ID of the vector store that the file belongs to. */
    @path vector_store_id: string,

    /** The ID of the file being retrieved. */
    @path file_id: string,
  ): VectorStoreFileObject | ErrorResponse;

  @route("{vector_store_id}/files/{file_id}")
  @delete
  @operationId("deleteVectorStoreFile")
  @tag("Vector Stores")
  @summary("Delete a vector store file. This will remove the file from the vector store but the file itself will not be deleted. To delete the file, use the [delete file](/docs/api-reference/files/delete) endpoint.")
  deleteVectorStoreFile(
    ...AcceptJsonHeader,
    ...AssistantsBetaHeader,

    /** The ID of the vector store that the file belongs to. */
    @path vector_store_id: string,

    /** The ID of the file to delete. */
    @path file_id: string,
  ): DeleteVectorStoreFileResponse | ErrorResponse;

  @route("{vector_store_id}/file_batches")
  @post
  @operationId("createVectorStoreFileBatch")
  @tag("Vector Stores")
  @summary("Create a vector store file batch.")
  createVectorStoreFileBatch(
    ...AcceptJsonHeader,
    ...AssistantsBetaHeader,

    /** The ID of the vector store for which to create a file batch. */
    @path vector_store_id: string,

    @body requestBody: CreateVectorStoreFileBatchRequest,
  ): VectorStoreFileBatchObject | ErrorResponse;

  @route("{vector_store_id}/file_batches/{batch_id}")
  @get
  @operationId("getVectorStoreFileBatch")
  @tag("Vector Stores")
  @summary("Retrieves a vector store file batch.")
  getVectorStoreFileBatch(
    ...AcceptJsonHeader,
    ...AssistantsBetaHeader,

    /** The ID of the vector store that the file batch belongs to. */
    @path vector_store_id: string,

    /** The ID of the file batch being retrieved. */
    @path batch_id: string,
  ): VectorStoreFileBatchObject | ErrorResponse;

  @route("{vector_store_id}/file_batches/{batch_id}/cancel")
  @post
  @operationId("cancelVectorStoreFileBatch")
  @tag("Vector Stores")
  @summary("Cancel a vector store file batch. This attempts to cancel the processing of files in this batch as soon as possible.")
  cancelVectorStoreFileBatch(
    ...AcceptJsonHeader,
    ...AssistantsBetaHeader,

    /** The ID of the vector store that the file batch belongs to. */
    @path vector_store_id: string,

    /** The ID of the file batch to cancel. */
    @path batch_id: string,
  ): VectorStoreFileBatchObject | ErrorResponse;

  @route("{vector_store_id}/file_batches/{batch_id}/files")
  @get
  @operationId("listFilesInVectorStoreBatch")
  @tag("Vector Stores")
  @summary("Returns a list of vector store files in a batch.")
  listFilesInVectorStoreBatch(
    ...AcceptJsonHeader,
    ...AssistantsBetaHeader,

    /** The ID of the vector store that the file batch belongs to. */
    @path vector_store_id: string,

    /** The ID of the file batch that the files belong to. */
    @path batch_id: string,

    ...VectorStoreFilesPageQueryParameters,
  ): ListVectorStoreFilesResponse | ErrorResponse;
}

alias VectorStoreFilesPageQueryParameters = {
  ...PageLimitQueryParameter;
  ...PageOrderQueryParameter;
  ...PageAfterQueryParameter;
  ...PageBeforeQueryParameter;

  /**
   * Filter by file status. One of `in_progress`, `completed`, `failed`, `cancelled`.
   */
  @query filter?: ListVectorStoreFilesFilter;
};
