using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace OpenAI.Chat;

[CodeGenModel("CreateChatCompletionRequestAudio")]
public partial class ChatAudioOptions
{
    [CodeGenMember("Voice")]
    public ChatResponseVoice ResponseVoice { get; set; }

    [CodeGenMember("Format")]
    public ChatOutputAudioFormat OutputAudioFormat { get; set; }
}
