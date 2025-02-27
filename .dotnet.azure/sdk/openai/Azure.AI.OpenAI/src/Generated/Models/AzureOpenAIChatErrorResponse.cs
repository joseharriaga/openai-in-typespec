// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.AI.OpenAI
{
    internal partial class AzureOpenAIChatErrorResponse
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private protected IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        internal AzureOpenAIChatErrorResponse()
        {
        }

        internal AzureOpenAIChatErrorResponse(AzureOpenAIChatError error, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            Error = error;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        public AzureOpenAIChatError Error { get; }

        internal IDictionary<string, BinaryData> SerializedAdditionalRawData
        {
            get => _additionalBinaryDataProperties;
            set => _additionalBinaryDataProperties = value;
        }
    }
}
