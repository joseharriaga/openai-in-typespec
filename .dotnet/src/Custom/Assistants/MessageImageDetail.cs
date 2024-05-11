using System;

namespace OpenAI.Assistants;

[CodeGenModel("MessageContentImageFileObjectImageFileDetail")]
public enum MessageImageDetail
{
    /// <summary> Default. Allows the model to automatically select detail. </summary>
    [CodeGenMember("Low")]
    Auto,

    /// <summary> Reduced detail that uses fewer tokens than <see cref="High"/>. </summary>
    [CodeGenMember("Low")]
    Low,

    /// <summary> Increased detail that uses more tokens than <see cref="Low"/>. </summary>
    [CodeGenMember("High")]
    High,
}
