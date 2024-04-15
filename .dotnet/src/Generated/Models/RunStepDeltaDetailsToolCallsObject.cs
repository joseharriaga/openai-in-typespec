// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Internal.Models
{
    /// <summary> Represents details of tool calls within a streaming run step. </summary>
    internal partial class RunStepDeltaDetailsToolCallsObject
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

        /// <summary> Initializes a new instance of <see cref="RunStepDeltaDetailsToolCallsObject"/>. </summary>
        internal RunStepDeltaDetailsToolCallsObject()
        {
            ToolCalls = new ChangeTrackingList<BinaryData>();
        }

        /// <summary> Initializes a new instance of <see cref="RunStepDeltaDetailsToolCallsObject"/>. </summary>
        /// <param name="toolCalls">
        /// The object type, which is always `tool_calls`.
        ///   type: "tool_calls";
        ///
        ///   /**
        /// An array of tool calls the run step was involved in. These can be associated with one of three
        /// types of tools: `code_interpreter`, `retrieval`, or `function`.
        /// </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal RunStepDeltaDetailsToolCallsObject(IReadOnlyList<BinaryData> toolCalls, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            ToolCalls = toolCalls;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary>
        /// The object type, which is always `tool_calls`.
        ///   type: "tool_calls";
        ///
        ///   /**
        /// An array of tool calls the run step was involved in. These can be associated with one of three
        /// types of tools: `code_interpreter`, `retrieval`, or `function`.
        /// <para>
        /// To assign an object to the element of this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
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
        public IReadOnlyList<BinaryData> ToolCalls { get; }
    }
}
