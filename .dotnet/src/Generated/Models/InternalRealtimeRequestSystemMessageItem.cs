// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.RealtimeConversation
{
    internal partial class InternalRealtimeRequestSystemMessageItem : InternalRealtimeRequestMessageItem
    {
        internal InternalRealtimeRequestSystemMessageItem(IList<ConversationContentPart> content, ConversationMessageRole role, ConversationItemStatus? status, InternalRealtimeItemType @type, string id, IDictionary<string, BinaryData> additionalBinaryDataProperties) : base(role, status, @type, id, additionalBinaryDataProperties)
        {
            Content = content;
        }
    }
}
