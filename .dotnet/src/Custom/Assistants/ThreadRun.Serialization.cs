using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Assistants;

public partial class ThreadRun : IJsonModel<ThreadRun>
{
    ThreadRun IJsonModel<ThreadRun>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
    {
        throw new NotImplementedException();
    }

    ThreadRun IPersistableModel<ThreadRun>.Create(BinaryData data, ModelReaderWriterOptions options)
    {
        throw new NotImplementedException();
    }

    string IPersistableModel<ThreadRun>.GetFormatFromOptions(ModelReaderWriterOptions options)
    {
        throw new NotImplementedException();
    }

    void IJsonModel<ThreadRun>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        throw new NotImplementedException();
    }

    BinaryData IPersistableModel<ThreadRun>.Write(ModelReaderWriterOptions options)
    {
        throw new NotImplementedException();
    }
}
