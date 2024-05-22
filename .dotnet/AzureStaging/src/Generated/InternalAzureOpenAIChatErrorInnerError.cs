// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.AI.OpenAI
{
    /// <summary> The AzureOpenAIChatErrorInnerError. </summary>
    internal partial class InternalAzureOpenAIChatErrorInnerError
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

        /// <summary> Initializes a new instance of <see cref="InternalAzureOpenAIChatErrorInnerError"/>. </summary>
        internal InternalAzureOpenAIChatErrorInnerError()
        {
        }

        /// <summary> Initializes a new instance of <see cref="InternalAzureOpenAIChatErrorInnerError"/>. </summary>
        /// <param name="code"></param>
        /// <param name="revisedPrompt"></param>
        /// <param name="contentFilterResults"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal InternalAzureOpenAIChatErrorInnerError(string code, string revisedPrompt, ContentFilterResultForPrompt contentFilterResults, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Code = code;
            RevisedPrompt = revisedPrompt;
            ContentFilterResults = contentFilterResults;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Gets the code. </summary>
        internal string Code { get; set; }
        /// <summary> Gets the revised prompt. </summary>
        internal string RevisedPrompt { get; set; }
        /// <summary> Gets the content filter results. </summary>
        internal ContentFilterResultForPrompt ContentFilterResults { get; set; }
    }
}

