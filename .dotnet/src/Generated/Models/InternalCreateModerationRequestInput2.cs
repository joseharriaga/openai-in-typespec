// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using OpenAI;

namespace OpenAI.Moderations
{
    internal partial class InternalCreateModerationRequestInput2
    {
        private protected IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        public InternalCreateModerationRequestInput2(InternalCreateModerationRequestInputImageUrl imageUrl)
        {
            Argument.AssertNotNull(imageUrl, nameof(imageUrl));

            ImageUrl = imageUrl;
        }

        internal InternalCreateModerationRequestInput2(InternalCreateModerationRequestInput2Type @type, InternalCreateModerationRequestInputImageUrl imageUrl, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            Type = @type;
            ImageUrl = imageUrl;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        public InternalCreateModerationRequestInput2Type Type { get; } = "image_url";

        public InternalCreateModerationRequestInputImageUrl ImageUrl { get; }

        internal IDictionary<string, BinaryData> SerializedAdditionalRawData
        {
            get => _additionalBinaryDataProperties;
            set => _additionalBinaryDataProperties = value;
        }
    }
}
