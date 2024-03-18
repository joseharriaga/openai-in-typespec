// <auto-generated/>

using System;
using System.Collections.Generic;
using OpenAI;

namespace OpenAI.Internal.Models
{
    /// <summary> The ChatCompletionResponseMessageFunctionCall. </summary>
    internal partial class ChatCompletionResponseMessageFunctionCall
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

        /// <summary> Initializes a new instance of <see cref="ChatCompletionResponseMessageFunctionCall"/>. </summary>
        /// <param name="arguments">
        /// The arguments to call the function with, as generated by the model in JSON format. Note that
        /// the model does not always generate valid JSON, and may hallucinate parameters not defined by
        /// your function schema. Validate the arguments in your code before calling your function.
        /// </param>
        /// <param name="name"> The name of the function to call. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="arguments"/> or <paramref name="name"/> is null. </exception>
        internal ChatCompletionResponseMessageFunctionCall(string arguments, string name)
        {
            Argument.AssertNotNull(arguments, nameof(arguments));
            Argument.AssertNotNull(name, nameof(name));

            Arguments = arguments;
            Name = name;
        }

        /// <summary> Initializes a new instance of <see cref="ChatCompletionResponseMessageFunctionCall"/>. </summary>
        /// <param name="arguments">
        /// The arguments to call the function with, as generated by the model in JSON format. Note that
        /// the model does not always generate valid JSON, and may hallucinate parameters not defined by
        /// your function schema. Validate the arguments in your code before calling your function.
        /// </param>
        /// <param name="name"> The name of the function to call. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal ChatCompletionResponseMessageFunctionCall(string arguments, string name, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Arguments = arguments;
            Name = name;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="ChatCompletionResponseMessageFunctionCall"/> for deserialization. </summary>
        internal ChatCompletionResponseMessageFunctionCall()
        {
        }

        /// <summary>
        /// The arguments to call the function with, as generated by the model in JSON format. Note that
        /// the model does not always generate valid JSON, and may hallucinate parameters not defined by
        /// your function schema. Validate the arguments in your code before calling your function.
        /// </summary>
        public string Arguments { get; }
        /// <summary> The name of the function to call. </summary>
        public string Name { get; }
    }
}
