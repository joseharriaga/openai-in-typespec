using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace OpenAI.Chat;

/// <summary>
/// Represents a chat message of the <c>user</c> role as supplied to a chat completion request. A user message contains
/// information originating from the caller and serves as a prompt for the model to complete. User messages may result
/// in either direct <c>assistant</c> message responses or in calls to supplied <c>tools</c> or <c>functions</c>.
/// </summary>
[CodeGenModel("ChatCompletionRequestUserMessage")]
[CodeGenSuppress("UserChatMessage", typeof(ReadOnlyMemory<ChatMessageContentPart>))]
public partial class UserChatMessage : ChatMessage
{
    /// <summary>
    /// Creates a new instance of <see cref="UserChatMessage"/> with ordinary text <c>content</c>.
    /// </summary>
    /// <param name="content"> The textual content associated with the message. </param>
    [SetsRequiredMembers]
    public UserChatMessage(string content)
    {
        Argument.AssertNotNull(content, nameof(content));

        Role = "user";
        Content = [ChatMessageContentPart.CreateTextMessageContentPart(content)];
    }

    /// <summary>
    /// Creates a new instance of <see cref="UserChatMessage"/> using a collection of content items that can
    /// include text and image information. This content format is currently only applicable to the
    /// <c>gpt-4-vision-preview</c> model and will not be accepted by other models.
    /// </summary>
    /// <param name="content">
    ///     The collection of text and image content items associated with the message.
    /// </param>
    [SetsRequiredMembers]
    public UserChatMessage(IEnumerable<ChatMessageContentPart> content)
    {
        Argument.AssertNotNullOrEmpty(content, nameof(content));

        Role = "user";
        Content = content.ToList();
    }

    /// <summary>
    /// Creates a new instance of <see cref="UserChatMessage"/> using a collection of content items that can
    /// include text and image information. This content format is currently only applicable to the
    /// <c>gpt-4-vision-preview</c> model and will not be accepted by other models.
    /// </summary>
    /// <param name="content">
    ///     The collection of text and image content items associated with the message.
    /// </param>
    [SetsRequiredMembers]
    public UserChatMessage(params ChatMessageContentPart[] content)
    {
        Argument.AssertNotNullOrEmpty(content, nameof(content));

        Role = "user";
        Content = content.ToList();
    }

    /// <summary>
    /// Creates a new instance of <see cref="UserChatMessage"/>.
    /// </summary>
    public UserChatMessage()
    {}

    [SetsRequiredMembers]
    internal UserChatMessage(string role, IList<ChatMessageContentPart> content, IDictionary<string, BinaryData> serializedAdditionalRawData, string participantName)
        : base(role, content, serializedAdditionalRawData)
    {
        ParticipantName = participantName;
    }

    /// <summary>
    /// The content associated with the chat message.
    /// </summary>
    /// <remarks>
    /// In <c>user</c> messages, content represents user-provided prompt data, typically in the form of instructions
    /// or a question, that the model should respond to.
    /// </remarks>
    public override required IList<ChatMessageContentPart> Content
    {
        get => base.Content;
        init => base.Content = value;
    }

    // CUSTOM: Rename.
    /// <summary>
    /// An optional <c>name</c> for the participant.
    /// </summary>
    [CodeGenMember("Name")]
    public string ParticipantName { get; init; }
}
