// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.RealtimeConversation
{
    public partial class ConversationTextDoneUpdate : ConversationUpdate
    {
        internal ConversationTextDoneUpdate(string eventId, string responseId, string itemId, int outputIndex, int contentIndex, string text)
        {
            Argument.AssertNotNull(eventId, nameof(eventId));
            Argument.AssertNotNull(responseId, nameof(responseId));
            Argument.AssertNotNull(itemId, nameof(itemId));
            Argument.AssertNotNull(text, nameof(text));

            Kind = ConversationUpdateKind.ResponseTextDone;
            EventId = eventId;
            ResponseId = responseId;
            ItemId = itemId;
            OutputIndex = outputIndex;
            ContentIndex = contentIndex;
            Text = text;
        }

        internal ConversationTextDoneUpdate(ConversationUpdateKind kind, IDictionary<string, BinaryData> serializedAdditionalRawData, string eventId, string responseId, string itemId, int outputIndex, int contentIndex, string text) : base(kind, serializedAdditionalRawData)
        {
            EventId = eventId;
            ResponseId = responseId;
            ItemId = itemId;
            OutputIndex = outputIndex;
            ContentIndex = contentIndex;
            Text = text;
        }

        internal ConversationTextDoneUpdate()
        {
        }

        public string EventId { get; }
        public string ResponseId { get; }
        public string ItemId { get; }
        public int OutputIndex { get; }
        public int ContentIndex { get; }
        public string Text { get; }
    }
}