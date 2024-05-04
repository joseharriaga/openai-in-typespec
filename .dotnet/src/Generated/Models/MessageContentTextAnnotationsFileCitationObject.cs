// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Internal.Models
{
    /// <summary>
    /// A citation within the message that points to a specific quote from a specific File associated
    /// with the assistant or the message. Generated when the assistant uses the "file_search" tool to
    /// search files.
    /// </summary>
    internal partial class MessageContentTextAnnotationsFileCitationObject
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

        /// <summary> Initializes a new instance of <see cref="MessageContentTextAnnotationsFileCitationObject"/>. </summary>
        /// <param name="text"> The text in the message content that needs to be replaced. </param>
        /// <param name="fileCitation"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="text"/> or <paramref name="fileCitation"/> is null. </exception>
        internal MessageContentTextAnnotationsFileCitationObject(string text, MessageContentTextAnnotationsFileCitationObjectFileCitation fileCitation, int startIndex, int endIndex)
        {
            Argument.AssertNotNull(text, nameof(text));
            Argument.AssertNotNull(fileCitation, nameof(fileCitation));

            Text = text;
            FileCitation = fileCitation;
            StartIndex = startIndex;
            EndIndex = endIndex;
        }

        /// <summary> Initializes a new instance of <see cref="MessageContentTextAnnotationsFileCitationObject"/>. </summary>
        /// <param name="type"> Always `file_citation`. </param>
        /// <param name="text"> The text in the message content that needs to be replaced. </param>
        /// <param name="fileCitation"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal MessageContentTextAnnotationsFileCitationObject(MessageContentTextAnnotationsFileCitationObjectType type, string text, MessageContentTextAnnotationsFileCitationObjectFileCitation fileCitation, int startIndex, int endIndex, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Type = type;
            Text = text;
            FileCitation = fileCitation;
            StartIndex = startIndex;
            EndIndex = endIndex;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="MessageContentTextAnnotationsFileCitationObject"/> for deserialization. </summary>
        internal MessageContentTextAnnotationsFileCitationObject()
        {
        }

        /// <summary> Always `file_citation`. </summary>
        public MessageContentTextAnnotationsFileCitationObjectType Type { get; } = MessageContentTextAnnotationsFileCitationObjectType.FileCitation;

        /// <summary> The text in the message content that needs to be replaced. </summary>
        public string Text { get; }
        /// <summary> Gets the file citation. </summary>
        public MessageContentTextAnnotationsFileCitationObjectFileCitation FileCitation { get; }
        /// <summary> Gets the start index. </summary>
        public int StartIndex { get; }
        /// <summary> Gets the end index. </summary>
        public int EndIndex { get; }
    }
}
