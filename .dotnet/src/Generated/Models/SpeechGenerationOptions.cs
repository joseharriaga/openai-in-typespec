// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Audio
{
    public partial class SpeechGenerationOptions
    {
        internal IDictionary<string, BinaryData> SerializedAdditionalRawData { get; set; }

        internal SpeechGenerationOptions(InternalCreateSpeechRequestModel model, string input, GeneratedSpeechVoice voice, GeneratedSpeechFormat? responseFormat, float? speed, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Model = model;
            Input = input;
            Voice = voice;
            ResponseFormat = responseFormat;
            Speed = speed;
            SerializedAdditionalRawData = serializedAdditionalRawData;
        }
        public GeneratedSpeechFormat? ResponseFormat { get; set; }
        public float? Speed { get; set; }
    }
}
