using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace OpenAI;

public class OpenAIPageToken : IJsonModel<OpenAIPageToken>
{
    public OpenAIPageOptions PageOptions { get; init; }

    void IJsonModel<OpenAIPageToken>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        throw new NotImplementedException();
    }

    BinaryData IPersistableModel<OpenAIPageToken>.Write(ModelReaderWriterOptions options)
    {
        throw new NotImplementedException();
    }

    OpenAIPageToken IJsonModel<OpenAIPageToken>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
    {
        throw new NotImplementedException();
    }

    OpenAIPageToken IPersistableModel<OpenAIPageToken>.Create(BinaryData data, ModelReaderWriterOptions options)
    {
        throw new NotImplementedException();
    }

    string IPersistableModel<OpenAIPageToken>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
}
