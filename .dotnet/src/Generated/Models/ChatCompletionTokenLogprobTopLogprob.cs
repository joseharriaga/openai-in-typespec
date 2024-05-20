// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace OpenAI.Internal.Models
{
    /// <summary> The ChatCompletionTokenLogprobTopLogprob. </summary>
    internal partial class ChatCompletionTokenLogprobTopLogprob
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

        /// <summary>
        /// Gets the dictionary containing additional raw data to serialize.
        /// </summary>
        /// <remarks>
        /// NOTE: This mechanism added for subclients pending availability of a C# language feature.
        ///       It is subject to change and not intended for stable use.
        /// </remarks>
        [Experimental("OPENAI002")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IDictionary<string, BinaryData> SerializedAdditionalRawData
            => _serializedAdditionalRawData ??= new ChangeTrackingDictionary<string, BinaryData>();

        /// <summary> Initializes a new instance of <see cref="ChatCompletionTokenLogprobTopLogprob"/>. </summary>
        /// <param name="token"> The token. </param>
        /// <param name="logprob"> The log probability of this token, if it is within the top 20 most likely tokens. Otherwise, the value `-9999.0` is used to signify that the token is very unlikely. </param>
        /// <param name="bytes"> A list of integers representing the UTF-8 bytes representation of the token. Useful in instances where characters are represented by multiple tokens and their byte representations must be combined to generate the correct text representation. Can be `null` if there is no bytes representation for the token. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="token"/> is null. </exception>
        internal ChatCompletionTokenLogprobTopLogprob(string token, float logprob, IEnumerable<int> bytes)
        {
            Argument.AssertNotNull(token, nameof(token));

            Token = token;
            Logprob = logprob;
            Bytes = bytes?.ToList();
        }

        /// <summary> Initializes a new instance of <see cref="ChatCompletionTokenLogprobTopLogprob"/>. </summary>
        /// <param name="token"> The token. </param>
        /// <param name="logprob"> The log probability of this token, if it is within the top 20 most likely tokens. Otherwise, the value `-9999.0` is used to signify that the token is very unlikely. </param>
        /// <param name="bytes"> A list of integers representing the UTF-8 bytes representation of the token. Useful in instances where characters are represented by multiple tokens and their byte representations must be combined to generate the correct text representation. Can be `null` if there is no bytes representation for the token. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal ChatCompletionTokenLogprobTopLogprob(string token, float logprob, IReadOnlyList<int> bytes, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Token = token;
            Logprob = logprob;
            Bytes = bytes;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="ChatCompletionTokenLogprobTopLogprob"/> for deserialization. </summary>
        internal ChatCompletionTokenLogprobTopLogprob()
        {
        }

        /// <summary> The token. </summary>
        public string Token { get; }
        /// <summary> The log probability of this token, if it is within the top 20 most likely tokens. Otherwise, the value `-9999.0` is used to signify that the token is very unlikely. </summary>
        public float Logprob { get; }
        /// <summary> A list of integers representing the UTF-8 bytes representation of the token. Useful in instances where characters are represented by multiple tokens and their byte representations must be combined to generate the correct text representation. Can be `null` if there is no bytes representation for the token. </summary>
        public IReadOnlyList<int> Bytes { get; }
    }
}

