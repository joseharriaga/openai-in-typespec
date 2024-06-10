// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using OpenAI.Chat;

namespace OpenAI.Internal.FineTuning
{
    internal partial class InternalFinetuneChatRequestInput
    {
        internal IDictionary<string, BinaryData> _serializedAdditionalRawData;

        internal InternalFinetuneChatRequestInput()
        {
            Messages = new ChangeTrackingList<BinaryData>();
            Functions = new ChangeTrackingList<ChatFunction>();
        }

        internal InternalFinetuneChatRequestInput(IReadOnlyList<BinaryData> messages, IReadOnlyList<ChatFunction> functions, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Messages = messages;
            Functions = functions;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        public IReadOnlyList<BinaryData> Messages { get; }
        public IReadOnlyList<ChatFunction> Functions { get; }
    }
}