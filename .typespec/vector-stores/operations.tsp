import "@typespec/http";
import "@typespec/openapi";

import "../common";
import "./custom.tsp";
import "./models.tsp";

using TypeSpec.Http;
using TypeSpec.OpenAPI;

namespace OpenAI;

@route("vector_stores")
interface VectorStores {
  @get
  @operationId("listVectorStores")
  @tag("Vector Stores")
  @summary("Returns a list of vector-stores.")
  listVectorStores(
    /**
     * A limit on the number of objects to be returned. Limit can range between 1 and 100, and the
     * default is 20.
     */
    @query limit?: int32 = 20,

    /**
     * Sort order by the `created_at` timestamp of the objects. `asc` for ascending order and`desc`
     * for descending order.
     */
    @query order?: ListOrder = ListOrder.desc,

    /**
     * A cursor for use in pagination. `after` is an object ID that defines your place in the list.
     * For instance, if you make a list request and receive 100 objects, ending with obj_foo, your
     * subsequent call can include after=obj_foo in order to fetch the next page of the list.
     */
    @query after?: string,

    /**
     * A cursor for use in pagination. `before` is an object ID that defines your place in the list.
     * For instance, if you make a list request and receive 100 objects, ending with obj_foo, your
     * subsequent call can include before=obj_foo in order to fetch the previous page of the list.
     */
    @query before?: string,
  ): ListVectorStoresResponse | ErrorResponse;

  @post
  @operationId("createVectorStore")
  @tag("Vector Stores")
  @summary("Creates a vector store.")
  createVectorStore(
    @body requestBody: CreateVectorStoreRequest,
  ): VectorStoreObject | ErrorResponse;

  @route("{vector_store_id}")
  @get
  @operationId("getVectorStore")
  @tag("Vector Stores")
  @summary("Retrieves a vector store.")
  getVectorStore(
    /** The ID of the vector store to retrieve. */
    @path vector_store_id: string,
  ): VectorStoreObject | ErrorResponse;

  @route("{vector_store_id}")
  @post
  @operationId("modifyVectorStore")
  @tag("Vector Stores")
  @summary("Modifies a vector store.")
  modifyVectorStore(
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
    /** The ID of the vector store to delete. */
    @path vector_store_id: string,
  ): DeleteVectorStoreResponse | ErrorResponse;

  @route("{vector_store_id}/files")
  @get
  @operationId("listVectorStoreFiles")
  @tag("Vector Stores")
  @summary("Returns a list of vector store files.")
  listVectorStoreFiles(
    /** The ID of the vector store that the files belong to. */
    @path vector_store_id: string,

    /**
     * A limit on the number of objects to be returned. Limit can range between 1 and 100, and the
     * default is 20.
     */
    @query limit?: int32 = 20,

    /**
     * Sort order by the `created_at` timestamp of the objects. `asc` for ascending order and`desc`
     * for descending order.
     */
    @query order?: ListOrder = ListOrder.desc,

    /**
     * A cursor for use in pagination. `after` is an object ID that defines your place in the list.
     * For instance, if you make a list request and receive 100 objects, ending with obj_foo, your
     * subsequent call can include after=obj_foo in order to fetch the next page of the list.
     */
    @query after?: string,

    /**
     * A cursor for use in pagination. `before` is an object ID that defines your place in the list.
     * For instance, if you make a list request and receive 100 objects, ending with obj_foo, your
     * subsequent call can include before=obj_foo in order to fetch the previous page of the list.
     */
    @query before?: string,

    /**
     * Filter by file status. One of `in_progress`, `completed`, `failed`, `cancelled`.
     */
    @query filter?: ListVectorStoreFilesFilter,
  ): ListVectorStoreFilesResponse | ErrorResponse;

  @route("{vector_store_id}/files")
  @post
  @operationId("createVectorStoreFile")
  @tag("Vector Stores")
  @summary("Create a vector store file by attaching a [File](/docs/api-reference/files) to a [vector store](/docs/api-reference/vector-stores/object).")
  createVectorStoreFile(
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
    /** The ID of the vector store that the file batch belongs to. */
    @path vector_store_id: string,

    /** The ID of the file batch that the files belong to. */
    @path batch_id: string,

    /**
     * A limit on the number of objects to be returned. Limit can range between 1 and 100, and the
     * default is 20.
     */
    @query limit?: int32 = 20,

    /**
     * Sort order by the `created_at` timestamp of the objects. `asc` for ascending order and`desc`
     * for descending order.
     */
    @query order?: ListOrder = ListOrder.desc,

    /**
     * A cursor for use in pagination. `after` is an object ID that defines your place in the list.
     * For instance, if you make a list request and receive 100 objects, ending with obj_foo, your
     * subsequent call can include after=obj_foo in order to fetch the next page of the list.
     */
    @query after?: string,

    /**
     * A cursor for use in pagination. `before` is an object ID that defines your place in the list.
     * For instance, if you make a list request and receive 100 objects, ending with obj_foo, your
     * subsequent call can include before=obj_foo in order to fetch the previous page of the list.
     */
    @query before?: string,

    /**
     * Filter by file status. One of `in_progress`, `completed`, `failed`, `cancelled`.
     */
    @query filter?: ListVectorStoreFilesFilter,
  ): ListVectorStoreFilesResponse | ErrorResponse;
}
