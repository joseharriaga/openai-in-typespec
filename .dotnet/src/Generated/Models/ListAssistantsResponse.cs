// <auto-generated/>

using System;
using System.Collections.Generic;
using System.Linq;
using OpenAI;

namespace OpenAI.Internal.Models
{
    /// <summary> The ListAssistantsResponse. </summary>
    internal partial class ListAssistantsResponse
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

        /// <summary> Initializes a new instance of <see cref="ListAssistantsResponse"/>. </summary>
        /// <param name="data"></param>
        /// <param name="firstId"></param>
        /// <param name="lastId"></param>
        /// <param name="hasMore"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/>, <paramref name="firstId"/> or <paramref name="lastId"/> is null. </exception>
        internal ListAssistantsResponse(IEnumerable<AssistantObject> data, string firstId, string lastId, bool hasMore)
        {
            Argument.AssertNotNull(data, nameof(data));
            Argument.AssertNotNull(firstId, nameof(firstId));
            Argument.AssertNotNull(lastId, nameof(lastId));

            Data = data.ToList();
            FirstId = firstId;
            LastId = lastId;
            HasMore = hasMore;
        }

        /// <summary> Initializes a new instance of <see cref="ListAssistantsResponse"/>. </summary>
        /// <param name="object"></param>
        /// <param name="data"></param>
        /// <param name="firstId"></param>
        /// <param name="lastId"></param>
        /// <param name="hasMore"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal ListAssistantsResponse(ListAssistantsResponseObject @object, IReadOnlyList<AssistantObject> data, string firstId, string lastId, bool hasMore, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Object = @object;
            Data = data;
            FirstId = firstId;
            LastId = lastId;
            HasMore = hasMore;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="ListAssistantsResponse"/> for deserialization. </summary>
        internal ListAssistantsResponse()
        {
        }

        /// <summary> Gets the object. </summary>
        public ListAssistantsResponseObject Object { get; } = ListAssistantsResponseObject.List;

        /// <summary> Gets the data. </summary>
        public IReadOnlyList<AssistantObject> Data { get; }
        /// <summary> Gets the first id. </summary>
        public string FirstId { get; }
        /// <summary> Gets the last id. </summary>
        public string LastId { get; }
        /// <summary> Gets the has more. </summary>
        public bool HasMore { get; }
    }
}
