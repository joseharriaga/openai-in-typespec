using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace OpenAI.Chat;

[CodeGenModel("ChatCompletionResponseMessageAudio")]
public partial class ChatResponseAudio
{
    [CodeGenMember("Id")]
    public string CorrelationId { get; }
}
