using System;
using System.Collections.Generic;
using System.ClientModel.Primitives;
using System.Text.Json;
using System.Linq;

namespace OpenAI.Assistants;

public partial class ToolResourceDefinitionCollection : IJsonModel<ToolResourceDefinitionCollection>
{
    void IJsonModel<ToolResourceDefinitionCollection>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        var format = options.Format == "W" ? ((IPersistableModel<ToolResourceDefinitionCollection>)this).GetFormatFromOptions(options) : options.Format;
        if (format != "J")
        {
            throw new FormatException($"The model {nameof(ToolResourceDefinitionCollection)} does not support writing '{format}' format.");
        }

        List<string> allCodeInterpreterFileIds
            = _definitions.SelectMany(definition => definition._codeInterpreterFileIds ?? []).ToList();
        List<string> allFileSearchVectorStoreIds
            = _definitions.SelectMany(definition => definition._existingFileSearchVectorStoreIds ?? []).ToList();
        List<ToolResourceDefinition.ToolResourceDefinitionVectorStoreCreationRequest> allFileSearchVectorStoreCreationRequests
            = _definitions.SelectMany(definition => definition._newFileSearchVectorStoreCreationRequests ?? []).ToList();

        if (allCodeInterpreterFileIds.Count == 0 && allFileSearchVectorStoreIds.Count == 0 && allFileSearchVectorStoreCreationRequests.Count == 0)
        {
            writer.WriteNullValue();
        }
        else
        {
            writer.WriteStartObject();
            if (allCodeInterpreterFileIds.Count > 0)
            {
                writer.WritePropertyName("code_interpreter"u8);
                writer.WriteStartObject();
                writer.WritePropertyName("file_ids"u8);
                writer.WriteObjectValue(allCodeInterpreterFileIds);
                writer.WriteEndObject();
            }
            if (allFileSearchVectorStoreIds.Count > 0 || allFileSearchVectorStoreCreationRequests.Count > 0)
            {
                writer.WritePropertyName("file_search"u8);
                writer.WriteStartObject();
                if (allFileSearchVectorStoreIds.Count > 0)
                {
                    writer.WritePropertyName("vector_store_ids"u8);
                    writer.WriteObjectValue(allFileSearchVectorStoreIds);
                }
                if (allFileSearchVectorStoreCreationRequests.Count > 0)
                {
                    writer.WritePropertyName("vector_stores"u8);
                    writer.WriteStartArray();
                    foreach (ToolResourceDefinition.ToolResourceDefinitionVectorStoreCreationRequest request
                        in allFileSearchVectorStoreCreationRequests)
                    {
                        writer.WriteStartObject();
                        if (request.FileIds?.Count > 0)
                        {
                            writer.WritePropertyName("file_ids"u8);
                            writer.WriteObjectValue(request.FileIds);
                        }
                        if (request.Metadata is not null)
                        {
                            writer.WritePropertyName("metadata"u8);
                            writer.WriteObjectValue(request.Metadata);
                        }
                        writer.WriteEndObject();
                    }
                    writer.WriteEndArray();
                }
                writer.WriteEndObject();
            }
            writer.WriteEndObject();
        }
    }

    ToolResourceDefinitionCollection IJsonModel<ToolResourceDefinitionCollection>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
    {
        var format = options.Format == "W" ? ((IPersistableModel<ToolResourceDefinitionCollection>)this).GetFormatFromOptions(options) : options.Format;
        if (format != "J")
        {
            throw new FormatException($"The model {nameof(ToolResourceDefinitionCollection)} does not support reading '{format}' format.");
        }

        using JsonDocument document = JsonDocument.ParseValue(ref reader);
        return DeserializeToolResourceDefinitionCollection(document.RootElement, options);
    }

    internal static ToolResourceDefinitionCollection DeserializeToolResourceDefinitionCollection(JsonElement element, ModelReaderWriterOptions options = null)
    {
        options ??= ModelSerializationExtensions.WireOptions;

        List<ToolResourceDefinition> definitions = [];

        foreach (JsonProperty property in element.EnumerateObject())
        {
            if (property.NameEquals("code_interpreter"u8))
            {
                foreach (JsonProperty codeInterpreterProperty in property.Value.EnumerateObject())
                {
                    if (codeInterpreterProperty.NameEquals("file_ids"u8))
                    {
                        List<string> ids = [];
                        foreach (JsonElement codeInterpreterIdElement in codeInterpreterProperty.Value.EnumerateArray())
                        {
                            ids.Add(codeInterpreterIdElement.GetString());
                        }
                        ToolResourceDefinition codeInterpreterFileIdsDefinition = new(ids, null, null);
                        definitions.Add(codeInterpreterFileIdsDefinition);
                        continue;
                    }
                }
                continue;
            }
            if (property.NameEquals("file_search"u8))
            {
                foreach (JsonProperty fileSearchProperty in property.Value.EnumerateObject())
                {
                    if (fileSearchProperty.NameEquals("vector_store_ids"u8))
                    {
                        List<string> ids = [];
                        foreach (JsonElement fileSearchIdElement in fileSearchProperty.Value.EnumerateArray())
                        {
                            ids.Add(fileSearchIdElement.GetString());
                        }
                        ToolResourceDefinition fileSearchVectorStoreIdsDefinition = new(null, ids, null);
                        definitions.Add(fileSearchVectorStoreIdsDefinition);
                        continue;
                    }
                    if (fileSearchProperty.NameEquals("vector_stores"u8))
                    {
                        List<ToolResourceDefinition.ToolResourceDefinitionVectorStoreCreationRequest> newVectorStoreRequests = [];
                        foreach (JsonElement fileSearchNewVectorStoreElement in fileSearchProperty.Value.EnumerateArray())
                        {
                            List<string> ids = [];
                            Dictionary<string, string> metadata = [];
                            foreach (JsonProperty newVectorStoreProperty in fileSearchNewVectorStoreElement.EnumerateObject())
                            {
                                if (newVectorStoreProperty.NameEquals("file_ids"u8))
                                {
                                    if (property.Value.ValueKind == JsonValueKind.Null)
                                    {
                                        continue;
                                    }
                                    foreach (JsonElement newVectorStoreFileIdElement in newVectorStoreProperty.Value.EnumerateArray())
                                    {
                                        ids.Add(newVectorStoreFileIdElement.GetString());
                                    }
                                    continue;
                                }
                                if (property.NameEquals("metadata"u8))
                                {
                                    if (property.Value.ValueKind == JsonValueKind.Null)
                                    {
                                        continue;
                                    }
                                    Dictionary<string, string> dictionary = new Dictionary<string, string>();
                                    foreach (var property0 in property.Value.EnumerateObject())
                                    {
                                        metadata[property0.Name] = property0.Value.GetString();
                                    }
                                    continue;
                                }
                            }
                            newVectorStoreRequests.Add(new(ids, metadata));
                        }
                        ToolResourceDefinition newVectorStoresDefinition = new(null, null, newVectorStoreRequests);
                        definitions.Add(newVectorStoresDefinition);
                    }
                }
                continue;
            }
        }

        return new ToolResourceDefinitionCollection(definitions);
    }

    BinaryData IPersistableModel<ToolResourceDefinitionCollection>.Write(ModelReaderWriterOptions options)
    {
        var format = options.Format == "W" ? ((IPersistableModel<ToolResourceDefinitionCollection>)this).GetFormatFromOptions(options) : options.Format;

        switch (format)
        {
            case "J":
                return ModelReaderWriter.Write(this, options);
            default:
                throw new FormatException($"The model {nameof(ToolResourceDefinitionCollection)} does not support writing '{options.Format}' format.");
        }
    }

    ToolResourceDefinitionCollection IPersistableModel<ToolResourceDefinitionCollection>.Create(BinaryData data, ModelReaderWriterOptions options)
    {
        var format = options.Format == "W" ? ((IPersistableModel<ToolResourceDefinitionCollection>)this).GetFormatFromOptions(options) : options.Format;

        switch (format)
        {
            case "J":
                {
                    using JsonDocument document = JsonDocument.Parse(data);
                    return DeserializeToolResourceDefinitionCollection(document.RootElement, options);
                }
            default:
                throw new FormatException($"The model {nameof(ToolResourceDefinitionCollection)} does not support reading '{options.Format}' format.");
        }
    }

    string IPersistableModel<ToolResourceDefinitionCollection>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
}
