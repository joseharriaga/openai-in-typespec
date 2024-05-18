// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.AI.OpenAI
{
    /// <summary> The AzureChatCompletionResponseMessageContextCitation. </summary>
    public partial class AzureChatCompletionResponseMessageContextCitation
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

        /// <summary> Initializes a new instance of <see cref="AzureChatCompletionResponseMessageContextCitation"/>. </summary>
        /// <param name="content"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        internal AzureChatCompletionResponseMessageContextCitation(string content)
        {
            Argument.AssertNotNull(content, nameof(content));

            Content = content;
        }

        /// <summary> Initializes a new instance of <see cref="AzureChatCompletionResponseMessageContextCitation"/>. </summary>
        /// <param name="content"></param>
        /// <param name="title"></param>
        /// <param name="url"></param>
        /// <param name="filepath"></param>
        /// <param name="chunkId"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal AzureChatCompletionResponseMessageContextCitation(string content, string title, string url, string filepath, string chunkId, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Content = content;
            Title = title;
            Url = url;
            Filepath = filepath;
            ChunkId = chunkId;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="AzureChatCompletionResponseMessageContextCitation"/> for deserialization. </summary>
        internal AzureChatCompletionResponseMessageContextCitation()
        {
        }

        /// <summary> Gets the content. </summary>
        public string Content { get; }
        /// <summary> Gets the title. </summary>
        public string Title { get; }
        /// <summary> Gets the url. </summary>
        public string Url { get; }
        /// <summary> Gets the filepath. </summary>
        public string Filepath { get; }
        /// <summary> Gets the chunk id. </summary>
        public string ChunkId { get; }
    }
}
