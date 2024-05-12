// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using OpenAI.Internal.Models;

namespace OpenAI.Assistants
{
    /// <summary> References an image URL in the content of a message. </summary>
    public partial class MessageImageUrlDeltaContent : MessageDeltaContent
    {
        /// <summary> Initializes a new instance of <see cref="MessageImageUrlDeltaContent"/>. </summary>
        /// <param name="index"> The index of the content part in the message. </param>
        internal MessageImageUrlDeltaContent(int index)
        {
            Type = "image_url";
            Index = index;
        }

        /// <summary> Initializes a new instance of <see cref="MessageImageUrlDeltaContent"/>. </summary>
        /// <param name="type"> The discriminated type identifier for the content item. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        /// <param name="index"> The index of the content part in the message. </param>
        /// <param name="imageUrl"></param>
        internal MessageImageUrlDeltaContent(string type, IDictionary<string, BinaryData> serializedAdditionalRawData, int index, InternalMessageDeltaContentImageUrlObjectImageUrl imageUrl) : base(type, serializedAdditionalRawData)
        {
            Index = index;
            _imageUrl = imageUrl;
        }

        /// <summary> Initializes a new instance of <see cref="MessageImageUrlDeltaContent"/> for deserialization. </summary>
        internal MessageImageUrlDeltaContent()
        {
        }

        /// <summary> The index of the content part in the message. </summary>
        public int Index { get; }
    }
}
