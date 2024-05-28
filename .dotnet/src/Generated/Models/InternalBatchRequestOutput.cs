// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Batch
{
    /// <summary> The per-line object of the batch output and error files. </summary>
    internal partial class InternalBatchRequestOutput
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

        /// <summary> Initializes a new instance of <see cref="InternalBatchRequestOutput"/>. </summary>
        internal InternalBatchRequestOutput()
        {
        }

        /// <summary> Initializes a new instance of <see cref="InternalBatchRequestOutput"/>. </summary>
        /// <param name="id"></param>
        /// <param name="customId"> A developer-provided per-request id that will be used to match outputs to inputs. </param>
        /// <param name="response"></param>
        /// <param name="error"> For requests that failed with a non-HTTP error, this will contain more information on the cause of the failure. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal InternalBatchRequestOutput(string id, string customId, InternalBatchRequestOutputResponse response, InternalBatchRequestOutputError error, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Id = id;
            CustomId = customId;
            Response = response;
            Error = error;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Gets the id. </summary>
        public string Id { get; }
        /// <summary> A developer-provided per-request id that will be used to match outputs to inputs. </summary>
        public string CustomId { get; }
        /// <summary> Gets the response. </summary>
        public InternalBatchRequestOutputResponse Response { get; }
        /// <summary> For requests that failed with a non-HTTP error, this will contain more information on the cause of the failure. </summary>
        public InternalBatchRequestOutputError Error { get; }
    }
}