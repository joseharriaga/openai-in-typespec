using OpenAI.ClientShared.Internal;
using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OpenAI.Audio;

/// <summary> The service client for OpenAI audio operations. </summary>
public partial class AudioClient
{
    private readonly OpenAIClientConnector _clientConnector;
    private Internal.Audio Shim => _clientConnector.InternalClient.GetAudioClient();

    /// <summary>
    /// Initializes a new instance of <see cref="AudioClient"/>, used for audio operation requests. 
    /// </summary>
    /// <remarks>
    /// <para>
    ///     If an endpoint is not provided, the client will use the <c>OPENAI_ENDPOINT</c> environment variable if it
    ///     defined and otherwise use the default OpenAI v1 endpoint.
    /// </para>
    /// <para>
    ///    If an authentication credential is not defined, the client use the <c>OPENAI_API_KEY</c> environment variable
    ///    if it is defined.
    /// </para>
    /// </remarks>
    /// <param name="endpoint">The connection endpoint to use.</param>
    /// <param name="model">The model name for audio operations that the client should use.</param>
    /// <param name="credential">The API key used to authenticate with the service endpoint.</param>
    /// <param name="options">Additional options to customize the client.</param>
    public AudioClient(Uri endpoint, string model, ApiKeyCredential credential, OpenAIClientOptions options = null)
    {
        _clientConnector = new(model, endpoint, credential, options);
    }

    /// <summary>
    /// Initializes a new instance of <see cref="AudioClient"/>, used for audio operation requests. 
    /// </summary>
    /// <remarks>
    /// <para>
    ///     If an endpoint is not provided, the client will use the <c>OPENAI_ENDPOINT</c> environment variable if it
    ///     defined and otherwise use the default OpenAI v1 endpoint.
    /// </para>
    /// <para>
    ///    If an authentication credential is not defined, the client use the <c>OPENAI_API_KEY</c> environment variable
    ///    if it is defined.
    /// </para>
    /// </remarks>
    /// <param name="endpoint">The connection endpoint to use.</param>
    /// <param name="model">The model name for audio operations that the client should use.</param>
    /// <param name="options">Additional options to customize the client.</param>
    public AudioClient(Uri endpoint, string model, OpenAIClientOptions options = null)
        : this(endpoint, model, credential: null, options)
    { }

    /// <summary>
    /// Initializes a new instance of <see cref="AudioClient"/>, used for audio operation requests. 
    /// </summary>
    /// <remarks>
    /// <para>
    ///     If an endpoint is not provided, the client will use the <c>OPENAI_ENDPOINT</c> environment variable if it
    ///     defined and otherwise use the default OpenAI v1 endpoint.
    /// </para>
    /// <para>
    ///    If an authentication credential is not defined, the client use the <c>OPENAI_API_KEY</c> environment variable
    ///    if it is defined.
    /// </para>
    /// </remarks>
    /// <param name="model">The model name for audio operations that the client should use.</param>
    /// <param name="credential">The API key used to authenticate with the service endpoint.</param>
    /// <param name="options">Additional options to customize the client.</param>
    public AudioClient(string model, ApiKeyCredential credential, OpenAIClientOptions options = null)
        : this(endpoint: null, model, credential, options)
    { }

    /// <summary>
    /// Initializes a new instance of <see cref="AudioClient"/>, used for audio operation requests. 
    /// </summary>
    /// <remarks>
    /// <para>
    ///     If an endpoint is not provided, the client will use the <c>OPENAI_ENDPOINT</c> environment variable if it
    ///     defined and otherwise use the default OpenAI v1 endpoint.
    /// </para>
    /// <para>
    ///    If an authentication credential is not defined, the client use the <c>OPENAI_API_KEY</c> environment variable
    ///    if it is defined.
    /// </para>
    /// </remarks>
    /// <param name="model">The model name for audio operations that the client should use.</param>
    /// <param name="options">Additional options to customize the client.</param>
    public AudioClient(string model, OpenAIClientOptions options = null)
        : this(endpoint: null, model, credential: null, options)
    { }

    /// <summary>
    /// Creates text-to-speech audio that reflects the specified voice speaking the provided input text.
    /// </summary>
    /// <remarks>
    /// Unless otherwise specified via <see cref="TextToSpeechOptions.ResponseFormat"/>, the <c>mp3</c> format of
    /// <see cref="AudioDataFormat.Mp3"/> will be used for the generated audio.
    /// </remarks>
    /// <param name="text"> The text for the voice to speak. </param>
    /// <param name="voice"> The voice to use. </param>
    /// <param name="options"> Additional options to control the text-to-speech operation. </param>
    /// <returns>
    ///     A result containing generated, spoken audio in the specified output format.
    ///     Unless otherwise specified via <see cref="TextToSpeechOptions.ResponseFormat"/>, the <c>mp3</c> format of
    ///     <see cref="AudioDataFormat.Mp3"/> will be used for the generated audio.
    /// </returns>
    public virtual ClientResult<BinaryData> GenerateSpeechFromText(
        string text,
        TextToSpeechVoice voice,
        TextToSpeechOptions options = null)
    {
        Internal.Models.CreateSpeechRequest request = CreateInternalTtsRequest(text, voice, options);
        return Shim.CreateSpeech(request);
    }

    /// <summary>
    /// Creates text-to-speech audio that reflects the specified voice speaking the provided input text.
    /// </summary>
    /// <remarks>
    /// Unless otherwise specified via <see cref="TextToSpeechOptions.ResponseFormat"/>, the <c>mp3</c> format of
    /// <see cref="AudioDataFormat.Mp3"/> will be used for the generated audio.
    /// </remarks>
    /// <param name="text"> The text for the voice to speak. </param>
    /// <param name="voice"> The voice to use. </param>
    /// <param name="options"> Additional options to control the text-to-speech operation. </param>
    /// <returns>
    ///     A result containing generated, spoken audio in the specified output format.
    ///     Unless otherwise specified via <see cref="TextToSpeechOptions.ResponseFormat"/>, the <c>mp3</c> format of
    ///     <see cref="AudioDataFormat.Mp3"/> will be used for the generated audio.
    /// </returns>
    public virtual Task<ClientResult<BinaryData>> GenerateSpeechFromTextAsync(
        string text,
        TextToSpeechVoice voice,
        TextToSpeechOptions options = null)
    {
        Internal.Models.CreateSpeechRequest request = CreateInternalTtsRequest(text, voice, options);
        return Shim.CreateSpeechAsync(request);
    }

    // convenience method - sync
    public virtual ClientResult<AudioTranscription> TranscribeAudio(BinaryData audioBytes, string filename, AudioTranscriptionOptions options = null)
    {
        if (audioBytes is null) throw new ArgumentNullException(nameof(audioBytes));
        if (filename is null) throw new ArgumentNullException(nameof(filename));

        options ??= new();

        // TODO: ensure correct patterns for sync-over-async
        (BinaryContent content, RequestOptions requestOptions) =
            options.CreateContentAsync(audioBytes, filename, _clientConnector.Model).Result;

        ClientResult result = TranscribeAudio(content, requestOptions);

        PipelineResponse response = result.GetRawResponse();

        // TODO: implement IJsonModel<AudioTranscription>
        //AudioTranscription value = ModelReaderWriter.Read<AudioTranscription>(response.Content)!;
        AudioTranscription value = AudioTranscription.Deserialize(response.Content!);

        return ClientResult.FromValue(value, response);
    }

    // convenience method - async
    public virtual async Task<ClientResult<AudioTranscription>> TranscribeAudioAsync(BinaryData audioBytes, string filename, AudioTranscriptionOptions options = null)
    {
        if (audioBytes is null) throw new ArgumentNullException(nameof(audioBytes));
        if (filename is null) throw new ArgumentNullException(nameof(filename));

        options ??= new();

        (BinaryContent content, RequestOptions requestOptions) =
            await options.CreateContentAsync(audioBytes, filename, _clientConnector.Model).ConfigureAwait(false);

        ClientResult result = await TranscribeAudioAsync(content, requestOptions).ConfigureAwait(false);

        PipelineResponse response = result.GetRawResponse();

        // TODO: implement IJsonModel<AudioTranscription>
        //AudioTranscription value = ModelReaderWriter.Read<AudioTranscription>(response.Content)!;
        AudioTranscription value = AudioTranscription.Deserialize(response.Content!);

        return ClientResult.FromValue(value, response);
    }

    // protocol method - sync
    public virtual ClientResult TranscribeAudio(BinaryContent content, RequestOptions options = null)
    {
        if (content is null) throw new ArgumentNullException(nameof(content));

        options ??= new RequestOptions();

        using PipelineMessage message = CreateCreateTranscriptionRequest(content, options);

        Shim.Pipeline.Send(message);

        PipelineResponse response = message.Response!;

        if (response.IsError && options.ErrorOptions == ClientErrorBehaviors.Default)
        {
            throw new ClientResultException(response);
        }

        return ClientResult.FromResponse(response);
    }

    // protocol method - async
    public virtual async Task<ClientResult> TranscribeAudioAsync(BinaryContent content, RequestOptions options = null)
    {
        if (content is null) throw new ArgumentNullException(nameof(content));

        options ??= new RequestOptions();

        using PipelineMessage message = CreateCreateTranscriptionRequest(content, options);

        Shim.Pipeline.Send(message);

        PipelineResponse response = message.Response!;

        if (response.IsError && options.ErrorOptions == ClientErrorBehaviors.Default)
        {
            throw await ClientResultException.CreateAsync(response).ConfigureAwait(false);
        }

        return ClientResult.FromResponse(response);
    }

    // request-creation helper for TranscribeAudio protocol method
    private PipelineMessage CreateCreateTranscriptionRequest(BinaryContent content, RequestOptions options)
    {
        PipelineMessage message = Shim.Pipeline.CreateMessage();
        message.ResponseClassifier = ResponseErrorClassifier200;

        PipelineRequest request = message.Request;
        request.Method = "POST";

        UriBuilder uriBuilder = new(_clientConnector.Endpoint.AbsoluteUri);

        StringBuilder path = new();
        path.Append("/audio/transcriptions");
        uriBuilder.Path += path.ToString();

        request.Uri = uriBuilder.Uri;

        request.Content = content;

        message.Apply(options);

        return message;
    }

    public virtual ClientResult<AudioTranslation> TranslateAudio(BinaryData audioBytes, string filename, AudioTranslationOptions options = null)
    {
        // TODO: ensure correct patterns for sync-over-async
        PipelineMessage message = CreateCreateTranslationRequestAsync(audioBytes, filename, options).Result;
        Shim.Pipeline.Send(message);
        return GetTranslationResultFromResponse(message.Response);
    }

    public virtual async Task<ClientResult<AudioTranslation>> TranslateAudioAsync(BinaryData audioBytes, string filename, AudioTranslationOptions options = null)
    {
        PipelineMessage message = await CreateCreateTranslationRequestAsync(audioBytes, filename, options).ConfigureAwait(false);
        await Shim.Pipeline.SendAsync(message).ConfigureAwait(false);
        return GetTranslationResultFromResponse(message.Response);
    }

    // request-creation helper for TranslateAudio protocol method
    private async Task<PipelineMessage> CreateCreateTranslationRequestAsync(BinaryData audioBytes, string filename, AudioTranslationOptions options)
    {
        PipelineMessage message = Shim.Pipeline.CreateMessage();
        message.ResponseClassifier = ResponseErrorClassifier200;

        PipelineRequest request = message.Request;
        request.Method = "POST";

        UriBuilder uriBuilder = new(_clientConnector.Endpoint.AbsoluteUri);

        StringBuilder path = new();
        path.Append("/audio/translations");
        uriBuilder.Path += path.ToString();

        request.Uri = uriBuilder.Uri;

        MultipartFormDataContent content = CreateInternalTranscriptionRequestContent(audioBytes, filename, options);
        Stream stream = await content.ReadAsStreamAsync().ConfigureAwait(false);
        request.Content = BinaryContent.Create(stream);

        // Add headers
        // TODO: can we improve perf?

        if (content.Headers.ContentType is MediaTypeHeaderValue contentType)
        {
            request.Headers.Set("Content-Type", contentType.ToString());
        }

        if (content.Headers.ContentLength is long contentLength)
        {
            request.Headers.Set("Content-Length", contentLength.ToString());
        }

        // TODO: other headers to transfer from content as part of MPFD spec?

        return message;
    }

    private MultipartFormDataContent CreateInternalTranscriptionRequestContent(BinaryData audioBytes, string filename, AudioTranscriptionOptions options)
    {
        options ??= new();
        return CreateInternalTranscriptionRequestContent(
            audioBytes,
            filename,
            options.Language,
            options.Prompt,
            options.ResponseFormat,
            options.Temperature,
            options.EnableWordTimestamps,
            options.EnableSegmentTimestamps);
    }

    private MultipartFormDataContent CreateInternalTranscriptionRequestContent(BinaryData audioBytes, string filename, AudioTranslationOptions options)
    {
        options ??= new();
        return CreateInternalTranscriptionRequestContent(
            audioBytes,
            filename,
            language: null,
            options.Prompt,
            options.ResponseFormat,
            options.Temperature,
            enableWordTimestamps: null,
            enableSegmentTimestamps: null);
    }

    private MultipartFormDataContent CreateInternalTranscriptionRequestContent(
        BinaryData audioBytes,
        string filename,
        string language = null,
        string prompt = null,
        AudioTranscriptionFormat? transcriptionFormat = null,
        float? temperature = null,
        bool? enableWordTimestamps = null,
        bool? enableSegmentTimestamps = null)
    {
        MultipartFormDataContent content = new();

        content.Add(new StringContent(_clientConnector.Model), name: "model");

        if (language is not null)
        {
            content.Add(new StringContent(language), name: "language");
        }

        if (prompt is not null)
        {
            content.Add(new StringContent(prompt), name: "prompt");
        }

        if (transcriptionFormat is not null)
        {
            content.Add(new StringContent(transcriptionFormat switch
            {
                AudioTranscriptionFormat.Simple => "json",
                AudioTranscriptionFormat.Detailed => "verbose_json",
                AudioTranscriptionFormat.Srt => "srt",
                AudioTranscriptionFormat.Vtt => "vtt",
                _ => throw new ArgumentException(nameof(transcriptionFormat)),
            }),
            name: "response_format");
        }

        if (temperature is not null)
        {
            // TODO: preferred way to handle floats/numerics?
            content.Add(new StringContent($"{temperature}"), name: "temperature");
        }

        if (enableWordTimestamps is not null ||
            enableSegmentTimestamps is not null)
        {
            // TODO: preferred way to serialize models?
            List<string> granularities = [];
            if (enableWordTimestamps == true)
            {
                granularities.Add("word");
            }
            if (enableSegmentTimestamps == true)
            {
                granularities.Add("segment");
            }

            byte[] data = JsonSerializer.SerializeToUtf8Bytes(granularities);
            content.Add(new ByteArrayContent(data), name: "timestamp_granularities");
        }

        return content;
    }

    private static ClientResult<AudioTranslation> GetTranslationResultFromResponse(PipelineResponse response)
    {
        if (response.IsError)
        {
            throw new ClientResultException(response);
        }

        using JsonDocument responseDocument = JsonDocument.Parse(response.Content);
        return ClientResult.FromValue(AudioTranslation.DeserializeAudioTranscription(responseDocument.RootElement), response);
    }

    private Internal.Models.CreateSpeechRequest CreateInternalTtsRequest(
        string input,
        TextToSpeechVoice voice,
        TextToSpeechOptions options = null)
    {
        options ??= new();
        Internal.Models.CreateSpeechRequestResponseFormat? internalResponseFormat = null;
        if (options.ResponseFormat != null)
        {
            internalResponseFormat = options.ResponseFormat switch
            {
                AudioDataFormat.Aac => "aac",
                AudioDataFormat.Flac => "flac",
                AudioDataFormat.M4a => "m4a",
                AudioDataFormat.Mp3 => "mp3",
                AudioDataFormat.Mp4 => "mp4",
                AudioDataFormat.Mpeg => "mpeg",
                AudioDataFormat.Mpga => "mpga",
                AudioDataFormat.Ogg => "ogg",
                AudioDataFormat.Opus => "opus",
                AudioDataFormat.Wav => "wav",
                AudioDataFormat.Webm => "webm",
                _ => throw new ArgumentException(nameof(options.ResponseFormat)),
            };
        }
        return new Internal.Models.CreateSpeechRequest(
            _clientConnector.Model,
            input,
            voice.ToString(),
            internalResponseFormat,
            options?.SpeedMultiplier,
            serializedAdditionalRawData: null);
    }
    private static PipelineMessageClassifier _responseErrorClassifier200;
    private static PipelineMessageClassifier ResponseErrorClassifier200 => _responseErrorClassifier200 ??= PipelineMessageClassifier.Create(stackalloc ushort[] { 200 });

}
