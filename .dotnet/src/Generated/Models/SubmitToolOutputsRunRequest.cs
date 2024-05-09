// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenAI.Internal.Models
{
    /// <summary> The SubmitToolOutputsRunRequest. </summary>
    internal partial class SubmitToolOutputsRunRequest
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

        /// <summary> Initializes a new instance of <see cref="SubmitToolOutputsRunRequest"/>. </summary>
        /// <param name="toolOutputs"> A list of tools for which the outputs are being submitted. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="toolOutputs"/> is null. </exception>
        public SubmitToolOutputsRunRequest(IEnumerable<SubmitToolOutputsRunRequestToolOutput> toolOutputs)
        {
            Argument.AssertNotNull(toolOutputs, nameof(toolOutputs));

            ToolOutputs = toolOutputs.ToList();
        }

        /// <summary> Initializes a new instance of <see cref="SubmitToolOutputsRunRequest"/>. </summary>
        /// <param name="toolOutputs"> A list of tools for which the outputs are being submitted. </param>
        /// <param name="stream"> If `true`, returns a stream of events that happen during the Run as server-sent events, terminating when the Run enters a terminal state with a `data: [DONE]` message. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal SubmitToolOutputsRunRequest(IList<SubmitToolOutputsRunRequestToolOutput> toolOutputs, bool? stream, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            ToolOutputs = toolOutputs;
            Stream = stream;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="SubmitToolOutputsRunRequest"/> for deserialization. </summary>
        internal SubmitToolOutputsRunRequest()
        {
        }

        /// <summary> A list of tools for which the outputs are being submitted. </summary>
        public IList<SubmitToolOutputsRunRequestToolOutput> ToolOutputs { get; }
        /// <summary> If `true`, returns a stream of events that happen during the Run as server-sent events, terminating when the Run enters a terminal state with a `data: [DONE]` message. </summary>
        public bool? Stream { get; set; }
    }
}
