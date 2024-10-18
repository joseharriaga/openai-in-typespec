using System;
using System.ComponentModel;

namespace OpenAI.Audio;

// CUSTOM: Introduced as scenario-specific redirection of common format.
/// <summary> The format of the transcription. </summary>
public readonly partial struct AudioTranscriptionFormat : IEquatable<AudioTranscriptionFormat>
{
    internal readonly InternalAudioResponseFormat _internalAudioResponseFormat;

    public AudioTranscriptionFormat(string value)
        : this(new InternalAudioResponseFormat(value))
    { }

    internal AudioTranscriptionFormat(InternalAudioResponseFormat internalAudioResponseFormat)
    {
        _internalAudioResponseFormat = internalAudioResponseFormat;
    }

    /// <summary> Plain text only. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static AudioTranscriptionFormat Text { get; } = new (InternalAudioResponseFormat.Text.ToString());

    /// <summary> Plain text only. </summary>
    public static AudioTranscriptionFormat Simple { get; } = new (InternalAudioResponseFormat.Json.ToString());

    /// <summary> Plain text provided with additional metadata, such as duration and timestamps. </summary>
    public static AudioTranscriptionFormat Verbose { get; } = new (InternalAudioResponseFormat.VerboseJson.ToString());

    /// <summary> Text formatted as SubRip (.srt) file. </summary>
    public static AudioTranscriptionFormat Srt { get; } = new (InternalAudioResponseFormat.Srt.ToString());

    /// <summary> Text formatted as a Web Video Text Tracks, a.k.a. WebVTT, (.vtt) file. </summary>
    public static AudioTranscriptionFormat Vtt { get; } = new(InternalAudioResponseFormat.Vtt.ToString());

    public static bool operator ==(AudioTranscriptionFormat left, AudioTranscriptionFormat right) => left.Equals(right);
    public static bool operator !=(AudioTranscriptionFormat left, AudioTranscriptionFormat right) => !left.Equals(right);
    public static implicit operator AudioTranscriptionFormat(string value) => new AudioTranscriptionFormat(value);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override bool Equals(object obj) => obj is AudioTranscriptionFormat other && Equals(other);
    public bool Equals(AudioTranscriptionFormat other) => _internalAudioResponseFormat.Equals(other._internalAudioResponseFormat);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override int GetHashCode() => _internalAudioResponseFormat.GetHashCode();
    public override string ToString() => _internalAudioResponseFormat.ToString();
}