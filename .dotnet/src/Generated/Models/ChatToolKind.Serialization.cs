// <auto-generated/>

#nullable disable

using System;

namespace OpenAI.Chat
{
    internal static partial class ChatToolKindExtensions
    {
        public static string ToSerialString(this ChatToolKind value) => value switch
        {
            ChatToolKind.Function => "function",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown ChatToolKind value.")
        };

        public static ChatToolKind ToChatToolKind(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "function")) return ChatToolKind.Function;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown ChatToolKind value.");
        }
    }
}