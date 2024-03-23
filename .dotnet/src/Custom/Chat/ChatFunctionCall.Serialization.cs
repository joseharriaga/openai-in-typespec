using OpenAI.ClientShared.Internal;
using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace OpenAI.Chat;

public partial class ChatFunctionCall :  IJsonModel<ChatFunctionCall>
{
    ChatFunctionCall IJsonModel<ChatFunctionCall>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
    {
        throw new NotImplementedException();
    }

    ChatFunctionCall IPersistableModel<ChatFunctionCall>.Create(BinaryData data, ModelReaderWriterOptions options)
    {
        throw new NotImplementedException();
    }

    BinaryData IPersistableModel<ChatFunctionCall>.Write(ModelReaderWriterOptions options)
    {
        ModelSerializationHelpers.AssertSupportedPersistableWriteFormat(this, options);
        return ModelReaderWriter.Write(this, options);
    }

    void IJsonModel<ChatFunctionCall>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        ModelSerializationHelpers.AssertSupportedJsonWriteFormat(this, options);
        writer.WriteStartObject();
        writer.WriteString("name"u8, FunctionName);
        writer.WriteString("arguments"u8, Arguments);
        writer.WriteEndObject();
    }

    string IPersistableModel<ChatFunctionCall>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
}
