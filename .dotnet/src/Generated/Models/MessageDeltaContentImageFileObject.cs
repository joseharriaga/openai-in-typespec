// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Internal.Models
{
    /// <summary> References an image file in the content of an image. </summary>
    internal partial class MessageDeltaContentImageFileObject
    {
        /// <summary>
        /// Keeps track of any properties unknown to the library.
        /// <para>
        /// To assign an object to the value of this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
        /// </para>
        /// <para>
        /// To assign an already formatted json string to this property use <see cref="BinaryData.FromString(string)"/>.
        /// </para>
        /// <para>
        /// Examples:
        /// <list type="bullet">
        /// <item>
        /// <term>BinaryData.FromObjectAsJson("foo")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("\"foo\"")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromObjectAsJson(new { key = "value" })</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("{\"key\": \"value\"}")</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="MessageDeltaContentImageFileObject"/>. </summary>
        /// <param name="index"> The index of the content part of the message. </param>
        internal MessageDeltaContentImageFileObject(long index)
        {
            Index = index;
        }

        /// <summary> Initializes a new instance of <see cref="MessageDeltaContentImageFileObject"/>. </summary>
        /// <param name="index"> The index of the content part of the message. </param>
        /// <param name="type"> The type of the content, which is always `image_file`. </param>
        /// <param name="imageFile"> The information about the image_file. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal MessageDeltaContentImageFileObject(long index, MessageDeltaContentImageFileObjectType type, MessageDeltaContentImageFileObjectImageFile imageFile, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Index = index;
            Type = type;
            ImageFile = imageFile;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="MessageDeltaContentImageFileObject"/> for deserialization. </summary>
        internal MessageDeltaContentImageFileObject()
        {
        }

        /// <summary> The index of the content part of the message. </summary>
        public long Index { get; }
        /// <summary> The type of the content, which is always `image_file`. </summary>
        public MessageDeltaContentImageFileObjectType Type { get; } = MessageDeltaContentImageFileObjectType.ImageFile;

        /// <summary> The information about the image_file. </summary>
        public MessageDeltaContentImageFileObjectImageFile ImageFile { get; }
    }
}
