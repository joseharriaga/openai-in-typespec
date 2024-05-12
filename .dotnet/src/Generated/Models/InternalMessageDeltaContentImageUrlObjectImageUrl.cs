// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Internal.Models
{
    /// <summary> The MessageDeltaContentImageUrlObjectImageUrl. </summary>
    internal partial class InternalMessageDeltaContentImageUrlObjectImageUrl
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

        /// <summary> Initializes a new instance of <see cref="InternalMessageDeltaContentImageUrlObjectImageUrl"/>. </summary>
        internal InternalMessageDeltaContentImageUrlObjectImageUrl()
        {
        }

        /// <summary> Initializes a new instance of <see cref="InternalMessageDeltaContentImageUrlObjectImageUrl"/>. </summary>
        /// <param name="url"> The URL of the image, must be a supported image types: jpeg, jpg, png, gif, webp. </param>
        /// <param name="detail"> Specifies the detail level of the image. `low` uses fewer tokens, you can opt in to high resolution using `high`. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal InternalMessageDeltaContentImageUrlObjectImageUrl(Uri url, string detail, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Url = url;
            Detail = detail;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> The URL of the image, must be a supported image types: jpeg, jpg, png, gif, webp. </summary>
        public Uri Url { get; }
    }
}
