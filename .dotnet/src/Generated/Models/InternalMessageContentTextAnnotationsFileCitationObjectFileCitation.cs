// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Assistants
{
    /// <summary> The MessageContentTextAnnotationsFileCitationObjectFileCitation. </summary>
    internal partial class InternalMessageContentTextAnnotationsFileCitationObjectFileCitation
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
        internal IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="InternalMessageContentTextAnnotationsFileCitationObjectFileCitation"/>. </summary>
        /// <param name="fileId"> The ID of the specific File the citation is from. </param>
        /// <param name="quote"> The specific quote in the file. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fileId"/> or <paramref name="quote"/> is null. </exception>
        public InternalMessageContentTextAnnotationsFileCitationObjectFileCitation(string fileId, string quote)
        {
            Argument.AssertNotNull(fileId, nameof(fileId));
            Argument.AssertNotNull(quote, nameof(quote));

            FileId = fileId;
            Quote = quote;
        }

        /// <summary> Initializes a new instance of <see cref="InternalMessageContentTextAnnotationsFileCitationObjectFileCitation"/>. </summary>
        /// <param name="fileId"> The ID of the specific File the citation is from. </param>
        /// <param name="quote"> The specific quote in the file. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal InternalMessageContentTextAnnotationsFileCitationObjectFileCitation(string fileId, string quote, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            FileId = fileId;
            Quote = quote;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="InternalMessageContentTextAnnotationsFileCitationObjectFileCitation"/> for deserialization. </summary>
        internal InternalMessageContentTextAnnotationsFileCitationObjectFileCitation()
        {
        }

        /// <summary> The ID of the specific File the citation is from. </summary>
        public string FileId { get; set; }
        /// <summary> The specific quote in the file. </summary>
        public string Quote { get; set; }
    }
}
