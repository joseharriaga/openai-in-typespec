// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Assistants
{
    /// <summary> Usage statistics related to the run. This value will be `null` if the run is not in a terminal state (i.e. `in_progress`, `queued`, etc.). </summary>
    public partial class RunTokenUsage
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

        /// <summary> Initializes a new instance of <see cref="RunTokenUsage"/>. </summary>
        /// <param name="completionTokens"> Number of completion tokens used over the course of the run. </param>
        /// <param name="promptTokens"> Number of prompt tokens used over the course of the run. </param>
        /// <param name="totalTokens"> Total number of tokens used (prompt + completion). </param>
        internal RunTokenUsage(int completionTokens, int promptTokens, int totalTokens)
        {
            CompletionTokens = completionTokens;
            PromptTokens = promptTokens;
            TotalTokens = totalTokens;
        }

        /// <summary> Initializes a new instance of <see cref="RunTokenUsage"/>. </summary>
        /// <param name="completionTokens"> Number of completion tokens used over the course of the run. </param>
        /// <param name="promptTokens"> Number of prompt tokens used over the course of the run. </param>
        /// <param name="totalTokens"> Total number of tokens used (prompt + completion). </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal RunTokenUsage(int completionTokens, int promptTokens, int totalTokens, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            CompletionTokens = completionTokens;
            PromptTokens = promptTokens;
            TotalTokens = totalTokens;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="RunTokenUsage"/> for deserialization. </summary>
        internal RunTokenUsage()
        {
        }

        /// <summary> Number of completion tokens used over the course of the run. </summary>
        public int CompletionTokens { get; }
        /// <summary> Number of prompt tokens used over the course of the run. </summary>
        public int PromptTokens { get; }
        /// <summary> Total number of tokens used (prompt + completion). </summary>
        public int TotalTokens { get; }
    }
}
