// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using OpenAI.FineTuning;

namespace OpenAI.Internal.Models
{
    /// <summary> The ListPaginatedFineTuningJobsResponse. </summary>
    internal partial class ListPaginatedFineTuningJobsResponse
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

        /// <summary> Initializes a new instance of <see cref="ListPaginatedFineTuningJobsResponse"/>. </summary>
        /// <param name="data"></param>
        /// <param name="hasMore"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        internal ListPaginatedFineTuningJobsResponse(IEnumerable<FineTuningJob> data, bool hasMore)
        {
            Argument.AssertNotNull(data, nameof(data));

            Data = data.ToList();
            HasMore = hasMore;
        }

        /// <summary> Initializes a new instance of <see cref="ListPaginatedFineTuningJobsResponse"/>. </summary>
        /// <param name="data"></param>
        /// <param name="hasMore"></param>
        /// <param name="object"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal ListPaginatedFineTuningJobsResponse(IReadOnlyList<FineTuningJob> data, bool hasMore, ListPaginatedFineTuningJobsResponseObject @object, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Data = data;
            HasMore = hasMore;
            Object = @object;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="ListPaginatedFineTuningJobsResponse"/> for deserialization. </summary>
        internal ListPaginatedFineTuningJobsResponse()
        {
        }

        /// <summary> Gets the data. </summary>
        public IReadOnlyList<FineTuningJob> Data { get; }
        /// <summary> Gets the has more. </summary>
        public bool HasMore { get; }
        /// <summary> Gets the object. </summary>
        public ListPaginatedFineTuningJobsResponseObject Object { get; } = ListPaginatedFineTuningJobsResponseObject.List;
    }
}
