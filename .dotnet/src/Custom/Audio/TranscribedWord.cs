using System;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace OpenAI.Audio;

[CodeGenModel("TranscriptionWord")]
[CodeGenSerialization(nameof(Start), DeserializationValueHook = nameof(DeserializeTimeSpan))]
[CodeGenSerialization(nameof(End), DeserializationValueHook = nameof(DeserializeTimeSpan))]
public readonly partial struct TranscribedWord
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static void DeserializeTimeSpan(JsonProperty property, ref TimeSpan timespan)
        => CustomSerialization.DeserializeTimeSpan(property, ref timespan);
}