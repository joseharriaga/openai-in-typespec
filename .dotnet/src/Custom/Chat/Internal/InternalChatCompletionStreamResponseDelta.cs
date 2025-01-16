using System.Collections.Generic;

namespace OpenAI.Chat;

[CodeGenModel("ChatCompletionStreamResponseDelta")]
[CodeGenSuppress("InternalChatCompletionStreamResponseDelta")]
[CodeGenSerialization(nameof(Content), SerializationValueHook = nameof(SerializeContentValue), DeserializationValueHook = nameof(DeserializeContentValue))]
internal partial class InternalChatCompletionStreamResponseDelta
{
    // CUSTOM: Changed type from string.
    /// <summary> The role of the author of this message. </summary>
    [CodeGenMember("Role")]
    public ChatMessageRole? Role { get; }

    // CUSTOM: Changed type from string.
    /// <summary> The contents of the message. </summary>
    [CodeGenMember("Content")]
    public ChatMessageContent Content { get; }

    // CUSTOM: Changed type to share with non-streaming response audio.
    /// <summary> The incremental response audio information for the message. </summary>
    [CodeGenMember("Audio")]
    public ChatResponseAudio Audio { get; }
}
