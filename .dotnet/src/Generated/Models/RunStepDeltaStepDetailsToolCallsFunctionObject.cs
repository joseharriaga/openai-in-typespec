// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Internal.Models
{
    /// <summary> Details of a function tool call that a streaming run step was involved in. </summary>
    internal partial class RunStepDeltaStepDetailsToolCallsFunctionObject
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

        /// <summary> Initializes a new instance of <see cref="RunStepDeltaStepDetailsToolCallsFunctionObject"/>. </summary>
        /// <param name="index"> The index of the tool call in the tool calls array. </param>
        /// <param name="function"> The definition of the function that was called. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="function"/> is null. </exception>
        internal RunStepDeltaStepDetailsToolCallsFunctionObject(long index, RunStepDeltaStepDetailsToolCallsFunctionObjectFunction function)
        {
            Argument.AssertNotNull(function, nameof(function));

            Index = index;
            Function = function;
        }

        /// <summary> Initializes a new instance of <see cref="RunStepDeltaStepDetailsToolCallsFunctionObject"/>. </summary>
        /// <param name="index"> The index of the tool call in the tool calls array. </param>
        /// <param name="id"> The ID of the tool call. </param>
        /// <param name="type"> The type of the tool call, which is always `retrieval`. </param>
        /// <param name="function"> The definition of the function that was called. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal RunStepDeltaStepDetailsToolCallsFunctionObject(long index, string id, RunStepDeltaStepDetailsToolCallsFunctionObjectType type, RunStepDeltaStepDetailsToolCallsFunctionObjectFunction function, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Index = index;
            Id = id;
            Type = type;
            Function = function;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="RunStepDeltaStepDetailsToolCallsFunctionObject"/> for deserialization. </summary>
        internal RunStepDeltaStepDetailsToolCallsFunctionObject()
        {
        }

        /// <summary> The index of the tool call in the tool calls array. </summary>
        public long Index { get; }
        /// <summary> The ID of the tool call. </summary>
        public string Id { get; }
        /// <summary> The type of the tool call, which is always `retrieval`. </summary>
        public RunStepDeltaStepDetailsToolCallsFunctionObjectType Type { get; } = RunStepDeltaStepDetailsToolCallsFunctionObjectType.Function;

        /// <summary> The definition of the function that was called. </summary>
        public RunStepDeltaStepDetailsToolCallsFunctionObjectFunction Function { get; }
    }
}
