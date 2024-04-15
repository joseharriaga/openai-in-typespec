// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Internal.Models
{
    /// <summary> Represents the server-sent event raised when the event stream is at its end. </summary>
    internal partial class DoneStreamEvent
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

        /// <summary> Initializes a new instance of <see cref="DoneStreamEvent"/>. </summary>
        internal DoneStreamEvent()
        {
        }

        /// <summary> Initializes a new instance of <see cref="DoneStreamEvent"/>. </summary>
        /// <param name="event"> The event label for the server-sent event, which is always `error`. </param>
        /// <param name="data"> The server-sent event data payload. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal DoneStreamEvent(DoneStreamEventEvent @event, DoneStreamEventData data, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Event = @event;
            Data = data;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> The event label for the server-sent event, which is always `error`. </summary>
        public DoneStreamEventEvent Event { get; } = DoneStreamEventEvent.Done;

        /// <summary> The server-sent event data payload. </summary>
        public DoneStreamEventData Data { get; } = DoneStreamEventData.DONE;
    }
}
