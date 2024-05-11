using System.Collections.Generic;

namespace OpenAI.Assistants;

[CodeGenModel("MessageObject")]
public partial class ThreadMessage
{
    private object Object;

    [CodeGenMember("Role")]
    public MessageRole Role { get; }

    /// <summary> A list of files attached to the message, and the tools they were added to. </summary>
    public IReadOnlyList<MessageCreationAttachment> Attachments { get; }
}
