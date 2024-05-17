// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Assistants
{
    /// <summary> The RunStepDeltaStepDetailsToolCallsCodeObjectCodeInterpreter. </summary>
    internal partial class InternalRunStepDeltaStepDetailsToolCallsCodeObjectCodeInterpreter
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

        /// <summary> Initializes a new instance of <see cref="InternalRunStepDeltaStepDetailsToolCallsCodeObjectCodeInterpreter"/>. </summary>
        internal InternalRunStepDeltaStepDetailsToolCallsCodeObjectCodeInterpreter()
        {
            Outputs = new ChangeTrackingList<RunStepUpdateCodeInterpreterOutput>();
        }

        /// <summary> Initializes a new instance of <see cref="InternalRunStepDeltaStepDetailsToolCallsCodeObjectCodeInterpreter"/>. </summary>
        /// <param name="input"> The input to the Code Interpreter tool call. </param>
        /// <param name="outputs">
        /// The outputs from the Code Interpreter tool call. Code Interpreter can output one or more items, including text (`logs`) or images (`image`). Each of these are represented by a different object type.
        /// Please note <see cref="RunStepUpdateCodeInterpreterOutput"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes..
        /// </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal InternalRunStepDeltaStepDetailsToolCallsCodeObjectCodeInterpreter(string input, IReadOnlyList<RunStepUpdateCodeInterpreterOutput> outputs, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Input = input;
            Outputs = outputs;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> The input to the Code Interpreter tool call. </summary>
        public string Input { get; }
        /// <summary>
        /// The outputs from the Code Interpreter tool call. Code Interpreter can output one or more items, including text (`logs`) or images (`image`). Each of these are represented by a different object type.
        /// Please note <see cref="RunStepUpdateCodeInterpreterOutput"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes..
        /// </summary>
        public IReadOnlyList<RunStepUpdateCodeInterpreterOutput> Outputs { get; }
    }
}
