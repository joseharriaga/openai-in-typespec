// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Embeddings
{
    /// <summary> The CreateEmbeddingResponseUsage. </summary>
    public partial class EmbeddingTokenUsage
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
        internal IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="EmbeddingTokenUsage"/>. </summary>
        /// <param name="inputTokens"> The number of tokens used by the prompt. </param>
        /// <param name="totalTokens"> The total number of tokens used by the request. </param>
        internal EmbeddingTokenUsage(int inputTokens, int totalTokens)
        {
            InputTokens = inputTokens;
            TotalTokens = totalTokens;
        }

        /// <summary> Initializes a new instance of <see cref="EmbeddingTokenUsage"/>. </summary>
        /// <param name="inputTokens"> The number of tokens used by the prompt. </param>
        /// <param name="totalTokens"> The total number of tokens used by the request. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal EmbeddingTokenUsage(int inputTokens, int totalTokens, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            InputTokens = inputTokens;
            TotalTokens = totalTokens;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="EmbeddingTokenUsage"/> for deserialization. </summary>
        internal EmbeddingTokenUsage()
        {
        }
        /// <summary> The total number of tokens used by the request. </summary>
        public int TotalTokens { get; }
    }
}
