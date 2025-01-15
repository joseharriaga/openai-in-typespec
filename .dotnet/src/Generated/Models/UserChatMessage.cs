// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Chat
{
    public partial class UserChatMessage : ChatMessage
    {
        internal UserChatMessage(ChatMessageRole role, ChatMessageContent content, IDictionary<string, BinaryData> additionalBinaryDataProperties, string participantName) : base(role, content, additionalBinaryDataProperties)
        {
            ParticipantName = participantName;
        }
    }
}
