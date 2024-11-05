using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace OpenAI.Chat;

[CodeGenModel("ChatCompletionRequestAssistantMessageAudio")]
public partial class ChatAudioReference
{
    [CodeGenMember("Id")]
    public string CorrelationId { get; set; }

    public static implicit operator ChatAudioReference(ChatResponseAudio responseAudio)
    {
        return new ChatAudioReference()
        {
            CorrelationId = responseAudio.CorrelationId,
        };
    }
}
