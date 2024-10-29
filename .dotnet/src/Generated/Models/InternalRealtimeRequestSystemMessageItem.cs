// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenAI.RealtimeConversation
{
    internal partial class InternalRealtimeRequestSystemMessageItem : InternalRealtimeRequestMessageItem
    {
        public InternalRealtimeRequestSystemMessageItem(IEnumerable<ConversationContentPart> content)
        {
            Argument.AssertNotNull(content, nameof(content));

            Role = ConversationMessageRole.System;
            Content = content.ToList();
        }

        internal InternalRealtimeRequestSystemMessageItem(InternalRealtimeItemType type, string id, IDictionary<string, BinaryData> serializedAdditionalRawData, ConversationMessageRole role, ConversationItemStatus? status, IList<ConversationContentPart> content) : base(type, id, serializedAdditionalRawData, role, status)
        {
            Content = content;
        }

        internal InternalRealtimeRequestSystemMessageItem()
        {
        }
    }
}
