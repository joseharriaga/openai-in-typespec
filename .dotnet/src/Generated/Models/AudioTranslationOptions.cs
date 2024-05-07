// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Audio
{
    /// <summary> The CreateTranslationRequest. </summary>
    public partial class AudioTranslationOptions
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

        /// <summary> Initializes a new instance of <see cref="AudioTranslationOptions"/>. </summary>
        /// <param name="file"> The audio file object (not file name) translate, in one of these formats: flac, mp3, mp4, mpeg, mpga, m4a, ogg, wav, or webm. </param>
        /// <param name="model"> ID of the model to use. Only `whisper-1` (which is powered by our open source Whisper V2 model) is currently available. </param>
        /// <param name="prompt"> An optional text to guide the model's style or continue a previous audio segment. The [prompt](/docs/guides/speech-to-text/prompting) should be in English. </param>
        /// <param name="responseFormat"> The format of the transcript output, in one of these options: `json`, `text`, `srt`, `verbose_json`, or `vtt`. </param>
        /// <param name="temperature"> The sampling temperature, between 0 and 1. Higher values like 0.8 will make the output more random, while lower values like 0.2 will make it more focused and deterministic. If set to 0, the model will use [log probability](https://en.wikipedia.org/wiki/Log_probability) to automatically increase the temperature until certain thresholds are hit. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal AudioTranslationOptions(BinaryData file, CreateTranslationRequestModel model, string prompt, AudioTranslationFormat? responseFormat, float? temperature, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            File = file;
            Model = model;
            Prompt = prompt;
            ResponseFormat = responseFormat;
            Temperature = temperature;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }
        /// <summary> An optional text to guide the model's style or continue a previous audio segment. The [prompt](/docs/guides/speech-to-text/prompting) should be in English. </summary>
        public string Prompt { get; set; }
        /// <summary> The format of the transcript output, in one of these options: `json`, `text`, `srt`, `verbose_json`, or `vtt`. </summary>
        public AudioTranslationFormat? ResponseFormat { get; set; }
        /// <summary> The sampling temperature, between 0 and 1. Higher values like 0.8 will make the output more random, while lower values like 0.2 will make it more focused and deterministic. If set to 0, the model will use [log probability](https://en.wikipedia.org/wiki/Log_probability) to automatically increase the temperature until certain thresholds are hit. </summary>
        public float? Temperature { get; set; }
    }
}
