using OpenAI.Internal;
using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace OpenAI.Audio;

/// <summary> The service client for OpenAI audio operations. </summary>
[CodeGenClient("Audio")]
[CodeGenSuppress("AudioClient", typeof(ClientPipeline), typeof(ApiKeyCredential), typeof(Uri))]
[CodeGenSuppress("CreateSpeechAsync", typeof(SpeechGenerationOptions), typeof(CancellationToken))]
[CodeGenSuppress("CreateSpeech", typeof(SpeechGenerationOptions), typeof(CancellationToken))]
[CodeGenSuppress("CreateTranscriptionAsync", typeof(AudioTranscriptionOptions), typeof(CancellationToken))]
[CodeGenSuppress("CreateTranscription", typeof(AudioTranscriptionOptions), typeof(CancellationToken))]
[CodeGenSuppress("CreateTranslationAsync", typeof(AudioTranslationOptions), typeof(CancellationToken))]
[CodeGenSuppress("CreateTranslation", typeof(AudioTranslationOptions), typeof(CancellationToken))]
[CodeGenSuppress("CreateCreateTranscriptionRequest", typeof(BinaryContent), typeof(RequestOptions))]
[CodeGenSuppress("CreateCreateTranslationRequest", typeof(BinaryContent), typeof(RequestOptions))]
public partial class AudioClient
{
    private readonly string _model;

    // CUSTOM:
    // - Added `model` parameter.
    // - Added support for retrieving credential and endpoint from environment variables.
    /// <summary> Initializes a new instance of AudioClient. </summary>
    /// <param name="model"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
    /// <param name="credential"> The key credential to copy. </param>
    /// <param name="options"> OpenAI Endpoint. </param>
    public AudioClient(string model, ApiKeyCredential credential = default, OpenAIClientOptions options = default)
    {
        Argument.AssertNotNullOrEmpty(model, nameof(model));
        options ??= new OpenAIClientOptions();

        _model = model;
        _keyCredential = credential ?? new(Environment.GetEnvironmentVariable(OpenAIClient.s_OpenAIApiKeyEnvironmentVariable) ?? string.Empty);
        _pipeline = ClientPipeline.Create(options, Array.Empty<PipelinePolicy>(), new PipelinePolicy[] { ApiKeyAuthenticationPolicy.CreateHeaderApiKeyPolicy(_keyCredential, AuthorizationHeader, AuthorizationApiKeyPrefix) }, Array.Empty<PipelinePolicy>());
        _endpoint = options.Endpoint ?? new(Environment.GetEnvironmentVariable(OpenAIClient.s_OpenAIEndpointEnvironmentVariable) ?? OpenAIClient.s_defaultOpenAIV1Endpoint);
    }

    // CUSTOM:
    // - Added `model` parameter.
    /// <summary> Initializes a new instance of EmbeddingClient. </summary>
    /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
    /// <param name="model"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
    /// <param name="credential"> The key credential to copy. </param>
    /// <param name="endpoint"> OpenAI Endpoint. </param>
    internal AudioClient(ClientPipeline pipeline, string model, ApiKeyCredential credential, Uri endpoint)
    {
        _pipeline = pipeline;
        _model = model;
        _keyCredential = credential;
        _endpoint = endpoint;
    }

    #region GenerateSpeech

    /// <summary>
    /// Creates text-to-speech audio that reflects the specified voice speaking the provided input text.
    /// </summary>
    /// <remarks>
    /// Unless otherwise specified via <see cref="SpeechGenerationOptions.ResponseFormat"/>, the <c>mp3</c> format of
    /// <see cref="GeneratedSpeechFormat.Mp3"/> will be used for the generated audio.
    /// </remarks>
    /// <param name="text"> The text for the voice to speak. </param>
    /// <param name="voice"> The voice to use. </param>
    /// <param name="options"> Additional options to control the text-to-speech operation. </param>
    /// <returns>
    ///     A result containing generated, spoken audio in the specified output format.
    ///     Unless otherwise specified via <see cref="SpeechGenerationOptions.ResponseFormat"/>, the <c>mp3</c> format of
    ///     <see cref="GeneratedSpeechFormat.Mp3"/> will be used for the generated audio.
    /// </returns>
    public virtual async Task<ClientResult<BinaryData>> GenerateSpeechFromTextAsync(string text, GeneratedSpeechVoice voice, SpeechGenerationOptions options = null)
    {
        Argument.AssertNotNull(text, nameof(text));

        options ??= new();
        CreateSpeechGenerationOptions(text, voice, ref options);

        using BinaryContent content = options.ToBinaryBody();
        ClientResult result = await GenerateSpeechFromTextAsync(content, DefaultRequestContext).ConfigureAwait(false);
        return ClientResult.FromValue(result.GetRawResponse().Content, result.GetRawResponse());
    }

    /// <summary>
    /// Creates text-to-speech audio that reflects the specified voice speaking the provided input text.
    /// </summary>
    /// <remarks>
    /// Unless otherwise specified via <see cref="SpeechGenerationOptions.ResponseFormat"/>, the <c>mp3</c> format of
    /// <see cref="AudioDataFormat.Mp3"/> will be used for the generated audio.
    /// </remarks>
    /// <param name="text"> The text for the voice to speak. </param>
    /// <param name="voice"> The voice to use. </param>
    /// <param name="options"> Additional options to control the text-to-speech operation. </param>
    /// <returns>
    ///     A result containing generated, spoken audio in the specified output format.
    ///     Unless otherwise specified via <see cref="SpeechGenerationOptions.ResponseFormat"/>, the <c>mp3</c> format of
    ///     <see cref="AudioDataFormat.Mp3"/> will be used for the generated audio.
    /// </returns>
    public virtual ClientResult<BinaryData> GenerateSpeechFromText(string text, GeneratedSpeechVoice voice, SpeechGenerationOptions options = null)
    {
        Argument.AssertNotNull(text, nameof(text));

        options ??= new();
        CreateSpeechGenerationOptions(text, voice, ref options);

        using BinaryContent content = options.ToBinaryBody();
        ClientResult result = GenerateSpeechFromText(content, DefaultRequestContext);
        return ClientResult.FromValue(result.GetRawResponse().Content, result.GetRawResponse());
    }

    #endregion

    #region TranscribeAudio

    /// <summary> TODO. </summary>
    /// <param name="audio"> TODO. </param>
    /// <param name="audioFilename"> TODO. </param>
    /// <param name="options"> TODO. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="audio"/> or <paramref name="audioFilename"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="audioFilename"/> is an empty string, and was expected to be non-empty. </exception>
    public virtual async Task<ClientResult<AudioTranscription>> TranscribeAudioAsync(Stream audio, string audioFilename, AudioTranscriptionOptions options = null)
    {
        Argument.AssertNotNull(audio, nameof(audio));
        Argument.AssertNotNull(audioFilename, nameof(audioFilename));

        options ??= new();
        CreateAudioTranscriptionOptions(audio, audioFilename, ref options);

        using MultipartFormDataBinaryContent content = options.ToMultipartContent(audio, audioFilename);
        ClientResult result = await TranscribeAudioAsync(content, content.ContentType).ConfigureAwait(false);
        return ClientResult.FromValue(AudioTranscription.FromResponse(result.GetRawResponse()), result.GetRawResponse());
    }

    /// <summary> TODO. </summary>
    /// <param name="audio"> TODO. </param>
    /// <param name="audioFilename"> TODO. </param>
    /// <param name="options"> TODO. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="audio"/> or <paramref name="audioFilename"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="audioFilename"/> is an empty string, and was expected to be non-empty. </exception>
    public virtual ClientResult<AudioTranscription> TranscribeAudio(Stream audio, string audioFilename, AudioTranscriptionOptions options = null)
    {
        Argument.AssertNotNull(audio, nameof(audio));
        Argument.AssertNotNull(audioFilename, nameof(audioFilename));

        options ??= new();
        CreateAudioTranscriptionOptions(audio, audioFilename, ref options);

        using MultipartFormDataBinaryContent content = options.ToMultipartContent(audio, audioFilename);
        ClientResult result = TranscribeAudio(content, content.ContentType);
        return ClientResult.FromValue(AudioTranscription.FromResponse(result.GetRawResponse()), result.GetRawResponse());
    }

    /// <summary>
    /// Transcribes audio from a file with a known path.
    /// </summary>
    /// <remarks>
    /// The provided file path's extension (like .mp3) will be used to infer the format of the input audio. The
    /// operation may fail if the file extension and input audio format do not match.
    /// </remarks>
    /// <param name="audioFilePath"> The path of the audio file to transcribe. </param>
    /// <param name="options"> Options for the transcription. </param>
    /// <returns> Audio transcription data for the provided file. </returns>
    /// <exception cref="ArgumentNullException"> <paramref name="audioFilePath"/> was null. </exception>
    public virtual async Task<ClientResult<AudioTranscription>> TranscribeAudioAsync(string audioFilePath, AudioTranscriptionOptions options = null)
    {
        Argument.AssertNotNull(audioFilePath, nameof(audioFilePath));

        using FileStream audioStream = File.OpenRead(audioFilePath);
        return await TranscribeAudioAsync(audioStream, audioFilePath, options);
    }

    /// <summary>
    /// Transcribes audio from a file with a known path.
    /// </summary>
    /// <remarks>
    /// The provided file path's extension (like .mp3) will be used to infer the format of the input audio. The
    /// operation may fail if the file extension and input audio format do not match.
    /// </remarks>
    /// <param name="audioFilePath"> The path of the audio file to transcribe. </param>
    /// <param name="options"> Options for the transcription. </param>
    /// <returns> Audio transcription data for the provided file. </returns>
    /// <exception cref="ArgumentNullException"> <paramref name="audioFilePath"/> was null. </exception>
    public virtual ClientResult<AudioTranscription> TranscribeAudio(string audioFilePath, AudioTranscriptionOptions options = null)
    {
        Argument.AssertNotNull(audioFilePath, nameof(audioFilePath));

        using FileStream audioStream = File.OpenRead(audioFilePath);
        return TranscribeAudio(audioStream, audioFilePath, options);
    }

    #endregion

    #region TranslateAudio

    /// <summary> TODO. </summary>
    /// <param name="audio"> TODO. </param>
    /// <param name="audioFilename"> TODO. </param>
    /// <param name="options"> TODO. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="audio"/> or <paramref name="audioFilename"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="audioFilename"/> is an empty string, and was expected to be non-empty. </exception>
    public virtual async Task<ClientResult<AudioTranslation>> TranslateAudioAsync(Stream audio, string audioFilename, AudioTranslationOptions options = null)
    {
        Argument.AssertNotNull(audio, nameof(audio));
        Argument.AssertNotNull(audioFilename, nameof(audioFilename));

        options ??= new();
        CreateAudioTranslationOptions(audio, audioFilename, ref options);

        using MultipartFormDataBinaryContent content = options.ToMultipartContent(audio, audioFilename);
        ClientResult result = await TranslateAudioAsync(content, content.ContentType).ConfigureAwait(false);
        return ClientResult.FromValue(AudioTranslation.FromResponse(result.GetRawResponse()), result.GetRawResponse());
    }

    /// <summary> TODO. </summary>
    /// <param name="audio"> TODO. </param>
    /// <param name="audioFilename"> TODO. </param>
    /// <param name="options"> TODO. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="audio"/> or <paramref name="audioFilename"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="audioFilename"/> is an empty string, and was expected to be non-empty. </exception>
    public virtual ClientResult<AudioTranslation> TranslateAudio(Stream audio, string audioFilename, AudioTranslationOptions options = null)
    {
        Argument.AssertNotNull(audio, nameof(audio));
        Argument.AssertNotNull(audioFilename, nameof(audioFilename));

        options ??= new();
        CreateAudioTranslationOptions(audio, audioFilename, ref options);

        using MultipartFormDataBinaryContent content = options.ToMultipartContent(audio, audioFilename);
        ClientResult result = TranslateAudio(content, content.ContentType);
        return ClientResult.FromValue(AudioTranslation.FromResponse(result.GetRawResponse()), result.GetRawResponse());
    }

    /// <summary>
    /// Translates audio into English from a file with a known path.
    /// </summary>
    /// <remarks>
    /// The provided file path's extension (like .mp3) will be used to infer the format of the input audio. The
    /// operation may fail if the file extension and input audio format do not match.
    /// </remarks>
    /// <param name="audioFilePath"> The path of the audio file to translate. </param>
    /// <param name="options"> Options for the translation. </param>
    /// <returns> Audio translation data for the provided file. </returns>
    /// <exception cref="ArgumentNullException"> <paramref name="audioFilePath"/> was null. </exception>
    public virtual ClientResult<AudioTranslation> TranslateAudio(string audioFilePath, AudioTranslationOptions options = null)
    {
        Argument.AssertNotNull(audioFilePath, nameof(audioFilePath));

        using FileStream audioStream = File.OpenRead(audioFilePath);
        return TranslateAudio(audioStream, audioFilePath, options);
    }

    /// <summary>
    /// Translates audio into English from a file with a known path.
    /// </summary>
    /// <remarks>
    /// The provided file path's extension (like .mp3) will be used to infer the format of the input audio. The
    /// operation may fail if the file extension and input audio format do not match.
    /// </remarks>
    /// <param name="audioFilePath"> The path of the audio file to translate. </param>
    /// <param name="options"> Options for the translation. </param>
    /// <returns> Audio translation data for the provided file. </returns>
    /// <exception cref="ArgumentNullException"> <paramref name="audioFilePath"/> was null. </exception>
    public virtual async Task<ClientResult<AudioTranslation>> TranslateAudioAsync(string audioFilePath, AudioTranslationOptions options = null)
    {
        Argument.AssertNotNull(audioFilePath, nameof(audioFilePath));

        using FileStream audioStream = File.OpenRead(audioFilePath);
        return await TranslateAudioAsync(audioStream, audioFilePath, options);
    }

    #endregion

    // CUSTOM: Parametrized the Content-Type header.
    internal PipelineMessage CreateCreateTranscriptionRequest(BinaryContent content, string contentType, RequestOptions options)
    {
        var message = _pipeline.CreateMessage();
        message.ResponseClassifier = PipelineMessageClassifier200;
        var request = message.Request;
        request.Method = "POST";
        var uri = new ClientUriBuilder();
        uri.Reset(_endpoint);
        uri.AppendPath("/audio/transcriptions", false);
        request.Uri = uri.ToUri();
        request.Headers.Set("Accept", "application/json");
        request.Headers.Set("content-type", contentType);
        request.Content = content;
        if (options != null)
        {
            message.Apply(options);
        }
        return message;
    }

    // CUSTOM: Parametrized the Content-Type header.
    internal PipelineMessage CreateCreateTranslationRequest(BinaryContent content, string contentType, RequestOptions options)
    {
        var message = _pipeline.CreateMessage();
        message.ResponseClassifier = PipelineMessageClassifier200;
        var request = message.Request;
        request.Method = "POST";
        var uri = new ClientUriBuilder();
        uri.Reset(_endpoint);
        uri.AppendPath("/audio/translations", false);
        request.Uri = uri.ToUri();
        request.Headers.Set("Accept", "application/json");
        request.Headers.Set("content-type", contentType);
        request.Content = content;
        if (options != null)
        {
            message.Apply(options);
        }
        return message;
    }

    private void CreateSpeechGenerationOptions(string text, GeneratedSpeechVoice voice, ref SpeechGenerationOptions options)
    {
        options.Input = text;
        options.Voice = voice;
        options.Model = _model;
    }

    private void CreateAudioTranscriptionOptions(Stream audio, string audioFilename, ref AudioTranscriptionOptions options)
    {
        options.Model = _model;
    }

    private void CreateAudioTranslationOptions(Stream audio, string audioFilename, ref AudioTranslationOptions options)
    {
        options.Model = _model;
    }
}
