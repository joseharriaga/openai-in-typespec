// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Internal.Models
{
    /// <summary> The expiration policy for a vector store. </summary>
    internal partial class VectorStoreExpirationAfter
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

        /// <summary> Initializes a new instance of <see cref="VectorStoreExpirationAfter"/>. </summary>
        /// <param name="days"> The number of days after the anchor time that the vector store will expire. </param>
        public VectorStoreExpirationAfter(int days)
        {
            Days = days;
        }

        /// <summary> Initializes a new instance of <see cref="VectorStoreExpirationAfter"/>. </summary>
        /// <param name="anchor"> Anchor timestamp after which the expiration policy applies. Supported anchors: `last_active_at`. </param>
        /// <param name="days"> The number of days after the anchor time that the vector store will expire. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal VectorStoreExpirationAfter(VectorStoreExpirationAfterAnchor anchor, int days, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Anchor = anchor;
            Days = days;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="VectorStoreExpirationAfter"/> for deserialization. </summary>
        internal VectorStoreExpirationAfter()
        {
        }

        /// <summary> Anchor timestamp after which the expiration policy applies. Supported anchors: `last_active_at`. </summary>
        public VectorStoreExpirationAfterAnchor Anchor { get; } = VectorStoreExpirationAfterAnchor.LastActiveAt;

        /// <summary> The number of days after the anchor time that the vector store will expire. </summary>
        public int Days { get; set; }
    }
}
