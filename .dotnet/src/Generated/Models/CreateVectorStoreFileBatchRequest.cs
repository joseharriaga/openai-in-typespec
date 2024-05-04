// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenAI.Internal.Models
{
    /// <summary> The CreateVectorStoreFileBatchRequest. </summary>
    internal partial class CreateVectorStoreFileBatchRequest
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

        /// <summary> Initializes a new instance of <see cref="CreateVectorStoreFileBatchRequest"/>. </summary>
        /// <param name="fileIds"> A list of [File](/docs/api-reference/files) IDs that the vector store should use. Useful for tools like `file_search` that can access files. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fileIds"/> is null. </exception>
        internal CreateVectorStoreFileBatchRequest(IEnumerable<string> fileIds)
        {
            Argument.AssertNotNull(fileIds, nameof(fileIds));

            FileIds = fileIds.ToList();
        }

        /// <summary> Initializes a new instance of <see cref="CreateVectorStoreFileBatchRequest"/>. </summary>
        /// <param name="fileIds"> A list of [File](/docs/api-reference/files) IDs that the vector store should use. Useful for tools like `file_search` that can access files. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal CreateVectorStoreFileBatchRequest(IReadOnlyList<string> fileIds, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            FileIds = fileIds;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="CreateVectorStoreFileBatchRequest"/> for deserialization. </summary>
        internal CreateVectorStoreFileBatchRequest()
        {
        }

        /// <summary> A list of [File](/docs/api-reference/files) IDs that the vector store should use. Useful for tools like `file_search` that can access files. </summary>
        public IReadOnlyList<string> FileIds { get; }
    }
}
