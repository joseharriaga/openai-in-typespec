// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.AI.OpenAI.Assistants
{
    /// <summary> The BingSearchToolDefinitionBrowser. </summary>
    internal partial class InternalBingSearchToolDefinitionBrowser
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
        internal IDictionary<string, BinaryData> SerializedAdditionalRawData { get; set; }
        /// <summary> Initializes a new instance of <see cref="InternalBingSearchToolDefinitionBrowser"/>. </summary>
        /// <param name="bingResourceId"> The resource ID of the Bing Search resource to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="bingResourceId"/> is null. </exception>
        internal InternalBingSearchToolDefinitionBrowser(string bingResourceId)
        {
            Argument.AssertNotNull(bingResourceId, nameof(bingResourceId));

            BingResourceId = bingResourceId;
        }

        /// <summary> Initializes a new instance of <see cref="InternalBingSearchToolDefinitionBrowser"/>. </summary>
        /// <param name="bingResourceId"> The resource ID of the Bing Search resource to use. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal InternalBingSearchToolDefinitionBrowser(string bingResourceId, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            BingResourceId = bingResourceId;
            SerializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="InternalBingSearchToolDefinitionBrowser"/> for deserialization. </summary>
        internal InternalBingSearchToolDefinitionBrowser()
        {
        }

        /// <summary> The resource ID of the Bing Search resource to use. </summary>
        internal string BingResourceId { get; set; }
    }
}

