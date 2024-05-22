// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.AI.OpenAI
{
    /// <summary> The AzureContentFilterSeverityResult. </summary>
    public partial class ContentFilterSeverityResult
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

        /// <summary> Initializes a new instance of <see cref="ContentFilterSeverityResult"/>. </summary>
        /// <param name="filtered"></param>
        /// <param name="severity"></param>
        internal ContentFilterSeverityResult(bool filtered, ContentFilterSeverity severity)
        {
            Filtered = filtered;
            Severity = severity;
        }

        /// <summary> Initializes a new instance of <see cref="ContentFilterSeverityResult"/>. </summary>
        /// <param name="filtered"></param>
        /// <param name="severity"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal ContentFilterSeverityResult(bool filtered, ContentFilterSeverity severity, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Filtered = filtered;
            Severity = severity;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="ContentFilterSeverityResult"/> for deserialization. </summary>
        internal ContentFilterSeverityResult()
        {
        }

        /// <summary> Gets the filtered. </summary>
        public bool Filtered { get; }
    }
}
