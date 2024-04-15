// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Internal.Models
{
    /// <summary> The MessageDeltaContentTextObjectText. </summary>
    internal partial class MessageDeltaContentTextObjectText
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

        /// <summary> Initializes a new instance of <see cref="MessageDeltaContentTextObjectText"/>. </summary>
        internal MessageDeltaContentTextObjectText()
        {
            Annotations = new ChangeTrackingList<BinaryData>();
        }

        /// <summary> Initializes a new instance of <see cref="MessageDeltaContentTextObjectText"/>. </summary>
        /// <param name="value"> The data that makes up the text. </param>
        /// <param name="annotations"> Annotations for the text. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal MessageDeltaContentTextObjectText(string value, IReadOnlyList<BinaryData> annotations, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Value = value;
            Annotations = annotations;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> The data that makes up the text. </summary>
        public string Value { get; }
        /// <summary>
        /// Annotations for the text.
        /// <para>
        /// To assign an object to the element of this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
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
        public IReadOnlyList<BinaryData> Annotations { get; }
    }
}
