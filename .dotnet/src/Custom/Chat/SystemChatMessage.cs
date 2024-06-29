using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace OpenAI.Chat;

/// <summary>
/// Represents a chat message of the <c>system</c> role as supplied to a chat completion request. A system message is
/// generally supplied as the first message to a chat completion request and guides the model's behavior across future
/// <c>assistant</c> role response messages. These messages may help control behavior, style, tone, and
/// restrictions for a model-based assistant.
/// </summary>
[CodeGenModel("ChatCompletionRequestSystemMessage")]
[CodeGenSuppress("SystemChatMessage", typeof(IEnumerable<ChatMessageContentPart>))]
// [CodeGenSuppress("SystemChatMessage", typeof(string), typeof(IList<ChatMessageContentPart>), typeof(IDictionary<string, BinaryData>), typeof(string))]
public partial class SystemChatMessage : ChatMessage
{
    /// <summary>
    /// Creates a new instance of <see cref="SystemChatMessage"/>.
    /// </summary>
    /// <param name="content"> The <c>system</c> message text that guides the model's behavior. </param>
    [SetsRequiredMembers]
    public SystemChatMessage(string content)
    {
        Argument.AssertNotNull(content, nameof(content));

        Role = "system";
        Content = new ChangeTrackingList<ChatMessageContentPart>(
            (IList<ChatMessageContentPart>)[ChatMessageContentPart.CreateTextMessageContentPart(content)]);
    }

    /// <summary>
    /// Creates a new instance of <see cref="SystemChatMessage"/>.
    /// </summary>
    public SystemChatMessage()
    {}

    [SetsRequiredMembers]
    internal SystemChatMessage(string role, IList<ChatMessageContentPart> content, IDictionary<string, BinaryData> serializedAdditionalRawData, string participantName) : base(role, content, serializedAdditionalRawData)
    {
        ParticipantName = participantName;
    }

    /// <summary>
    /// The content associated with the chat message.
    /// </summary>
    /// <remarks>
    /// In <c>system</c> messages, content represents instructions or other guidance to influence the generation of
    /// assistant messages.
    /// </remarks>
    public override required IList<ChatMessageContentPart> Content
    {
        get => base.Content;
        init => base.Content = value;
    }

    /// <summary>
    /// An optional <c>name</c> for the participant.
    /// </summary>
    [CodeGenMember("Name")]
    public string ParticipantName { get; init; }
}