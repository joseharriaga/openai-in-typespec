using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace OpenAI.Audio;

[CodeGenModel("TranscriptionSegment")]
[CodeGenSerialization(nameof(Start), DeserializationValueHook = nameof(DeserializeTimeSpan))]
[CodeGenSerialization(nameof(End), DeserializationValueHook = nameof(DeserializeTimeSpan))]
public readonly partial struct TranscribedSegment
{
    // CUSTOM: Rename.
    [CodeGenMember("Seek")]
    public long SeekOffset { get; }

    // CUSTOM: Rename.
    [CodeGenMember("Tokens")]
    public IReadOnlyList<long> TokenIds { get; }

    // CUSTOM: Rename.
    [CodeGenMember("AvgLogprob")]
    public double AverageLogProbability { get; }

    // CUSTOM: Rename.
    [CodeGenMember("NoSpeechProb")]
    public double NoSpeechProbability { get; }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static void DeserializeTimeSpan(JsonProperty property, ref TimeSpan timespan)
        => CustomSerialization.DeserializeTimeSpan(property, ref timespan);
}