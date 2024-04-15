// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Internal.Models
{
    /// <summary> Details of an image output from a Code Interpreter tool call within a streaming run step. </summary>
    internal partial class RunStepDeltaStepDetailsToolCallsCodeOutputImageObject
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

        /// <summary> Initializes a new instance of <see cref="RunStepDeltaStepDetailsToolCallsCodeOutputImageObject"/>. </summary>
        /// <param name="index"> The index of the output in the outputs array. </param>
        internal RunStepDeltaStepDetailsToolCallsCodeOutputImageObject(long index)
        {
            Index = index;
        }

        /// <summary> Initializes a new instance of <see cref="RunStepDeltaStepDetailsToolCallsCodeOutputImageObject"/>. </summary>
        /// <param name="index"> The index of the output in the outputs array. </param>
        /// <param name="type"> The type of the object, which is always `image`. </param>
        /// <param name="image"> The file ID data for the image. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal RunStepDeltaStepDetailsToolCallsCodeOutputImageObject(long index, RunStepDeltaStepDetailsToolCallsCodeOutputImageObjectType type, RunStepDeltaStepDetailsToolCallsCodeOutputImageObjectImage image, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Index = index;
            Type = type;
            Image = image;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="RunStepDeltaStepDetailsToolCallsCodeOutputImageObject"/> for deserialization. </summary>
        internal RunStepDeltaStepDetailsToolCallsCodeOutputImageObject()
        {
        }

        /// <summary> The index of the output in the outputs array. </summary>
        public long Index { get; }
        /// <summary> The type of the object, which is always `image`. </summary>
        public RunStepDeltaStepDetailsToolCallsCodeOutputImageObjectType Type { get; } = RunStepDeltaStepDetailsToolCallsCodeOutputImageObjectType.Image;

        /// <summary> The file ID data for the image. </summary>
        public RunStepDeltaStepDetailsToolCallsCodeOutputImageObjectImage Image { get; }
    }
}
