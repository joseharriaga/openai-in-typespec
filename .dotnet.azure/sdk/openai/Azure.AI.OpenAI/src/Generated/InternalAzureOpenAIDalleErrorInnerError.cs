// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.AI.OpenAI
{
    /// <summary> The AzureOpenAIDalleErrorInnerError. </summary>
    internal partial class InternalAzureOpenAIDalleErrorInnerError
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
        /// <summary> Initializes a new instance of <see cref="InternalAzureOpenAIDalleErrorInnerError"/>. </summary>
        internal InternalAzureOpenAIDalleErrorInnerError()
        {
        }

        /// <summary> Initializes a new instance of <see cref="InternalAzureOpenAIDalleErrorInnerError"/>. </summary>
        /// <param name="code"> The code associated with the inner error. </param>
        /// <param name="revisedPrompt"> If applicable, the modified prompt used for generation. </param>
        /// <param name="contentFilterResults"> The content filter result details associated with the inner error. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal InternalAzureOpenAIDalleErrorInnerError(InternalAzureOpenAIDalleErrorInnerErrorCode? code, string revisedPrompt, RequestImageContentFilterResult contentFilterResults, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Code = code;
            RevisedPrompt = revisedPrompt;
            ContentFilterResults = contentFilterResults;
            SerializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> The code associated with the inner error. </summary>
        internal InternalAzureOpenAIDalleErrorInnerErrorCode? Code { get; set; }
        /// <summary> If applicable, the modified prompt used for generation. </summary>
        internal string RevisedPrompt { get; set; }
        /// <summary> The content filter result details associated with the inner error. </summary>
        internal RequestImageContentFilterResult ContentFilterResults { get; set; }
    }
}



