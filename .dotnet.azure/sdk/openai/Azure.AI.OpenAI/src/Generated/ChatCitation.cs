// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.AI.OpenAI.Chat
{
    /// <summary> The AzureChatMessageContextCitation. </summary>
    public partial class ChatCitation
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
        /// <summary> Initializes a new instance of <see cref="ChatCitation"/>. </summary>
        /// <param name="content"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        internal ChatCitation(string content)
        {
            Argument.AssertNotNull(content, nameof(content));

            Content = content;
        }

        /// <summary> Initializes a new instance of <see cref="ChatCitation"/>. </summary>
        /// <param name="content"></param>
        /// <param name="title"></param>
        /// <param name="uri"></param>
        /// <param name="filePath"></param>
        /// <param name="chunkId"></param>
        /// <param name="rerankScore"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal ChatCitation(string content, string title, Uri uri, string filePath, string chunkId, double? rerankScore, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Content = content;
            Title = title;
            Uri = uri;
            FilePath = filePath;
            ChunkId = chunkId;
            RerankScore = rerankScore;
            SerializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="ChatCitation"/> for deserialization. </summary>
        internal ChatCitation()
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
    }
}
