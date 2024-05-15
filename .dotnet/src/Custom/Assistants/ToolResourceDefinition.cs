using System.Collections.Generic;
using System.Linq;

namespace OpenAI.Assistants;

/// <summary>
/// Defines a single unit of resources to make available to an assistant tool. This includes file IDs for the
/// <c>code_interpreter</c> tool to use as well as vector store IDs for the <c>file_search</c> tool.
/// </summary>
/// <remarks>
/// All <see cref="ToolResourceDefinition"/> instances will be combined when making a request.
/// </remarks>
public partial class ToolResourceDefinition
{
    internal readonly IReadOnlyList<string> _codeInterpreterFileIds;
    internal readonly IReadOnlyList<string> _existingFileSearchVectorStoreIds;
    internal readonly IReadOnlyList<ToolResourceDefinitionVectorStoreCreationRequest> _newFileSearchVectorStoreCreationRequests;

    /// <summary>
    /// Creates a new resource definition from a list of file IDs to be made available to the code_interpreter tool.
    /// There can be a maximum of 20 files associated with the tool.
    /// </summary>
    /// <param name="fileIds"> The uploaded file IDs for the Code Interpreter tool to use. </param>
    /// <returns> A new <see cref="ToolResourceDefinition"/>. </returns>
    public static ToolResourceDefinition FromCodeInterpreterFileIds(IEnumerable<string> fileIds)
        => new(fileIds, null, null);

    /// <summary>
    /// Creates a new resource definition for the File Search tool, from existing vector store IDs.
    /// </summary>
    /// <remarks>
    /// Currently, there can be a maximum of <c>1</c> vector store attached.
    /// </remarks>
    /// <param name="vectorStoreIds"> The vector store IDs for the File Search tool to use. </param>
    /// <returns> A new <see cref="ToolResourceDefinition"/>. </returns>
    public static ToolResourceDefinition FromFileSearchVectorStoreIds(IEnumerable<string> vectorStoreIds)
        => new(null, vectorStoreIds, null);

    /// <summary>
    /// Creates a new resource definition that acts as a helper to create a new vector store and immediately attach it
    /// to the available File Search tool resources.
    /// </summary>
    /// <remarks>
    /// Currently, there can be a maximum of <c>1</c> vector store attached.
    /// </remarks>
    /// <param name="fileIds"></param>
    /// <param name="metadata"></param>
    /// <returns></returns>
    public static ToolResourceDefinition FromNewFileSearchVectorStore(
        IEnumerable<string> fileIds,
        IDictionary<string, string> metadata = null)
            => FromNewFileSearchVectorStores([new(fileIds, metadata)]);

    internal static ToolResourceDefinition FromNewFileSearchVectorStores(
        IEnumerable<ToolResourceDefinitionVectorStoreCreationRequest> vectorStoreCreationRequests)
            => new(null, null, vectorStoreCreationRequests);

    internal ToolResourceDefinition(
        IEnumerable<string> codeInterpreterFileIds = null,
        IEnumerable<string> existingFileSearchVectorStoreIds = null,
        IEnumerable<ToolResourceDefinitionVectorStoreCreationRequest> newFileSearchVectorStoreCreationRequests = null)
    {
        _codeInterpreterFileIds = codeInterpreterFileIds?.ToList() ?? [];
        _existingFileSearchVectorStoreIds = existingFileSearchVectorStoreIds?.ToList() ?? [];
        _newFileSearchVectorStoreCreationRequests = newFileSearchVectorStoreCreationRequests?.ToList() ?? [];
    }

    internal readonly struct ToolResourceDefinitionVectorStoreCreationRequest
    {
        internal IReadOnlyList<string> FileIds { get; } = null;
        internal IReadOnlyDictionary<string, string> Metadata { get; } = null;

        public ToolResourceDefinitionVectorStoreCreationRequest(
            IEnumerable<string> fileIds,
            IDictionary<string, string> metadata)
        {
            FileIds = fileIds?.ToList() ?? [];
            Metadata = metadata as IReadOnlyDictionary<string, string>;
        }
    }
}

