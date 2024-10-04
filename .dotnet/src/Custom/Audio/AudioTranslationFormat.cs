using System;
using System.ComponentModel;

namespace OpenAI.Audio;

// CUSTOM: Introduced as scenario-specific redirection of common format.
/// <summary> The format of the transcription. </summary>
public readonly partial struct AudioTranslationFormat : IEquatable<AudioTranslationFormat>
{
    internal readonly InternalAudioResponseFormat _internalAudioResponseFormat;

    public AudioTranslationFormat(string value)
        : this(new InternalAudioResponseFormat(value))
    { }

    internal AudioTranslationFormat(InternalAudioResponseFormat internalAudioResponseFormat)
    {
        _internalAudioResponseFormat = internalAudioResponseFormat;
    }

    /// <summary> Plain text only. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static AudioTranslationFormat Text { get; } = new (InternalAudioResponseFormat.Text.ToString());

    /// <summary> Plain text only. </summary>
    public static AudioTranslationFormat Simple { get; } = new (InternalAudioResponseFormat.Json.ToString());

    /// <summary> Plain text provided with additional metadata, such as duration and timestamps. </summary>
    public static AudioTranslationFormat Verbose { get; } = new (InternalAudioResponseFormat.VerboseJson.ToString());

    /// <summary> Text formatted as SubRip (.srt) file. </summary>
    public static AudioTranslationFormat Srt { get; } = new (InternalAudioResponseFormat.Srt.ToString());

    /// <summary> Text formatted as a Web Video Text Tracks, a.k.a. WebVTT, (.vtt) file. </summary>
    public static AudioTranslationFormat Vtt { get; } = new(InternalAudioResponseFormat.Vtt.ToString());

    public static bool operator ==(AudioTranslationFormat left, AudioTranslationFormat right) => left.Equals(right);
    public static bool operator !=(AudioTranslationFormat left, AudioTranslationFormat right) => !left.Equals(right);
    public static implicit operator AudioTranslationFormat(string value) => new AudioTranslationFormat(value);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override bool Equals(object obj) => obj is AudioTranslationFormat other && Equals(other);
    public bool Equals(AudioTranslationFormat other) => _internalAudioResponseFormat.Equals(other._internalAudioResponseFormat);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override int GetHashCode() => _internalAudioResponseFormat.GetHashCode();
    public override string ToString() => _internalAudioResponseFormat.ToString();
}