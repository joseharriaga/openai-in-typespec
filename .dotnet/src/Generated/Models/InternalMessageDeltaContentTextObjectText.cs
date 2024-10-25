// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using OpenAI;

namespace OpenAI.Assistants
{
    internal partial class InternalMessageDeltaContentTextObjectText
    {
        private protected IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        internal InternalMessageDeltaContentTextObjectText()
        {
            Annotations = new ChangeTrackingList<InternalMessageDeltaTextContentAnnotation>();
        }

        internal InternalMessageDeltaContentTextObjectText(string value, IList<InternalMessageDeltaTextContentAnnotation> annotations, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            Value = value;
            Annotations = annotations;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        public string Value { get; }

        public IList<InternalMessageDeltaTextContentAnnotation> Annotations { get; }

        internal IDictionary<string, BinaryData> SerializedAdditionalRawData
        {
            get => _additionalBinaryDataProperties;
            set => _additionalBinaryDataProperties = value;
        }
    }
}
