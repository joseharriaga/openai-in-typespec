using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Assistants;

[CodeGenModel("AssistantObjectToolResourcesFileSearch")]
[CodeGenSerialization(nameof(NewVectorStores), "vector_stores", SerializationValueHook = nameof(SerializeNewVectorStores))]
public partial class FileSearchToolResources
{
    private ChangeTrackingList<string> _vectorStoreIds = new();

    [CodeGenMember("VectorStoreIds")]
    public IList<string> VectorStoreIds
    {
        get => _vectorStoreIds;
        init
        {
            _vectorStoreIds = [.. value];
        }
    }

    [CodeGenMember("vector_stores")]
    public IList<VectorStoreCreationHelper> NewVectorStores { get; init; } = new ChangeTrackingList<VectorStoreCreationHelper>();

    public FileSearchToolResources()
    { }

    private void SerializeNewVectorStores(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        => writer.WriteObjectValue(NewVectorStores, options);
}

