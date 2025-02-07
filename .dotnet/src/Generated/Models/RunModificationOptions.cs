// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using OpenAI;

namespace OpenAI.Assistants
{
    public partial class RunModificationOptions
    {
        private protected IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        public RunModificationOptions()
        {
            Metadata = new ChangeTrackingDictionary<string, string>();
        }

        internal RunModificationOptions(IDictionary<string, string> metadata, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            Metadata = metadata;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        public IDictionary<string, string> Metadata { get; }

        internal IDictionary<string, BinaryData> SerializedAdditionalRawData
        {
            get => _additionalBinaryDataProperties;
            set => _additionalBinaryDataProperties = value;
        }
    }
}
