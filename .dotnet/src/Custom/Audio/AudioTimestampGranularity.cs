using System;

namespace OpenAI.Audio;

[Flags]
public enum AudioTimestampGranularity
{
    /// <summary>
    /// The default value that, when equivalent to a request's flags, specifies no specific audio timestamp granularity
    /// and defers to the default timestamp behavior.
    /// </summary>
    Default,
    /// <summary>
    /// The value that, when present in the request's flags, specifies that audio information should include word-level
    /// timestamp information.
    /// </summary>
    Word,
    /// <summary>
    /// The value that, when present in the request's flags, specifies that audio information should include
    /// segment-level timestamp information.
    /// </summary>
    Segment,
}