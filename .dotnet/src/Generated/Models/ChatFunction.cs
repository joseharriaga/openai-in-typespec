// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Chat
{
    [Obsolete("This field is marked as deprecated.")]
    public partial class ChatFunction
    {
        internal IDictionary<string, BinaryData> SerializedAdditionalRawData { get; }

        internal ChatFunction(string functionDescription, string functionName, BinaryData functionParameters, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            FunctionDescription = functionDescription;
            FunctionName = functionName;
            FunctionParameters = functionParameters;
            SerializedAdditionalRawData = serializedAdditionalRawData;
        }

        internal ChatFunction()
        {
        }
    }
}
