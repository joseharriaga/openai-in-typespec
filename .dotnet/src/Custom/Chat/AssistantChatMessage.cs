using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace OpenAI.Chat;

/// <summary>
/// Represents a chat message of the <c>assistant</c> role as supplied to a chat completion request. As assistant
/// messages are originated by the model on responses, <see cref="AssistantChatMessage"/> instances typically
/// represent chat history or example interactions to guide model behavior.
/// </summary>
[CodeGenModel("ChatCompletionRequestAssistantMessage")]
public partial class AssistantChatMessage : ChatMessage
{
    // Assistant messages may present ONE OF:
    //	- Ordinary text content without tools or a function, in which case the content is required.
    //	- A list of tool calls, together with optional text content
    //	- A function call, together with optional text content

    /// <summary>
    /// Creates a new instance of <see cref="AssistantChatMessage"/> that represents ordinary text content and
    /// does not feature tool or function calls.
    /// </summary>
    /// <param name="content"> The text content of the message. </param>
    public AssistantChatMessage(string content)
    {
        Argument.AssertNotNull(content, nameof(content));

        Role = "assistant";
        Content = [ChatMessageContentPart.CreateTextMessageContentPart(content)];
        ToolCalls = new ChangeTrackingList<ChatToolCall>();
    }

    /// <summary>
    /// Creates a new instance of <see cref="AssistantChatMessage"/> that represents <c>tool_calls</c> that
    /// were provided by the model.
    /// </summary>
    /// <param name="toolCalls"> The <c>tool_calls</c> made by the model. </param>
    public AssistantChatMessage(IEnumerable<ChatToolCall> toolCalls)
    {
        Argument.AssertNotNull(toolCalls, nameof(toolCalls));

        Role = "assistant";
        Content = new ChangeTrackingList<ChatMessageContentPart>();
        ToolCalls = new List<ChatToolCall>(toolCalls);
    }

    /// <summary>
    /// Creates a new instance of <see cref="AssistantChatMessage"/> that represents a <c>function_call</c>
    /// (deprecated in favor of <c>tool_calls</c>) that was made by the model.
    /// </summary>
    /// <param name="functionCall"> The <c>function_call</c> made by the model. </param>
    public AssistantChatMessage(ChatFunctionCall functionCall)
    {
        Argument.AssertNotNull(functionCall, nameof(functionCall));

        Role = "assistant";
        ToolCalls = new ChangeTrackingList<ChatToolCall>();
        FunctionCall = functionCall;
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
    {
        Argument.AssertNotNull(chatCompletion, nameof(chatCompletion));

        if (chatCompletion.Role != ChatMessageRole.Assistant)
        {
            throw new NotSupportedException($"Cannot instantiate an {nameof(AssistantChatMessage)} from a {nameof(ChatCompletion)} with role: {chatCompletion.Role}.");
        }

        Role = "assistant";
        Content = (IList<ChatMessageContentPart>)chatCompletion.Content;
        ToolCalls = (IList<ChatToolCall>)chatCompletion.ToolCalls;
        FunctionCall = chatCompletion.FunctionCall;
    }

    /// <summary> Initializes a new instance of <see cref="AssistantChatMessage"/>. </summary>
    public AssistantChatMessage()
    {
    }

    [SetsRequiredMembers]
    internal AssistantChatMessage(string role, IList<ChatMessageContentPart> content, IDictionary<string, BinaryData> serializedAdditionalRawData, string participantName, IList<ChatToolCall> toolCalls, ChatFunctionCall functionCall) : base(role, content, serializedAdditionalRawData)
    {
        ParticipantName = participantName;
        ToolCalls = toolCalls;
        FunctionCall = functionCall;
    }

    /// <summary>
    /// The tool calls produced by the assistant, as provided on a response's <see cref="ChatCompletion.ToolCalls"/>. 
    /// </summary>
    public IList<ChatToolCall> ToolCalls { get; init; }

    /// <summary>
    /// The function call produced by the assistant, as provided on a response's <see cref="ChatCompletion.FunctionCall"/>. 
    /// </summary>
    public ChatFunctionCall FunctionCall { get; set; }

    /// <summary>
    /// The content associated with the chat message.
    /// </summary>
    /// <remarks>
    /// In <c>assistant</c> messages, content represents the model's response to a sequence of prior messages.
    /// </remarks>
    public override IList<ChatMessageContentPart> Content
    {
        get => base.Content;
        init => base.Content = value;
    }

    // CUSTOM: Renamed.
    /// <summary>
    /// An optional <c>name</c> associated with the assistant message. This is typically defined with a <c>system</c>
    /// message and is used to differentiate between multiple participants of the same role.
    /// </summary>
    [CodeGenMember("Name")]
    public string ParticipantName { get; set; }
}