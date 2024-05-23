// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Assistants
{
    /// <summary> A citation within the message that points to a specific quote from a specific File associated with the assistant or the message. Generated when the assistant uses the "file_search" tool to search files. </summary>
    internal partial class MessageContentTextAnnotationsFileCitationObject : MessageContentTextObjectAnnotation
    {
        /// <summary> Initializes a new instance of <see cref="MessageContentTextAnnotationsFileCitationObject"/>. </summary>
        /// <param name="text"> The text in the message content that needs to be replaced. </param>
        /// <param name="fileCitation"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="text"/> or <paramref name="fileCitation"/> is null. </exception>
        public MessageContentTextAnnotationsFileCitationObject(string text, InternalMessageContentTextAnnotationsFileCitationObjectFileCitation fileCitation, int startIndex, int endIndex)
        {
            Argument.AssertNotNull(text, nameof(text));
            Argument.AssertNotNull(fileCitation, nameof(fileCitation));

            Type = "file_citation";
            Text = text;
            FileCitation = fileCitation;
            StartIndex = startIndex;
            EndIndex = endIndex;
        }

        /// <summary> Initializes a new instance of <see cref="MessageContentTextAnnotationsFileCitationObject"/>. </summary>
        /// <param name="type"> The discriminated type identifier for the content item. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        /// <param name="text"> The text in the message content that needs to be replaced. </param>
        /// <param name="fileCitation"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        internal MessageContentTextAnnotationsFileCitationObject(string type, IDictionary<string, BinaryData> serializedAdditionalRawData, string text, InternalMessageContentTextAnnotationsFileCitationObjectFileCitation fileCitation, int startIndex, int endIndex) : base(type, serializedAdditionalRawData)
        {
            Text = text;
            FileCitation = fileCitation;
            StartIndex = startIndex;
            EndIndex = endIndex;
        }

        /// <summary> Initializes a new instance of <see cref="MessageContentTextAnnotationsFileCitationObject"/> for deserialization. </summary>
        internal MessageContentTextAnnotationsFileCitationObject()
        {
        }

        /// <summary> The text in the message content that needs to be replaced. </summary>
        public string Text { get; init; }
        /// <summary> Gets or sets the file citation. </summary>
        public InternalMessageContentTextAnnotationsFileCitationObjectFileCitation FileCitation { get; init; }
        /// <summary> Gets or sets the start index. </summary>
        public int StartIndex { get; init; }
        /// <summary> Gets or sets the end index. </summary>
        public int EndIndex { get; init; }
    }
}
