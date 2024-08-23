using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenAI.Chat;

/// <summary>
/// Represents a chat message of the <c>assistant</c> role as supplied to a chat completion request. As assistant
/// messages are originated by the model on responses, <see cref="AssistantChatMessage"/> instances typically
/// represent chat history or example interactions to guide model behavior.
/// </summary>
[CodeGenModel("ChatCompletionRequestAssistantMessage")]
public partial class AssistantChatMessage : ChatMessage
{
    /// <summary>
    /// Creates a new instance of <see cref="AssistantChatMessage"/> using a collection of content items.
    /// For <c>assistant</c> messages, this can be one or more of type <c>text</c> or exactly one of type <c>refusal</c>.
    /// </summary>
    /// <param name="contentParts">
    ///     The collection of content items associated with the message.
    /// </param>
    public AssistantChatMessage(IEnumerable<ChatMessageContentPart> contentParts)
        : base("assistant", contentParts)
    {
        Argument.AssertNotNullOrEmpty(contentParts, nameof(contentParts));
        ToolCalls = new ChangeTrackingList<ChatToolCall>();
    }

    /// <summary>
    /// Creates a new instance of <see cref="AssistantChatMessage"/> using a collection of content items.
    /// For <c>assistant</c> messages, this can be one or more of type <c>text</c> or exactly one of type <c>refusal</c>.
    /// </summary>
    /// <param name="contentParts">
    ///     The collection of text and image content items associated with the message.
    /// </param>
    public AssistantChatMessage(params ChatMessageContentPart[] contentParts)
        : base("assistant", contentParts)
    {
        Argument.AssertNotNullOrEmpty(contentParts, nameof(contentParts));
        ToolCalls = new ChangeTrackingList<ChatToolCall>();
    }

    /// <summary>
    /// Creates a new instance of <see cref="AssistantChatMessage"/> that represents ordinary text content and
    /// does not feature tool or function calls.
    /// </summary>
    /// <param name="content"> The text content of the message. </param>
    public AssistantChatMessage(string content)
        : base("assistant", [ChatMessageContentPart.CreateTextMessageContentPart(content)])
    {
        Argument.AssertNotNull(content, nameof(content));
        ToolCalls = new ChangeTrackingList<ChatToolCall>();
    }

    /// <summary>
    /// Creates a new instance of <see cref="AssistantChatMessage"/> that represents <c>tool_calls</c> that
    /// were provided by the model.
    /// </summary>
    /// <param name="toolCalls"> The <c>tool_calls</c> made by the model. </param>
    /// <param name="content"> Optional text content associated with the message. </param>
    public AssistantChatMessage(IEnumerable<ChatToolCall> toolCalls, string content = null)
        : base("assistant", content == null ? null : [ChatMessageContentPart.CreateTextMessageContentPart(content)])
    {
        Argument.AssertNotNull(toolCalls, nameof(toolCalls));

        ToolCalls = new ChangeTrackingList<ChatToolCall>();
        foreach (ChatToolCall toolCall in toolCalls)
        {
            ToolCalls.Add(toolCall);
        }
    }

    /// <summary>
    /// Creates a new instance of <see cref="AssistantChatMessage"/> that represents a <c>function_call</c>
    /// (deprecated in favor of <c>tool_calls</c>) that was made by the model.
    /// </summary>
    /// <param name="functionCall"> The <c>function_call</c> made by the model. </param>
    /// <param name="content"> Optional text content associated with the message. </param>
    public AssistantChatMessage(ChatFunctionCall functionCall, string content = null)
        : base("assistant", content == null ? null : [ChatMessageContentPart.CreateTextMessageContentPart(content)])
    {
        Argument.AssertNotNull(functionCall, nameof(functionCall));

        FunctionCall = functionCall;
        ToolCalls = new ChangeTrackingList<ChatToolCall>();
    }

    /// <summary>
    /// Creates a new instance of <see cref="AssistantChatMessage"/> from a <see cref="ChatCompletion"/> with
    /// an <c>assistant</c> role response.
    /// </summary>
    /// <remarks>
    ///     This constructor will copy the <c>content</c>, <c>tool_calls</c>, and <c>function_call</c> from a chat
    ///     completion response into a new <c>assistant</c> role request message. 
    /// </remarks>
    /// <param name="chatCompletion">
    ///     The <see cref="ChatCompletion"/> from which the conversation history request message should be created.
    /// </param>
    /// <exception cref="ArgumentException">
    ///     The <c>role</c> of the provided chat completion response was not <see cref="ChatMessageRole.Assistant"/>.
    /// </exception>
    public AssistantChatMessage(ChatCompletion chatCompletion)
        : base("assistant", chatCompletion.Content)
    {
        Argument.AssertNotNull(chatCompletion, nameof(chatCompletion));

        if (chatCompletion.Role != ChatMessageRole.Assistant)
        {
            throw new NotSupportedException($"Cannot instantiate an {nameof(AssistantChatMessage)} from a {nameof(ChatCompletion)} with role: {chatCompletion.Role}.");
        }

        ToolCalls = new ChangeTrackingList<ChatToolCall>();
        Refusal = chatCompletion.Refusal;
        FunctionCall = chatCompletion.FunctionCall;
        foreach (ChatToolCall toolCall in chatCompletion.ToolCalls ?? [])
        {
            ToolCalls.Add(toolCall);
        }
    }

    // CUSTOM: Renamed.
    /// <summary>
    /// An optional <c>name</c> associated with the assistant message. This is typically defined with a <c>system</c>
    /// message and is used to differentiate between multiple participants of the same role.
    /// </summary>
    [CodeGenMember("Name")]
    public string ParticipantName { get; set; }

    // CUSTOM: Made internal.
    internal AssistantChatMessage() { }
}