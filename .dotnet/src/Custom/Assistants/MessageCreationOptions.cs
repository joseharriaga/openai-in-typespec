namespace OpenAI.Assistants;

/// <summary>
/// Represents additional options available when creating a new <see cref="ThreadMessage"/>.
/// </summary>
[CodeGenModel("CreateMessageRequest")]
public partial class MessageCreationOptions
{
    [CodeGenMember("Role")]
    public MessageRole Role { get; }

    // [CodeGenMember("Attachments")]
    // public IList<MessageCreationAttachment> Attachments { get; } = new ChangeTrackingList<MessageCreationAttachment>();
}