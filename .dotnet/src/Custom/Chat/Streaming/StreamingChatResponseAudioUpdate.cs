namespace OpenAI.Chat;

using System;

/// <summary> A streaming update representing part of a tool call made by the model. </summary>
[CodeGenModel("ChatCompletionMessageAudioChunk")]
public partial class StreamingChatResponseAudioUpdate
{
    [CodeGenMember("Id")]
    public string CorrelationId { get; }

    [CodeGenMember("Transcript")]
    public string TranscriptUpdate { get; }

    [CodeGenMember("Data")]
    public BinaryData AudioBytesUpdate { get; }
}
