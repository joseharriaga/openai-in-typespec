// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.AI.OpenAI.Chat
{
    /// <summary> The AzureChatMessageContextAllRetrievedDocuments. </summary>
    public partial class ChatRetrievedDocument
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
        /// <summary> Initializes a new instance of <see cref="ChatRetrievedDocument"/>. </summary>
        /// <param name="content"></param>
        /// <param name="searchQueries"></param>
        /// <param name="dataSourceIndex"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> or <paramref name="searchQueries"/> is null. </exception>
        internal ChatRetrievedDocument(string content, IEnumerable<string> searchQueries, int dataSourceIndex)
        {
            Argument.AssertNotNull(content, nameof(content));
            Argument.AssertNotNull(searchQueries, nameof(searchQueries));

            Content = content;
            SearchQueries = searchQueries.ToList();
            DataSourceIndex = dataSourceIndex;
        }

        /// <summary> Initializes a new instance of <see cref="ChatRetrievedDocument"/>. </summary>
        /// <param name="content"></param>
        /// <param name="title"></param>
        /// <param name="uri"></param>
        /// <param name="filePath"></param>
        /// <param name="chunkId"></param>
        /// <param name="rerankScore"></param>
        /// <param name="searchQueries"></param>
        /// <param name="dataSourceIndex"></param>
        /// <param name="originalSearchScore"></param>
        /// <param name="filterReason"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal ChatRetrievedDocument(string content, string title, Uri uri, string filePath, string chunkId, double? rerankScore, IReadOnlyList<string> searchQueries, int dataSourceIndex, double? originalSearchScore, ChatDocumentFilterReason? filterReason, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Content = content;
            Title = title;
            Uri = uri;
            FilePath = filePath;
            ChunkId = chunkId;
            RerankScore = rerankScore;
            SearchQueries = searchQueries;
            DataSourceIndex = dataSourceIndex;
            OriginalSearchScore = originalSearchScore;
            FilterReason = filterReason;
            SerializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="ChatRetrievedDocument"/> for deserialization. </summary>
        internal ChatRetrievedDocument()
        {
        }

        /// <summary> Gets the content. </summary>
        public string Content { get; }
        /// <summary> Gets the title. </summary>
        public string Title { get; }
        /// <summary> Gets the chunk id. </summary>
        public string ChunkId { get; }
        /// <summary> Gets the rerank score. </summary>
        public double? RerankScore { get; }
        /// <summary> Gets the search queries. </summary>
        public IReadOnlyList<string> SearchQueries { get; }
        /// <summary> Gets the data source index. </summary>
        public int DataSourceIndex { get; }
        /// <summary> Gets the original search score. </summary>
        public double? OriginalSearchScore { get; }
        /// <summary> Gets the filter reason. </summary>
        public ChatDocumentFilterReason? FilterReason { get; }
    }
}
