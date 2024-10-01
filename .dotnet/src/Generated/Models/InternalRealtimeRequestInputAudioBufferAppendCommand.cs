// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.RealtimeConversation
{
    internal partial class InternalRealtimeRequestInputAudioBufferAppendCommand : InternalRealtimeRequestCommand
    {
        public InternalRealtimeRequestInputAudioBufferAppendCommand(BinaryData audio)
        {
            Argument.AssertNotNull(audio, nameof(audio));

            Kind = InternalRealtimeRequestCommandType.InputAudioBufferAppend;
            Audio = audio;
        }

        internal InternalRealtimeRequestInputAudioBufferAppendCommand(InternalRealtimeRequestCommandType kind, string eventId, IDictionary<string, BinaryData> serializedAdditionalRawData, BinaryData audio) : base(kind, eventId, serializedAdditionalRawData)
        {
            Audio = audio;
        }

        internal InternalRealtimeRequestInputAudioBufferAppendCommand()
        {
        }

        public BinaryData Audio { get; }
    }
}
