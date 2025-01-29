// <auto-generated/>

#nullable disable

using System;

namespace OpenAI.RealtimeConversation
{
    internal static partial class ConversationTurnDetectionKindExtensions
    {
        public static string ToSerialString(this RealtimeConversation.ConversationTurnDetectionKind value) => value switch
        {
            RealtimeConversation.ConversationTurnDetectionKind.ServerVoiceActivityDetection => "server_vad",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown ConversationTurnDetectionKind value.")
        };

        public static RealtimeConversation.ConversationTurnDetectionKind ToConversationTurnDetectionKind(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "server_vad"))
            {
                return RealtimeConversation.ConversationTurnDetectionKind.ServerVoiceActivityDetection;
            }
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown ConversationTurnDetectionKind value.");
        }
    }
}
