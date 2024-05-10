// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Internal.Models
{
    /// <summary> The text content that is part of a message. </summary>
    internal partial class MessageRequestContentTextObject
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

        /// <summary> Initializes a new instance of <see cref="MessageRequestContentTextObject"/>. </summary>
        /// <param name="text"> Text content to be sent to the model. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="text"/> is null. </exception>
        public MessageRequestContentTextObject(string text)
        {
            Argument.AssertNotNull(text, nameof(text));

            Text = text;
        }

        /// <summary> Initializes a new instance of <see cref="MessageRequestContentTextObject"/>. </summary>
        /// <param name="type"> Always `text`. </param>
        /// <param name="text"> Text content to be sent to the model. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal MessageRequestContentTextObject(MessageRequestContentTextObjectType type, string text, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Type = type;
            Text = text;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="MessageRequestContentTextObject"/> for deserialization. </summary>
        internal MessageRequestContentTextObject()
        {
        }

        /// <summary> Always `text`. </summary>
        public MessageRequestContentTextObjectType Type { get; } = MessageRequestContentTextObjectType.Text;

        /// <summary> Text content to be sent to the model. </summary>
        public string Text { get; }
    }
}