// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Internal.Models
{
    /// <summary>
    /// A citation within the message that points to a specific quote from a specific File associated
    /// with the assistant or the message. Generated when the assistant uses the "retrieval" tool to
    /// search files.
    /// </summary>
    internal partial class MessageDeltaContentTextAnnotationsFileCitationObject
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

        /// <summary> Initializes a new instance of <see cref="MessageDeltaContentTextAnnotationsFileCitationObject"/>. </summary>
        /// <param name="index"> The index of the annotation in a text content part. </param>
        internal MessageDeltaContentTextAnnotationsFileCitationObject(long index)
        {
            Index = index;
        }

        /// <summary> Initializes a new instance of <see cref="MessageDeltaContentTextAnnotationsFileCitationObject"/>. </summary>
        /// <param name="index"> The index of the annotation in a text content part. </param>
        /// <param name="type"> The type of the citation, which is always `file_citation`. </param>
        /// <param name="fileCitation">
        /// The text in the message content that needs to be replaced.
        ///   text?: string;
        ///
        ///   /**
        /// </param>
        /// <param name="startIndex"> The start index of the citation. </param>
        /// <param name="endIndex"> The end index of the citation. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal MessageDeltaContentTextAnnotationsFileCitationObject(long index, MessageDeltaContentTextAnnotationsFileCitationObjectType type, MessageDeltaContentTextAnnotationsFileCitationObjectFileCitation fileCitation, long? startIndex, long? endIndex, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Index = index;
            Type = type;
            FileCitation = fileCitation;
            StartIndex = startIndex;
            EndIndex = endIndex;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="MessageDeltaContentTextAnnotationsFileCitationObject"/> for deserialization. </summary>
        internal MessageDeltaContentTextAnnotationsFileCitationObject()
        {
        }

        /// <summary> The index of the annotation in a text content part. </summary>
        public long Index { get; }
        /// <summary> The type of the citation, which is always `file_citation`. </summary>
        public MessageDeltaContentTextAnnotationsFileCitationObjectType Type { get; } = MessageDeltaContentTextAnnotationsFileCitationObjectType.FileCitation;

        /// <summary>
        /// The text in the message content that needs to be replaced.
        ///   text?: string;
        ///
        ///   /**
        /// </summary>
        public MessageDeltaContentTextAnnotationsFileCitationObjectFileCitation FileCitation { get; }
        /// <summary> The start index of the citation. </summary>
        public long? StartIndex { get; }
        /// <summary> The end index of the citation. </summary>
        public long? EndIndex { get; }
    }
}
