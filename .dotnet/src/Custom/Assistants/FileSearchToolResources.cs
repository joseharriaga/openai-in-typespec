using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Assistants;

[CodeGenModel("ToolResourcesFileSearch")]
[CodeGenSerialization(nameof(NewVectorStores), "vector_stores", SerializationValueHook = nameof(SerializeNewVectorStores))]
public partial class FileSearchToolResources
{
    private ChangeTrackingList<string> _vectorStoreIds = new();

    [CodeGenMember("VectorStoreIds")]
    public IList<string> VectorStoreIds
    {
        get => _vectorStoreIds;
        set
        {
            _vectorStoreIds = new ChangeTrackingList<string>();
            foreach (string item in value)
            {
                _vectorStoreIds.Add(item);
            }
        }
    }

    [CodeGenMember("VectorStores")]
    public IList<VectorStoreCreationHelper> NewVectorStores { get; init; } = new ChangeTrackingList<VectorStoreCreationHelper>();

    public FileSearchToolResources()
    { }

    private void SerializeNewVectorStores(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        => writer.WriteObjectValue(NewVectorStores, options);
}

