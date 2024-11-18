using System;
using System.ClientModel.Primitives.FullDuplexMessaging;
using System.Collections.Generic;
using System.Text;

#nullable enable

namespace OpenAI.RealtimeConversation;

public class AssistantConversationOptions : DuplexPipelineOptions
{
    //public ConversationSessionOptions? ConversationOptions { get; set; }
    public AssistantConversationOptions()
    {
        Instructions = "default instructions";
        Tools = [];
    }

    public ConversationVoice? Voice { get; set; }
    public string Instructions { get; set; }
    public ConversationAudioFormat? InputAudioFormat { get; set; }
    public ConversationAudioFormat? OutputAudioFormat { get; set; }
    public IList<ConversationTool> Tools { get; }
    public float? Temperature { get; set; }
    public ConversationTurnDetectionOptions? TurnDetectionOptions { get; set; }
}
