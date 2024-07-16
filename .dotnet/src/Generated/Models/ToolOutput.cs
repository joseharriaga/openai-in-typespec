// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Assistants
{
    public partial class ToolOutput
    {
        internal IDictionary<string, BinaryData> SerializedAdditionalRawData { get; }
        public ToolOutput()
        {
            SerializedAdditionalRawData = new ChangeTrackingDictionary<string, BinaryData>();
        }

        internal ToolOutput(string toolCallId, string output, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            ToolCallId = toolCallId;
            Output = output;
            SerializedAdditionalRawData = serializedAdditionalRawData;
        }

        public string ToolCallId { get; init; }
        public string Output { get; init; }
    }
}
