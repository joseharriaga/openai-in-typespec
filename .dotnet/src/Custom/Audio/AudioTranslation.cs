using System;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace OpenAI.Audio;

[CodeGenModel("CreateTranslationResponseVerboseJson")]
[CodeGenSerialization(nameof(Duration), DeserializationValueHook = nameof(DeserializeNullableTimespan))]
public partial class AudioTranslation
{
    // CUSTOM: Made private. This property does not add value in the context of a strongly-typed class.
    private CreateTranslationResponseVerboseJsonTask Task { get; }

    // CUSTOM: Made nullable because this is an optional property.
    /// <summary> TODO. </summary>
    public TimeSpan? Duration { get; }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static void DeserializeNullableTimespan(JsonProperty property, ref TimeSpan? nullableTimespan)
        => CustomSerialization.DeserializeNullableTimeSpan(property, ref nullableTimespan);
}