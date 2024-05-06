using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Assistants;

public partial class Assistant : IJsonModel<Assistant>
{
    Assistant IJsonModel<Assistant>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
    {
        throw new NotImplementedException();
    }

    Assistant IPersistableModel<Assistant>.Create(BinaryData data, ModelReaderWriterOptions options)
    {
        throw new NotImplementedException();
    }

    string IPersistableModel<Assistant>.GetFormatFromOptions(ModelReaderWriterOptions options)
    {
        throw new NotImplementedException();
    }

    void IJsonModel<Assistant>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        throw new NotImplementedException();
    }

    BinaryData IPersistableModel<Assistant>.Write(ModelReaderWriterOptions options)
    {
        throw new NotImplementedException();
    }
}
