using System;
using System.Collections.Generic;

namespace OpenAI;

// CUSTOM: made internal; always set to "include_usage": true

[CodeGenModel("ChatCompletionStreamOptions")]
internal partial class InternalChatCompletionStreamOptions {}

internal interface IInternalListResponse<T>
{
    IReadOnlyList<T> Data { get; }
    string FirstId { get; }
    string LastId { get; }
    bool HasMore { get; }
}