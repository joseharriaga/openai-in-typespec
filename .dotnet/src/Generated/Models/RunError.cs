// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Assistants
{
    /// <summary> The RunObjectLastError. </summary>
    public partial class RunError
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

        /// <summary> Initializes a new instance of <see cref="RunError"/>. </summary>
        /// <param name="code"> One of `server_error`, `rate_limit_exceeded`, or `invalid_prompt`. </param>
        /// <param name="message"> A human-readable description of the error. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="message"/> is null. </exception>
        internal RunError(RunErrorCode code, string message)
        {
            Argument.AssertNotNull(message, nameof(message));

            Code = code;
            Message = message;
        }

        /// <summary> Initializes a new instance of <see cref="RunError"/>. </summary>
        /// <param name="code"> One of `server_error`, `rate_limit_exceeded`, or `invalid_prompt`. </param>
        /// <param name="message"> A human-readable description of the error. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal RunError(RunErrorCode code, string message, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Code = code;
            Message = message;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="RunError"/> for deserialization. </summary>
        internal RunError()
        {
        }

        /// <summary> One of `server_error`, `rate_limit_exceeded`, or `invalid_prompt`. </summary>
        public RunErrorCode Code { get; }
        /// <summary> A human-readable description of the error. </summary>
        public string Message { get; }
    }
}
