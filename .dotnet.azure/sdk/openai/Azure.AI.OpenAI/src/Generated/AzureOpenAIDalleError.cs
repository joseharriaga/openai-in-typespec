// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.AI.OpenAI
{
    /// <summary> The AzureOpenAIDalleError. </summary>
    internal partial class AzureOpenAIDalleError
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
        /// <summary> Initializes a new instance of <see cref="AzureOpenAIDalleError"/>. </summary>
        internal AzureOpenAIDalleError()
        {
        }

        /// <summary> Initializes a new instance of <see cref="AzureOpenAIDalleError"/>. </summary>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <param name="param"></param>
        /// <param name="type"></param>
        /// <param name="innerError"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal AzureOpenAIDalleError(string code, string message, string param, string type, InternalAzureOpenAIDalleErrorInnerError innerError, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Code = code;
            Message = message;
            Param = param;
            Type = type;
            InnerError = innerError;
            SerializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Gets the code. </summary>
        public string Code { get; }
        /// <summary> Gets the message. </summary>
        public string Message { get; }
        /// <summary> Gets the param. </summary>
        public string Param { get; }
        /// <summary> Gets the type. </summary>
        public string Type { get; }
        /// <summary> Gets the inner error. </summary>
        public InternalAzureOpenAIDalleErrorInnerError InnerError { get; }
    }
}
