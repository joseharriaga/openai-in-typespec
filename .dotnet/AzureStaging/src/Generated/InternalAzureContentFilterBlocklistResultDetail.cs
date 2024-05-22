// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.AI.OpenAI
{
    /// <summary> The AzureContentFilterBlocklistResultDetail. </summary>
    internal partial class InternalAzureContentFilterBlocklistResultDetail
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

        /// <summary> Initializes a new instance of <see cref="InternalAzureContentFilterBlocklistResultDetail"/>. </summary>
        /// <param name="filtered"></param>
        /// <param name="id"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> is null. </exception>
        internal InternalAzureContentFilterBlocklistResultDetail(bool filtered, string id)
        {
            Argument.AssertNotNull(id, nameof(id));

            Filtered = filtered;
            Id = id;
        }

        /// <summary> Initializes a new instance of <see cref="InternalAzureContentFilterBlocklistResultDetail"/>. </summary>
        /// <param name="filtered"></param>
        /// <param name="id"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal InternalAzureContentFilterBlocklistResultDetail(bool filtered, string id, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Filtered = filtered;
            Id = id;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="InternalAzureContentFilterBlocklistResultDetail"/> for deserialization. </summary>
        internal InternalAzureContentFilterBlocklistResultDetail()
        {
        }

        /// <summary> Gets the filtered. </summary>
        internal bool Filtered { get; set; }
        /// <summary> Gets the id. </summary>
        internal string Id { get; set; }
    }
}

