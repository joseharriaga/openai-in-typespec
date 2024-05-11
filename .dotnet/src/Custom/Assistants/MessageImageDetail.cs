namespace OpenAI.Assistants;

public enum MessageImageDetail
{
    /// <summary> Default. Allows the model to automatically select detail. </summary>
    Auto,

    /// <summary> Reduced detail that uses fewer tokens than <see cref="High"/>. </summary>
    Low,

    /// <summary> Increased detail that uses more tokens than <see cref="Low"/>. </summary>
    High,
}
