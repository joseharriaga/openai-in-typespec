using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Assistants;

public partial class ThreadMessage : IJsonModel<ThreadMessage>
{
    ThreadMessage IJsonModel<ThreadMessage>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
    {
        throw new NotImplementedException();
    }

    ThreadMessage IPersistableModel<ThreadMessage>.Create(BinaryData data, ModelReaderWriterOptions options)
    {
        throw new NotImplementedException();
    }

    string IPersistableModel<ThreadMessage>.GetFormatFromOptions(ModelReaderWriterOptions options)
    {
        throw new NotImplementedException();
    }

    void IJsonModel<ThreadMessage>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        throw new NotImplementedException();
    }

    BinaryData IPersistableModel<ThreadMessage>.Write(ModelReaderWriterOptions options)
    {
        throw new NotImplementedException();
    }
}
