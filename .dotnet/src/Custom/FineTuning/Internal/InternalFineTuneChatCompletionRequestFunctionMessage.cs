using OpenAI.Chat;
using System.Collections.Generic;

namespace OpenAI.FineTuning;

[CodeGenSuppress(nameof(InternalFineTuneChatCompletionRequestFunctionMessage), typeof(IEnumerable<ChatMessageContentPart>), typeof(string))]
[CodeGenModel("FineTuneChatCompletionRequestFunctionMessage")]
internal partial class InternalFineTuneChatCompletionRequestFunctionMessage
{
}
