// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Internal.Models
{
    /// <summary> The MessageDeltaContentImageFileObjectImageFile. </summary>
    internal partial class InternalMessageDeltaContentImageFileObjectImageFile
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

        /// <summary> Initializes a new instance of <see cref="InternalMessageDeltaContentImageFileObjectImageFile"/>. </summary>
        internal InternalMessageDeltaContentImageFileObjectImageFile()
        {
        }

        /// <summary> Initializes a new instance of <see cref="InternalMessageDeltaContentImageFileObjectImageFile"/>. </summary>
        /// <param name="fileId"> The [File](/docs/api-reference/files) ID of the image in the message content. Set `purpose="vision"` when uploading the File if you need to later display the file content. </param>
        /// <param name="internalDetail"> Specifies the detail level of the image if specified by the user. `low` uses fewer tokens, you can opt in to high resolution using `high`. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal InternalMessageDeltaContentImageFileObjectImageFile(string fileId, string internalDetail, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            FileId = fileId;
            InternalDetail = internalDetail;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> The [File](/docs/api-reference/files) ID of the image in the message content. Set `purpose="vision"` when uploading the File if you need to later display the file content. </summary>
        public string FileId { get; }
    }
}
