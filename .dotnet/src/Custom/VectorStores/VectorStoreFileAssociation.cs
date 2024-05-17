﻿namespace OpenAI.VectorStores;

/// <summary>
/// A representation of a file association between an uploaded file and a vector store.
/// </summary>
[CodeGenModel("VectorStoreFileObject")]
public partial class VectorStoreFileAssociation
{
    private readonly object Object;

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
}