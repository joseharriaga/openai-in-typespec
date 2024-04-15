// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Internal.Models
{
    /// <summary> Represents the server-sent event raised when a run enters the `cancelling` status. </summary>
    internal partial class RunCancellingStreamEvent
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

        /// <summary> Initializes a new instance of <see cref="RunCancellingStreamEvent"/>. </summary>
        /// <param name="data"> The server-sent event data payload. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        internal RunCancellingStreamEvent(RunObject data)
        {
            Argument.AssertNotNull(data, nameof(data));

            Data = data;
        }

        /// <summary> Initializes a new instance of <see cref="RunCancellingStreamEvent"/>. </summary>
        /// <param name="event"> The event label for the server-sent event, which is always `thread.run.cancelling`. </param>
        /// <param name="data"> The server-sent event data payload. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal RunCancellingStreamEvent(RunCancellingStreamEventEvent @event, RunObject data, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Event = @event;
            Data = data;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="RunCancellingStreamEvent"/> for deserialization. </summary>
        internal RunCancellingStreamEvent()
        {
        }

        /// <summary> The event label for the server-sent event, which is always `thread.run.cancelling`. </summary>
        public RunCancellingStreamEventEvent Event { get; } = RunCancellingStreamEventEvent.ThreadRunCancelling;

        /// <summary> The server-sent event data payload. </summary>
        public RunObject Data { get; }
    }
}
