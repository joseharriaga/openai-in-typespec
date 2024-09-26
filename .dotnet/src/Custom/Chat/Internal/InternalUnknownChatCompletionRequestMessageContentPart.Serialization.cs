using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace OpenAI.Chat;

[CodeGenModel("UnknownChatCompletionRequestMessageContentPart")]
internal partial class InternalUnknownChatCompletionRequestMessageContentPart
{
    internal override void WriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        throw new NotImplementedException();
    }
}