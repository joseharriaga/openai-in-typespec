// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.AI.OpenAI
{
    internal partial class InternalAzureContentFilterBlocklistIdResult
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private protected IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        internal InternalAzureContentFilterBlocklistIdResult(string id, bool filtered)
        {
            Id = id;
            Filtered = filtered;
        }

        internal InternalAzureContentFilterBlocklistIdResult(string id, bool filtered, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            Id = id;
            Filtered = filtered;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        internal string Id { get; set; }

        internal bool Filtered { get; set; }

        internal IDictionary<string, BinaryData> SerializedAdditionalRawData
        {
            get => _additionalBinaryDataProperties;
            set => _additionalBinaryDataProperties = value;
        }
    }
}
