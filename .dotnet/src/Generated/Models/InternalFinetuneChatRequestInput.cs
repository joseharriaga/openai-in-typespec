// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using OpenAI.Chat;

namespace OpenAI.FineTuning
{
    internal partial class InternalFinetuneChatRequestInput
    {
        internal IDictionary<string, BinaryData> _serializedAdditionalRawData;

        public InternalFinetuneChatRequestInput()
        {
            Messages = new ChangeTrackingList<BinaryData>();
            Tools = new ChangeTrackingList<ChatTool>();
            Functions = new ChangeTrackingList<ChatFunction>();
        }

        internal InternalFinetuneChatRequestInput(IList<BinaryData> messages, IList<ChatTool> tools, bool? parallelToolCalls, IList<ChatFunction> functions, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Messages = messages;
            Tools = tools;
            ParallelToolCalls = parallelToolCalls;
            Functions = functions;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        public IList<BinaryData> Messages { get; }
        public IList<ChatTool> Tools { get; }
        public bool? ParallelToolCalls { get; set; }
        public IList<ChatFunction> Functions { get; }
    }
}
