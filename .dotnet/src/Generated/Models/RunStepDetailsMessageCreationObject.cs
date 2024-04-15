// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Internal.Models
{
    /// <summary> Details of the message creation by the run step. </summary>
    internal partial class RunStepDetailsMessageCreationObject
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

        /// <summary> Initializes a new instance of <see cref="RunStepDetailsMessageCreationObject"/>. </summary>
        /// <param name="messageCreation"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="messageCreation"/> is null. </exception>
        internal RunStepDetailsMessageCreationObject(RunStepDetailsMessageCreationObjectMessageCreation messageCreation)
        {
            Argument.AssertNotNull(messageCreation, nameof(messageCreation));

            MessageCreation = messageCreation;
        }

        /// <summary> Initializes a new instance of <see cref="RunStepDetailsMessageCreationObject"/>. </summary>
        /// <param name="type"> Details of the message creation by the run step. </param>
        /// <param name="messageCreation"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal RunStepDetailsMessageCreationObject(RunStepDetailsMessageCreationObjectType type, RunStepDetailsMessageCreationObjectMessageCreation messageCreation, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Type = type;
            MessageCreation = messageCreation;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="RunStepDetailsMessageCreationObject"/> for deserialization. </summary>
        internal RunStepDetailsMessageCreationObject()
        {
        }

        /// <summary> Details of the message creation by the run step. </summary>
        public RunStepDetailsMessageCreationObjectType Type { get; } = RunStepDetailsMessageCreationObjectType.MessageCreation;

        /// <summary> Gets the message creation. </summary>
        public RunStepDetailsMessageCreationObjectMessageCreation MessageCreation { get; }
    }
}
