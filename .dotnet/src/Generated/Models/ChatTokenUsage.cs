// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Chat
{
    /// <summary> Usage statistics for the completion request. </summary>
    public partial class ChatTokenUsage
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

        /// <summary> Initializes a new instance of <see cref="ChatTokenUsage"/>. </summary>
        /// <param name="outputTokens"> Number of tokens in the generated completion. </param>
        /// <param name="inputTokens"> Number of tokens in the prompt. </param>
        /// <param name="totalTokens"> Total number of tokens used in the request (prompt + completion). </param>
        internal ChatTokenUsage(int outputTokens, int inputTokens, int totalTokens)
        {
            OutputTokens = outputTokens;
            InputTokens = inputTokens;
            TotalTokens = totalTokens;
        }

        /// <summary> Initializes a new instance of <see cref="ChatTokenUsage"/>. </summary>
        /// <param name="outputTokens"> Number of tokens in the generated completion. </param>
        /// <param name="inputTokens"> Number of tokens in the prompt. </param>
        /// <param name="totalTokens"> Total number of tokens used in the request (prompt + completion). </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal ChatTokenUsage(int outputTokens, int inputTokens, int totalTokens, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            OutputTokens = outputTokens;
            InputTokens = inputTokens;
            TotalTokens = totalTokens;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="ChatTokenUsage"/> for deserialization. </summary>
        internal ChatTokenUsage()
        {
        }
        /// <summary> Total number of tokens used in the request (prompt + completion). </summary>
        public int TotalTokens { get; }
    }
}