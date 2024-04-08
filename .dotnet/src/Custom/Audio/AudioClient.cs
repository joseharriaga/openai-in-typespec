using OpenAI.Internal;
using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.IO;
using System.Text;
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
    /// <param name="model">The model name for audio operations that the client should use.</param>
    /// <param name="credential">The API key used to authenticate with the service endpoint.</param>
    /// <param name="options">Additional options to customize the client.</param>
    public AudioClient(string model, ApiKeyCredential credential = default, OpenAIClientOptions options = default)
    {
        _clientConnector = new(model, credential, options);
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

    public virtual ClientResult<AudioTranscription> TranscribeAudio(FileStream audio, AudioTranscriptionOptions options = null)
        => TranscribeAudio(audio, Path.GetFileName(audio.Name), options);

    public virtual ClientResult<AudioTranscription> TranscribeAudio(Stream audio, string fileName, AudioTranscriptionOptions options = null)
    {
        Argument.AssertNotNull(audio, nameof(audio));
        Argument.AssertNotNull(fileName, nameof(fileName));

        options ??= new();

        using MultipartFormDataBinaryContent content = options.ToMultipartContent(audio, fileName, _clientConnector.Model);

        ClientResult result = TranscribeAudio(content, content.ContentType);

        PipelineResponse response = result.GetRawResponse();

        AudioTranscription value = AudioTranscription.Deserialize(response.Content!);

        return ClientResult.FromValue(value, response);
    }

    public virtual async Task<ClientResult<AudioTranscription>> TranscribeAudioAsync(FileStream audio, AudioTranscriptionOptions options = null)
        => await TranscribeAudioAsync(audio, Path.GetFileName(audio.Name), options).ConfigureAwait(false);

    public virtual async Task<ClientResult<AudioTranscription>> TranscribeAudioAsync(Stream audio, string filename, AudioTranscriptionOptions options = null)
    {
        Argument.AssertNotNull(audio, nameof(audio));
        Argument.AssertNotNull(filename, nameof(filename));

        options ??= new();

        using MultipartFormDataBinaryContent content = options.ToMultipartContent(audio, filename, _clientConnector.Model);

        ClientResult result = await TranscribeAudioAsync(content, content.ContentType).ConfigureAwait(false);

        PipelineResponse response = result.GetRawResponse();

        AudioTranscription value = AudioTranscription.Deserialize(response.Content!);

        return ClientResult.FromValue(value, response);
    }

    private PipelineMessage CreateCreateTranscriptionRequest(BinaryContent content, string contentType, RequestOptions options)
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

        request.Headers.Set("Content-Type", contentType);

        request.Content = content;

        message.Apply(options);

        return message;
    }

    public virtual ClientResult<AudioTranslation> TranslateAudio(FileStream audio, AudioTranslationOptions options = null)
        => TranslateAudio(audio, Path.GetFileName(audio.Name), options);

    public virtual ClientResult<AudioTranslation> TranslateAudio(Stream audio, string fileName, AudioTranslationOptions options = null)
    {
        Argument.AssertNotNull(audio, nameof(audio));
        Argument.AssertNotNull(fileName, nameof(fileName));

        options ??= new();

        using MultipartFormDataBinaryContent content = options.ToMultipartContent(audio, fileName, _clientConnector.Model);

        ClientResult result = TranslateAudio(content, content.ContentType);

        PipelineResponse response = result.GetRawResponse();

        AudioTranslation value = AudioTranslation.Deserialize(response.Content!);

        return ClientResult.FromValue(value, response);
    }

    public virtual async Task<ClientResult<AudioTranslation>> TranslateAudioAsync(FileStream audio, AudioTranslationOptions options = null)
        => await TranslateAudioAsync(audio, Path.GetFileName(audio.Name), options).ConfigureAwait(false);

    public virtual async Task<ClientResult<AudioTranslation>> TranslateAudioAsync(Stream audio, string fileName, AudioTranslationOptions options = null)
    {
        Argument.AssertNotNull(audio, nameof(audio));
        Argument.AssertNotNull(fileName, nameof(fileName));

        options ??= new();

        using MultipartFormDataBinaryContent content = options.ToMultipartContent(audio, fileName, _clientConnector.Model);

        ClientResult result = await TranslateAudioAsync(content, content.ContentType).ConfigureAwait(false);

        PipelineResponse response = result.GetRawResponse();

        AudioTranslation value = AudioTranslation.Deserialize(response.Content!);

        return ClientResult.FromValue(value, response);
    }

    private PipelineMessage CreateCreateTranslationRequest(BinaryContent content, string contentType, RequestOptions options)
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

        request.Headers.Set("Content-Type", contentType);

        request.Content = content;

        message.Apply(options);

        return message;
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
                AudioDataFormat.Pcm => "pcm",
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
