using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace OpenAI.Chat;

/// <summary>
/// Represents a chat message of the <c>function</c> role as provided to a chat completion request. A function message
/// resolves a prior <c>function_call</c> received from the model and correlates to both a supplied
/// <see cref="ChatFunction"/> instance as well as a <see cref="ChatFunctionCall"/> made by the model on an
/// <c>assistant</c> response message.
/// </summary>
[CodeGenModel("ChatCompletionRequestFunctionMessage")]
[CodeGenSuppress("FunctionChatMessage", typeof(IEnumerable<ChatMessageContentPart>), typeof(string))]
public partial class FunctionChatMessage : ChatMessage
{
    [CodeGenMember("Name")]
    private string _name;

    /// <summary>
    /// Creates a new instance of <see cref="FunctionChatMessage"/>.
    /// </summary>
    /// <param name="functionName">
    ///     The name of the called function that this message provides information from.
    /// </param>
    /// <param name=""=
    [SetsRequiredMembers]
    public FunctionChatMessage(string functionName, string content)
    {
        Argument.AssertNotNull(functionName, nameof(functionName));

        Role = "function";
        FunctionName = functionName;
        Content = new ChangeTrackingList<ChatMessageContentPart>(
            new List<ChatMessageContentPart>()
            {
                ChatMessageContentPart.CreateTextMessageContentPart(content)
            } as IList<ChatMessageContentPart>);
    }

    /// <summary>
    /// Creates a new instance of <see cref="FunctionChatMessage"/>.
    /// </summary>
    public FunctionChatMessage()
    {}

    [SetsRequiredMembers]
    internal FunctionChatMessage(string role, IList<ChatMessageContentPart> content, IDictionary<string, BinaryData> serializedAdditionalRawData, string functionName)
        : base(role, content, serializedAdditionalRawData)
    {
        FunctionName = functionName;
    }

    // CUSTOM: Renamed.
    /// <summary>
    /// The <c>name</c> of the called function that this message provides information from.
    /// </summary>
    public required string FunctionName
    {
        get => _name;
        init => _name = value;
    }

    /// <summary>
    /// The content associated with the chat message.
    /// </summary>
    /// <remarks>
    /// In <c>function</c> messages, content represents the output from a function that should be used to resolve the
    /// function call matching the provided <see cref="FunctionName"/>.
    /// </remarks>
    public override required IList<ChatMessageContentPart> Content
    {
        get => base.Content;
        init => base.Content = value;
    }
}
