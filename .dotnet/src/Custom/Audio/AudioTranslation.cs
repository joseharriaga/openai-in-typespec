using System;

namespace OpenAI.Audio;

[CodeGenModel("CreateTranslationResponseVerboseJson")]
public partial class AudioTranslation
{
    // CUSTOM: Made private. This property does not add value in the context of a strongly-typed class.
    private CreateTranslationResponseVerboseJsonTask Task { get; }

    // CUSTOM: Made nullable because this is an optional property.
    /// <summary> TODO. </summary>
    public TimeSpan? Duration { get; }
}