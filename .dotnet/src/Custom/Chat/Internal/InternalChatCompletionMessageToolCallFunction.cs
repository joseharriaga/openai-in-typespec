using System;

namespace OpenAI.Chat;

[CodeGenModel("ChatCompletionMessageToolCallFunction")]
internal partial class InternalChatCompletionMessageToolCallFunction
{
    // CUSTOM: Changed type from string to BinaryData.
    public BinaryData Arguments { get; set; }
}
