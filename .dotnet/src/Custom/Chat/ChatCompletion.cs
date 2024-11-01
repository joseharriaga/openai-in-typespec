using System;
using System.Collections.Generic;

namespace OpenAI.Chat;

/// <summary> A chat completion generated by the model. </summary>
[CodeGenModel("CreateChatCompletionResponse")]
public partial class ChatCompletion
{
    private IReadOnlyList<ChatTokenLogProbabilityDetails> _contentTokenLogProbabilities;
    private IReadOnlyList<ChatTokenLogProbabilityDetails> _refusalTokenLogProbabilities;

    // CUSTOM: Made private. This property does not add value in the context of a strongly-typed class.
    /// <summary> The object type, which is always `chat.completion`. </summary>
    [CodeGenMember("Object")]
    internal InternalCreateChatCompletionResponseObject Object { get; } = InternalCreateChatCompletionResponseObject.ChatCompletion;

    // CUSTOM: Made internal.
    [CodeGenMember("ServiceTier")]
    internal InternalCreateChatCompletionResponseServiceTier? ServiceTier { get; }

    // CUSTOM: Made internal. We only get back a single choice, and instead we flatten the structure for usability.
    [CodeGenMember("Choices")]
    internal IReadOnlyList<InternalCreateChatCompletionResponseChoice> Choices { get; }

    // CUSTOM: Renamed.
    /// <summary> The timestamp when the chat completion was created. </summary>
    [CodeGenMember("Created")]
    public DateTimeOffset CreatedAt { get; }

    // CUSTOM: Flattened choice property.
    /// <summary>
    ///     The reason the model stopped generating tokens. This will be:
    ///     <list>
    ///         <item>
    ///             <see cref="ChatFinishReason.Stop"/> if the model hit a natural stop point or a provided stop sequence
    ///         </item>
    ///         <item>
    ///             <see cref="ChatFinishReason.Length"/> if the maximum number of tokens specified in the request was reached
    ///         </item>
    ///         <item>
    ///             <see cref="ChatFinishReason.ContentFilter"/> if content was omitted due to a flag from our content filters
    ///         </item>
    ///         <item>
    ///             <see cref="ChatFinishReason.ToolCalls"/> if the model called a tool
    ///         </item>
    ///         <item>
    ///             <see cref="ChatFinishReason.FunctionCall"/> (obsolte) if the model called a function
    ///         </item>
    ///     </list>
    /// </summary>
    public ChatFinishReason FinishReason => Choices[0].FinishReason;

    // CUSTOM: Flattened choice logprobs property.
    /// <summary> The message content tokens with log probability information. </summary>
    public IReadOnlyList<ChatTokenLogProbabilityDetails> ContentTokenLogProbabilities =>
        _contentTokenLogProbabilities
            ??= Choices[0].Logprobs?.Content
                ?? new ChangeTrackingList<ChatTokenLogProbabilityDetails>();

    // CUSTOM: Flattened choice logprobs property.
    /// <summary> The message refusal tokens with log probability information. </summary>
    public IReadOnlyList<ChatTokenLogProbabilityDetails> RefusalTokenLogProbabilities =>
        _refusalTokenLogProbabilities
            ??= Choices[0].Logprobs?.Refusal
                ?? new ChangeTrackingList<ChatTokenLogProbabilityDetails>();

    // CUSTOM: Flattened choice message property.
    /// <summary> The role of the author of this message. </summary>
    public ChatMessageRole Role => Choices[0].Message.Role;

    // CUSTOM: Flattened choice message property.
    /// <summary> The contents of the message. </summary>
    public ChatMessageContent Content => _content ??= GetWrappedContent();
    private ChatMessageContent _content;

    // CUSTOM: Flattened choice message property.
    /// <summary> The tool calls generated by the model, such as function calls. </summary>
    public IReadOnlyList<ChatToolCall> ToolCalls => Choices[0].Message.ToolCalls;

    // CUSTOM: Flattened choice message property.
    /// <summary> The refusal message generated by the model. </summary>
    public string Refusal => Choices[0].Message.Refusal;

    // CUSTOM: Flattened choice message property.
    [Obsolete($"This property is obsolete. Please use {nameof(ToolCalls)} instead.")]
    public ChatFunctionCall FunctionCall => Choices[0].Message.FunctionCall;

    private ChatMessageContent GetWrappedContent()
    {
        if (Choices[0].Message.Audio is not null)
        {
            return new ChatMessageContent(
                [
                    new ChatMessageContentPart(ChatMessageContentPartKind.Audio, outputAudio: Choices[0].Message.Audio),
                    ..Choices[0].Message.Content,
                ]);
        }
        else
        {
            return Choices[0].Message.Content;
        }
    }
}
