using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace OpenAI.Chat;

[CodeGenModel("UnknownChatCompletionMessageToolCall")]
internal partial class InternalUnknownChatCompletionMessageToolCall
{
    internal override void WriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        throw new NotImplementedException();
    }
}