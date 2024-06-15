import "./models.tsp";
import "./operations.tsp";

using TypeSpec.OpenAPI;

namespace OpenAI;

@@extension(OpenAI.VectorStores.listVectorStores,
  "x-oaiMeta",
  """
    name: List vector stores
    group: vector_stores
    beta: true
    returns: A list of [vector store](/docs/api-reference/vector-stores/object) objects.
    examples:
      request:
        curl: |
          curl https://api.openai.com/v1/vector_stores \\
            -H "Authorization: Bearer $OPENAI_API_KEY" \\
            -H "Content-Type: application/json" \\
            -H "OpenAI-Beta: assistants=v2"
        python: |
          from openai import OpenAI
          client = OpenAI()

          vector_stores = client.beta.vector_stores.list()
          print(vector_stores)
        node.js: |
          import OpenAI from "openai";
          const openai = new OpenAI();

          async function main() {
            const vectorStores = await openai.beta.vectorStores.list();
            console.log(vectorStores);
          }

          main();
      response: |
        {
          "object": "list",
          "data": [
            {
              "id": "vs_abc123",
              "object": "vector_store",
              "created_at": 1699061776,
              "name": "Support FAQ",
              "bytes": 139920,
              "file_counts": {
                "in_progress": 0,
                "completed": 3,
                "failed": 0,
                "cancelled": 0,
                "total": 3
              }
            },
            {
              "id": "vs_abc456",
              "object": "vector_store",
              "created_at": 1699061776,
              "name": "Support FAQ v2",
              "bytes": 139920,
              "file_counts": {
                "in_progress": 0,
                "completed": 3,
                "failed": 0,
                "cancelled": 0,
                "total": 3
              }
            }
          ],
          "first_id": "vs_abc123",
          "last_id": "vs_abc456",
          "has_more": false
        }
    """
);

@@extension(OpenAI.VectorStores.createVectorStore,
  "x-oaiMeta",
  """
    name: Create vector store
    group: vector_stores
    beta: true
    returns: A [vector store](/docs/api-reference/vector-stores/object) object.
    examples:
        request:
        curl: |
            curl https://api.openai.com/v1/vector_stores \\
            -H "Authorization: Bearer $OPENAI_API_KEY" \\
            -H "Content-Type: application/json" \\
            -H "OpenAI-Beta: assistants=v2"
            -d '{
                "name": "Support FAQ"
            }'
        python: |
            from openai import OpenAI
            client = OpenAI()

            vector_store = client.beta.vector_stores.create(
            name="Support FAQ"
            )
            print(vector_store)
        node.js: |
            import OpenAI from "openai";
            const openai = new OpenAI();

            async function main() {
            const vectorStore = await openai.beta.vectorStores.create({
                name: "Support FAQ"
            });
            console.log(vectorStore);
            }

            main();
        response: |
        {
            "id": "vs_abc123",
            "object": "vector_store",
            "created_at": 1699061776,
            "name": "Support FAQ",
            "bytes": 139920,
            "file_counts": {
            "in_progress": 0,
            "completed": 3,
            "failed": 0,
            "cancelled": 0,
            "total": 3
            }
        }
    """
);

@@extension(OpenAI.VectorStores.getVectorStore,
  "x-oaiMeta",
  """
    name: Retrieve vector store
    group: vector_stores
    beta: true
    returns: The [vector store](/docs/api-reference/vector-stores/object) object matching the specified ID.
    examples:
        request:
        curl: |
            curl https://api.openai.com/v1/vector_stores/vs_abc123 \\
            -H "Authorization: Bearer $OPENAI_API_KEY" \\
            -H "Content-Type: application/json" \\
            -H "OpenAI-Beta: assistants=v2"
        python: |
            from openai import OpenAI
            client = OpenAI()

            vector_store = client.beta.vector_stores.retrieve(
            vector_store_id="vs_abc123"
            )
            print(vector_store)
        node.js: |
            import OpenAI from "openai";
            const openai = new OpenAI();

            async function main() {
            const vectorStore = await openai.beta.vectorStores.retrieve(
                "vs_abc123"
            );
            console.log(vectorStore);
            }

            main();
        response: |
        {
            "id": "vs_abc123",
            "object": "vector_store",
            "created_at": 1699061776
        }
    """
);

@@extension(OpenAI.VectorStores.modifyVectorStore,
  "x-oaiMeta",
  """
    name: Modify vector store
    group: vector_stores
    beta: true
    returns: The modified [vector store](/docs/api-reference/vector-stores/object) object.
    examples:
      request:
        curl: |
          curl https://api.openai.com/v1/vector_stores/vs_abc123 \\
            -H "Authorization: Bearer $OPENAI_API_KEY" \\
            -H "Content-Type: application/json" \\
            -H "OpenAI-Beta: assistants=v2"
            -d '{
              "name": "Support FAQ"
            }'
        python: |
          from openai import OpenAI
          client = OpenAI()

          vector_store = client.beta.vector_stores.update(
            vector_store_id="vs_abc123",
            name="Support FAQ"
          )
          print(vector_store)
        node.js: |
          import OpenAI from "openai";
          const openai = new OpenAI();

          async function main() {
            const vectorStore = await openai.beta.vectorStores.update(
              "vs_abc123",
              {
                name: "Support FAQ"
              }
            );
            console.log(vectorStore);
          }

          main();
      response: |
        {
          "id": "vs_abc123",
          "object": "vector_store",
          "created_at": 1699061776,
          "name": "Support FAQ",
          "bytes": 139920,
          "file_counts": {
            "in_progress": 0,
            "completed": 3,
            "failed": 0,
            "cancelled": 0,
            "total": 3
          }
        }
    """
);

@@extension(OpenAI.VectorStores.deleteVectorStore,
  "x-oaiMeta",
  """
    name: Delete vector store
    group: vector_stores
    beta: true
    returns: Deletion status
    examples:
      request:
        curl: |
          curl https://api.openai.com/v1/vector_stores/vs_abc123 \\
            -H "Authorization: Bearer $OPENAI_API_KEY" \\
            -H "Content-Type: application/json" \\
            -H "OpenAI-Beta: assistants=v2" \\
            -X DELETE
        python: |
          from openai import OpenAI
          client = OpenAI()

          deleted_vector_store = client.beta.vector_stores.delete(
            vector_store_id="vs_abc123"
          )
          print(deleted_vector_store)
        node.js: |
          import OpenAI from "openai";
          const openai = new OpenAI();

          async function main() {
            const deletedVectorStore = await openai.beta.vectorStores.del(
              "vs_abc123"
            );
            console.log(deletedVectorStore);
          }

          main();
      response: |
        {
          id: "vs_abc123",
          object: "vector_store.deleted",
          deleted: true
        }
    """
);

@@extension(OpenAI.VectorStores.listVectorStoreFiles,
  "x-oaiMeta",
  """
    name: List vector store files
    group: vector_stores
    beta: true
    returns: A list of [vector store file](/docs/api-reference/vector-stores-files/file-object) objects.
    examples:
      request:
        curl: |
          curl https://api.openai.com/v1/vector_stores/vs_abc123/files \\
            -H "Authorization: Bearer $OPENAI_API_KEY" \\
            -H "Content-Type: application/json" \\
            -H "OpenAI-Beta: assistants=v2"
        python: |
          from openai import OpenAI
          client = OpenAI()

          vector_store_files = client.beta.vector_stores.files.list(
            vector_store_id="vs_abc123"
          )
          print(vector_store_files)
        node.js: |
          import OpenAI from "openai";
          const openai = new OpenAI();

          async function main() {
            const vectorStoreFiles = await openai.beta.vectorStores.files.list(
              "vs_abc123"
            );
            console.log(vectorStoreFiles);
          }

          main();
      response: |
        {
          "object": "list",
          "data": [
            {
              "id": "file-abc123",
              "object": "vector_store.file",
              "created_at": 1699061776,
              "vector_store_id": "vs_abc123"
            },
            {
              "id": "file-abc456",
              "object": "vector_store.file",
              "created_at": 1699061776,
              "vector_store_id": "vs_abc123"
            }
          ],
          "first_id": "file-abc123",
          "last_id": "file-abc456",
          "has_more": false
        }
"""
);

@@extension(OpenAI.VectorStores.createVectorStoreFile,
  "x-oaiMeta",
  """
  name: Create vector store file
  group: vector_stores
  beta: true
  returns: A [vector store file](/docs/api-reference/vector-stores-files/file-object) object.
  examples:
    request:
      curl: |
        curl https://api.openai.com/v1/vector_stores/vs_abc123/files \\
            -H "Authorization: Bearer $OPENAI_API_KEY" \\
            -H "Content-Type: application/json" \\
            -H "OpenAI-Beta: assistants=v2" \\
            -d '{
              "file_id": "file-abc123"
            }'
      python: |
        from openai import OpenAI
        client = OpenAI()

        vector_store_file = client.beta.vector_stores.files.create(
          vector_store_id="vs_abc123",
          file_id="file-abc123"
        )
        print(vector_store_file)
      node.js: |
        import OpenAI from "openai";
        const openai = new OpenAI();

        async function main() {
          const myVectorStoreFile = await openai.beta.vectorStores.files.create(
            "vs_abc123",
            {
              file_id: "file-abc123"
            }
          );
          console.log(myVectorStoreFile);
        }

        main();
    response: |
      {
        "id": "file-abc123",
        "object": "vector_store.file",
        "created_at": 1699061776,
        "usage_bytes": 1234,
        "vector_store_id": "vs_abcd",
        "status": "completed",
        "last_error": null
      }
"""
);

@@extension(OpenAI.VectorStores.getVectorStoreFile,
  "x-oaiMeta",
  """
  name: Retrieve vector store file
  group: vector_stores
  beta: true
  returns: The [vector store file](/docs/api-reference/vector-stores-files/file-object) object.
  examples:
    request:
      curl: |
        curl https://api.openai.com/v1/vector_stores/vs_abc123/files/file-abc123 \\
          -H "Authorization: Bearer $OPENAI_API_KEY" \\
          -H "Content-Type: application/json" \\
          -H "OpenAI-Beta: assistants=v2"
      python: |
        from openai import OpenAI
        client = OpenAI()

        vector_store_file = client.beta.vector_stores.files.retrieve(
          vector_store_id="vs_abc123",
          file_id="file-abc123"
        )
        print(vector_store_file)
      node.js: |
        import OpenAI from "openai";
        const openai = new OpenAI();

        async function main() {
          const vectorStoreFile = await openai.beta.vectorStores.files.retrieve(
            "vs_abc123",
            "file-abc123"
          );
          console.log(vectorStoreFile);
        }

        main();
    response: |
      {
        "id": "file-abc123",
        "object": "vector_store.file",
        "created_at": 1699061776,
        "vector_store_id": "vs_abcd",
        "status": "completed",
        "last_error": null
      }
"""
);

@@extension(OpenAI.VectorStores.deleteVectorStoreFile,
  "x-oaiMeta",
  """
  name: Delete vector store file
  group: vector_stores
  beta: true
  returns: Deletion status
  examples:
    request:
      curl: |
        curl https://api.openai.com/v1/vector_stores/vs_abc123/files/file-abc123 \\
          -H "Authorization: Bearer $OPENAI_API_KEY" \\
          -H "Content-Type: application/json" \\
          -H "OpenAI-Beta: assistants=v2" \\
          -X DELETE
      python: |
        from openai import OpenAI
        client = OpenAI()

        deleted_vector_store_file = client.beta.vector_stores.files.delete(
            vector_store_id="vs_abc123",
            file_id="file-abc123"
        )
        print(deleted_vector_store_file)
      node.js: |
        import OpenAI from "openai";
        const openai = new OpenAI();

        async function main() {
          const deletedVectorStoreFile = await openai.beta.vectorStores.files.del(
            "vs_abc123",
            "file-abc123"
          );
          console.log(deletedVectorStoreFile);
        }

        main();
    response: |
      {
        id: "file-abc123",
        object: "vector_store.file.deleted",
        deleted: true
      }
"""
);

@@extension(OpenAI.VectorStores.createVectorStoreFileBatch,
  "x-oaiMeta",
  """
  name: Create vector store file batch
  group: vector_stores
  beta: true
  returns: A [vector store file batch](/docs/api-reference/vector-stores-file-batches/batch-object) object.
  examples:
    request:
      curl: |
        curl https://api.openai.com/v1/vector_stores/vs_abc123/file_batches \\
            -H "Authorization: Bearer $OPENAI_API_KEY" \\
            -H "Content-Type: application/json \\
            -H "OpenAI-Beta: assistants=v2" \\
            -d '{
              "file_ids": ["file-abc123", "file-abc456"]
            }'
      python: |
        from openai import OpenAI
        client = OpenAI()

        vector_store_file_batch = client.beta.vector_stores.file_batches.create(
          vector_store_id="vs_abc123",
          file_ids=["file-abc123", "file-abc456"]
        )
        print(vector_store_file_batch)
      node.js: |
        import OpenAI from "openai";
        const openai = new OpenAI();

        async function main() {
          const myVectorStoreFileBatch = await openai.beta.vectorStores.fileBatches.create(
            "vs_abc123",
            {
              file_ids: ["file-abc123", "file-abc456"]
            }
          );
          console.log(myVectorStoreFileBatch);
        }

        main();
    response: |
      {
        "id": "vsfb_abc123",
        "object": "vector_store.file_batch",
        "created_at": 1699061776,
        "vector_store_id": "vs_abc123",
        "status": "in_progress",
        "file_counts": {
          "in_progress": 1,
          "completed": 1,
          "failed": 0,
          "cancelled": 0,
          "total": 0,
        }
      }
"""
);

@@extension(OpenAI.VectorStores.getVectorStoreFileBatch,
  "x-oaiMeta",
  """
  name: Retrieve vector store file batch
  group: vector_stores
  beta: true
  returns: The [vector store file batch](/docs/api-reference/vector-stores-file-batches/batch-object) object.
  examples:
    request:
      curl: |
        curl https://api.openai.com/v1/vector_stores/vs_abc123/files_batches/vsfb_abc123 \\
          -H "Authorization: Bearer $OPENAI_API_KEY" \\
          -H "Content-Type: application/json" \\
          -H "OpenAI-Beta: assistants=v2"
      python: |
        from openai import OpenAI
        client = OpenAI()

        vector_store_file_batch = client.beta.vector_stores.file_batches.retrieve(
          vector_store_id="vs_abc123",
          batch_id="vsfb_abc123"
        )
        print(vector_store_file_batch)
      node.js: |
        import OpenAI from "openai";
        const openai = new OpenAI();

        async function main() {
          const vectorStoreFileBatch = await openai.beta.vectorStores.fileBatches.retrieve(
            "vs_abc123",
            "vsfb_abc123"
          );
          console.log(vectorStoreFileBatch);
        }

        main();
    response: |
      {
        "id": "vsfb_abc123",
        "object": "vector_store.file_batch",
        "created_at": 1699061776,
        "vector_store_id": "vs_abc123",
        "status": "in_progress",
        "file_counts": {
          "in_progress": 1,
          "completed": 1,
          "failed": 0,
          "cancelled": 0,
          "total": 0,
        }
      }
"""
);

@@extension(OpenAI.VectorStores.cancelVectorStoreFileBatch,
  "x-oaiMeta",
  """
  name: Cancel vector store file batch
  group: vector_stores
  beta: true
  returns: The modified vector store file batch object.
  examples:
    request:
      curl: |
        curl https://api.openai.com/v1/vector_stores/vs_abc123/files_batches/vsfb_abc123/cancel \\
          -H "Authorization: Bearer $OPENAI_API_KEY" \\
          -H "Content-Type: application/json" \\
          -H "OpenAI-Beta: assistants=v2" \\
          -X POST
      python: |
        from openai import OpenAI
        client = OpenAI()

        deleted_vector_store_file_batch = client.beta.vector_stores.file_batches.cancel(
            vector_store_id="vs_abc123",
            file_batch_id="vsfb_abc123"
        )
        print(deleted_vector_store_file_batch)
      node.js: |
        import OpenAI from "openai";
        const openai = new OpenAI();

        async function main() {
          const deletedVectorStoreFileBatch = await openai.vector_stores.fileBatches.cancel(
            "vs_abc123",
            "vsfb_abc123"
          );
          console.log(deletedVectorStoreFileBatch);
        }

        main();
    response: |
      {
        "id": "vsfb_abc123",
        "object": "vector_store.file_batch",
        "created_at": 1699061776,
        "vector_store_id": "vs_abc123",
        "status": "cancelling",
        "file_counts": {
          "in_progress": 12,
          "completed": 3,
          "failed": 0,
          "cancelled": 0,
          "total": 15,
        }
      }
  """
);

@@extension(OpenAI.VectorStores.listFilesInVectorStoreBatch,
  "x-oaiMeta",
  """
  name: List vector store files in a batch
  group: vector_stores
  beta: true
  returns: A list of [vector store file](/docs/api-reference/vector-stores-files/file-object) objects.
  examples:
    request:
      curl: |
        curl https://api.openai.com/v1/vector_stores/vs_abc123/files_batches/vsfb_abc123/files \\
          -H "Authorization: Bearer $OPENAI_API_KEY" \\
          -H "Content-Type: application/json" \\
          -H "OpenAI-Beta: assistants=v2"
      python: |
        from openai import OpenAI
        client = OpenAI()

        vector_store_files = client.beta.vector_stores.file_batches.list_files(
          vector_store_id="vs_abc123",
          batch_id="vsfb_abc123"
        )
        print(vector_store_files)
      node.js: |
        import OpenAI from "openai";
        const openai = new OpenAI();

        async function main() {
          const vectorStoreFiles = await openai.beta.vectorStores.fileBatches.listFiles(
            "vs_abc123",
            "vsfb_abc123"
          );
          console.log(vectorStoreFiles);
        }

        main();
    response: |
      {
        "object": "list",
        "data": [
          {
            "id": "file-abc123",
            "object": "vector_store.file",
            "created_at": 1699061776,
            "vector_store_id": "vs_abc123"
          },
          {
            "id": "file-abc456",
            "object": "vector_store.file",
            "created_at": 1699061776,
            "vector_store_id": "vs_abc123"
          }
        ],
        "first_id": "file-abc123",
        "last_id": "file-abc456",
        "has_more": false
      }
  """
);
