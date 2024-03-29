using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI;

// TODO: Make it work for non-JSON models too.
// TODO: The list part is a hack - pull it out
internal abstract class StreamedEventCollection<TModel> : List<TModel>, IJsonModel<StreamedEventCollection<TModel>>
    // This just promises me I can deserialize a collection of serializable models.
    // Should it be more general?
    where TModel : IJsonModel<TModel>
{
    public abstract StreamedEventCollection<TModel> Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options);

    public abstract StreamedEventCollection<TModel> Create(BinaryData data, ModelReaderWriterOptions options);

    public string GetFormatFromOptions(ModelReaderWriterOptions options)
    {
        throw new NotImplementedException();
    }

    public void Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        throw new NotImplementedException();
    }

    public BinaryData Write(ModelReaderWriterOptions options)
    {
        throw new NotImplementedException();
    }
}
