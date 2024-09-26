using System.ComponentModel;
using System;

namespace OpenAI.Chat;

/// <summary>
/// Represents the possibles of underlying data for a chat message's <c>content</c> property.
/// </summary>
[CodeGenModel("ChatCompletionRequestMessageContentPartType")]
public readonly partial struct ChatMessageContentPartKind : IEquatable<ChatMessageContentPartKind>
{
    [CodeGenMember("ImageUrl")]
    public static ChatMessageContentPartKind Image { get; } = new ChatMessageContentPartKind(ImageValue);
}