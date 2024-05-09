using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI;

public partial class ListQueryPage<T> : IJsonModel<ListQueryPage<T>>
{
    ListQueryPage<T> IJsonModel<ListQueryPage<T>>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
    {
        throw new NotImplementedException();
    }

    ListQueryPage<T> IPersistableModel<ListQueryPage<T>>.Create(BinaryData data, ModelReaderWriterOptions options)
    {
        throw new NotImplementedException();
    }

    string IPersistableModel<ListQueryPage<T>>.GetFormatFromOptions(ModelReaderWriterOptions options)
    {
        throw new NotImplementedException();
    }

    void IJsonModel<ListQueryPage<T>>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        throw new NotImplementedException();
    }

    BinaryData IPersistableModel<ListQueryPage<T>>.Write(ModelReaderWriterOptions options)
    {
        throw new NotImplementedException();
    }

    internal static ListQueryPage<T> DeserializeListQueryPage(JsonElement element, ModelReaderWriterOptions options = null)
    {
        List<T> items = [];

        string firstId = null;
        string lastId = null;
        bool? hasMore = null;

        foreach (JsonProperty property in element.EnumerateObject())
        {
            if (property.NameEquals("data"u8))
            {
                foreach (JsonElement dataItemElement in property.Value.EnumerateArray())
                {
                    BinaryData dataItem = BinaryData.FromObjectAsJson(dataItemElement);
                    items.Add(ModelReaderWriter.Read(dataItem, typeof(T), options) as T);
                }
                continue;
            }
            if (property.NameEquals("first_id"u8))
            {
                firstId = property.Value.GetString();
                continue;
            }
            if (property.NameEquals("last_id"u8))
            {
                lastId = property.Value.GetString();
                continue;
            }
            if (property.NameEquals("has_more"u8))
            {
                hasMore = property.Value.GetBoolean();
                continue;
            }
        }

        return new(items, firstId, lastId, hasMore.Value);
    }

    internal static ListQueryPage<T> FromResponse(PipelineResponse response)
    {
        using JsonDocument document = JsonDocument.Parse(response.Content);
        return DeserializeListQueryPage(document.RootElement);
    }
}
