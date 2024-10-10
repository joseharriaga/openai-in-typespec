using System;

namespace OpenAI.RealtimeConversation;
internal static partial class ConversationUpdateKindExtensions
{
    public static string ToSerialString(this ConversationUpdateKind value) => value switch
    {
        ConversationUpdateKind.SessionStarted => "session.created",
        ConversationUpdateKind.SessionConfigured => "session.updated",
        // ConversationUpdateKind.ConversationCreated => "conversation.created",
        ConversationUpdateKind.ItemAcknowledged => "conversation.item.created",
        ConversationUpdateKind.ItemDeleted => "conversation.item.deleted",
        ConversationUpdateKind.ItemTruncated => "conversation.item.truncated",
        ConversationUpdateKind.ResponseStarted => "response.created",
        ConversationUpdateKind.ResponseFinished => "response.done",
        ConversationUpdateKind.RateLimitsUpdated => "rate_limits.updated",
        ConversationUpdateKind.ItemStarted => "response.output_item.added",
        ConversationUpdateKind.ItemFinished => "response.output_item.done",
        ConversationUpdateKind.ContentPartStarted => "response.content_part.added",
        ConversationUpdateKind.ContentPartFinished => "response.content_part.done",
        ConversationUpdateKind.AudioContentDelta => "response.audio.delta",
        ConversationUpdateKind.AudioContentFinished => "response.audio.done",
        ConversationUpdateKind.OutputTranscriptionDelta => "response.audio_transcript.delta",
        ConversationUpdateKind.OutputTranscriptionFinished => "response.audio_transcript.done",
        ConversationUpdateKind.TextContentDelta => "response.text.delta",
        ConversationUpdateKind.TextContentFinished => "response.text.done",
        ConversationUpdateKind.FunctionCallArgumentsDelta => "response.function_call_arguments.delta",
        ConversationUpdateKind.FunctionCallArgumentsFinished => "response.function_call_arguments.done",
        ConversationUpdateKind.InputSpeechStarted => "input_audio_buffer.speech_started",
        ConversationUpdateKind.InputSpeechStopped => "input_audio_buffer.speech_stopped",
        ConversationUpdateKind.InputTranscriptionFinished => "conversation.item.input_audio_transcription.completed",
        ConversationUpdateKind.InputTranscriptionFailed => "conversation.item.input_audio_transcription.failed",
        ConversationUpdateKind.InputAudioCommitted => "input_audio_buffer.committed",
        ConversationUpdateKind.InputAudioCleared => "input_audio_buffer.cleared",
        ConversationUpdateKind.Error => "error",
        _ => null,
    };

    public static ConversationUpdateKind ToConversationUpdateKind(this string value)
    {
        if (StringComparer.OrdinalIgnoreCase.Equals(value, "session.created")) return ConversationUpdateKind.SessionStarted;
        if (StringComparer.OrdinalIgnoreCase.Equals(value, "session.updated")) return ConversationUpdateKind.SessionConfigured;
        // if (StringComparer.OrdinalIgnoreCase.Equals(value, "conversation.created")) return ConversationUpdateKind.ConversationCreated;
        if (StringComparer.OrdinalIgnoreCase.Equals(value, "conversation.item.created")) return ConversationUpdateKind.ItemAcknowledged;
        if (StringComparer.OrdinalIgnoreCase.Equals(value, "conversation.item.deleted")) return ConversationUpdateKind.ItemDeleted;
        if (StringComparer.OrdinalIgnoreCase.Equals(value, "conversation.item.truncated")) return ConversationUpdateKind.ItemTruncated;
        if (StringComparer.OrdinalIgnoreCase.Equals(value, "response.created")) return ConversationUpdateKind.ResponseStarted;
        if (StringComparer.OrdinalIgnoreCase.Equals(value, "response.done")) return ConversationUpdateKind.ResponseFinished;
        if (StringComparer.OrdinalIgnoreCase.Equals(value, "rate_limits.updated")) return ConversationUpdateKind.RateLimitsUpdated;
        if (StringComparer.OrdinalIgnoreCase.Equals(value, "response.output_item.added")) return ConversationUpdateKind.ItemStarted;
        if (StringComparer.OrdinalIgnoreCase.Equals(value, "response.output_item.done")) return ConversationUpdateKind.ItemFinished;
        if (StringComparer.OrdinalIgnoreCase.Equals(value, "response.content_part.added")) return ConversationUpdateKind.ContentPartStarted;
        if (StringComparer.OrdinalIgnoreCase.Equals(value, "response.content_part.done")) return ConversationUpdateKind.ContentPartFinished;
        if (StringComparer.OrdinalIgnoreCase.Equals(value, "response.audio.delta")) return ConversationUpdateKind.AudioContentDelta;
        if (StringComparer.OrdinalIgnoreCase.Equals(value, "response.audio.done")) return ConversationUpdateKind.AudioContentFinished;
        if (StringComparer.OrdinalIgnoreCase.Equals(value, "response.audio_transcript.delta")) return ConversationUpdateKind.OutputTranscriptionDelta;
        if (StringComparer.OrdinalIgnoreCase.Equals(value, "response.audio_transcript.done")) return ConversationUpdateKind.OutputTranscriptionFinished;
        if (StringComparer.OrdinalIgnoreCase.Equals(value, "response.text.delta")) return ConversationUpdateKind.TextContentDelta;
        if (StringComparer.OrdinalIgnoreCase.Equals(value, "response.text.done")) return ConversationUpdateKind.TextContentFinished;
        if (StringComparer.OrdinalIgnoreCase.Equals(value, "response.function_call_arguments.delta")) return ConversationUpdateKind.FunctionCallArgumentsDelta;
        if (StringComparer.OrdinalIgnoreCase.Equals(value, "response.function_call_arguments.done")) return ConversationUpdateKind.FunctionCallArgumentsFinished;
        if (StringComparer.OrdinalIgnoreCase.Equals(value, "input_audio_buffer.speech_started")) return ConversationUpdateKind.InputSpeechStarted;
        if (StringComparer.OrdinalIgnoreCase.Equals(value, "input_audio_buffer.speech_stopped")) return ConversationUpdateKind.InputSpeechStopped;
        if (StringComparer.OrdinalIgnoreCase.Equals(value, "conversation.item.input_audio_transcription.completed")) return ConversationUpdateKind.InputTranscriptionFinished;
        if (StringComparer.OrdinalIgnoreCase.Equals(value, "conversation.item.input_audio_transcription.failed")) return ConversationUpdateKind.InputTranscriptionFailed;
        if (StringComparer.OrdinalIgnoreCase.Equals(value, "input_audio_buffer.committed")) return ConversationUpdateKind.InputAudioCommitted;
        if (StringComparer.OrdinalIgnoreCase.Equals(value, "input_audio_buffer.cleared")) return ConversationUpdateKind.InputAudioCleared;
        if (StringComparer.OrdinalIgnoreCase.Equals(value, "error")) return ConversationUpdateKind.Error;
        return ConversationUpdateKind.Unknown;
    }
}
