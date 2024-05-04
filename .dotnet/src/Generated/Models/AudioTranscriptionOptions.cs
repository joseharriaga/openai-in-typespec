// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Audio
{
    /// <summary> The CreateTranscriptionRequest. </summary>
    public partial class AudioTranscriptionOptions
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

        /// <summary> Initializes a new instance of <see cref="CreateTranscriptionRequest"/>. </summary>
        /// <param name="file">
        /// The audio file object (not file name) to transcribe, in one of these formats: flac, mp3, mp4,
        /// mpeg, mpga, m4a, ogg, wav, or webm.
        /// </param>
        /// <param name="model">
        /// ID of the model to use. Only `whisper-1` (which is powered by our open source Whisper V2
        /// model) is currently available.
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="file"/> is null. </exception>
        public CreateTranscriptionRequest(string file, CreateTranscriptionRequestModel model)
        {
            Argument.AssertNotNull(file, nameof(file));

            File = file;
            Model = model;
            TimestampGranularities = new ChangeTrackingList<BinaryData>();
        }

        /// <summary> Initializes a new instance of <see cref="CreateTranscriptionRequest"/>. </summary>
        /// <param name="file">
        /// The audio file object (not file name) to transcribe, in one of these formats: flac, mp3, mp4,
        /// mpeg, mpga, m4a, ogg, wav, or webm.
        /// </param>
        /// <param name="model">
        /// ID of the model to use. Only `whisper-1` (which is powered by our open source Whisper V2
        /// model) is currently available.
        /// </param>
        /// <param name="language">
        /// The language of the input audio. Supplying the input language in
        /// [ISO-639-1](https://en.wikipedia.org/wiki/List_of_ISO_639-1_codes) format will improve
        /// accuracy and latency.
        /// </param>
        /// <param name="prompt">
        /// An optional text to guide the model's style or continue a previous audio segment. The
        /// [prompt](/docs/guides/speech-to-text/prompting) should match the audio language.
        /// </param>
        /// <param name="responseFormat">
        /// The format of the transcript output, in one of these options: `json`, `text`, `srt`,
        /// `verbose_json`, or `vtt`.
        /// </param>
        /// <param name="temperature">
        /// The sampling temperature, between 0 and 1. Higher values like 0.8 will make the output more
        /// random, while lower values like 0.2 will make it more focused and deterministic. If set to 0,
        /// the model will use [log probability](https://en.wikipedia.org/wiki/Log_probability) to
        /// automatically increase the temperature until certain thresholds are hit.
        /// </param>
        /// <param name="timestampGranularities">
        /// The timestamp granularities to populate for this transcription. `response_format` must be set
        /// `verbose_json` to use timestamp granularities. Either or both of these options are supported:
        /// `word`, or `segment`. Note: There is no additional latency for segment timestamps, but
        /// generating word timestamps incurs additional latency.
        /// </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal CreateTranscriptionRequest(string file, CreateTranscriptionRequestModel model, string language, string prompt, CreateTranscriptionRequestResponseFormat? responseFormat, double? temperature, IList<BinaryData> timestampGranularities, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            File = file;
            Model = model;
            Language = language;
            Prompt = prompt;
            ResponseFormat = responseFormat;
            Temperature = temperature;
            TimestampGranularities = timestampGranularities;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="CreateTranscriptionRequest"/> for deserialization. </summary>
        internal CreateTranscriptionRequest()
        {
        }

        /// <summary>
        /// The audio file object (not file name) to transcribe, in one of these formats: flac, mp3, mp4,
        /// mpeg, mpga, m4a, ogg, wav, or webm.
        /// </summary>
        public string File { get; }
        /// <summary>
        /// ID of the model to use. Only `whisper-1` (which is powered by our open source Whisper V2
        /// model) is currently available.
        /// </summary>
        public CreateTranscriptionRequestModel Model { get; }
        /// <summary>
        /// The language of the input audio. Supplying the input language in
        /// [ISO-639-1](https://en.wikipedia.org/wiki/List_of_ISO_639-1_codes) format will improve
        /// accuracy and latency.
        /// </summary>
        public string Language { get; set; }
        /// <summary>
        /// An optional text to guide the model's style or continue a previous audio segment. The
        /// [prompt](/docs/guides/speech-to-text/prompting) should match the audio language.
        /// </summary>
        public string Prompt { get; set; }
        /// <summary>
        /// The format of the transcript output, in one of these options: `json`, `text`, `srt`,
        /// `verbose_json`, or `vtt`.
        /// </summary>
        public AudioTranscriptionFormat? ResponseFormat { get; set; }
        /// <summary>
        /// The sampling temperature, between 0 and 1. Higher values like 0.8 will make the output more
        /// random, while lower values like 0.2 will make it more focused and deterministic. If set to 0,
        /// the model will use [log probability](https://en.wikipedia.org/wiki/Log_probability) to
        /// automatically increase the temperature until certain thresholds are hit.
        /// </summary>
        public double? Temperature { get; set; }
    }
}
