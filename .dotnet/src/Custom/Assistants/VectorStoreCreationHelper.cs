using OpenAI.Files;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System;

namespace OpenAI.Assistants;

[CodeGenModel("CreateAssistantRequestToolResourcesFileSearchVectorStoreCreationHelpersVectorStore")]
public partial class VectorStoreCreationHelper
{
    [CodeGenMember("FileIds")]
    internal IList<string> _internalFileIds;

    [SetsRequiredMembers]
    public VectorStoreCreationHelper(IEnumerable<string> fileIds)
        : this(fileIds?.ToList(), metadata: null, serializedAdditionalRawData: null)
    {
        Argument.AssertNotNull(fileIds, nameof(fileIds));
    }

    [SetsRequiredMembers]
    public VectorStoreCreationHelper(IEnumerable<OpenAIFileInfo> files)
        : this(files?.Select(file => file.Id)?.ToList(), metadata: null, serializedAdditionalRawData: null)
    {
        Argument.AssertNotNull(files, nameof(files));
    }

    [SetsRequiredMembers]
    internal VectorStoreCreationHelper(IList<string> fileIds, IDictionary<string, string> metadata, IDictionary<string, BinaryData> serializedAdditionalRawData)
    {
        FileIds = fileIds;
        Metadata = metadata;
        _serializedAdditionalRawData = serializedAdditionalRawData;
    }

    public required IList<string> FileIds
    {
        get => _internalFileIds;
        init => _internalFileIds = value;
    }
}
