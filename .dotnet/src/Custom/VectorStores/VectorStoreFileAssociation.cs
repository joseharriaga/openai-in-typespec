using System;
using System.Collections.Generic;

namespace OpenAI.VectorStores;

/// <summary>
/// A representation of a file association between an uploaded file and a vector store.
/// </summary>
[CodeGenModel("VectorStoreFileObject")]
public partial class VectorStoreFileAssociation
{
    private readonly object Object;
    private readonly IDictionary<string, BinaryData> _serializedAdditionalRawData;

    /// <summary>
    /// The ID of the file that is associated with the vector store.
    /// </summary>
    [CodeGenMember("Id")]
    public string FileId { get; }

    /// <summary>
    /// The total count of bytes used for vector storage of the file. Note that this may differ from the size of the
    /// file.
    /// </summary>
    [CodeGenMember("UsageBytes")]
    public int Size { get; }

    [CodeGenMember("CreatedAt")]
    public DateTimeOffset CreatedAt { get; }

    /// <summary> The ID of the [vector store](/docs/api-reference/vector-stores/object) that the [File](/docs/api-reference/files) is attached to. </summary>
    public string VectorStoreId { get; }

    /// <summary>
    /// The status of the vector store file, which can be either `in_progress`, `completed`, `cancelled`, or `failed`. The status `completed` indicates that the vector store file is ready for use.
    /// </summary>
    [CodeGenMember("Status")]
    public VectorStoreFileAssociationStatus Status { get; }
    
    /// <summary> The last error associated with this vector store file. Will be `null` if there are no errors. </summary>
    public VectorStoreFileAssociationError? LastError { get; }

    /// <summary> Initializes a new instance of <see cref="VectorStoreFileAssociation"/>. </summary>
    /// <param name="fileId"> The identifier, which can be referenced in API endpoints. </param>
    /// <param name="size"> The total vector store usage in bytes. Note that this may be different from the original file size. </param>
    /// <param name="createdAt"> The Unix timestamp (in seconds) for when the vector store file was created. </param>
    /// <param name="vectorStoreId"> The ID of the [vector store](/docs/api-reference/vector-stores/object) that the [File](/docs/api-reference/files) is attached to. </param>
    /// <param name="status"> The status of the vector store file, which can be either `in_progress`, `completed`, `cancelled`, or `failed`. The status `completed` indicates that the vector store file is ready for use. </param>
    /// <param name="lastError"> The last error associated with this vector store file. Will be `null` if there are no errors. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="fileId"/> or <paramref name="vectorStoreId"/> is null. </exception>
    internal VectorStoreFileAssociation(string fileId, int size, DateTimeOffset createdAt, string vectorStoreId, VectorStoreFileAssociationStatus status, VectorStoreFileAssociationError? lastError)
    {
        Argument.AssertNotNull(fileId, nameof(fileId));
        Argument.AssertNotNull(vectorStoreId, nameof(vectorStoreId));

        FileId = fileId;
        Size = size;
        CreatedAt = createdAt;
        VectorStoreId = vectorStoreId;
        Status = status;
        LastError = lastError;
    }

    /// <summary> Initializes a new instance of <see cref="VectorStoreFileAssociation"/>. </summary>
    /// <param name="fileId"> The identifier, which can be referenced in API endpoints. </param>
    /// <param name="object"> The object type, which is always `vector_store.file`. </param>
    /// <param name="size"> The total vector store usage in bytes. Note that this may be different from the original file size. </param>
    /// <param name="createdAt"> The Unix timestamp (in seconds) for when the vector store file was created. </param>
    /// <param name="vectorStoreId"> The ID of the [vector store](/docs/api-reference/vector-stores/object) that the [File](/docs/api-reference/files) is attached to. </param>
    /// <param name="status"> The status of the vector store file, which can be either `in_progress`, `completed`, `cancelled`, or `failed`. The status `completed` indicates that the vector store file is ready for use. </param>
    /// <param name="lastError"> The last error associated with this vector store file. Will be `null` if there are no errors. </param>
    /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
    internal VectorStoreFileAssociation(string fileId, object @object, int size, DateTimeOffset createdAt, string vectorStoreId, VectorStoreFileAssociationStatus status, VectorStoreFileAssociationError? lastError, IDictionary<string, BinaryData> serializedAdditionalRawData)
    {
        FileId = fileId;
        Object = @object;
        Size = size;
        CreatedAt = createdAt;
        VectorStoreId = vectorStoreId;
        Status = status;
        LastError = lastError;
        _serializedAdditionalRawData = serializedAdditionalRawData;
    }
}