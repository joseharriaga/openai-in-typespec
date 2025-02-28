// <auto-generated/>

#nullable disable

using System;

namespace OpenAI.Chat
{
    internal static partial class ChatToolCallKindExtensions
    {
        public static string ToSerialString(this ChatToolCallKind value) => value switch
        {
            ChatToolCallKind.Function => "function",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown ChatToolCallKind value.")
        };

        public static ChatToolCallKind ToChatToolCallKind(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "function"))
            {
                return ChatToolCallKind.Function;
            }
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown ChatToolCallKind value.");
        }
    }
}
