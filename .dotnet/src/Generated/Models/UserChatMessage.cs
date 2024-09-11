// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Chat
{
    public partial class UserChatMessage : ChatMessage
    {
        internal UserChatMessage(ChatMessageRole role, IList<ChatMessageContentPart> content, IDictionary<string, BinaryData> serializedAdditionalRawData, string participantName) : base(role, content, serializedAdditionalRawData)
        {
            ParticipantName = participantName;
        }

        internal UserChatMessage()
        {
        }
    }
}
